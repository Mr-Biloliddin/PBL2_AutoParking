using System;
using System.Globalization;
using System.IO;
using Microsoft.Data.Sqlite;

namespace OnlineAutoParking
{
    /// <summary>
    /// SQLite ma'lumotlar bazasi bilan ishlash: fayl yo'li, ulanish ochish,
    /// jadvallarni yaratish va namunaviy ma'lumotlarni bir marta qo'shish.
    /// </summary>
    public static class DatabaseHelper
    {
        public const string DatabaseFileName = "parking.db";

        // Vaqt bazada doimo UTC va bir xil uzunlikdagi ISO-8601 satr ko'rinishida saqlanadi:
        // 2026-10-26T10:00:00.0000000Z. Shu sababli satrlarni oddiy < va > bilan solishtirish mumkin.
        private const string DbTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'";

        // PRAGMA user_version orqali saqlanadigan sxema versiyasi (initsializatsiya belgisi):
        // 1 — avtoturargohlar va bronlar, 2 — foydalanuvchilar (Users) va Bookings.UserID,
        // 3 — foydalanuvchi mashinalari (Cars) va Bookings.CarID
        private const int SchemaVersion = 3;

        // Yagona administrator hisobi (birinchi ishga tushishda yaratiladi)
        private const string AdminUsername = "admin";
        private const string AdminPassword = "admin123";
        private const string AdminFullName = "Administrator";

        // Baza band bo'lsa (boshqa yozuvchi ishlayotgan bo'lsa) shuncha soniya kutiladi
        private const int BusyTimeoutSeconds = 10;

        private static string _databasePath = FindDatabasePath();

        /// <summary>
        /// .exe papkasidan yuqoriga qarab birinchi topilgan parking.db
        /// (masalan, PBL2_AutoParking\parking.db). Topilmasa — .exe yonida yangi parking.db yaratiladi.
        /// </summary>
        public static string DatabasePath
        {
            get { return _databasePath; }
            set { _databasePath = value; }
        }

        private static string FindDatabasePath()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            for (var directory = new DirectoryInfo(baseDirectory); directory != null; directory = directory.Parent)
            {
                string candidate = Path.Combine(directory.FullName, DatabaseFileName);
                if (File.Exists(candidate))
                {
                    return candidate;
                }
            }
            return Path.Combine(baseDirectory, DatabaseFileName);
        }

        private static string ConnectionString
        {
            get
            {
                var builder = new SqliteConnectionStringBuilder
                {
                    DataSource = DatabasePath,
                    Mode = SqliteOpenMode.ReadWriteCreate,
                    ForeignKeys = true,
                    DefaultTimeout = BusyTimeoutSeconds
                };
                return builder.ToString();
            }
        }

