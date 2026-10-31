using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OnlineAutoParking.Models;

namespace OnlineAutoParking
{
    /// <summary>
    /// Kirish oynasi: mavjud hisob bilan kirish yoki yangi foydalanuvchi sifatida ro'yxatdan o'tish.
    /// Muvaffaqiyatli kirilganda DialogResult.OK va AuthenticatedUser qaytariladi.
    /// </summary>
    public partial class LoginForm : Form
    {
        // Login: 3-30 belgi, faqat lotin harflari va raqamlar
        private static readonly Regex UsernamePattern = new Regex(@"^[A-Za-z0-9]{3,30}$");

        // Ism: faqat harflar, bo'shliq, tire va apostrof (BookingForm dagi qoida bilan bir xil)
        private static readonly Regex FullNamePattern = new Regex(@"^\p{L}+(?:[ \-'‘’ʻʼ`]+\p{L}+)*$");

        private const int MinPasswordLength = 6;

        private readonly UserRepository _userRepository = new UserRepository();

        /// <summary>
        /// Kirgan foydalanuvchi (DialogResult.OK bo'lgandagina to'ldiriladi).
        /// </summary>
        public User AuthenticatedUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            txtLoginUsername.Focus();
        }

        private void tabAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
            AcceptButton = tabAuth.SelectedTab == tabRegister ? btnRegister : btnLogin;
            if (tabAuth.SelectedTab == tabRegister)
            {
                txtFullName.Focus();
            }
            else
            {
                txtLoginUsername.Focus();
            }
        }

        // ===================== KIRISH =====================

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtLoginUsername.Text.Trim();
            string password = txtLoginPassword.Text;

            if (username.Length == 0)
            {
                ShowValidation("Loginni kiriting.", txtLoginUsername);
                return;
            }
            if (password.Length == 0)
            {
                ShowValidation("Parolni kiriting.", txtLoginPassword);
                return;
            }

            User user;
            Cursor = Cursors.WaitCursor;
            try
            {
                user = _userRepository.Authenticate(username, password);
            }
            catch (Exception ex)
            {
                ShowError("Kirishda xatolik yuz berdi.", ex);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            if (user == null)
            {
                txtLoginPassword.Clear();
                ShowValidation("Login yoki parol noto‘g‘ri.", txtLoginPassword);
                return;
            }

            CompleteLogin(user);
        }

        // ===================== RO'YXATDAN O'TISH =====================

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = Regex.Replace(txtFullName.Text.Trim(), @"\s+", " ");
            string username = txtRegisterUsername.Text.Trim();
            string password = txtRegisterPassword.Text;
            string confirm = txtConfirmPassword.Text;

            if (fullName.Length == 0)
            {
                ShowValidation("Ism va familiyani kiriting.", txtFullName);
                return;
            }
            if (!FullNamePattern.IsMatch(fullName) || fullName.Count(char.IsLetter) < 2)
            {
                ShowValidation("Ism faqat harflardan iborat bo‘lishi kerak " +
                    "(bo‘shliq, tire va apostrof ruxsat etiladi).", txtFullName);
                return;
            }
            if (!UsernamePattern.IsMatch(username))
            {
                ShowValidation("Login 3–30 belgidan iborat bo‘lishi kerak: faqat lotin harflari va raqamlar.",
                    txtRegisterUsername);
                return;
            }
            if (password.Length < MinPasswordLength)
            {
                ShowValidation("Parol kamida " + MinPasswordLength + " ta belgidan iborat bo‘lishi kerak.",
                    txtRegisterPassword);
                return;
            }
            if (password != confirm)
            {
                txtConfirmPassword.Clear();
                ShowValidation("Parollar bir xil emas.", txtConfirmPassword);
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                int userId;
                RegisterStatus status = _userRepository.Register(username, password, fullName, out userId);
                if (status == RegisterStatus.UsernameTaken)
                {
                    ShowValidation("Bu login band. Boshqa login tanlang.", txtRegisterUsername);
                    return;
                }

                MessageBox.Show("Ro‘yxatdan muvaffaqiyatli o‘tdingiz!\n\nLogin: " + username,
                    "Ro‘yxatdan o‘tish", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ro'yxatdan o'tgandan keyin avtomatik kiriladi
                CompleteLogin(_userRepository.Authenticate(username, password));
            }
            catch (Exception ex)
            {
                ShowError("Ro‘yxatdan o‘tib bo‘lmadi.", ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void CompleteLogin(User user)
        {
            AuthenticatedUser = user;
            DialogResult = DialogResult.OK;
            Close();
        }

        private static void ShowValidation(string message, Control control)
        {
            MessageBox.Show(message, "Tekshiruv", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private static void ShowError(string message, Exception ex)
        {
            MessageBox.Show(message + "\n\n" + ex.Message, "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
