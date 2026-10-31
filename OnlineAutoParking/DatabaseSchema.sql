-- =====================================================================
-- Online AutoParking — SQLite ma'lumotlar bazasi sxemasi
-- Fayl: PBL2_AutoParking\parking.db
--
-- Eslatma: dastur bu sxemani birinchi ishga tushishda O'ZI yaratadi
-- (DatabaseHelper.Initialize). Bu fayl hujjat va DB Browser for SQLite
-- da tekshirish uchun berilgan.
-- =====================================================================

PRAGMA foreign_keys = ON;

-- 1. Avtoturargohlar
CREATE TABLE IF NOT EXISTS ParkingLots (
    ParkingLotID INTEGER PRIMARY KEY AUTOINCREMENT,
    ParkingName TEXT NOT NULL,
    Address TEXT NOT NULL,
    TotalSpaces INTEGER NOT NULL
        CHECK (TotalSpaces > 0),
    IsActive INTEGER NOT NULL DEFAULT 1
        CHECK (IsActive IN (0, 1))
);

-- 2. Bronlar (vaqtlar UTC, masalan: 2026-10-26T10:00:00.0000000Z)
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

-- 3. Foydalanuvchilar (parollar PBKDF2-SHA256 xeshi + salt ko'rinishida saqlanadi)
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

-- Bronni qilgan foydalanuvchi (eski bronlarda NULL). Dastur eski bazaga avtomatik qo'shadi:
-- ALTER TABLE Bookings ADD COLUMN UserID INTEGER NULL REFERENCES Users(UserID);

-- Administrator hisobi dastur tomonidan yaratiladi (parol xeshlanadi):
--     login: admin   parol: admin123
-- Ro'yxatdan o'tish oynasi orqali faqat oddiy foydalanuvchilar (Role = 'User') yaratiladi.

-- Bo'sh joylarni tez hisoblash uchun indeks
CREATE INDEX IF NOT EXISTS
idx_bookings_parking_status_time
ON Bookings (
    ParkingLotID,
    Status,
    StartTime,
    EndTime
);

-- Namunaviy ma'lumotlar (dastur faqat birinchi initsializatsiyada qo'shadi,
-- so'ng PRAGMA user_version = 1 belgisini qo'yadi — qayta qo'shilmaydi)
-- INSERT INTO ParkingLots (ParkingName, Address, TotalSpaces) VALUES
--     ('Chilonzor Parking', 'Toshkent, Chilonzor', 15),
--     ('Yunusobod Parking', 'Toshkent, Yunusobod', 20),
--     ('Sergeli Parking',   'Toshkent, Sergeli',   10);
-- PRAGMA user_version = 2;   (1 — parking/bronlar, 2 — foydalanuvchilar)


-- =====================================================================
-- Taqdimot uchun foydali so'rovlar (DB Browser -> "Execute SQL")
-- =====================================================================

-- Barcha avtoturargohlar
-- SELECT * FROM ParkingLots;

-- Barcha bronlar avtoturargoh nomi bilan (AdminForm dagi JOIN)
-- SELECT b.BookingID, p.ParkingName, b.DriverName, b.CarPlate,
--        b.StartTime, b.EndTime, b.Status
-- FROM Bookings b
-- INNER JOIN ParkingLots p ON p.ParkingLotID = b.ParkingLotID
-- ORDER BY b.BookingID DESC;

-- Berilgan oraliqda band joylar soni (kesishish sharti)
-- SELECT COUNT(*)
-- FROM Bookings
-- WHERE ParkingLotID = 1
--   AND Status = 'Active'
--   AND StartTime < '2026-10-28T07:00:00.0000000Z'   -- so'ralgan tugash
--   AND EndTime   > '2026-10-28T05:00:00.0000000Z';  -- so'ralgan boshlanish

-- Foydalanuvchilar va ularning bronlari soni
-- SELECT u.UserID, u.Username, u.FullName, u.Role, COUNT(b.BookingID) AS Bronlar
-- FROM Users u
-- LEFT JOIN Bookings b ON b.UserID = u.UserID
-- GROUP BY u.UserID;

-- Initsializatsiya belgisi
-- PRAGMA user_version;
