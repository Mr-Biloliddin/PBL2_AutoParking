using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OnlineAutoParking.Models;

namespace OnlineAutoParking
{
    /// <summary>
    /// "Mening mashinalarim": foydalanuvchi o'z mashinalarini ko'radi, qo'shadi va o'chiradi.
    /// </summary>
    public partial class CarsForm : Form
    {
        private readonly CarRepository _carRepository = new CarRepository();

        public CarsForm()
        {
            InitializeComponent();
            UiTheme.StyleGrid(dgvCars);
        }

        private void CarsForm_Load(object sender, EventArgs e)
        {
            LoadCars();
            txtPlate.Focus();
        }

        private void LoadCars()
        {
            try
            {
                List<Car> cars = _carRepository.GetCarsByUser(Session.CurrentUser.UserID);
                dgvCars.DataSource = cars;
                lblCount.Text = cars.Count == 0
                    ? "Hali mashina qo‘shilmagan. Joy band qilish uchun avval mashina qo‘shing."
                    : "Mashinalar soni: " + cars.Count;
                btnDelete.Enabled = cars.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mashinalarni yuklab bo‘lmadi.\n\n" + ex.Message, "Xatolik",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string rawPlate = txtPlate.Text.Trim();
            // Ortiqcha bo'shliqlar bitta bo'shliqqa almashtiriladi
            string carName = Regex.Replace(txtCarName.Text.Trim(), @"\s+", " ");

            if (rawPlate.Length == 0)
            {
                ShowValidation("Avtomobil raqamini kiriting.", txtPlate);
                return;
            }
            string carPlate = PlateFormat.Normalize(rawPlate);
            if (carPlate == null)
            {
                ShowValidation("Avtomobil raqami noto‘g‘ri formatda.\n\n" + PlateFormat.FormatHelp, txtPlate);
                return;
            }

            try
            {
                int carId;
                AddCarStatus status = _carRepository.AddCar(Session.CurrentUser.UserID, carPlate, carName, out carId);
                switch (status)
                {
                    case AddCarStatus.Success:
                        txtPlate.Clear();
                        txtCarName.Clear();
                        LoadCars();
                        SelectCar(carId);
                        txtPlate.Focus();
                        break;

                    case AddCarStatus.AlreadyYours:
                        ShowValidation("Bu raqam (" + carPlate + ") sizning ro‘yxatingizda allaqachon bor.", txtPlate);
                        break;

                    case AddCarStatus.PlateTaken:
                        ShowValidation("Bu raqam (" + carPlate + ") boshqa foydalanuvchi nomiga ro‘yxatdan o‘tgan.",
                            txtPlate);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mashina saqlanmadi.\n\n" + ex.Message, "Xatolik",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Car car = dgvCars.CurrentRow != null ? dgvCars.CurrentRow.DataBoundItem as Car : null;
            if (car == null)
            {
                MessageBox.Show("Iltimos, jadvaldan mashinani tanlang.", "Mening mashinalarim",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult answer = MessageBox.Show(
                "Mashina o‘chirilsinmi?\n\n" + car.DisplayText,
                "O‘chirishni tasdiqlang", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes)
            {
                return;
            }

            try
            {
                switch (_carRepository.DeleteCar(Session.CurrentUser.UserID, car.CarID))
                {
                    case DeleteCarStatus.Success:
                        break;

                    case DeleteCarStatus.HasActiveBookings:
                        MessageBox.Show(
                            "Bu mashinaning tugamagan faol broni bor, shuning uchun uni o‘chirib bo‘lmaydi.\n\n" +
                            "Avval bronni bekor qiling yoki u tugashini kuting.",
                            "O‘chirib bo‘lmaydi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                    case DeleteCarStatus.NotFound:
                        MessageBox.Show("Mashina topilmadi (allaqachon o‘chirilgan bo‘lishi mumkin).",
                            "Mening mashinalarim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mashina o‘chirilmadi.\n\n" + ex.Message, "Xatolik",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadCars();
        }

        private void SelectCar(int carId)
        {
            foreach (DataGridViewRow row in dgvCars.Rows)
            {
                var car = row.DataBoundItem as Car;
                if (car != null && car.CarID == carId)
                {
                    dgvCars.CurrentCell = row.Cells[0];
                    row.Selected = true;
                    return;
                }
            }
        }

        private static void ShowValidation(string message, Control control)
        {
            MessageBox.Show(message, "Tekshiruv", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }
    }
}
