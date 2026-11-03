using System;

namespace OnlineAutoParking.Models
{
    /// <summary>
    /// Cars jadvalidagi bitta mashina (har bir mashina bitta foydalanuvchiga tegishli).
    /// </summary>
    public class Car
    {
        public int CarID { get; set; }
        public int UserID { get; set; }

        /// <summary>Yagona ko'rinishdagi raqam: "01 A123BC" yoki "01 123ABC".</summary>
        public string CarPlate { get; set; }

        /// <summary>Mashina nomi/modeli (ixtiyoriy), masalan "Chevrolet Cobalt".</summary>
        public string CarName { get; set; }

        /// <summary>Mahalliy vaqtda (bazada UTC saqlanadi).</summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>Ro'yxatlarda ko'rsatiladigan matn: "01 A123BC — Chevrolet Cobalt".</summary>
        public string DisplayText
        {
            get
            {
                return string.IsNullOrEmpty(CarName) ? CarPlate : CarPlate + " — " + CarName;
            }
        }
    }
}
