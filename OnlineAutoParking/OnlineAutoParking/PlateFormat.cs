using System.Text.RegularExpressions;

namespace OnlineAutoParking
{
    /// <summary>
    /// Avtomobil raqamini tekshirish va yagona ko'rinishga keltirish (CarsForm va boshqa joylar uchun umumiy).
    /// </summary>
    internal static class PlateFormat
    {
        // Bo'shliqsiz raqam: "01A123AA" (## A###AA) yoki "01123AAA" (## ###AAA)
        private static readonly Regex LetterFirst = new Regex(@"^(\d{2})([A-Z]\d{3}[A-Z]{2})$");
        private static readonly Regex DigitsFirst = new Regex(@"^(\d{2})(\d{3}[A-Z]{3})$");

        public const string FormatHelp =
            "Ruxsat etilgan formatlar:\n" +
            "  ## A###AA   (masalan: 01 A123BC)\n" +
            "  ## ###AAA   (masalan: 01 123ABC)";

        /// <summary>
        /// Raqamni tekshiradi va yagona ko'rinishga keltiradi: "01 a 123 bc" -> "01 A123BC",
        /// "01123abc" -> "01 123ABC". Format mos kelmasa null qaytaradi.
        /// </summary>
        public static string Normalize(string input)
        {
            if (input == null)
            {
                return null;
            }
            string compact = Regex.Replace(input, @"[\s\-]+", "").ToUpperInvariant();
            Match match = LetterFirst.Match(compact);
            if (!match.Success)
            {
                match = DigitsFirst.Match(compact);
            }
            return match.Success ? match.Groups[1].Value + " " + match.Groups[2].Value : null;
        }
    }
}
