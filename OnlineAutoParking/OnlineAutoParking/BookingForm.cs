using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OnlineAutoParking.Models;

namespace OnlineAutoParking
{
    /// <summary>
    /// Haydovchi ma'lumotlarini kiritish va bronni tasdiqlash oynasi.
    /// </summary>
    public partial class BookingForm : Form
    {
        // Bo'shliqlarsiz raqam: "01A123AA" (## A###AA) yoki "01123AAA" (## ###AAA)
        private static readonly Regex PlateLetterFirst = new Regex(@"^(\d{2})([A-Z]\d{3}[A-Z]{2})$");
        private static readonly Regex PlateDigitsFirst = new Regex(@"^(\d{2})(\d{3}[A-Z]{3})$");

        // Ism: faqat harflar, bo'shliq, tire va apostrof (O'g'li, G‘ulom). Raqam va boshqa belgilar mumkin emas.
        private static readonly Regex DriverNamePattern = new Regex(@"^\p{L}+(?:[ \-'‘’ʻʼ`]+\p{L}+)*$");

        private readonly ParkingRepository _parkingRepository = new ParkingRepository();
        private readonly BookingRepository _bookingRepository = new BookingRepository();
        private readonly int _parkingLotId;
        private ParkingLot _parkingLot;

        /// <summary>
        /// Muvaffaqiyatli yaratilgan bron raqami (bo'lmasa 0).
        /// </summary>
        public int CreatedBookingId { get; private set; }

        public BookingForm(int parkingLotId, DateTime startTime, DateTime endTime)
        {
            InitializeComponent();
            _parkingLotId = parkingLotId;
            dtpStart.Value = startTime;
            dtpEnd.Value = endTime;
        }

