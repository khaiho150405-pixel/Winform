namespace WindowsForm_QLTV
{
    partial class FormQLNXB
    {
        private System.ComponentModel.IContainer components = null;

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
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.pnlDataGrid = new System.Windows.Forms.Panel();
            this.dgvNXB = new System.Windows.Forms.DataGridView();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.txtMaNXB = new System.Windows.Forms.TextBox(); // KHAI BÁO TXT MỚI
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtTenNXB = new System.Windows.Forms.TextBox();
            this.lblTenNXB = new System.Windows.Forms.Label();
            this.lblMaNXB = new System.Windows.Forms.Label(); // Label Mã NXB
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlBackground.SuspendLayout();
            this.pnlDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNXB)).BeginInit();
            this.pnlControl.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBackground.Controls.Add(this.pnlDataGrid);
            this.pnlBackground.Controls.Add(this.pnlControl);
            this.pnlBackground.Controls.Add(this.pnlInput);
            this.pnlBackground.Controls.Add(this.lblHeader);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(1000, 600);
            this.pnlBackground.TabIndex = 0;
            // 
            // pnlDataGrid
            // 
            this.pnlDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDataGrid.BackColor = System.Drawing.Color.White;
            this.pnlDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDataGrid.Controls.Add(this.dgvNXB);
            this.pnlDataGrid.Location = new System.Drawing.Point(30, 280);
            this.pnlDataGrid.Name = "pnlDataGrid";
            this.pnlDataGrid.Padding = new System.Windows.Forms.Padding(5);
            this.pnlDataGrid.Size = new System.Drawing.Size(940, 300);
            this.pnlDataGrid.TabIndex = 3;
            // 
            // dgvNXB
            // 
            this.dgvNXB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNXB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNXB.Location = new System.Drawing.Point(5, 5);
            this.dgvNXB.Name = "dgvNXB";
            this.dgvNXB.RowHeadersWidth = 51;
            this.dgvNXB.RowTemplate.Height = 24;
            this.dgvNXB.Size = new System.Drawing.Size(928, 288);
            this.dgvNXB.TabIndex = 0;
            this.dgvNXB.ReadOnly = true;
            this.dgvNXB.RowHeadersVisible = false;
            this.dgvNXB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnHuy);
            this.pnlControl.Controls.Add(this.btnLuu);
            this.pnlControl.Controls.Add(this.btnXoa);
            this.pnlControl.Controls.Add(this.btnThem);
            this.pnlControl.Location = new System.Drawing.Point(600, 100);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(370, 160);
            this.pnlControl.TabIndex = 2;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Gray;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(200, 90);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(150, 40);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "HỦY BỎ";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(20, 90);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 40);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "LƯU";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(200, 30);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(150, 40);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "XÓA";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(20, 30);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(150, 40);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "THÊM";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.White;
            this.pnlInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInput.Controls.Add(this.txtMaNXB); // THÊM TXT MỚI
            this.pnlInput.Controls.Add(this.txtSDT);
            this.pnlInput.Controls.Add(this.lblSDT);
            this.pnlInput.Controls.Add(this.txtDiaChi);
            this.pnlInput.Controls.Add(this.lblDiaChi);
            this.pnlInput.Controls.Add(this.txtTenNXB);
            this.pnlInput.Controls.Add(this.lblTenNXB);
            this.pnlInput.Controls.Add(this.lblMaNXB);
            this.pnlInput.Location = new System.Drawing.Point(30, 90);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Padding = new System.Windows.Forms.Padding(10);
            this.pnlInput.Size = new System.Drawing.Size(550, 170);
            this.pnlInput.TabIndex = 1;
            // 
            // txtMaNXB (Mã NXB - KHÔNG SỬA)
            // 
            this.txtMaNXB.Enabled = false;
            this.txtMaNXB.Location = new System.Drawing.Point(120, 25);
            this.txtMaNXB.Name = "txtMaNXB";
            this.txtMaNXB.Size = new System.Drawing.Size(140, 22);
            this.txtMaNXB.TabIndex = 0;
            // 
            // lblMaNXB (Label Mã NXB - Đã điều chỉnh)
            // 
            this.lblMaNXB.AutoSize = true;
            this.lblMaNXB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNXB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblMaNXB.Location = new System.Drawing.Point(20, 28);
            this.lblMaNXB.Name = "lblMaNXB";
            this.lblMaNXB.Size = new System.Drawing.Size(73, 20);
            this.lblMaNXB.TabIndex = 9;
            this.lblMaNXB.Text = "Mã NXB:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(170, 95);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(350, 57);
            this.txtDiaChi.TabIndex = 7;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblDiaChi.Location = new System.Drawing.Point(20, 98);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(62, 20);
            this.lblDiaChi.TabIndex = 6;
            this.lblDiaChi.Text = "Địa Chỉ:";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(380, 60);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(140, 22);
            this.txtSDT.TabIndex = 5;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblSDT.Location = new System.Drawing.Point(280, 63);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(41, 20);
            this.lblSDT.TabIndex = 4;
            this.lblSDT.Text = "SĐT:";
            // 
            // txtTenNXB
            // 
            this.txtTenNXB.Location = new System.Drawing.Point(120, 60);
            this.txtTenNXB.Name = "txtTenNXB";
            this.txtTenNXB.Size = new System.Drawing.Size(140, 22);
            this.txtTenNXB.TabIndex = 3;
            // 
            // lblTenNXB
            // 
            this.lblTenNXB.AutoSize = true;
            this.lblTenNXB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNXB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTenNXB.Location = new System.Drawing.Point(20, 63);
            this.lblTenNXB.Name = "lblTenNXB";
            this.lblTenNXB.Size = new System.Drawing.Size(74, 20);
            this.lblTenNXB.TabIndex = 2;
            this.lblTenNXB.Text = "Tên NXB:";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblHeader.Location = new System.Drawing.Point(30, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblHeader.Size = new System.Drawing.Size(359, 43);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "QUẢN LÝ NHÀ XUẤT BẢN";
            // 
            // FormQLNXB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQLNXB";
            this.Text = "FormQLNXB";
            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            this.pnlDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNXB)).EndInit();
            this.pnlControl.ResumeLayout(false);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.TextBox txtTenNXB;
        private System.Windows.Forms.Label lblTenNXB;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Panel pnlDataGrid;
        private System.Windows.Forms.DataGridView dgvNXB;
        private System.Windows.Forms.Label lblMaNXB;
        private System.Windows.Forms.TextBox txtMaNXB;
    }
}