namespace OnlineAutoParking
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlpFilter = new System.Windows.Forms.TableLayoutPanel();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnCheckAvailability = new System.Windows.Forms.Button();
            this.lblIntervalInfo = new System.Windows.Forms.Label();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnMyCars = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblDatabasePath = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvParkingLots = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalSpaces = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvailableSpaces = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.tlpFilter.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParkingLots)).BeginInit();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(56)))));
            this.pnlHeader.Controls.Add(this.btnRegister);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(984, 92);
            this.pnlHeader.TabIndex = 0;
            //
            // btnRegister
            //
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(792, 13);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(172, 38);
            this.btnRegister.TabIndex = 2;
            this.btnRegister.Text = "Ro‘yxatdan o‘tish";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            //
            // lblSubtitle
            //
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(194)))), ((int)(((byte)(217)))));
            this.lblSubtitle.Location = new System.Drawing.Point(24, 56);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(263, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Avtoturargohni oldindan band qiling";
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(305, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ONLINE AUTOPARKING";
            //
            // tlpFilter
            //
            this.tlpFilter.AutoSize = true;
            this.tlpFilter.BackColor = System.Drawing.Color.White;
            this.tlpFilter.ColumnCount = 6;
            this.tlpFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFilter.Controls.Add(this.lblStart, 0, 0);
            this.tlpFilter.Controls.Add(this.dtpStart, 1, 0);
            this.tlpFilter.Controls.Add(this.lblEnd, 2, 0);
            this.tlpFilter.Controls.Add(this.dtpEnd, 3, 0);
            this.tlpFilter.Controls.Add(this.btnCheckAvailability, 4, 0);
            this.tlpFilter.Controls.Add(this.lblIntervalInfo, 0, 1);
            this.tlpFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpFilter.Location = new System.Drawing.Point(0, 92);
            this.tlpFilter.Name = "tlpFilter";
            this.tlpFilter.Padding = new System.Windows.Forms.Padding(20, 14, 20, 10);
            this.tlpFilter.RowCount = 2;
            this.tlpFilter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFilter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFilter.Size = new System.Drawing.Size(984, 92);
            this.tlpFilter.TabIndex = 1;
            //
            // lblStart
            //
            this.lblStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStart.AutoSize = true;
            this.lblStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblStart.Location = new System.Drawing.Point(23, 25);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(109, 17);
            this.lblStart.TabIndex = 0;
            this.lblStart.Text = "Boshlanish vaqti";
            //
            // dtpStart
            //
            this.dtpStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpStart.CustomFormat = "dd.MM.yyyy  HH:mm";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(138, 21);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(3, 3, 24, 3);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(170, 25);
            this.dtpStart.TabIndex = 1;
            //
            // lblEnd
            //
            this.lblEnd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEnd.AutoSize = true;
            this.lblEnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblEnd.Location = new System.Drawing.Point(335, 25);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(88, 17);
            this.lblEnd.TabIndex = 2;
            this.lblEnd.Text = "Tugash vaqti";
            //
            // dtpEnd
            //
            this.dtpEnd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpEnd.CustomFormat = "dd.MM.yyyy  HH:mm";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(429, 21);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(3, 3, 24, 3);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(170, 25);
            this.dtpEnd.TabIndex = 3;
            //
            // btnCheckAvailability
            //
            this.btnCheckAvailability.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCheckAvailability.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnCheckAvailability.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckAvailability.FlatAppearance.BorderSize = 0;
            this.btnCheckAvailability.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckAvailability.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckAvailability.ForeColor = System.Drawing.Color.White;
            this.btnCheckAvailability.Location = new System.Drawing.Point(626, 17);
            this.btnCheckAvailability.Name = "btnCheckAvailability";
            this.btnCheckAvailability.Size = new System.Drawing.Size(240, 38);
            this.btnCheckAvailability.TabIndex = 4;
            this.btnCheckAvailability.Text = "Bo‘sh joylarni tekshirish";
            this.btnCheckAvailability.UseVisualStyleBackColor = false;
            this.btnCheckAvailability.Click += new System.EventHandler(this.btnCheckAvailability_Click);
            //
            // lblIntervalInfo
            //
            this.lblIntervalInfo.AutoSize = true;
            this.tlpFilter.SetColumnSpan(this.lblIntervalInfo, 6);
            this.lblIntervalInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblIntervalInfo.Location = new System.Drawing.Point(23, 64);
            this.lblIntervalInfo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblIntervalInfo.Name = "lblIntervalInfo";
            this.lblIntervalInfo.Size = new System.Drawing.Size(0, 17);
            this.lblIntervalInfo.TabIndex = 5;
            //
            // flpButtons
            //
            this.flpButtons.AutoSize = true;
            this.flpButtons.Controls.Add(this.btnBook);
            this.flpButtons.Controls.Add(this.btnMyCars);
            this.flpButtons.Controls.Add(this.btnRefresh);
            this.flpButtons.Controls.Add(this.btnLogout);
            this.flpButtons.Controls.Add(this.btnExit);
            this.flpButtons.Controls.Add(this.lblDatabasePath);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpButtons.Location = new System.Drawing.Point(0, 541);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(17, 6, 17, 14);
            this.flpButtons.Size = new System.Drawing.Size(984, 70);
            this.flpButtons.TabIndex = 3;
            //
            // btnBook
            //
            this.btnBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBook.FlatAppearance.BorderSize = 0;
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.Location = new System.Drawing.Point(20, 9);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(190, 42);
            this.btnBook.TabIndex = 0;
            this.btnBook.Text = "Joy band qilish";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            //
            // btnMyCars
            //
            this.btnMyCars.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnMyCars.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMyCars.FlatAppearance.BorderSize = 0;
            this.btnMyCars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyCars.ForeColor = System.Drawing.Color.White;
            this.btnMyCars.Location = new System.Drawing.Point(216, 9);
            this.btnMyCars.Name = "btnMyCars";
            this.btnMyCars.Size = new System.Drawing.Size(190, 42);
            this.btnMyCars.TabIndex = 1;
            this.btnMyCars.Text = "Mening mashinalarim";
            this.btnMyCars.UseVisualStyleBackColor = false;
            this.btnMyCars.Click += new System.EventHandler(this.btnMyCars_Click);
            //
            // btnRefresh
            //
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnRefresh.Location = new System.Drawing.Point(412, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(140, 42);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Yangilash";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // btnLogout
            //
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(56)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(558, 9);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(160, 42);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Hisobdan chiqish";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            //
            // btnExit
            //
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(724, 9);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(160, 42);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Dasturdan chiqish";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            //
            // lblDatabasePath
            //
            this.lblDatabasePath.AutoSize = true;
            this.lblDatabasePath.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabasePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblDatabasePath.Location = new System.Drawing.Point(736, 22);
            this.lblDatabasePath.Margin = new System.Windows.Forms.Padding(15, 16, 3, 0);
            this.lblDatabasePath.Name = "lblDatabasePath";
            this.lblDatabasePath.Size = new System.Drawing.Size(0, 13);
            this.lblDatabasePath.TabIndex = 4;
            //
            // pnlGrid
            //
            this.pnlGrid.Controls.Add(this.dgvParkingLots);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 184);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(20, 14, 20, 4);
            this.pnlGrid.Size = new System.Drawing.Size(984, 357);
            this.pnlGrid.TabIndex = 2;
            //
            // dgvParkingLots
            //
            this.dgvParkingLots.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colAddress,
            this.colTotalSpaces,
            this.colAvailableSpaces});
            this.dgvParkingLots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvParkingLots.Location = new System.Drawing.Point(20, 14);
            this.dgvParkingLots.Name = "dgvParkingLots";
            this.dgvParkingLots.Size = new System.Drawing.Size(944, 339);
            this.dgvParkingLots.TabIndex = 0;
            this.dgvParkingLots.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParkingLots_CellDoubleClick);
            this.dgvParkingLots.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvParkingLots_CellFormatting);
            //
            // colId
            //
            this.colId.DataPropertyName = "ParkingLotID";
            this.colId.FillWeight = 10F;
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            //
            // colName
            //
            this.colName.DataPropertyName = "ParkingName";
            this.colName.FillWeight = 30F;
            this.colName.HeaderText = "Avtoturargoh";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            //
            // colAddress
            //
            this.colAddress.DataPropertyName = "Address";
            this.colAddress.FillWeight = 30F;
            this.colAddress.HeaderText = "Manzil";
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;
            //
            // colTotalSpaces
            //
            this.colTotalSpaces.DataPropertyName = "TotalSpaces";
            this.colTotalSpaces.FillWeight = 15F;
            this.colTotalSpaces.HeaderText = "Umumiy joylar";
            this.colTotalSpaces.Name = "colTotalSpaces";
            this.colTotalSpaces.ReadOnly = true;
            //
            // colAvailableSpaces
            //
            this.colAvailableSpaces.DataPropertyName = "AvailableSpaces";
            this.colAvailableSpaces.FillWeight = 15F;
            this.colAvailableSpaces.HeaderText = "Bo‘sh joylar";
            this.colAvailableSpaces.Name = "colAvailableSpaces";
            this.colAvailableSpaces.ReadOnly = true;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.flpButtons);
            this.Controls.Add(this.tlpFilter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.MinimumSize = new System.Drawing.Size(940, 560);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Online AutoParking — Foydalanuvchi paneli";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpFilter.ResumeLayout(false);
            this.tlpFilter.PerformLayout();
            this.flpButtons.ResumeLayout(false);
            this.flpButtons.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParkingLots)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TableLayoutPanel tlpFilter;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnCheckAvailability;
        private System.Windows.Forms.Label lblIntervalInfo;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnMyCars;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblDatabasePath;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvParkingLots;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalSpaces;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailableSpaces;
    }
}
