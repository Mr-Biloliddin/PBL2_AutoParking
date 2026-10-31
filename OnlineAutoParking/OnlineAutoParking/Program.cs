using System;
using System.Windows.Forms;

namespace OnlineAutoParking
{
    internal static class Program
    {
        /// <summary>
        /// Dasturning kirish nuqtasi.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Birinchi ishga tushishda parking.db fayli, jadvallar va namunaviy ma'lumotlar yaratiladi
                DatabaseHelper.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ma'lumotlar bazasini ishga tushirib bo‘lmadi.\n\n" + ex.Message +
                    "\n\nFayl: " + DatabaseHelper.DatabasePath,
                    "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kirish -> rolga qarab panel. Panel "Chiqish" tugmasi bilan yopilsa, yana kirish oynasi ochiladi.
            while (true)
            {
                Models.User user;
                using (var loginForm = new LoginForm())
                {
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    user = loginForm.AuthenticatedUser;
                }

                Session.Start(user);
                Form panel = user.IsAdmin ? (Form)new AdminForm() : new MainForm();
                Application.Run(panel);

                if (!Session.LogoutRequested)
                {
                    return;
                }
            }
        }
    }
}
