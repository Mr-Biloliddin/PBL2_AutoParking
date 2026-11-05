using OnlineAutoParking.Models;

namespace OnlineAutoParking
{
    /// <summary>
    /// Joriy kirgan foydalanuvchi va "Chiqish" (logout) belgisi.
    /// </summary>
    internal static class Session
    {
        public static User CurrentUser { get; private set; }

        /// <summary>
        /// Panel "Chiqish" tugmasi bilan yopilgan bo'lsa true — dastur login oynasiga qaytadi.
        /// Oddiy yopilganda (X) false — dastur tugaydi.
        /// </summary>
        public static bool LogoutRequested { get; private set; }

        /// <summary>
        /// Foydalanuvchi kirmagan (mehmon) rejimi.
        /// </summary>
        public static bool IsGuest { get { return CurrentUser == null; } }

        public static void Start(User user)
        {
            CurrentUser = user;
            LogoutRequested = false;
        }

        /// <summary>
        /// Mehmon paneli ichida kirish/ro'yxatdan o'tish bajarilgandan keyin chaqiriladi:
        /// joriy oyna yopilib, dastur mos panelni qayta ochadi.
        /// </summary>
        public static void StartAndRestart(User user)
        {
            CurrentUser = user;
            LogoutRequested = true;
        }

        /// <summary>
        /// Dasturdan to'liq chiqish: panel yopilgach login/mehmon oynasi qayta ochilmaydi.
        /// </summary>
        public static void RequestExit()
        {
            LogoutRequested = false;
        }

        public static void Logout()
        {
            CurrentUser = null;
            LogoutRequested = true;
        }
    }
}
