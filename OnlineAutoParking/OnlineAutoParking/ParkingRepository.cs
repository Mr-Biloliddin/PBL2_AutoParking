using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using OnlineAutoParking.Models;

namespace OnlineAutoParking
{
    /// <summary>
    /// Avtoturargohni tahrirlash natijasi.
    /// </summary>
    public enum UpdateParkingStatus
    {
        Success,
        NotFound,
        CapacityTooLow
    }

    /// <summary>
    /// ParkingLots jadvali bilan ishlash: o'qish, qo'shish, tahrirlash, faolsizlantirish
    /// va bo'sh joylarni hisoblash.
    /// </summary>
    public class ParkingRepository
    {
        /// <summary>
        /// Faol avtoturargohlar va har biri uchun berilgan oraliqdagi bo'sh joylar soni.
        /// </summary>
        public List<ParkingLot> GetActiveParkingLotsWithAvailability(DateTime startTime, DateTime endTime)
        {
            var lots = new List<ParkingLot>();
            using (var connection = DatabaseHelper.OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
SELECT p.ParkingLotID, p.ParkingName, p.Address, p.TotalSpaces, p.IsActive,
       (SELECT COUNT(*)
        FROM Bookings b
        WHERE b.ParkingLotID = p.ParkingLotID
          AND b.Status = 'Active'
          AND b.StartTime < @RequestedEnd
          AND b.EndTime > @RequestedStart) AS OccupiedSpaces
FROM ParkingLots p
WHERE p.IsActive = 1
ORDER BY p.ParkingLotID;";
                command.Parameters.AddWithValue("@RequestedStart", DatabaseHelper.ToDbTime(startTime));
                command.Parameters.AddWithValue("@RequestedEnd", DatabaseHelper.ToDbTime(endTime));

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ParkingLot lot = ReadParkingLot(reader);
                        int occupied = reader.GetInt32(5);
                        // Bo'sh joylar hech qachon manfiy ko'rsatilmaydi
                        lot.AvailableSpaces = Math.Max(0, lot.TotalSpaces - occupied);
                        lots.Add(lot);
                    }
                }
            }
            return lots;
        }

        /// <summary>
        /// Admin panel uchun barcha avtoturargohlar (faol va faol bo'lmagan).
        /// </summary>
        public List<ParkingLot> GetAllParkingLots()
        {
            var lots = new List<ParkingLot>();
            using (var connection = DatabaseHelper.OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "SELECT ParkingLotID, ParkingName, Address, TotalSpaces, IsActive " +
                    "FROM ParkingLots ORDER BY ParkingLotID;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lots.Add(ReadParkingLot(reader));
                    }
                }
            }
            return lots;
        }

        /// <summary>
        /// ID bo'yicha avtoturargoh. Topilmasa null.
        /// </summary>
        public ParkingLot GetParkingLotById(int parkingLotId)
        {
            using (var connection = DatabaseHelper.OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "SELECT ParkingLotID, ParkingName, Address, TotalSpaces, IsActive " +
                    "FROM ParkingLots WHERE ParkingLotID = @ParkingLotID;";
                command.Parameters.AddWithValue("@ParkingLotID", parkingLotId);
                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? ReadParkingLot(reader) : null;
                }
            }
        }

        /// <summary>
        /// Yangi avtoturargoh qo'shadi va uning ID raqamini qaytaradi.
        /// </summary>
        public int AddParkingLot(string parkingName, string address, int totalSpaces, bool isActive)
        {
            if (totalSpaces <= 0)
            {
                throw new ArgumentOutOfRangeException("totalSpaces", "Joylar soni 0 dan katta bo‘lishi kerak.");
            }

            using (var connection = DatabaseHelper.OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "INSERT INTO ParkingLots (ParkingName, Address, TotalSpaces, IsActive) " +
                    "VALUES (@ParkingName, @Address, @TotalSpaces, @IsActive); " +
                    "SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@ParkingName", parkingName);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@TotalSpaces", totalSpaces);
                command.Parameters.AddWithValue("@IsActive", isActive ? 1 : 0);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        /// <summary>
        /// Avtoturargoh ma'lumotlarini yangilaydi (ParkingLotID o'zgarmaydi).
        /// Sig'imni bir vaqtda mavjud faol bronlar sonidan kamaytirishga ruxsat berilmaydi.
        /// requiredCapacity — ruxsat etilgan minimal sig'im.
        /// </summary>
        public UpdateParkingStatus UpdateParkingLot(ParkingLot lot, out int requiredCapacity)
        {
            requiredCapacity = 0;
            if (lot.TotalSpaces <= 0)
            {
                throw new ArgumentOutOfRangeException("lot", "Joylar soni 0 dan katta bo‘lishi kerak.");
            }

            using (var connection = DatabaseHelper.OpenConnection())
            // Tekshiruv va UPDATE orasida yangi bron qo'shilib qolmasligi uchun BEGIN IMMEDIATE
            using (var transaction = connection.BeginTransaction(deferred: false))
            {
                try
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = "SELECT COUNT(*) FROM ParkingLots WHERE ParkingLotID = @ParkingLotID;";
                        command.Parameters.AddWithValue("@ParkingLotID", lot.ParkingLotID);
                        if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                        {
                            transaction.Rollback();
                            return UpdateParkingStatus.NotFound;
                        }
                    }

                    requiredCapacity = GetMaxSimultaneousBookings(connection, transaction, lot.ParkingLotID);
                    if (lot.TotalSpaces < requiredCapacity)
                    {
                        transaction.Rollback();
                        return UpdateParkingStatus.CapacityTooLow;
                    }

                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText =
                            "UPDATE ParkingLots " +
                            "SET ParkingName = @ParkingName, Address = @Address, " +
                            "    TotalSpaces = @TotalSpaces, IsActive = @IsActive " +
                            "WHERE ParkingLotID = @ParkingLotID;";
                        command.Parameters.AddWithValue("@ParkingName", lot.ParkingName);
                        command.Parameters.AddWithValue("@Address", lot.Address);
                        command.Parameters.AddWithValue("@TotalSpaces", lot.TotalSpaces);
                        command.Parameters.AddWithValue("@IsActive", lot.IsActive ? 1 : 0);
                        command.Parameters.AddWithValue("@ParkingLotID", lot.ParkingLotID);
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return UpdateParkingStatus.Success;
                }
                catch
                {
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
        /// Avtoturargohni faolsizlantiradi (IsActive = 0). Yozuv o'chirilmaydi,
        /// eski bronlar tarixda qoladi, yangi bron qilish esa taqiqlanadi.
        /// </summary>
        public bool DeactivateParkingLot(int parkingLotId)
        {
            using (var connection = DatabaseHelper.OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE ParkingLots SET IsActive = 0 WHERE ParkingLotID = @ParkingLotID;";
                command.Parameters.AddWithValue("@ParkingLotID", parkingLotId);
                return command.ExecuteNonQuery() == 1;
            }
        }

        /// <summary>
        /// Berilgan oraliq uchun bo'sh joylar: TotalSpaces - kesishadigan faol bronlar.
        /// Avtoturargoh topilmasa yoki faol bo'lmasa 0 qaytaradi.
        /// </summary>
        public int GetAvailableSpaces(int parkingLotId, DateTime startTime, DateTime endTime)
        {
            using (var connection = DatabaseHelper.OpenConnection())
            {
                int totalSpaces;
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT TotalSpaces FROM ParkingLots WHERE ParkingLotID = @ParkingLotID AND IsActive = 1;";
                    command.Parameters.AddWithValue("@ParkingLotID", parkingLotId);
                    object result = command.ExecuteScalar();
                    if (result == null)
                    {
                        return 0;
                    }
                    totalSpaces = Convert.ToInt32(result);
                }

                int occupied = BookingRepository.CountOverlappingActiveBookings(connection, null, parkingLotId,
                    DatabaseHelper.ToDbTime(startTime), DatabaseHelper.ToDbTime(endTime));
                return Math.Max(0, totalSpaces - occupied);
            }
        }

        /// <summary>
        /// Sig'imni xavfsiz o'zgartirish uchun minimal qiymat: hali tugamagan faol bronlarning
        /// bir vaqtning o'zida eng ko'p kesishgan soni.
        /// </summary>
        public int GetRequiredCapacity(int parkingLotId)
        {
            using (var connection = DatabaseHelper.OpenConnection())
            {
                return GetMaxSimultaneousBookings(connection, null, parkingLotId);
            }
        }

        /// <summary>
        /// "Sweep line" algoritmi: har bir bron boshlanishi +1, tugashi -1 hodisa.
        /// Hodisalar vaqt bo'yicha saralanadi (bir vaqtda bo'lsa avval tugash, keyin boshlanish —
        /// chunki 10:00 da tugagan va 10:00 da boshlangan bronlar kesishmaydi).
        /// Yig'indining eng katta qiymati bir vaqtda band bo'lgan joylarning maksimumi.
        /// </summary>
        internal static int GetMaxSimultaneousBookings(SqliteConnection connection, SqliteTransaction transaction,
            int parkingLotId)
        {
            var events = new List<KeyValuePair<string, int>>();
            using (var command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                // Allaqachon tugagan bronlar sig'imga ta'sir qilmaydi
                command.CommandText = @"
SELECT StartTime, EndTime
FROM Bookings
WHERE ParkingLotID = @ParkingLotID
  AND Status = 'Active'
  AND EndTime > @Now;";
                command.Parameters.AddWithValue("@ParkingLotID", parkingLotId);
                command.Parameters.AddWithValue("@Now", DatabaseHelper.ToDbTime(DateTime.Now));
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        events.Add(new KeyValuePair<string, int>(reader.GetString(0), +1));
                        events.Add(new KeyValuePair<string, int>(reader.GetString(1), -1));
                    }
                }
            }

            events.Sort((a, b) =>
            {
                int byTime = string.CompareOrdinal(a.Key, b.Key);
                return byTime != 0 ? byTime : a.Value.CompareTo(b.Value);
            });

            int current = 0;
            int maximum = 0;
            foreach (var item in events)
            {
                current += item.Value;
                if (current > maximum)
                {
                    maximum = current;
                }
            }
            return maximum;
        }

        private static ParkingLot ReadParkingLot(SqliteDataReader reader)
        {
            return new ParkingLot
            {
                ParkingLotID = reader.GetInt32(0),
                ParkingName = reader.GetString(1),
                Address = reader.GetString(2),
                TotalSpaces = reader.GetInt32(3),
                IsActive = reader.GetInt32(4) == 1
            };
        }
    }
}
