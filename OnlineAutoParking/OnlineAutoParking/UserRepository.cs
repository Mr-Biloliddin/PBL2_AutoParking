using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Data.Sqlite;
using OnlineAutoParking.Models;

namespace OnlineAutoParking
{
    /// <summary>
    /// Ro'yxatdan o'tish natijasi.
    /// </summary>
    public enum RegisterStatus
    {
        Success,
        UsernameTaken
    }

    /// <summary>
    /// Users jadvali bilan ishlash: kirish (login), ro'yxatdan o'tish, ro'yxat.
    /// Parollar ochiq holda saqlanmaydi — PBKDF2 (SHA-256) xeshi va tasodifiy "salt" saqlanadi.
    /// </summary>
    public class UserRepository
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100000;

        /// <summary>
        /// Login va parolni tekshiradi. To'g'ri bo'lsa foydalanuvchini, aks holda null qaytaradi.
        /// </summary>
        public User Authenticate(string username, string password)
        {
            using (var connection = DatabaseHelper.OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "SELECT UserID, Username, FullName, Role, CreatedAt, PasswordHash, PasswordSalt " +
                    "FROM Users WHERE Username = @Username;";
                command.Parameters.AddWithValue("@Username", username);
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }
                    if (!VerifyPassword(password, reader.GetString(5), reader.GetString(6)))
                    {
                        return null;
                    }
                    return ReadUser(reader);
                }
            }
        }

        /// <summary>
        /// Yangi oddiy foydalanuvchi (Role = 'User') yaratadi. Administrator bu yerda yaratilmaydi.
        /// </summary>
        public RegisterStatus Register(string username, string password, string fullName, out int userId)
        {
            userId = 0;
            using (var connection = DatabaseHelper.OpenConnection())
            using (var transaction = connection.BeginTransaction(deferred: false))
            {
                try
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = @Username;";
                        command.Parameters.AddWithValue("@Username", username);
                        if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                        {
                            transaction.Rollback();
                            return RegisterStatus.UsernameTaken;
                        }
                    }

                    userId = InsertUser(connection, transaction, username, password, fullName, UserRole.User);
                    transaction.Commit();
                    return RegisterStatus.Success;
                }
                catch
                {
                    userId = 0;
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception)
                    {
                        // Asl xatolik yuqoriga uzatiladi
                    }
                    throw;
                }
            }
        }

        /// <summary>
        /// Admin panel uchun barcha foydalanuvchilar.
        /// </summary>
        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            using (var connection = DatabaseHelper.OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "SELECT UserID, Username, FullName, Role, CreatedAt FROM Users ORDER BY UserID;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(ReadUser(reader));
                    }
                }
            }
            return users;
        }

        /// <summary>
        /// Foydalanuvchini qo'shadi (parol xeshlanadi) va uning ID raqamini qaytaradi.
        /// DatabaseHelper ham administratorni yaratishda shu metoddan foydalanadi.
        /// </summary>
        internal static int InsertUser(SqliteConnection connection, SqliteTransaction transaction,
            string username, string password, string fullName, string role)
        {
            string hash, salt;
            HashPassword(password, out hash, out salt);

            using (var command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText =
                    "INSERT INTO Users (Username, PasswordHash, PasswordSalt, FullName, Role, CreatedAt) " +
                    "VALUES (@Username, @PasswordHash, @PasswordSalt, @FullName, @Role, @CreatedAt); " +
                    "SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@PasswordHash", hash);
                command.Parameters.AddWithValue("@PasswordSalt", salt);
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@Role", role);
                command.Parameters.AddWithValue("@CreatedAt", DatabaseHelper.ToDbTime(DateTime.Now));
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private static void HashPassword(string password, out string hash, out string salt)
        {
            byte[] saltBytes = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            salt = Convert.ToBase64String(saltBytes);
            hash = Convert.ToBase64String(DeriveHash(password, saltBytes));
        }

        private static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            byte[] expected = Convert.FromBase64String(storedHash);
            byte[] actual = DeriveHash(password, Convert.FromBase64String(storedSalt));

            // Vaqt bo'yicha hujumlarga qarshi: barcha baytlar har doim solishtiriladi
            int difference = expected.Length ^ actual.Length;
            for (int i = 0; i < Math.Min(expected.Length, actual.Length); i++)
            {
                difference |= expected[i] ^ actual[i];
            }
            return difference == 0;
        }

        private static byte[] DeriveHash(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(HashSize);
            }
        }

        private static User ReadUser(SqliteDataReader reader)
        {
            return new User
            {
                UserID = reader.GetInt32(0),
                Username = reader.GetString(1),
                FullName = reader.GetString(2),
                Role = reader.GetString(3),
                CreatedAt = DatabaseHelper.FromDbTime(reader.GetString(4))
            };
        }
    }
}
