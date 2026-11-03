namespace OnlineAutoParking
{
    partial class BookingForm
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
            this.tlpFields = new System.Windows.Forms.TableLayoutPanel();
            this.lblParkingCaption = new System.Windows.Forms.Label();
            this.lblParkingName = new System.Windows.Forms.Label();
            this.lblParkingAddress = new System.Windows.Forms.Label();
            this.lblDriverName = new System.Windows.Forms.Label();
            this.txtDriverName = new System.Windows.Forms.TextBox();
            this.lblCarPlate = new System.Windows.Forms.Label();
            this.cmbCar = new System.Windows.Forms.ComboBox();
            this.lblPlateHint = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblAvailableCaption = new System.Windows.Forms.Label();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.tlpFields.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(56)))));
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(534, 64);
            this.pnlHeader.TabIndex = 0;
            //
            // lblHeader
            //
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(22, 16);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(165, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Joy band qilish";
            //
            // tlpFields
            //
            this.tlpFields.ColumnCount = 2;
            this.tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFields.Controls.Add(this.lblParkingCaption, 0, 0);
            this.tlpFields.Controls.Add(this.lblParkingName, 1, 0);
            this.tlpFields.Controls.Add(this.lblParkingAddress, 1, 1);
            this.tlpFields.Controls.Add(this.lblDriverName, 0, 2);
            this.tlpFields.Controls.Add(this.txtDriverName, 1, 2);
            this.tlpFields.Controls.Add(this.lblCarPlate, 0, 3);
            this.tlpFields.Controls.Add(this.cmbCar, 1, 3);
            this.tlpFields.Controls.Add(this.lblPlateHint, 1, 4);
            this.tlpFields.Controls.Add(this.lblStart, 0, 5);
            this.tlpFields.Controls.Add(this.dtpStart, 1, 5);
            this.tlpFields.Controls.Add(this.lblEnd, 0, 6);
            this.tlpFields.Controls.Add(this.dtpEnd, 1, 6);
            this.tlpFields.Controls.Add(this.lblAvailableCaption, 0, 7);
            this.tlpFields.Controls.Add(this.lblAvailable, 1, 7);
            this.tlpFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFields.Location = new System.Drawing.Point(0, 64);
            this.tlpFields.Name = "tlpFields";
            this.tlpFields.Padding = new System.Windows.Forms.Padding(24, 20, 24, 8);
            this.tlpFields.RowCount = 9;
            this.tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFields.Size = new System.Drawing.Size(534, 381);
            this.tlpFields.TabIndex = 1;
            //
            // lblParkingCaption
            //
            this.lblParkingCaption.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblParkingCaption.AutoSize = true;
            this.lblParkingCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblParkingCaption.Location = new System.Drawing.Point(27, 25);
            this.lblParkingCaption.Name = "lblParkingCaption";
            this.lblParkingCaption.Size = new System.Drawing.Size(154, 17);
            this.lblParkingCaption.TabIndex = 0;
            this.lblParkingCaption.Text = "Tanlangan avtoturargoh";
            //
            // lblParkingName
            //
            this.lblParkingName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParkingName.AutoSize = true;
            this.lblParkingName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParkingName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblParkingName.Location = new System.Drawing.Point(212, 20);
            this.lblParkingName.Name = "lblParkingName";
            this.lblParkingName.Size = new System.Drawing.Size(295, 21);
            this.lblParkingName.TabIndex = 1;
            this.lblParkingName.Text = "—";
            //
            // lblParkingAddress
            //
            this.lblParkingAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParkingAddress.AutoSize = true;
            this.lblParkingAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblParkingAddress.Location = new System.Drawing.Point(212, 44);
            this.lblParkingAddress.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblParkingAddress.Name = "lblParkingAddress";
            this.lblParkingAddress.Size = new System.Drawing.Size(295, 17);
            this.lblParkingAddress.TabIndex = 2;
            //
            // lblDriverName
            //
            this.lblDriverName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDriverName.AutoSize = true;
            this.lblDriverName.Location = new System.Drawing.Point(27, 80);
            this.lblDriverName.Name = "lblDriverName";
            this.lblDriverName.Size = new System.Drawing.Size(103, 17);
            this.lblDriverName.TabIndex = 3;
            this.lblDriverName.Text = "Haydovchi ismi";
            //
            // txtDriverName
            //
            this.txtDriverName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDriverName.Location = new System.Drawing.Point(212, 76);
            this.txtDriverName.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtDriverName.MaxLength = 100;
            this.txtDriverName.Name = "txtDriverName";
            this.txtDriverName.Size = new System.Drawing.Size(295, 25);
            this.txtDriverName.TabIndex = 0;
            //
            // lblCarPlate
            //
            this.lblCarPlate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCarPlate.AutoSize = true;
            this.lblCarPlate.Location = new System.Drawing.Point(27, 117);
            this.lblCarPlate.Name = "lblCarPlate";
            this.lblCarPlate.Size = new System.Drawing.Size(119, 17);
            this.lblCarPlate.TabIndex = 4;
            this.lblCarPlate.Text = "Mashina";
            //
            // cmbCar
            //
            this.cmbCar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCar.DisplayMember = "DisplayText";
            this.cmbCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCar.FormattingEnabled = true;
            this.cmbCar.Location = new System.Drawing.Point(212, 113);
            this.cmbCar.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.cmbCar.Name = "cmbCar";
            this.cmbCar.Size = new System.Drawing.Size(295, 25);
            this.cmbCar.TabIndex = 1;
            //
            // lblPlateHint
            //
            this.lblPlateHint.AutoSize = true;
            this.lblPlateHint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlateHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblPlateHint.Location = new System.Drawing.Point(212, 140);
            this.lblPlateHint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 6);
            this.lblPlateHint.Name = "lblPlateHint";
            this.lblPlateHint.Size = new System.Drawing.Size(190, 13);
            this.lblPlateHint.TabIndex = 5;
            this.lblPlateHint.Text = "";
            //
            // lblStart
            //
            this.lblStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(27, 168);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(109, 17);
            this.lblStart.TabIndex = 6;
            this.lblStart.Text = "Boshlanish vaqti";
            //
            // dtpStart
            //
            this.dtpStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpStart.CustomFormat = "dd.MM.yyyy  HH:mm";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(212, 164);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(190, 25);
            this.dtpStart.TabIndex = 2;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpInterval_ValueChanged);
            //
            // lblEnd
            //
            this.lblEnd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(27, 205);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(88, 17);
            this.lblEnd.TabIndex = 7;
            this.lblEnd.Text = "Tugash vaqti";
            //
            // dtpEnd
            //
            this.dtpEnd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpEnd.CustomFormat = "dd.MM.yyyy  HH:mm";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(212, 201);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(190, 25);
            this.dtpEnd.TabIndex = 3;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpInterval_ValueChanged);
            //
            // lblAvailableCaption
            //
            this.lblAvailableCaption.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAvailableCaption.AutoSize = true;
            this.lblAvailableCaption.Location = new System.Drawing.Point(27, 245);
            this.lblAvailableCaption.Name = "lblAvailableCaption";
            this.lblAvailableCaption.Size = new System.Drawing.Size(81, 17);
            this.lblAvailableCaption.TabIndex = 8;
            this.lblAvailableCaption.Text = "Bo‘sh joylar";
            //
            // lblAvailable
            //
            this.lblAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailable.Location = new System.Drawing.Point(212, 242);
            this.lblAvailable.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(295, 20);
            this.lblAvailable.TabIndex = 9;
            this.lblAvailable.Text = "—";
            //
            // flpButtons
            //
            this.flpButtons.AutoSize = true;
            this.flpButtons.Controls.Add(this.btnConfirm);
            this.flpButtons.Controls.Add(this.btnCancel);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Location = new System.Drawing.Point(0, 445);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(21, 8, 21, 16);
            this.flpButtons.Size = new System.Drawing.Size(534, 66);
            this.flpButtons.TabIndex = 2;
            //
            // btnConfirm
            //
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(323, 11);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(187, 42);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Bronni tasdiqlash";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            //
            // btnCancel
            //
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(187, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 42);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Orqaga";
            this.btnCancel.UseVisualStyleBackColor = false;
            //
            // BookingForm
            //
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(534, 511);
            this.Controls.Add(this.tlpFields);
            this.Controls.Add(this.flpButtons);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BookingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Joy band qilish";
            this.Load += new System.EventHandler(this.BookingForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpFields.ResumeLayout(false);
            this.tlpFields.PerformLayout();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TableLayoutPanel tlpFields;
        private System.Windows.Forms.Label lblParkingCaption;
        private System.Windows.Forms.Label lblParkingName;
        private System.Windows.Forms.Label lblParkingAddress;
        private System.Windows.Forms.Label lblDriverName;
        private System.Windows.Forms.TextBox txtDriverName;
        private System.Windows.Forms.Label lblCarPlate;
        private System.Windows.Forms.ComboBox cmbCar;
        private System.Windows.Forms.Label lblPlateHint;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblAvailableCaption;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}
