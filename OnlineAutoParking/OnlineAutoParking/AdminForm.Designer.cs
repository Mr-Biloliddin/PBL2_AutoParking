namespace OnlineAutoParking
{
    partial class AdminForm
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabParking = new System.Windows.Forms.TabPage();
            this.tlpParking = new System.Windows.Forms.TableLayoutPanel();
            this.dgvParkingLots = new System.Windows.Forms.DataGridView();
            this.colParkingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParkingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParkingAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParkingTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParkingStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpParkingEditor = new System.Windows.Forms.TableLayoutPanel();
            this.lblEditorTitle = new System.Windows.Forms.Label();
            this.lblParkingName = new System.Windows.Forms.Label();
            this.txtParkingName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblTotalSpaces = new System.Windows.Forms.Label();
            this.numTotalSpaces = new System.Windows.Forms.NumericUpDown();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.btnRefreshParking = new System.Windows.Forms.Button();
            this.lblSelectedParking = new System.Windows.Forms.Label();
            this.tabBookings = new System.Windows.Forms.TabPage();
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.colBookingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBookingParking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBookingDriver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBookingPlate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBookingUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBookingStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBookingEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBookingStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpBookingButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.btnRefreshBookings = new System.Windows.Forms.Button();
            this.lblBookingCount = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.colUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserCreatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpUserButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefreshUsers = new System.Windows.Forms.Button();
            this.lblUserCount = new System.Windows.Forms.Label();
            this.tabMain.SuspendLayout();
            this.tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.flpUserButtons.SuspendLayout();
            this.tabParking.SuspendLayout();
            this.tlpParking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParkingLots)).BeginInit();
            this.tlpParkingEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalSpaces)).BeginInit();
            this.tabBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.flpBookingButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(56)))));
            this.pnlHeader.Controls.Add(this.btnLogout);
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1084, 64);
            this.pnlHeader.TabIndex = 0;
            //
            // lblHeader
            //
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(22, 16);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(216, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Administrator paneli";
            //
            // btnLogout
            //
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(942, 13);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 38);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Chiqish";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            //
            // tabMain
            //
            this.tabMain.Controls.Add(this.tabParking);
            this.tabMain.Controls.Add(this.tabBookings);
            this.tabMain.Controls.Add(this.tabUsers);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 64);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Drawing.Point(16, 6);
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1084, 597);
            this.tabMain.TabIndex = 1;
            //
            // tabParking
            //
            this.tabParking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.tabParking.Controls.Add(this.tlpParking);
            this.tabParking.Location = new System.Drawing.Point(4, 32);
            this.tabParking.Name = "tabParking";
            this.tabParking.Size = new System.Drawing.Size(1076, 561);
            this.tabParking.TabIndex = 0;
            this.tabParking.Text = "Avtoturargohlar";
            //
            // tlpParking
            //
            this.tlpParking.ColumnCount = 2;
            this.tlpParking.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpParking.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.tlpParking.Controls.Add(this.dgvParkingLots, 0, 0);
            this.tlpParking.Controls.Add(this.tlpParkingEditor, 1, 0);
            this.tlpParking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpParking.Location = new System.Drawing.Point(0, 0);
            this.tlpParking.Name = "tlpParking";
            this.tlpParking.Padding = new System.Windows.Forms.Padding(12);
            this.tlpParking.RowCount = 1;
            this.tlpParking.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpParking.Size = new System.Drawing.Size(1076, 561);
            this.tlpParking.TabIndex = 0;
            //
            // dgvParkingLots
            //
            this.dgvParkingLots.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colParkingId,
            this.colParkingName,
            this.colParkingAddress,
            this.colParkingTotal,
            this.colParkingStatus});
            this.dgvParkingLots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvParkingLots.Location = new System.Drawing.Point(15, 15);
            this.dgvParkingLots.Name = "dgvParkingLots";
            this.dgvParkingLots.Size = new System.Drawing.Size(706, 531);
            this.dgvParkingLots.TabIndex = 0;
            this.dgvParkingLots.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvParkingLots_CellFormatting);
            this.dgvParkingLots.SelectionChanged += new System.EventHandler(this.dgvParkingLots_SelectionChanged);
            //
            // colParkingId
            //
            this.colParkingId.DataPropertyName = "ParkingLotID";
            this.colParkingId.FillWeight = 10F;
            this.colParkingId.HeaderText = "ID";
            this.colParkingId.Name = "colParkingId";
            this.colParkingId.ReadOnly = true;
            //
            // colParkingName
            //
            this.colParkingName.DataPropertyName = "ParkingName";
            this.colParkingName.FillWeight = 30F;
            this.colParkingName.HeaderText = "Avtoturargoh";
            this.colParkingName.Name = "colParkingName";
            this.colParkingName.ReadOnly = true;
            //
            // colParkingAddress
            //
            this.colParkingAddress.DataPropertyName = "Address";
            this.colParkingAddress.FillWeight = 30F;
            this.colParkingAddress.HeaderText = "Manzil";
            this.colParkingAddress.Name = "colParkingAddress";
            this.colParkingAddress.ReadOnly = true;
            //
            // colParkingTotal
            //
            this.colParkingTotal.DataPropertyName = "TotalSpaces";
            this.colParkingTotal.FillWeight = 15F;
            this.colParkingTotal.HeaderText = "Umumiy joylar";
            this.colParkingTotal.Name = "colParkingTotal";
            this.colParkingTotal.ReadOnly = true;
            //
            // colParkingStatus
            //
            this.colParkingStatus.DataPropertyName = "StatusText";
            this.colParkingStatus.FillWeight = 15F;
            this.colParkingStatus.HeaderText = "Holat";
            this.colParkingStatus.Name = "colParkingStatus";
            this.colParkingStatus.ReadOnly = true;
            //
            // tlpParkingEditor
            //
            this.tlpParkingEditor.BackColor = System.Drawing.Color.White;
            this.tlpParkingEditor.ColumnCount = 1;
            this.tlpParkingEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpParkingEditor.Controls.Add(this.lblEditorTitle, 0, 0);
            this.tlpParkingEditor.Controls.Add(this.lblParkingName, 0, 1);
            this.tlpParkingEditor.Controls.Add(this.txtParkingName, 0, 2);
            this.tlpParkingEditor.Controls.Add(this.lblAddress, 0, 3);
            this.tlpParkingEditor.Controls.Add(this.txtAddress, 0, 4);
            this.tlpParkingEditor.Controls.Add(this.lblTotalSpaces, 0, 5);
            this.tlpParkingEditor.Controls.Add(this.numTotalSpaces, 0, 6);
            this.tlpParkingEditor.Controls.Add(this.chkIsActive, 0, 7);
            this.tlpParkingEditor.Controls.Add(this.btnAdd, 0, 8);
            this.tlpParkingEditor.Controls.Add(this.btnUpdate, 0, 9);
            this.tlpParkingEditor.Controls.Add(this.btnDeactivate, 0, 10);
            this.tlpParkingEditor.Controls.Add(this.btnRefreshParking, 0, 11);
            this.tlpParkingEditor.Controls.Add(this.lblSelectedParking, 0, 12);
            this.tlpParkingEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpParkingEditor.Location = new System.Drawing.Point(736, 15);
            this.tlpParkingEditor.Margin = new System.Windows.Forms.Padding(12, 3, 3, 3);
            this.tlpParkingEditor.Name = "tlpParkingEditor";
            this.tlpParkingEditor.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.tlpParkingEditor.RowCount = 14;
            this.tlpParkingEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpParkingEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpParkingEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpParkingEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpParkingEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpParkingEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpParkingEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpParkingEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpParkingEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpParkingEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpParkingEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpParkingEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpParkingEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpParkingEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpParkingEditor.Size = new System.Drawing.Size(322, 531);
            this.tlpParkingEditor.TabIndex = 1;
            //
            // lblEditorTitle
            //
            this.lblEditorTitle.AutoSize = true;
            this.lblEditorTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditorTitle.Location = new System.Drawing.Point(19, 12);
            this.lblEditorTitle.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lblEditorTitle.Name = "lblEditorTitle";
            this.lblEditorTitle.Size = new System.Drawing.Size(220, 20);
            this.lblEditorTitle.TabIndex = 0;
            this.lblEditorTitle.Text = "Avtoturargoh ma’lumotlari";
            //
            // lblParkingName
            //
            this.lblParkingName.AutoSize = true;
            this.lblParkingName.Location = new System.Drawing.Point(19, 40);
            this.lblParkingName.Name = "lblParkingName";
            this.lblParkingName.Size = new System.Drawing.Size(131, 17);
            this.lblParkingName.TabIndex = 1;
            this.lblParkingName.Text = "Avtoturargoh nomi";
            //
            // txtParkingName
            //
            this.txtParkingName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtParkingName.Location = new System.Drawing.Point(19, 60);
            this.txtParkingName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.txtParkingName.MaxLength = 100;
            this.txtParkingName.Name = "txtParkingName";
            this.txtParkingName.Size = new System.Drawing.Size(284, 25);
            this.txtParkingName.TabIndex = 2;
            //
            // lblAddress
            //
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(19, 93);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(51, 17);
            this.lblAddress.TabIndex = 3;
            this.lblAddress.Text = "Manzil";
            //
            // txtAddress
            //
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddress.Location = new System.Drawing.Point(19, 113);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(284, 25);
            this.txtAddress.TabIndex = 4;
            //
            // lblTotalSpaces
            //
            this.lblTotalSpaces.AutoSize = true;
            this.lblTotalSpaces.Location = new System.Drawing.Point(19, 146);
            this.lblTotalSpaces.Name = "lblTotalSpaces";
            this.lblTotalSpaces.Size = new System.Drawing.Size(140, 17);
            this.lblTotalSpaces.TabIndex = 5;
            this.lblTotalSpaces.Text = "Umumiy joylar soni";
            //
            // numTotalSpaces
            //
            this.numTotalSpaces.Location = new System.Drawing.Point(19, 166);
            this.numTotalSpaces.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.numTotalSpaces.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTotalSpaces.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTotalSpaces.Name = "numTotalSpaces";
            this.numTotalSpaces.Size = new System.Drawing.Size(120, 25);
            this.numTotalSpaces.TabIndex = 6;
            this.numTotalSpaces.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            //
            // chkIsActive
            //
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(19, 202);
            this.chkIsActive.Margin = new System.Windows.Forms.Padding(3, 3, 3, 14);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(55, 21);
            this.chkIsActive.TabIndex = 7;
            this.chkIsActive.Text = "Faol";
            this.chkIsActive.UseVisualStyleBackColor = true;
            //
            // btnAdd
            //
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(19, 240);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(284, 38);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Qo‘shish";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnUpdate
            //
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(19, 284);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(284, 38);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Tahrirlash";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            //
            // btnDeactivate
            //
            this.btnDeactivate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnDeactivate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeactivate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeactivate.FlatAppearance.BorderSize = 0;
            this.btnDeactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeactivate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeactivate.ForeColor = System.Drawing.Color.White;
            this.btnDeactivate.Location = new System.Drawing.Point(19, 328);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(284, 38);
            this.btnDeactivate.TabIndex = 10;
            this.btnDeactivate.Text = "Faolsizlantirish";
            this.btnDeactivate.UseVisualStyleBackColor = false;
            this.btnDeactivate.Click += new System.EventHandler(this.btnDeactivate_Click);
            //
            // btnRefreshParking
            //
            this.btnRefreshParking.BackColor = System.Drawing.Color.White;
            this.btnRefreshParking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshParking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefreshParking.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnRefreshParking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshParking.Location = new System.Drawing.Point(19, 372);
            this.btnRefreshParking.Name = "btnRefreshParking";
            this.btnRefreshParking.Size = new System.Drawing.Size(284, 38);
            this.btnRefreshParking.TabIndex = 11;
            this.btnRefreshParking.Text = "Yangilash";
            this.btnRefreshParking.UseVisualStyleBackColor = false;
            this.btnRefreshParking.Click += new System.EventHandler(this.btnRefreshParking_Click);
            //
            // lblSelectedParking
            //
            this.lblSelectedParking.AutoSize = true;
            this.lblSelectedParking.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSelectedParking.Location = new System.Drawing.Point(19, 421);
            this.lblSelectedParking.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblSelectedParking.MaximumSize = new System.Drawing.Size(284, 0);
            this.lblSelectedParking.Name = "lblSelectedParking";
            this.lblSelectedParking.Size = new System.Drawing.Size(270, 34);
            this.lblSelectedParking.TabIndex = 12;
            this.lblSelectedParking.Text = "Tahrirlash uchun jadvaldan avtoturargohni tanlang.";
            //
            // tabBookings
            //
            this.tabBookings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.tabBookings.Controls.Add(this.dgvBookings);
            this.tabBookings.Controls.Add(this.flpBookingButtons);
            this.tabBookings.Location = new System.Drawing.Point(4, 32);
            this.tabBookings.Name = "tabBookings";
            this.tabBookings.Padding = new System.Windows.Forms.Padding(15, 15, 15, 0);
            this.tabBookings.Size = new System.Drawing.Size(1076, 561);
            this.tabBookings.TabIndex = 1;
            this.tabBookings.Text = "Bronlar";
            //
            // dgvBookings
            //
            this.dgvBookings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBookingId,
            this.colBookingParking,
            this.colBookingDriver,
            this.colBookingPlate,
            this.colBookingUser,
            this.colBookingStart,
            this.colBookingEnd,
            this.colBookingStatus});
            this.dgvBookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBookings.Location = new System.Drawing.Point(15, 15);
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.Size = new System.Drawing.Size(1046, 478);
            this.dgvBookings.TabIndex = 0;
            this.dgvBookings.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBookings_CellFormatting);
            //
            // colBookingId
            //
            this.colBookingId.DataPropertyName = "BookingID";
            this.colBookingId.FillWeight = 9F;
            this.colBookingId.HeaderText = "Bron ID";
            this.colBookingId.Name = "colBookingId";
            this.colBookingId.ReadOnly = true;
            //
            // colBookingParking
            //
            this.colBookingParking.DataPropertyName = "ParkingName";
            this.colBookingParking.FillWeight = 18F;
            this.colBookingParking.HeaderText = "Avtoturargoh";
            this.colBookingParking.Name = "colBookingParking";
            this.colBookingParking.ReadOnly = true;
            //
            // colBookingDriver
            //
            this.colBookingDriver.DataPropertyName = "DriverName";
            this.colBookingDriver.FillWeight = 18F;
            this.colBookingDriver.HeaderText = "Haydovchi";
            this.colBookingDriver.Name = "colBookingDriver";
            this.colBookingDriver.ReadOnly = true;
            //
            // colBookingPlate
            //
            this.colBookingPlate.DataPropertyName = "CarPlate";
            this.colBookingPlate.FillWeight = 14F;
            this.colBookingPlate.HeaderText = "Avtomobil raqami";
            this.colBookingPlate.Name = "colBookingPlate";
            this.colBookingPlate.ReadOnly = true;
            //
            // colBookingUser
            //
            this.colBookingUser.DataPropertyName = "Username";
            this.colBookingUser.FillWeight = 12F;
            this.colBookingUser.HeaderText = "Foydalanuvchi";
            this.colBookingUser.Name = "colBookingUser";
            this.colBookingUser.ReadOnly = true;
            //
            // colBookingStart
            //
            this.colBookingStart.DataPropertyName = "StartTime";
            this.colBookingStart.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            this.colBookingStart.FillWeight = 15F;
            this.colBookingStart.HeaderText = "Boshlanish";
            this.colBookingStart.Name = "colBookingStart";
            this.colBookingStart.ReadOnly = true;
            //
            // colBookingEnd
            //
            this.colBookingEnd.DataPropertyName = "EndTime";
            this.colBookingEnd.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            this.colBookingEnd.FillWeight = 15F;
            this.colBookingEnd.HeaderText = "Tugash";
            this.colBookingEnd.Name = "colBookingEnd";
            this.colBookingEnd.ReadOnly = true;
            //
            // colBookingStatus
            //
            this.colBookingStatus.DataPropertyName = "StatusText";
            this.colBookingStatus.FillWeight = 13F;
            this.colBookingStatus.HeaderText = "Holat";
            this.colBookingStatus.Name = "colBookingStatus";
            this.colBookingStatus.ReadOnly = true;
            //
            // flpBookingButtons
            //
            this.flpBookingButtons.AutoSize = true;
            this.flpBookingButtons.Controls.Add(this.btnCancelBooking);
            this.flpBookingButtons.Controls.Add(this.btnRefreshBookings);
            this.flpBookingButtons.Controls.Add(this.lblBookingCount);
            this.flpBookingButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpBookingButtons.Location = new System.Drawing.Point(15, 493);
            this.flpBookingButtons.Name = "flpBookingButtons";
            this.flpBookingButtons.Padding = new System.Windows.Forms.Padding(0, 10, 0, 12);
            this.flpBookingButtons.Size = new System.Drawing.Size(1046, 68);
            this.flpBookingButtons.TabIndex = 1;
            //
            // btnCancelBooking
            //
            this.btnCancelBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnCancelBooking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelBooking.FlatAppearance.BorderSize = 0;
            this.btnCancelBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelBooking.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelBooking.ForeColor = System.Drawing.Color.White;
            this.btnCancelBooking.Location = new System.Drawing.Point(3, 13);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(210, 40);
            this.btnCancelBooking.TabIndex = 0;
            this.btnCancelBooking.Text = "Bronni bekor qilish";
            this.btnCancelBooking.UseVisualStyleBackColor = false;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);
            //
            // btnRefreshBookings
            //
            this.btnRefreshBookings.BackColor = System.Drawing.Color.White;
            this.btnRefreshBookings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshBookings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnRefreshBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshBookings.Location = new System.Drawing.Point(219, 13);
            this.btnRefreshBookings.Name = "btnRefreshBookings";
            this.btnRefreshBookings.Size = new System.Drawing.Size(140, 40);
            this.btnRefreshBookings.TabIndex = 1;
            this.btnRefreshBookings.Text = "Yangilash";
            this.btnRefreshBookings.UseVisualStyleBackColor = false;
            this.btnRefreshBookings.Click += new System.EventHandler(this.btnRefreshBookings_Click);
            //
            // lblBookingCount
            //
            this.lblBookingCount.AutoSize = true;
            this.lblBookingCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblBookingCount.Location = new System.Drawing.Point(377, 24);
            this.lblBookingCount.Margin = new System.Windows.Forms.Padding(15, 11, 3, 0);
            this.lblBookingCount.Name = "lblBookingCount";
            this.lblBookingCount.Size = new System.Drawing.Size(0, 17);
            this.lblBookingCount.TabIndex = 2;
            //
            // tabUsers
            //
            this.tabUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.tabUsers.Controls.Add(this.dgvUsers);
            this.tabUsers.Controls.Add(this.flpUserButtons);
            this.tabUsers.Location = new System.Drawing.Point(4, 32);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(15, 15, 15, 0);
            this.tabUsers.Size = new System.Drawing.Size(1076, 561);
            this.tabUsers.TabIndex = 2;
            this.tabUsers.Text = "Foydalanuvchilar";
            //
            // dgvUsers
            //
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUserId,
            this.colUserUsername,
            this.colUserFullName,
            this.colUserRole,
            this.colUserCreatedAt});
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(15, 15);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(1046, 478);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvUsers_CellFormatting);
            //
            // colUserId
            //
            this.colUserId.DataPropertyName = "UserID";
            this.colUserId.FillWeight = 8F;
            this.colUserId.HeaderText = "ID";
            this.colUserId.Name = "colUserId";
            this.colUserId.ReadOnly = true;
            //
            // colUserUsername
            //
            this.colUserUsername.DataPropertyName = "Username";
            this.colUserUsername.FillWeight = 22F;
            this.colUserUsername.HeaderText = "Login";
            this.colUserUsername.Name = "colUserUsername";
            this.colUserUsername.ReadOnly = true;
            //
            // colUserFullName
            //
            this.colUserFullName.DataPropertyName = "FullName";
            this.colUserFullName.FillWeight = 30F;
            this.colUserFullName.HeaderText = "Ism va familiya";
            this.colUserFullName.Name = "colUserFullName";
            this.colUserFullName.ReadOnly = true;
            //
            // colUserRole
            //
            this.colUserRole.DataPropertyName = "RoleText";
            this.colUserRole.FillWeight = 18F;
            this.colUserRole.HeaderText = "Rol";
            this.colUserRole.Name = "colUserRole";
            this.colUserRole.ReadOnly = true;
            //
            // colUserCreatedAt
            //
            this.colUserCreatedAt.DataPropertyName = "CreatedAt";
            this.colUserCreatedAt.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            this.colUserCreatedAt.FillWeight = 22F;
            this.colUserCreatedAt.HeaderText = "Ro‘yxatdan o‘tgan";
            this.colUserCreatedAt.Name = "colUserCreatedAt";
            this.colUserCreatedAt.ReadOnly = true;
            //
            // flpUserButtons
            //
            this.flpUserButtons.AutoSize = true;
            this.flpUserButtons.Controls.Add(this.btnRefreshUsers);
            this.flpUserButtons.Controls.Add(this.lblUserCount);
            this.flpUserButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpUserButtons.Location = new System.Drawing.Point(15, 493);
            this.flpUserButtons.Name = "flpUserButtons";
            this.flpUserButtons.Padding = new System.Windows.Forms.Padding(0, 10, 0, 12);
            this.flpUserButtons.Size = new System.Drawing.Size(1046, 68);
            this.flpUserButtons.TabIndex = 1;
            //
            // btnRefreshUsers
            //
            this.btnRefreshUsers.BackColor = System.Drawing.Color.White;
            this.btnRefreshUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshUsers.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnRefreshUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshUsers.Location = new System.Drawing.Point(3, 13);
            this.btnRefreshUsers.Name = "btnRefreshUsers";
            this.btnRefreshUsers.Size = new System.Drawing.Size(140, 40);
            this.btnRefreshUsers.TabIndex = 0;
            this.btnRefreshUsers.Text = "Yangilash";
            this.btnRefreshUsers.UseVisualStyleBackColor = false;
            this.btnRefreshUsers.Click += new System.EventHandler(this.btnRefreshUsers_Click);
            //
            // lblUserCount
            //
            this.lblUserCount.AutoSize = true;
            this.lblUserCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblUserCount.Location = new System.Drawing.Point(161, 24);
            this.lblUserCount.Margin = new System.Windows.Forms.Padding(15, 11, 3, 0);
            this.lblUserCount.Name = "lblUserCount";
            this.lblUserCount.Size = new System.Drawing.Size(0, 17);
            this.lblUserCount.TabIndex = 1;
            //
            // AdminForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.MinimumSize = new System.Drawing.Size(980, 640);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrator paneli";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabParking.ResumeLayout(false);
            this.tlpParking.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParkingLots)).EndInit();
            this.tlpParkingEditor.ResumeLayout(false);
            this.tlpParkingEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalSpaces)).EndInit();
            this.tabBookings.ResumeLayout(false);
            this.tabBookings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.flpBookingButtons.ResumeLayout(false);
            this.flpBookingButtons.PerformLayout();
            this.tabUsers.ResumeLayout(false);
            this.tabUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.flpUserButtons.ResumeLayout(false);
            this.flpUserButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabParking;
        private System.Windows.Forms.TableLayoutPanel tlpParking;
        private System.Windows.Forms.DataGridView dgvParkingLots;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParkingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParkingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParkingAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParkingTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParkingStatus;
        private System.Windows.Forms.TableLayoutPanel tlpParkingEditor;
        private System.Windows.Forms.Label lblEditorTitle;
        private System.Windows.Forms.Label lblParkingName;
        private System.Windows.Forms.TextBox txtParkingName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblTotalSpaces;
        private System.Windows.Forms.NumericUpDown numTotalSpaces;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDeactivate;
        private System.Windows.Forms.Button btnRefreshParking;
        private System.Windows.Forms.Label lblSelectedParking;
        private System.Windows.Forms.TabPage tabBookings;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookingParking;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookingDriver;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookingPlate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookingUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookingStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookingEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookingStatus;
        private System.Windows.Forms.FlowLayoutPanel flpBookingButtons;
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.Button btnRefreshBookings;
        private System.Windows.Forms.Label lblBookingCount;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserCreatedAt;
        private System.Windows.Forms.FlowLayoutPanel flpUserButtons;
        private System.Windows.Forms.Button btnRefreshUsers;
        private System.Windows.Forms.Label lblUserCount;
    }
}
