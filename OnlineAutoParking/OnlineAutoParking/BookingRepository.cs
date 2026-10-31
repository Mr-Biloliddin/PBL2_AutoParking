using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using OnlineAutoParking.Models;

namespace OnlineAutoParking
{
    /// <summary>
    /// Bron yaratish natijasi.
    /// </summary>
    public enum CreateBookingStatus
    {
        Success,
        NoSpace,
        ParkingNotFound,
        ParkingInactive,
        InvalidInterval
    }

    /// <summary>
    /// Bookings jadvali bilan ishlash: bron yaratish, ro'yxat, bekor qilish, band joylarni sanash.
    /// </summary>
    public class BookingRepository
    {
        /// <summary>
        /// Yangi bron yaratadi. Bo'sh joy borligi shu tranzaksiya ichida qayta tekshiriladi —
        /// MainForm'da ko'rsatilgan raqamga ishonilmaydi. userId — bronni qilgan foydalanuvchi.
        /// </summary>
        public CreateBookingStatus CreateBooking(int userId, int parkingLotId, string driverName, string carPlate,
            DateTime startTime, DateTime endTime, out int bookingId)
        {
            bookingId = 0;
            if (endTime <= startTime)
            {
                return CreateBookingStatus.InvalidInterval;
            }

            string start = DatabaseHelper.ToDbTime(startTime);
            string end = DatabaseHelper.ToDbTime(endTime);

            using (var connection = DatabaseHelper.OpenConnection())
            // deferred: false => "BEGIN IMMEDIATE". Yozish qulfi tranzaksiya boshidayoq olinadi,
            // shuning uchun ikki parallel bron bir vaqtda "oxirgi bo'sh joy bor" deb qaror qila olmaydi:
            // ikkinchisi birinchisi COMMIT qilguncha kutadi (busy_timeout) va keyin yangilangan sonni ko'radi.
            using (var transaction = connection.BeginTransaction(deferred: false))
            {
                try
                {
                    bool found = false;
                    int totalSpaces = 0;
                    bool isActive = false;
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText =
                            "SELECT TotalSpaces, IsActive FROM ParkingLots WHERE ParkingLotID = @ParkingLotID;";
                        command.Parameters.AddWithValue("@ParkingLotID", parkingLotId);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                found = true;
                                totalSpaces = reader.GetInt32(0);
                                isActive = reader.GetInt32(1) == 1;
                            }
                        }
                    }

                    if (!found)
                    {
                        transaction.Rollback();
                        return CreateBookingStatus.ParkingNotFound;
                    }

                    if (!isActive)
                    {
                        transaction.Rollback();
                        return CreateBookingStatus.ParkingInactive;
                    }

                    // Aynan shu ulanish va shu tranzaksiya orqali sanaladi
                    int occupied = CountOverlappingActiveBookings(connection, transaction, parkingLotId, start, end);
                    if (occupied >= totalSpaces)
                    {
                        transaction.Rollback();
                        return CreateBookingStatus.NoSpace;
                    }

                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText =
                            "INSERT INTO Bookings (UserID, ParkingLotID, DriverName, CarPlate, StartTime, EndTime, Status) " +
                            "VALUES (@UserID, @ParkingLotID, @DriverName, @CarPlate, @StartTime, @EndTime, @Status); " +
                            "SELECT last_insert_rowid();";
                        command.Parameters.AddWithValue("@UserID", userId);
                        command.Parameters.AddWithValue("@ParkingLotID", parkingLotId);
                        command.Parameters.AddWithValue("@DriverName", driverName);
                        command.Parameters.AddWithValue("@CarPlate", carPlate);
                        command.Parameters.AddWithValue("@StartTime", start);
                        command.Parameters.AddWithValue("@EndTime", end);
                        command.Parameters.AddWithValue("@Status", BookingStatus.Active);
                        bookingId = Convert.ToInt32(command.ExecuteScalar());
                    }

                    transaction.Commit();
                    return CreateBookingStatus.Success;
                }
                catch
                {
                    bookingId = 0;
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
        /// Barcha bronlar, avtoturargoh nomi va foydalanuvchi logini bilan
        /// (Bookings JOIN ParkingLots, LEFT JOIN Users — eski bronlarda UserID bo'lmasligi mumkin).
        /// </summary>
        public List<Booking> GetAllBookings()
        {
            var bookings = new List<Booking>();
            using (var connection = DatabaseHelper.OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
SELECT b.BookingID, b.ParkingLotID, p.ParkingName, b.DriverName, b.CarPlate,
       b.StartTime, b.EndTime, b.Status, b.UserID, u.Username
FROM Bookings b
INNER JOIN ParkingLots p ON p.ParkingLotID = b.ParkingLotID
LEFT JOIN Users u ON u.UserID = b.UserID
ORDER BY b.BookingID DESC;";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookings.Add(new Booking
                        {
                            BookingID = reader.GetInt32(0),
                            ParkingLotID = reader.GetInt32(1),
                            ParkingName = reader.GetString(2),
                            DriverName = reader.GetString(3),
                            CarPlate = reader.GetString(4),
                            StartTime = DatabaseHelper.FromDbTime(reader.GetString(5)),
                            EndTime = DatabaseHelper.FromDbTime(reader.GetString(6)),
                            Status = reader.GetString(7),
                            UserID = reader.IsDBNull(8) ? (int?)null : reader.GetInt32(8),
                            Username = reader.IsDBNull(9) ? "—" : reader.GetString(9)
                        });
                    }
                }
            }
            return bookings;
        }

        /// <summary>
        /// Berilgan oraliq bilan kesishadigan faol bronlar soni.
        /// </summary>
        public int CountOverlappingActiveBookings(int parkingLotId, DateTime startTime, DateTime endTime)
        {
            using (var connection = DatabaseHelper.OpenConnection())
            {
                return CountOverlappingActiveBookings(connection, null, parkingLotId,
                    DatabaseHelper.ToDbTime(startTime), DatabaseHelper.ToDbTime(endTime));
            }
        }

        /// <summary>
        /// Ikki oraliq kesishadi, agar: mavjud.Start &lt; so'ralgan.End VA mavjud.End &gt; so'ralgan.Start.
        /// Biri tugagan paytda ikkinchisi boshlansa — kesishmaydi. Bekor qilingan bronlar sanalmaydi.
        /// </summary>
        internal static int CountOverlappingActiveBookings(SqliteConnection connection, SqliteTransaction transaction,
            int parkingLotId, string requestedStart, string requestedEnd)
        {
            using (var command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText = @"
SELECT COUNT(*)
FROM Bookings
WHERE ParkingLotID = @ParkingLotID
  AND Status = 'Active'
  AND StartTime < @RequestedEnd
  AND EndTime > @RequestedStart;";
                command.Parameters.AddWithValue("@ParkingLotID", parkingLotId);
                command.Parameters.AddWithValue("@RequestedStart", requestedStart);
                command.Parameters.AddWithValue("@RequestedEnd", requestedEnd);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        /// <summary>
        /// Bronni bekor qiladi (yozuv o'chirilmaydi, faqat Status o'zgaradi).
        /// Faqat faol bron bekor qilinsa true qaytaradi.
        /// </summary>
        public bool CancelBooking(int bookingId)
        {
            using (var connection = DatabaseHelper.OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "UPDATE Bookings SET Status = 'Cancelled' " +
                    "WHERE BookingID = @BookingID AND Status = 'Active';";
                command.Parameters.AddWithValue("@BookingID", bookingId);
                return command.ExecuteNonQuery() == 1;
            }
        }
    }
}
