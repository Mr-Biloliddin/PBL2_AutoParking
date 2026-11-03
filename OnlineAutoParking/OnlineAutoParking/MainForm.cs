using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OnlineAutoParking.Models;

namespace OnlineAutoParking
{
    /// <summary>
    /// Foydalanuvchi paneli: faol avtoturargohlar, tanlangan vaqt oralig'idagi bo'sh joylar va bron qilish.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly ParkingRepository _parkingRepository = new ParkingRepository();
        private readonly Font _boldFont = new Font("Segoe UI", 9.75F, FontStyle.Bold);

        public MainForm()
        {
            InitializeComponent();
            UiTheme.StyleGrid(dgvParkingLots);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblDatabasePath.Text = "Baza: " + DatabaseHelper.DatabasePath;
            lblSubtitle.Text = "Xush kelibsiz, " + Session.CurrentUser.FullName +
                " (" + Session.CurrentUser.Username + ")  •  Avtoturargohni oldindan band qiling";
            SetDefaultInterval();
            LoadParkingLots();
        }

        /// <summary>
        /// Standart oraliq: keyingi to'liq soatdan boshlab 1 soat.
        /// </summary>
        private void SetDefaultInterval()
        {
            DateTime now = DateTime.Now;
            DateTime start = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0).AddHours(1);
            dtpStart.Value = start;
            dtpEnd.Value = start.AddHours(1);
        }

        private bool TryGetInterval(out DateTime start, out DateTime end)
        {
            start = DatabaseHelper.TruncateToMinute(dtpStart.Value);
            end = DatabaseHelper.TruncateToMinute(dtpEnd.Value);
            if (end <= start)
            {
                MessageBox.Show("Tugash vaqti boshlanish vaqtidan keyin bo‘lishi kerak.",
                    "Noto‘g‘ri vaqt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Avtoturargohlarni SQLite'dan o'qiydi va bo'sh joylarni qayta hisoblaydi.
        /// </summary>
        private void LoadParkingLots()
        {
            DateTime start, end;
            if (!TryGetInterval(out start, out end))
            {
                return;
            }

            try
            {
                ParkingLot selected = GetSelectedParkingLot();
                int? selectedId = selected != null ? selected.ParkingLotID : (int?)null;

                List<ParkingLot> lots = _parkingRepository.GetActiveParkingLotsWithAvailability(start, end);
                dgvParkingLots.DataSource = lots;
                SelectParkingLot(selectedId);

                lblIntervalInfo.Text = string.Format(
                    "Bo‘sh joylar {0:dd.MM.yyyy HH:mm} — {1:dd.MM.yyyy HH:mm} oralig‘i uchun hisoblangan.  Faol avtoturargohlar: {2} ta.",
                    start, end, lots.Count);
            }
            catch (Exception ex)
            {
                ShowError("Ma'lumotlarni yuklab bo‘lmadi.", ex);
            }
        }

        private ParkingLot GetSelectedParkingLot()
        {
            if (dgvParkingLots.CurrentRow == null)
            {
                return null;
            }
            return dgvParkingLots.CurrentRow.DataBoundItem as ParkingLot;
        }

        private void SelectParkingLot(int? parkingLotId)
        {
            if (parkingLotId == null)
            {
                return;
            }
            foreach (DataGridViewRow row in dgvParkingLots.Rows)
            {
                var lot = row.DataBoundItem as ParkingLot;
                if (lot != null && lot.ParkingLotID == parkingLotId.Value)
                {
                    dgvParkingLots.CurrentCell = row.Cells[0];
                    row.Selected = true;
                    return;
                }
            }
        }

        private void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            LoadParkingLots();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadParkingLots();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            OpenBookingForm();
        }

        private void btnMyCars_Click(object sender, EventArgs e)
        {
            using (var carsForm = new CarsForm())
            {
                carsForm.ShowDialog(this);
            }
        }

        private void dgvParkingLots_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                OpenBookingForm();
            }
        }

        private void OpenBookingForm()
        {
            ParkingLot lot = GetSelectedParkingLot();
            if (lot == null)
            {
                MessageBox.Show("Iltimos, jadvaldan avtoturargohni tanlang.",
                    "Joy band qilish", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime start, end;
            if (!TryGetInterval(out start, out end))
            {
                return;
            }

            try
            {
                // Jadvaldagi raqam eskirgan bo'lishi mumkin — bazadan qayta tekshiramiz
                int available = _parkingRepository.GetAvailableSpaces(lot.ParkingLotID, start, end);
                if (available <= 0)
                {
                    MessageBox.Show("Uzr, tanlangan vaqt uchun bo‘sh joy mavjud emas.",
                        "Joy band qilish", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadParkingLots();
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowError("Bo‘sh joylarni tekshirib bo‘lmadi.", ex);
                return;
            }

            using (var bookingForm = new BookingForm(lot.ParkingLotID, start, end))
            {
                bookingForm.ShowDialog(this);
            }

            // Bron qilingan yoki qilinmaganidan qat'i nazar, jadvalni yangilaymiz
            LoadParkingLots();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Logout();
            Close();
        }

        private void dgvParkingLots_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvParkingLots.Columns[e.ColumnIndex] != colAvailableSpaces || e.Value == null)
            {
                return;
            }

            int available = Convert.ToInt32(e.Value);
            e.CellStyle.ForeColor = available > 0 ? UiTheme.Success : UiTheme.Danger;
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            e.CellStyle.Font = _boldFont;
        }

        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show(message + "\n\n" + ex.Message, "Xatolik",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
