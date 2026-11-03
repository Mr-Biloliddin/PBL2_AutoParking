namespace OnlineAutoParking
{
    partial class CarsForm
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
            this.tlpAdd = new System.Windows.Forms.TableLayoutPanel();
            this.lblPlate = new System.Windows.Forms.Label();
            this.lblCarName = new System.Windows.Forms.Label();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.txtCarName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblPlateHint = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvCars = new System.Windows.Forms.DataGridView();
            this.colPlate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCount = new System.Windows.Forms.Label();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.tlpAdd.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).BeginInit();
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
            this.pnlHeader.Size = new System.Drawing.Size(640, 64);
            this.pnlHeader.TabIndex = 0;
            //
            // lblHeader
            //
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(22, 16);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(210, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Mening mashinalarim";
            //
            // tlpAdd
            //
            this.tlpAdd.AutoSize = true;
            this.tlpAdd.BackColor = System.Drawing.Color.White;
            this.tlpAdd.ColumnCount = 3;
            this.tlpAdd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tlpAdd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAdd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpAdd.Controls.Add(this.lblPlate, 0, 0);
            this.tlpAdd.Controls.Add(this.lblCarName, 1, 0);
            this.tlpAdd.Controls.Add(this.txtPlate, 0, 1);
            this.tlpAdd.Controls.Add(this.txtCarName, 1, 1);
            this.tlpAdd.Controls.Add(this.btnAdd, 2, 1);
            this.tlpAdd.Controls.Add(this.lblPlateHint, 0, 2);
            this.tlpAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpAdd.Location = new System.Drawing.Point(0, 64);
            this.tlpAdd.Name = "tlpAdd";
            this.tlpAdd.Padding = new System.Windows.Forms.Padding(20, 14, 20, 12);
            this.tlpAdd.RowCount = 3;
            this.tlpAdd.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAdd.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAdd.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAdd.Size = new System.Drawing.Size(640, 120);
            this.tlpAdd.TabIndex = 1;
            //
            // lblPlate
            //
            this.lblPlate.AutoSize = true;
            this.lblPlate.Location = new System.Drawing.Point(23, 14);
            this.lblPlate.Name = "lblPlate";
            this.lblPlate.Size = new System.Drawing.Size(119, 17);
            this.lblPlate.TabIndex = 0;
            this.lblPlate.Text = "Avtomobil raqami";
            //
            // lblCarName
            //
            this.lblCarName.AutoSize = true;
            this.lblCarName.Location = new System.Drawing.Point(193, 14);
            this.lblCarName.Name = "lblCarName";
            this.lblCarName.Size = new System.Drawing.Size(180, 17);
            this.lblCarName.TabIndex = 1;
            this.lblCarName.Text = "Nomi / modeli (ixtiyoriy)";
            //
            // txtPlate
            //
            this.txtPlate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlate.Location = new System.Drawing.Point(23, 38);
            this.txtPlate.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);
            this.txtPlate.MaxLength = 20;
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(135, 25);
            this.txtPlate.TabIndex = 0;
            //
            // txtCarName
            //
            this.txtCarName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCarName.Location = new System.Drawing.Point(193, 38);
            this.txtCarName.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);
            this.txtCarName.MaxLength = 50;
            this.txtCarName.Name = "txtCarName";
            this.txtCarName.Size = new System.Drawing.Size(250, 25);
            this.txtCarName.TabIndex = 1;
            //
            // btnAdd
            //
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(473, 35);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(144, 32);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Qo‘shish";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // lblPlateHint
            //
            this.lblPlateHint.AutoSize = true;
            this.tlpAdd.SetColumnSpan(this.lblPlateHint, 3);
            this.lblPlateHint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlateHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblPlateHint.Location = new System.Drawing.Point(23, 70);
            this.lblPlateHint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.lblPlateHint.Name = "lblPlateHint";
            this.lblPlateHint.Size = new System.Drawing.Size(190, 13);
            this.lblPlateHint.TabIndex = 3;
            this.lblPlateHint.Text = "Raqam formati: 01 A123AA yoki 01 123AAA";
            //
            // pnlGrid
            //
            this.pnlGrid.Controls.Add(this.dgvCars);
            this.pnlGrid.Controls.Add(this.lblCount);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 184);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(20, 12, 20, 4);
            this.pnlGrid.Size = new System.Drawing.Size(640, 252);
            this.pnlGrid.TabIndex = 2;
            //
            // dgvCars
            //
            this.dgvCars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPlate,
            this.colName,
            this.colCreated});
            this.dgvCars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCars.Location = new System.Drawing.Point(20, 36);
            this.dgvCars.Name = "dgvCars";
            this.dgvCars.Size = new System.Drawing.Size(600, 212);
            this.dgvCars.TabIndex = 0;
            //
            // colPlate
            //
            this.colPlate.DataPropertyName = "CarPlate";
            this.colPlate.FillWeight = 28F;
            this.colPlate.HeaderText = "Raqam";
            this.colPlate.Name = "colPlate";
            this.colPlate.ReadOnly = true;
            //
            // colName
            //
            this.colName.DataPropertyName = "CarName";
            this.colName.FillWeight = 42F;
            this.colName.HeaderText = "Nomi / modeli";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            //
            // colCreated
            //
            this.colCreated.DataPropertyName = "CreatedAt";
            this.colCreated.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            this.colCreated.FillWeight = 30F;
            this.colCreated.HeaderText = "Qo‘shilgan";
            this.colCreated.Name = "colCreated";
            this.colCreated.ReadOnly = true;
            //
            // lblCount
            //
            this.lblCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblCount.Location = new System.Drawing.Point(20, 12);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(600, 24);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "—";
            //
            // flpButtons
            //
            this.flpButtons.AutoSize = true;
            this.flpButtons.Controls.Add(this.btnClose);
            this.flpButtons.Controls.Add(this.btnDelete);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Location = new System.Drawing.Point(0, 436);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(17, 8, 17, 14);
            this.flpButtons.Size = new System.Drawing.Size(640, 64);
            this.flpButtons.TabIndex = 3;
            //
            // btnClose
            //
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(480, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 38);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Yopish";
            this.btnClose.UseVisualStyleBackColor = false;
            //
            // btnDelete
            //
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(314, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(160, 38);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Mashinani o‘chirish";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // CarsForm
            //
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(640, 500);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.flpButtons);
            this.Controls.Add(this.tlpAdd);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.MinimumSize = new System.Drawing.Size(560, 480);
            this.Name = "CarsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mening mashinalarim";
            this.Load += new System.EventHandler(this.CarsForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpAdd.ResumeLayout(false);
            this.tlpAdd.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).EndInit();
            this.flpButtons.ResumeLayout(false);
            this.flpButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TableLayoutPanel tlpAdd;
        private System.Windows.Forms.Label lblPlate;
        private System.Windows.Forms.Label lblCarName;
        private System.Windows.Forms.TextBox txtPlate;
        private System.Windows.Forms.TextBox txtCarName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblPlateHint;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvCars;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreated;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
    }
}
