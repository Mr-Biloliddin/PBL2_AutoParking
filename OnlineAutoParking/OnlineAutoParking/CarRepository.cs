using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using OnlineAutoParking.Models;

namespace OnlineAutoParking
{
    /// <summary>
    /// Mashina qo'shish natijasi.
    /// </summary>
    public enum AddCarStatus
    {
        Success,
        AlreadyYours,   // Shu raqam shu foydalanuvchida allaqachon bor
        PlateTaken      // Shu raqam boshqa foydalanuvchida ro'yxatdan o'tgan
    }

    /// <summary>
    /// Mashinani o'chirish natijasi.
    /// </summary>
    public enum DeleteCarStatus
    {
        Success,
        NotFound,
        HasActiveBookings   // Hali tugamagan faol bron bor
    }

    /// <summary>
    /// Cars jadvali bilan ishlash: foydalanuvchining mashinalari, qo'shish, o'chirish.
    /// </summary>
    public class CarRepository
    {
        /// <summary>
        /// Foydalanuvchining barcha mashinalari (qo'shilgan tartibda).
        /// </summary>
        public List<Car> GetCarsByUser(int userId)
        {
            var cars = new List<Car>();
            using (var connection = DatabaseHelper.OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "SELECT CarID, UserID, CarPlate, CarName, CreatedAt " +
                    "FROM Cars WHERE UserID = @UserID ORDER BY CarID;";
                command.Parameters.AddWithValue("@UserID", userId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cars.Add(new Car
                        {
                            CarID = reader.GetInt32(0),
                            UserID = reader.GetInt32(1),
                            CarPlate = reader.GetString(2),
                            CarName = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            CreatedAt = DatabaseHelper.FromDbTime(reader.GetString(4))
                        });
                    }
                }
            }
            return cars;
        }

        /// <summary>
        /// Foydalanuvchiga yangi mashina qo'shadi. carPlate allaqachon <see cref="PlateFormat.Normalize"/>
        /// dan o'tgan bo'lishi kerak. Bitta raqam bazada faqat bir marta bo'lishi mumkin.
        /// </summary>
        public AddCarStatus AddCar(int userId, string carPlate, string carName, out int carId)
        {
            carId = 0;
            using (var connection = DatabaseHelper.OpenConnection())
            using (var transaction = connection.BeginTransaction(deferred: false))
            {
                try
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = "SELECT UserID FROM Cars WHERE CarPlate = @CarPlate;";
                        command.Parameters.AddWithValue("@CarPlate", carPlate);
                        object owner = command.ExecuteScalar();
                        if (owner != null)
                        {
                            transaction.Rollback();
                            return Convert.ToInt32(owner) == userId
                                ? AddCarStatus.AlreadyYours
                                : AddCarStatus.PlateTaken;
                        }
                    }

                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText =
                            "INSERT INTO Cars (UserID, CarPlate, CarName, CreatedAt) " +
                            "VALUES (@UserID, @CarPlate, @CarName, @CreatedAt); " +
                            "SELECT last_insert_rowid();";
                        command.Parameters.AddWithValue("@UserID", userId);
                        command.Parameters.AddWithValue("@CarPlate", carPlate);
                        command.Parameters.AddWithValue("@CarName", carName ?? "");
                        command.Parameters.AddWithValue("@CreatedAt", DatabaseHelper.ToDbTime(DateTime.Now));
                        carId = Convert.ToInt32(command.ExecuteScalar());
                    }

                    transaction.Commit();
                    return AddCarStatus.Success;
                }
                catch
                {
                    carId = 0;
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception)
                    {
                        // Tranzaksiya allaqachon yopilgan bo'lishi mumkin — asl xatolik muhimroq
                    }
                    throw;
                }
            }
        }

        /// <summary>
        /// Foydalanuvchining o'z mashinasini o'chiradi. Tugamagan faol broni bor mashinani o'chirib bo'lmaydi.
        /// Eski (tugagan yoki bekor qilingan) bronlar tarixda qoladi: ularda raqam matn sifatida saqlangan,
        /// faqat CarID bog'lanishi bo'shatiladi.
        /// </summary>
        public DeleteCarStatus DeleteCar(int userId, int carId)
        {
            using (var connection = DatabaseHelper.OpenConnection())
            using (var transaction = connection.BeginTransaction(deferred: false))
            {
                try
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = "SELECT COUNT(*) FROM Cars WHERE CarID = @CarID AND UserID = @UserID;";
                        command.Parameters.AddWithValue("@CarID", carId);
                        command.Parameters.AddWithValue("@UserID", userId);
                        if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                        {
                            transaction.Rollback();
                            return DeleteCarStatus.NotFound;
                        }
                    }

                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText =
                            "SELECT COUNT(*) FROM Bookings " +
                            "WHERE CarID = @CarID AND Status = 'Active' AND EndTime > @Now;";
                        command.Parameters.AddWithValue("@CarID", carId);
                        command.Parameters.AddWithValue("@Now", DatabaseHelper.ToDbTime(DateTime.Now));
                        if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                        {
                            transaction.Rollback();
                            return DeleteCarStatus.HasActiveBookings;
                        }
                    }

                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = "UPDATE Bookings SET CarID = NULL WHERE CarID = @CarID;";
                        command.Parameters.AddWithValue("@CarID", carId);
                        command.ExecuteNonQuery();
                    }

                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = "DELETE FROM Cars WHERE CarID = @CarID AND UserID = @UserID;";
                        command.Parameters.AddWithValue("@CarID", carId);
                        command.Parameters.AddWithValue("@UserID", userId);
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return DeleteCarStatus.Success;
                }
                catch
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception)
                    {
                        // Tranzaksiya allaqachon yopilgan bo'lishi mumkin — asl xatolik muhimroq
                    }
                    throw;
                }
            }
        }
    }
}