        private void BookingForm_Load(object sender, EventArgs e)
        {
            try
            {
                _parkingLot = _parkingRepository.GetParkingLotById(_parkingLotId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Avtoturargoh ma'lumotlarini o‘qib bo‘lmadi.\n\n" + ex.Message,
                    "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BeginInvoke(new MethodInvoker(Close));
                return;
            }

            if (_parkingLot == null || !_parkingLot.IsActive)
            {
                MessageBox.Show(_parkingLot == null
                        ? "Tanlangan avtoturargoh topilmadi."
                        : "Bu avtoturargoh faol emas. Yangi bron qilib bo‘lmaydi.",
                    "Joy band qilish", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BeginInvoke(new MethodInvoker(Close));
                return;
            }

            // Haydovchi ismi sifatida kirgan foydalanuvchining ismi taklif qilinadi (o'zgartirish mumkin)
            if (Session.CurrentUser != null && txtDriverName.Text.Length == 0)
            {
                txtDriverName.Text = Session.CurrentUser.FullName;
            }

            lblParkingName.Text = _parkingLot.ParkingName;
            lblParkingAddress.Text = _parkingLot.Address + "  •  jami " + _parkingLot.TotalSpaces + " ta joy";
            UpdateAvailability();
            txtDriverName.Focus();
        }

        private void dtpInterval_ValueChanged(object sender, EventArgs e)
        {
            UpdateAvailability();
        }

        /// <summary>
        /// Tanlangan vaqt oralig'i uchun bo'sh joylarni bazadan qayta hisoblab ko'rsatadi.
        /// </summary>
        private void UpdateAvailability()
        {
            if (_parkingLot == null)
            {
                return; // Forma hali yuklanmagan
            }

            DateTime start = DatabaseHelper.TruncateToMinute(dtpStart.Value);
            DateTime end = DatabaseHelper.TruncateToMinute(dtpEnd.Value);
            if (end <= start)
            {
                lblAvailable.Text = "Vaqt oralig‘i noto‘g‘ri";
                lblAvailable.ForeColor = UiTheme.Danger;
                return;
            }

            try
            {
                int available = _parkingRepository.GetAvailableSpaces(_parkingLotId, start, end);
                lblAvailable.Text = available + " ta (jami " + _parkingLot.TotalSpaces + " ta)";
                lblAvailable.ForeColor = available > 0 ? UiTheme.Success : UiTheme.Danger;
            }
            catch (Exception ex)
            {
                lblAvailable.Text = "Tekshirib bo‘lmadi";
                lblAvailable.ForeColor = UiTheme.Danger;
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Ortiqcha bo'shliqlar bitta bo'shliqqa almashtiriladi: "  Ali   Valiyev " -> "Ali Valiyev"
            string driverName = Regex.Replace(txtDriverName.Text.Trim(), @"\s+", " ");
            string rawPlate = txtCarPlate.Text.Trim();
            DateTime start = DatabaseHelper.TruncateToMinute(dtpStart.Value);
            DateTime end = DatabaseHelper.TruncateToMinute(dtpEnd.Value);

            // 1-4. Kiritilgan ma'lumotlarni tekshirish
            if (driverName.Length == 0)
            {
                ShowValidation("Haydovchi ismini kiriting.", txtDriverName);
                return;
            }
            if (driverName.Any(char.IsDigit))
            {
                ShowValidation("Haydovchi ismida raqam bo‘lishi mumkin emas.", txtDriverName);
                return;
            }
            if (!DriverNamePattern.IsMatch(driverName) || driverName.Count(char.IsLetter) < 2)
            {
                ShowValidation("Haydovchi ismi faqat harflardan iborat bo‘lishi kerak " +
                    "(bo‘shliq, tire va apostrof ruxsat etiladi).", txtDriverName);
                return;
            }
            if (rawPlate.Length == 0)
            {
                ShowValidation("Avtomobil raqamini kiriting.", txtCarPlate);
                return;
            }
            string carPlate = NormalizeCarPlate(rawPlate);
            if (carPlate == null)
            {
                ShowValidation("Avtomobil raqami noto‘g‘ri formatda.\n\n" +
                    "Ruxsat etilgan formatlar:\n" +
                    "  ## A###AA   (masalan: 01 A123BC)\n" +
                    "  ## ###AAA   (masalan: 01 123ABC)", txtCarPlate);
                return;
            }
            if (start < DatabaseHelper.TruncateToMinute(DateTime.Now))
            {
                ShowValidation("Boshlanish vaqti o‘tib ketgan vaqt bo‘lishi mumkin emas.", dtpStart);
                return;
            }
            if (end <= start)
            {
                ShowValidation("Tugash vaqti boshlanish vaqtidan keyin bo‘lishi kerak.", dtpEnd);
                return;
            }

            btnConfirm.Enabled = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                // 5-6. Avtoturargoh holati va bo'sh joy tranzaksiya ichida qayta tekshiriladi
                int bookingId;
                CreateBookingStatus status = _bookingRepository.CreateBooking(
                    Session.CurrentUser.UserID, _parkingLotId, driverName, carPlate, start, end, out bookingId);

                switch (status)
                {
                    case CreateBookingStatus.Success:
                        CreatedBookingId = bookingId;
                        MessageBox.Show(
                            "Joy muvaffaqiyatli band qilindi!\n\nBron raqami: " + bookingId,
                            "Muvaffaqiyatli", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                        return;

                    case CreateBookingStatus.NoSpace:
                        MessageBox.Show("Uzr, tanlangan vaqt uchun bo‘sh joy mavjud emas.",
                            "Joy yo‘q", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                    case CreateBookingStatus.ParkingInactive:
                        MessageBox.Show("Bu avtoturargoh faol emas. Yangi bron qilib bo‘lmaydi.",
                            "Joy band qilish", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                    case CreateBookingStatus.ParkingNotFound:
                        MessageBox.Show("Tanlangan avtoturargoh topilmadi.",
                            "Joy band qilish", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                    case CreateBookingStatus.InvalidInterval:
                        MessageBox.Show("Tugash vaqti boshlanish vaqtidan keyin bo‘lishi kerak.",
                            "Noto‘g‘ri vaqt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bron saqlanmadi. O‘zgarishlar bekor qilindi.\n\n" + ex.Message,
                    "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnConfirm.Enabled = true;
            }

            UpdateAvailability();
        }

        /// <summary>
        /// Raqamni tekshiradi va yagona ko'rinishga keltiradi: "01 a 123 bc" -> "01 A123BC",
        /// "01123abc" -> "01 123ABC". Format mos kelmasa null qaytaradi.
        /// </summary>
        private static string NormalizeCarPlate(string input)
        {
            string compact = Regex.Replace(input, @"[\s\-]+", "").ToUpperInvariant();
            Match match = PlateLetterFirst.Match(compact);
            if (!match.Success)
            {
                match = PlateDigitsFirst.Match(compact);
            }
            return match.Success ? match.Groups[1].Value + " " + match.Groups[2].Value : null;
        }

        private static void ShowValidation(string message, Control control)
        {
            MessageBox.Show(message, "Tekshiruv", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }
    }
}
