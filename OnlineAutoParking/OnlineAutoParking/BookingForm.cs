using System;
using System.Collections.Generic;
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
        // Ism: faqat harflar, bo'shliq, tire va apostrof (O'g'li, G‘ulom). Raqam va boshqa belgilar mumkin emas.
        private static readonly Regex DriverNamePattern = new Regex(@"^\p{L}+(?:[ \-'‘’ʻʼ`]+\p{L}+)*$");

        private readonly ParkingRepository _parkingRepository = new ParkingRepository();
        private readonly BookingRepository _bookingRepository = new BookingRepository();
        private readonly CarRepository _carRepository = new CarRepository();
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

            // Foydalanuvchining mashinalari yuklanadi (bo'lmasa avval mashina qo'shish taklif qilinadi)
            if (!LoadCars())
            {
                BeginInvoke(new MethodInvoker(Close));
                return;
            }

            lblParkingName.Text = _parkingLot.ParkingName;
            lblParkingAddress.Text = _parkingLot.Address + "  •  jami " + _parkingLot.TotalSpaces + " ta joy";
            UpdateAvailability();
            txtDriverName.Focus();
        }

        /// <summary>
        /// Foydalanuvchining mashinalarini ro'yxatga yuklaydi. Bitta mashina bo'lsa u avtomatik tanlanadi,
        /// ikki va undan ko'p bo'lsa foydalanuvchi o'zi tanlashi shart. Mashina yo'q bo'lsa va foydalanuvchi
        /// qo'shmasa — false qaytaradi (bron qilib bo'lmaydi).
        /// </summary>
        private bool LoadCars()
        {
            List<Car> cars;
            try
            {
                cars = _carRepository.GetCarsByUser(Session.CurrentUser.UserID);

                if (cars.Count == 0)
                {
                    DialogResult answer = MessageBox.Show(
                        "Sizda hali mashina qo‘shilmagan. Joy band qilish uchun avval mashinangizni qo‘shing.\n\n" +
                        "Hozir mashina qo‘shasizmi?",
                        "Mashina kerak", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (answer == DialogResult.Yes)
                    {
                        using (var carsForm = new CarsForm())
                        {
                            carsForm.ShowDialog(this);
                        }
                        cars = _carRepository.GetCarsByUser(Session.CurrentUser.UserID);
                    }
                    if (cars.Count == 0)
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mashinalarni o‘qib bo‘lmadi.\n\n" + ex.Message,
                    "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            cmbCar.DataSource = cars;
            if (cars.Count == 1)
            {
                cmbCar.SelectedIndex = 0;
                lblPlateHint.Text = "Sizda 1 ta mashina bor — avtomatik tanlandi.";
            }
            else
            {
                cmbCar.SelectedIndex = -1; // Qaysi biri bilan borishini foydalanuvchi o'zi tanlaydi
                lblPlateHint.Text = "Sizda " + cars.Count + " ta mashina bor — qaysi biri bilan borishingizni tanlang.";
            }
            return true;
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
            var car = cmbCar.SelectedItem as Car;
            if (car == null)
            {
                ShowValidation("Qaysi mashina bilan parkingga borishingizni tanlang.", cmbCar);
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
                    Session.CurrentUser.UserID, car.CarID, _parkingLotId, driverName, start, end, out bookingId);

                switch (status)
                {
                    case CreateBookingStatus.Success:
                        CreatedBookingId = bookingId;
                        MessageBox.Show(
                            "Joy muvaffaqiyatli band qilindi!\n\nBron raqami: " + bookingId +
                            "\nMashina: " + car.CarPlate,
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

                    case CreateBookingStatus.CarNotFound:
                        MessageBox.Show("Tanlangan mashina topilmadi (o‘chirilgan bo‘lishi mumkin). Ro‘yxat yangilanadi.",
                            "Joy band qilish", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (!LoadCars())
                        {
                            Close();
                            return;
                        }
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

        private static void ShowValidation(string message, Control control)
        {
            MessageBox.Show(message, "Tekshiruv", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }
    }
}