        /// <summary>
        /// Yangi ulanish ochadi. Har bir ulanishda tashqi kalitlar (foreign keys) yoqiladi.
        /// Chaqiruvchi ulanishni using ichida yopishi kerak.
        /// </summary>
        public static SqliteConnection OpenConnection()
        {
            var connection = new SqliteConnection(ConnectionString);
            try
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "PRAGMA foreign_keys = ON; " +
                        "PRAGMA busy_timeout = " + (BusyTimeoutSeconds * 1000) + ";";
                    command.ExecuteNonQuery();
                }
                return connection;
            }
            catch
            {
                connection.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Baza faylini, jadvallarni va indeksni yaratadi. Namunaviy avtoturargohlar faqat
        /// birinchi initsializatsiyada qo'shiladi (PRAGMA user_version belgisi orqali).
        /// Mavjud baza fayli hech qachon o'chirilmaydi yoki almashtirilmaydi.
        /// </summary>
        public static void Initialize()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(DatabasePath));

            using (var connection = OpenConnection())
            using (var transaction = connection.BeginTransaction(deferred: false))
            {
                try
                {
                    ExecuteNonQuery(connection, transaction, @"
CREATE TABLE IF NOT EXISTS ParkingLots (
    ParkingLotID INTEGER PRIMARY KEY AUTOINCREMENT,
    ParkingName TEXT NOT NULL,
    Address TEXT NOT NULL,
    TotalSpaces INTEGER NOT NULL
        CHECK (TotalSpaces > 0),
    IsActive INTEGER NOT NULL DEFAULT 1
        CHECK (IsActive IN (0, 1))
);

CREATE TABLE IF NOT EXISTS Bookings (
    BookingID INTEGER PRIMARY KEY AUTOINCREMENT,
    ParkingLotID INTEGER NOT NULL,
    DriverName TEXT NOT NULL,
    CarPlate TEXT NOT NULL,
    StartTime TEXT NOT NULL,
    EndTime TEXT NOT NULL,
    Status TEXT NOT NULL DEFAULT 'Active'
        CHECK (Status IN ('Active', 'Cancelled')),
    FOREIGN KEY (ParkingLotID)
        REFERENCES ParkingLots(ParkingLotID),
    CHECK (EndTime > StartTime)
);

CREATE INDEX IF NOT EXISTS
idx_bookings_parking_status_time
ON Bookings (
    ParkingLotID,
    Status,
    StartTime,
    EndTime
);

CREATE TABLE IF NOT EXISTS Users (
    UserID INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT NOT NULL UNIQUE COLLATE NOCASE,
    PasswordHash TEXT NOT NULL,
    PasswordSalt TEXT NOT NULL,
    FullName TEXT NOT NULL,
    Role TEXT NOT NULL DEFAULT 'User'
        CHECK (Role IN ('Admin', 'User')),
    CreatedAt TEXT NOT NULL
);

-- Bazada faqat bitta administrator bo'lishi mumkin
CREATE UNIQUE INDEX IF NOT EXISTS
idx_users_single_admin
ON Users (Role)
WHERE Role = 'Admin';

-- Foydalanuvchilarning mashinalari (bir foydalanuvchida bir nechta mashina bo'lishi mumkin)
CREATE TABLE IF NOT EXISTS Cars (
    CarID INTEGER PRIMARY KEY AUTOINCREMENT,
    UserID INTEGER NOT NULL,
    CarPlate TEXT NOT NULL UNIQUE,
    CarName TEXT NOT NULL DEFAULT '',
    CreatedAt TEXT NOT NULL,
    FOREIGN KEY (UserID)
        REFERENCES Users(UserID)
);

CREATE INDEX IF NOT EXISTS
idx_cars_user
ON Cars (UserID);");

                    // Eski bazalarda (1-versiya) Bookings jadvalida UserID ustuni yo'q — qo'shiladi.
                    // Eski bronlar uchun UserID = NULL bo'lib qoladi.
                    if (!ColumnExists(connection, transaction, "Bookings", "UserID"))
                    {
                        ExecuteNonQuery(connection, transaction,
                            "ALTER TABLE Bookings ADD COLUMN UserID INTEGER NULL REFERENCES Users(UserID);");
                    }

                    // Eski bazalarda (2-versiya) Bookings jadvalida CarID ustuni yo'q — qo'shiladi.
                    // Eski bronlarda CarID = NULL bo'lib qoladi (raqam CarPlate matnida saqlanib turadi).
                    if (!ColumnExists(connection, transaction, "Bookings", "CarID"))
                    {
                        ExecuteNonQuery(connection, transaction,
                            "ALTER TABLE Bookings ADD COLUMN CarID INTEGER NULL REFERENCES Cars(CarID);");
                    }

                    long version = Convert.ToInt64(
                        ExecuteScalar(connection, transaction, "PRAGMA user_version;"));

                    if (version < 1)
                    {
                        // Birinchi marta: jadval bo'sh bo'lsagina namunaviy ma'lumotlar qo'shiladi
                        long parkingCount = Convert.ToInt64(
                            ExecuteScalar(connection, transaction, "SELECT COUNT(*) FROM ParkingLots;"));

                        if (parkingCount == 0)
                        {
                            InsertSampleParkingLot(connection, transaction, "Chilonzor Parking", "Toshkent, Chilonzor", 15);
                            InsertSampleParkingLot(connection, transaction, "Yunusobod Parking", "Toshkent, Yunusobod", 20);
                            InsertSampleParkingLot(connection, transaction, "Sergeli Parking", "Toshkent, Sergeli", 10);
                        }
                    }

                    // Administrator hisobi yo'q bo'lsa yaratiladi: login "admin", parol "admin123"
                    long adminCount = Convert.ToInt64(
                        ExecuteScalar(connection, transaction, "SELECT COUNT(*) FROM Users WHERE Role = 'Admin';"));
                    if (adminCount == 0)
                    {
                        UserRepository.InsertUser(connection, transaction,
                            AdminUsername, AdminPassword, AdminFullName, Models.UserRole.Admin);
                    }

                    if (version < SchemaVersion)
                    {
                        // Belgi qo'yiladi: keyingi ishga tushishlarda namunaviy ma'lumotlar qayta qo'shilmaydi,
                        // hatto admin barcha avtoturargohlarni o'chirib tashlagan bo'lsa ham.
                        ExecuteNonQuery(connection, transaction, "PRAGMA user_version = " + SchemaVersion + ";");
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        private static void InsertSampleParkingLot(SqliteConnection connection, SqliteTransaction transaction,
            string name, string address, int totalSpaces)
        {
            using (var command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText =
                    "INSERT INTO ParkingLots (ParkingName, Address, TotalSpaces, IsActive) " +
                    "VALUES (@ParkingName, @Address, @TotalSpaces, 1);";
                command.Parameters.AddWithValue("@ParkingName", name);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@TotalSpaces", totalSpaces);
                command.ExecuteNonQuery();
            }
        }

        private static void ExecuteNonQuery(SqliteConnection connection, SqliteTransaction transaction, string sql)
        {
            using (var command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }

        private static bool ColumnExists(SqliteConnection connection, SqliteTransaction transaction,
            string table, string column)
        {
            using (var command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText = "PRAGMA table_info(" + table + ");";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (string.Equals(reader.GetString(1), column, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private static object ExecuteScalar(SqliteConnection connection, SqliteTransaction transaction, string sql)
        {
            using (var command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText = sql;
                return command.ExecuteScalar();
            }
        }

        /// <summary>
        /// Mahalliy vaqtni bazaga yoziladigan UTC satrga aylantiradi.
        /// </summary>
        public static string ToDbTime(DateTime localTime)
        {
            return localTime.ToUniversalTime().ToString(DbTimeFormat, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Bazadagi UTC satrni ekranda ko'rsatish uchun mahalliy vaqtga aylantiradi.
        /// </summary>
        public static DateTime FromDbTime(string value)
        {
            DateTime utc = DateTime.ParseExact(value, DbTimeFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
            return utc.ToLocalTime();
        }

        /// <summary>
        /// Soniya va millisoniyalarni olib tashlaydi (DateTimePicker qiymatlari daqiqagacha aniq bo'ladi).
        /// </summary>
        public static DateTime TruncateToMinute(DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0, value.Kind);
        }
    }
}
