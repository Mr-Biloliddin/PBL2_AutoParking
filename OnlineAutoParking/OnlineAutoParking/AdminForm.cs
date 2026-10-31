using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OnlineAutoParking.Models;

namespace OnlineAutoParking
{
    /// <summary>
    /// Administrator paneli: avtoturargohlarni boshqarish, bronlarni ko'rish/bekor qilish
    /// va ro'yxatdan o'tgan foydalanuvchilarni ko'rish.
    /// </summary>
    public partial class AdminForm : Form
    {
        private readonly ParkingRepository _parkingRepository = new ParkingRepository();
        private readonly BookingRepository _bookingRepository = new BookingRepository();
        private readonly UserRepository _userRepository = new UserRepository();

        public AdminForm()
        {
            InitializeComponent();
            UiTheme.StyleGrid(dgvParkingLots);
            UiTheme.StyleGrid(dgvBookings);
            UiTheme.StyleGrid(dgvUsers);
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            lblHeader.Text = "Administrator paneli  •  " + Session.CurrentUser.Username;
            LoadParkingLots(null);
            LoadBookings();
            LoadUsers();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Logout();
            Close();
        }

        // ===================== A. AVTOTURARGOHLAR =====================

        private void LoadParkingLots(int? selectParkingLotId)
        {
            try
            {
                if (selectParkingLotId == null)
                {
                    ParkingLot current = GetSelectedParkingLot();
                    selectParkingLotId = current != null ? current.ParkingLotID : (int?)null;
                }

                List<ParkingLot> lots = _parkingRepository.GetAllParkingLots();
                dgvParkingLots.DataSource = lots;

                if (selectParkingLotId != null)
                {
                    foreach (DataGridViewRow row in dgvParkingLots.Rows)
                    {
                        var lot = (ParkingLot)row.DataBoundItem;
                        if (lot.ParkingLotID == selectParkingLotId.Value)
                        {
                            dgvParkingLots.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                }
                FillEditorFromSelection();
            }
            catch (Exception ex)
            {
                ShowError("Avtoturargohlarni yuklab bo‘lmadi.", ex);
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

        private void dgvParkingLots_SelectionChanged(object sender, EventArgs e)
        {
            FillEditorFromSelection();
        }

        private void FillEditorFromSelection()
        {
            ParkingLot lot = GetSelectedParkingLot();
            if (lot == null)
            {
                lblSelectedParking.Text = "Tahrirlash uchun jadvaldan avtoturargohni tanlang.";
                return;
            }

            txtParkingName.Text = lot.ParkingName;
            txtAddress.Text = lot.Address;
            numTotalSpaces.Value = Math.Min(numTotalSpaces.Maximum, Math.Max(numTotalSpaces.Minimum, lot.TotalSpaces));
            chkIsActive.Checked = lot.IsActive;
            lblSelectedParking.Text = "Tanlangan: ID " + lot.ParkingLotID + " — " + lot.ParkingName +
                ". Yangi qo‘shish uchun maydonlarni o‘zgartirib, \"Qo‘shish\" tugmasini bosing.";
        }

        /// <summary>
        /// Formadagi qiymatlarni tekshiradi. Xato bo'lsa xabar chiqarib false qaytaradi.
        /// </summary>
        private bool ValidateParkingInput(out string name, out string address, out int totalSpaces)
        {
            name = txtParkingName.Text.Trim();
            address = txtAddress.Text.Trim();
            totalSpaces = (int)numTotalSpaces.Value;

            if (name.Length == 0)
            {
                ShowWarning("Avtoturargoh nomini kiriting.");
                txtParkingName.Focus();
                return false;
            }
            if (address.Length == 0)
            {
                ShowWarning("Manzilni kiriting.");
                txtAddress.Focus();
                return false;
            }
            if (totalSpaces <= 0)
            {
                ShowWarning("Umumiy joylar soni 0 dan katta bo‘lishi kerak.");
                numTotalSpaces.Focus();
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name, address;
            int totalSpaces;
            if (!ValidateParkingInput(out name, out address, out totalSpaces))
            {
                return;
            }

            try
            {
                int newId = _parkingRepository.AddParkingLot(name, address, totalSpaces, chkIsActive.Checked);
                LoadParkingLots(newId);
                ShowInfo("Avtoturargoh qo‘shildi.\n\nID: " + newId);
            }
            catch (Exception ex)
            {
                ShowError("Avtoturargohni qo‘shib bo‘lmadi.", ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ParkingLot selected = GetSelectedParkingLot();
            if (selected == null)
            {
                ShowWarning("Tahrirlash uchun jadvaldan avtoturargohni tanlang.");
                return;
            }

            string name, address;
            int totalSpaces;
            if (!ValidateParkingInput(out name, out address, out totalSpaces))
            {
                return;
            }

            var updated = new ParkingLot
            {
                ParkingLotID = selected.ParkingLotID,
                ParkingName = name,
                Address = address,
                TotalSpaces = totalSpaces,
                IsActive = chkIsActive.Checked
            };

            try
            {
                int requiredCapacity;
                UpdateParkingStatus status = _parkingRepository.UpdateParkingLot(updated, out requiredCapacity);
                switch (status)
                {
                    case UpdateParkingStatus.Success:
                        LoadParkingLots(updated.ParkingLotID);
                        LoadBookings();
                        ShowInfo("O‘zgarishlar saqlandi.");
                        break;

                    case UpdateParkingStatus.CapacityTooLow:
                        ShowWarning(
                            "Sig‘imni " + totalSpaces + " taga kamaytirib bo‘lmaydi.\n\n" +
                            "Bu avtoturargohda bir vaqtning o‘zida " + requiredCapacity +
                            " ta faol bron mavjud.\nRuxsat etilgan minimal sig‘im: " + requiredCapacity + ".");
                        break;

                    case UpdateParkingStatus.NotFound:
                        ShowWarning("Avtoturargoh topilmadi. Jadval yangilanadi.");
                        LoadParkingLots(null);
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowError("O‘zgarishlarni saqlab bo‘lmadi.", ex);
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            ParkingLot selected = GetSelectedParkingLot();
            if (selected == null)
            {
                ShowWarning("Jadvaldan avtoturargohni tanlang.");
                return;
            }
            if (!selected.IsActive)
            {
                ShowInfo("Bu avtoturargoh allaqachon faol emas.");
                return;
            }

            DialogResult answer = MessageBox.Show(
                "\"" + selected.ParkingName + "\" faolsizlantirilsinmi?\n\n" +
                "Yangi bron qilish taqiqlanadi, mavjud bronlar tarixda saqlanib qoladi.",
                "Tasdiqlash", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (answer != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _parkingRepository.DeactivateParkingLot(selected.ParkingLotID);
                LoadParkingLots(selected.ParkingLotID);
                ShowInfo("Avtoturargoh faolsizlantirildi.");
            }
            catch (Exception ex)
            {
                ShowError("Avtoturargohni faolsizlantirib bo‘lmadi.", ex);
            }
        }

        private void btnRefreshParking_Click(object sender, EventArgs e)
        {
            LoadParkingLots(null);
        }

        private void dgvParkingLots_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvParkingLots.Columns[e.ColumnIndex] != colParkingStatus)
            {
                return;
            }
            var lot = dgvParkingLots.Rows[e.RowIndex].DataBoundItem as ParkingLot;
            if (lot != null)
            {
                e.CellStyle.ForeColor = lot.IsActive ? UiTheme.Success : UiTheme.Danger;
                e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            }
        }

        // ===================== B. BRONLAR =====================

        private void LoadBookings()
        {
            try
            {
                List<Booking> bookings = _bookingRepository.GetAllBookings();
                dgvBookings.DataSource = bookings;
                int activeCount = bookings.Count(b => b.IsActive);
                lblBookingCount.Text = "Jami bronlar: " + bookings.Count + "   •   Faol: " + activeCount +
                    "   •   Bekor qilingan: " + (bookings.Count - activeCount);
            }
            catch (Exception ex)
            {
                ShowError("Bronlarni yuklab bo‘lmadi.", ex);
            }
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            Booking booking = dgvBookings.CurrentRow != null
                ? dgvBookings.CurrentRow.DataBoundItem as Booking
                : null;
            if (booking == null)
            {
                ShowWarning("Jadvaldan bronni tanlang.");
                return;
            }
            if (!booking.IsActive)
            {
                ShowInfo("Bu bron allaqachon bekor qilingan.");
                return;
            }

            DialogResult answer = MessageBox.Show(
                "Bron #" + booking.BookingID + " bekor qilinsinmi?\n\n" +
                booking.DriverName + ", " + booking.CarPlate + "\n" +
                booking.ParkingName + ": " + booking.StartTime.ToString("dd.MM.yyyy HH:mm") +
                " — " + booking.EndTime.ToString("dd.MM.yyyy HH:mm"),
                "Tasdiqlash", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (answer != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (_bookingRepository.CancelBooking(booking.BookingID))
                {
                    ShowInfo("Bron #" + booking.BookingID + " bekor qilindi.");
                }
                else
                {
                    ShowWarning("Bron bekor qilinmadi: u allaqachon bekor qilingan yoki topilmadi.");
                }
                LoadBookings();
            }
            catch (Exception ex)
            {
                ShowError("Bronni bekor qilib bo‘lmadi.", ex);
            }
        }

        private void btnRefreshBookings_Click(object sender, EventArgs e)
        {
            LoadBookings();
        }

        private void dgvBookings_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var booking = dgvBookings.Rows[e.RowIndex].DataBoundItem as Booking;
            if (booking == null)
            {
                return;
            }

            if (!booking.IsActive)
            {
                // Bekor qilingan bronlar kulrang ko'rinadi
                e.CellStyle.ForeColor = UiTheme.MutedText;
                e.CellStyle.SelectionForeColor = UiTheme.MutedText;
            }
            if (dgvBookings.Columns[e.ColumnIndex] == colBookingStatus)
            {
                e.CellStyle.ForeColor = booking.IsActive ? UiTheme.Success : UiTheme.Danger;
                e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            }
        }

        // ===================== C. FOYDALANUVCHILAR =====================

        private void LoadUsers()
        {
            try
            {
                List<User> users = _userRepository.GetAllUsers();
                dgvUsers.DataSource = users;
                lblUserCount.Text = "Foydalanuvchilar: " + users.Count(u => !u.IsAdmin) +
                    "   •   Administrator: " + users.Count(u => u.IsAdmin);
            }
            catch (Exception ex)
            {
                ShowError("Foydalanuvchilarni yuklab bo‘lmadi.", ex);
            }
        }

        private void btnRefreshUsers_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvUsers.Columns[e.ColumnIndex] != colUserRole)
            {
                return;
            }
            var user = dgvUsers.Rows[e.RowIndex].DataBoundItem as User;
            if (user != null && user.IsAdmin)
            {
                e.CellStyle.ForeColor = UiTheme.Primary;
                e.CellStyle.SelectionForeColor = UiTheme.Primary;
            }
        }

        // ===================== Xabarlar =====================

        private void ShowInfo(string message)
        {
            MessageBox.Show(message, "Administrator paneli", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Administrator paneli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show(message + "\n\n" + ex.Message, "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
