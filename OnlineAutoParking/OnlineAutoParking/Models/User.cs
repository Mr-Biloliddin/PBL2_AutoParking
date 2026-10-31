using System;

namespace OnlineAutoParking.Models
{
    /// <summary>
    /// Users jadvalidagi Role ustuni qiymatlari.
    /// </summary>
    public static class UserRole
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }

    /// <summary>
    /// Users jadvalidagi bitta foydalanuvchi (parol xeshi modelga o'qilmaydi).
    /// </summary>
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }

        /// <summary>Mahalliy vaqtda (bazada UTC saqlanadi).</summary>
        public DateTime CreatedAt { get; set; }

        public bool IsAdmin
        {
            get { return Role == UserRole.Admin; }
        }

        public string RoleText
        {
            get { return IsAdmin ? "Administrator" : "Foydalanuvchi"; }
        }
    }
}
