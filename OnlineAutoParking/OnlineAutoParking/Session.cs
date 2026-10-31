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

        public static void Start(User user)
        {
            CurrentUser = user;
            LogoutRequested = false;
        }

        public static void Logout()
        {
            CurrentUser = null;
            LogoutRequested = true;
        }
    }
}
