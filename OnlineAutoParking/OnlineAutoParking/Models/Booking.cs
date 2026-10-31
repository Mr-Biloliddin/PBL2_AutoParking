using System;

namespace OnlineAutoParking.Models
{
    /// <summary>
    /// Bookings jadvalidagi Status ustuni qiymatlari.
    /// </summary>
    public static class BookingStatus
    {
        public const string Active = "Active";
        public const string Cancelled = "Cancelled";
    }

    /// <summary>
    /// Bookings jadvalidagi bitta bron (ParkingLots va Users bilan JOIN qilingan nomlar bilan birga).
    /// </summary>
    public class Booking
    {
        public int BookingID { get; set; }
        public int ParkingLotID { get; set; }
        public string ParkingName { get; set; }
        public string DriverName { get; set; }
        public string CarPlate { get; set; }

        /// <summary>Mahalliy vaqtda (bazada UTC saqlanadi).</summary>
        public DateTime StartTime { get; set; }

        /// <summary>Mahalliy vaqtda (bazada UTC saqlanadi).</summary>
        public DateTime EndTime { get; set; }

        public string Status { get; set; }

        /// <summary>Bronni qilgan foydalanuvchi (eski bronlarda null).</summary>
        public int? UserID { get; set; }

        /// <summary>Foydalanuvchi logini (Users bilan JOIN qilinadi).</summary>
        public string Username { get; set; }

        public bool IsActive
        {
            get { return Status == BookingStatus.Active; }
        }

        public string StatusText
        {
            get { return IsActive ? "Faol" : "Bekor qilingan"; }
        }
    }
}
