using System.Drawing;
using System.Windows.Forms;

namespace OnlineAutoParking
{
    /// <summary>
    /// Ilovaning umumiy ranglari va DataGridView uslubi.
    /// </summary>
    internal static class UiTheme
    {
        public static readonly Color Background = Color.FromArgb(0xF4, 0xF6, 0xFA);
        public static readonly Color Header = Color.FromArgb(0x17, 0x23, 0x38);
        public static readonly Color Primary = Color.FromArgb(0x25, 0x63, 0xEB);
        public static readonly Color Success = Color.FromArgb(0x16, 0xA3, 0x4A);
        public static readonly Color Danger = Color.FromArgb(0xDC, 0x26, 0x26);
        public static readonly Color Text = Color.FromArgb(0x1F, 0x29, 0x37);
        public static readonly Color MutedText = Color.FromArgb(0x6B, 0x72, 0x80);
        public static readonly Color AlternateRow = Color.FromArgb(0xF1, 0xF5, 0xFB);
        public static readonly Color Selection = Color.FromArgb(0xDB, 0xEA, 0xFE);
        public static readonly Color GridLine = Color.FromArgb(0xE5, 0xE7, 0xEB);

        public static void StyleGrid(DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowHeadersVisible = false;
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = GridLine;

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Header;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Header;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 8, 6, 8);

            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F);
            grid.DefaultCellStyle.ForeColor = Text;
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.SelectionBackColor = Selection;
            grid.DefaultCellStyle.SelectionForeColor = Text;
            grid.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            grid.AlternatingRowsDefaultCellStyle.BackColor = AlternateRow;
            grid.RowTemplate.Height = 34;
        }
    }
}
