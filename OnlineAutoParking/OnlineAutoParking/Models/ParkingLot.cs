namespace OnlineAutoParking.Models
{
    /// <summary>
    /// ParkingLots jadvalidagi bitta avtoturargoh.
    /// </summary>
    public class ParkingLot
    {
        public int ParkingLotID { get; set; }
        public string ParkingName { get; set; }
        public string Address { get; set; }
        public int TotalSpaces { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// Tanlangan vaqt oralig'i uchun hisoblangan bo'sh joylar soni.
        /// Bazada saqlanmaydi — har safar bronlar asosida qayta hisoblanadi.
        /// </summary>
        public int AvailableSpaces { get; set; }

        public string StatusText
        {
            get { return IsActive ? "Faol" : "Faol emas"; }
        }
    }
}
