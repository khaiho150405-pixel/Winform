namespace WindowsForm_QLTV
{
    partial class FormQLTatCaSach
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
            this.pnlGridContainer = new System.Windows.Forms.Panel();
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.pnlRightControls = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.pnlCount = new System.Windows.Forms.Panel();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.pnlNXB = new System.Windows.Forms.Panel();
            this.lblNXB = new System.Windows.Forms.Label();
            this.pnlTheLoai = new System.Windows.Forms.Panel();
            this.lblTheLoai = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lblSoLuongInput = new System.Windows.Forms.Label();
            this.cboMaNXB = new System.Windows.Forms.ComboBox();
            this.lblMaNXB = new System.Windows.Forms.Label();
            this.txtNamXuatBan = new System.Windows.Forms.TextBox();
            this.lblNamXuatBan = new System.Windows.Forms.Label();
            this.cboMaTheLoai = new System.Windows.Forms.ComboBox();
            this.lblMaTheLoai = new System.Windows.Forms.Label();
            this.cboMaTacGia = new System.Windows.Forms.ComboBox();
            this.lblMaTacGia = new System.Windows.Forms.Label();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.lblTenSach = new System.Windows.Forms.Label();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.lblMaSach = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlBackground.SuspendLayout();
            this.pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            this.pnlRightControls.SuspendLayout();
            this.pnlCount.SuspendLayout();
            this.pnlNXB.SuspendLayout();
            this.pnlTheLoai.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBackground.Controls.Add(this.pnlGridContainer);
            this.pnlBackground.Controls.Add(this.pnlRightControls);
            this.pnlBackground.Controls.Add(this.pnlInput);
            this.pnlBackground.Controls.Add(this.pnlImage);
            this.pnlBackground.Controls.Add(this.btnChooseFile);
            this.pnlBackground.Controls.Add(this.lblHeader);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(1200, 750);
            this.pnlBackground.TabIndex = 0;
            // 
            // pnlGridContainer
            // 
            this.pnlGridContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGridContainer.Controls.Add(this.dgvSach);
            this.pnlGridContainer.Location = new System.Drawing.Point(20, 310);
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.pnlGridContainer.Size = new System.Drawing.Size(950, 420);
            this.pnlGridContainer.TabIndex = 6;
            // 
            // dgvSach
            // 
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSach.Location = new System.Drawing.Point(0, 0);
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.RowHeadersWidth = 51;
            this.dgvSach.RowTemplate.Height = 24;
            this.dgvSach.Size = new System.Drawing.Size(950, 420);
            this.dgvSach.TabIndex = 0;
            // 
            // pnlRightControls
            // 
            this.pnlRightControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRightControls.Controls.Add(this.btnXoa);
            this.pnlRightControls.Controls.Add(this.btnCapNhat);
            this.pnlRightControls.Controls.Add(this.btnThem);
            this.pnlRightControls.Controls.Add(this.pnlCount);
            this.pnlRightControls.Controls.Add(this.pnlNXB);
            this.pnlRightControls.Controls.Add(this.pnlTheLoai);
            this.pnlRightControls.Location = new System.Drawing.Point(980, 50);
            this.pnlRightControls.Name = "pnlRightControls";
            this.pnlRightControls.Size = new System.Drawing.Size(200, 680);
            this.pnlRightControls.TabIndex = 5;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(25, 430);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(150, 45);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Thanh Lý";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.btnCapNhat.FlatAppearance.BorderSize = 0;
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCapNhat.ForeColor = System.Drawing.Color.White;
            this.btnCapNhat.Location = new System.Drawing.Point(25, 365);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(150, 45);
            this.btnCapNhat.TabIndex = 4;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(25, 300);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(150, 45);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Nhập Sách";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // pnlCount
            // 
            this.pnlCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.pnlCount.Controls.Add(this.lblSoLuong);
            this.pnlCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCount.Location = new System.Drawing.Point(0, 180);
            this.pnlCount.Name = "pnlCount";
            this.pnlCount.Size = new System.Drawing.Size(200, 90);
            this.pnlCount.TabIndex = 2;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSoLuong.ForeColor = System.Drawing.Color.White;
            this.lblSoLuong.Location = new System.Drawing.Point(10, 10);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(98, 23);
            this.lblSoLuong.TabIndex = 0;
            this.lblSoLuong.Text = "SỐ LƯỢNG";
            // 
            // pnlNXB
            // 
            this.pnlNXB.BackColor = System.Drawing.Color.LightPink;
            this.pnlNXB.Controls.Add(this.lblNXB);
            this.pnlNXB.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNXB.Location = new System.Drawing.Point(0, 90);
            this.pnlNXB.Name = "pnlNXB";
            this.pnlNXB.Size = new System.Drawing.Size(200, 90);
            this.pnlNXB.TabIndex = 1;
            // 
            // lblNXB
            // 
            this.lblNXB.AutoSize = true;
            this.lblNXB.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNXB.ForeColor = System.Drawing.Color.White;
            this.lblNXB.Location = new System.Drawing.Point(10, 10);
            this.lblNXB.Name = "lblNXB";
            this.lblNXB.Size = new System.Drawing.Size(45, 23);
            this.lblNXB.TabIndex = 0;
            this.lblNXB.Text = "NXB";
            // 
            // pnlTheLoai
            // 
            this.pnlTheLoai.BackColor = System.Drawing.Color.Teal;
            this.pnlTheLoai.Controls.Add(this.lblTheLoai);
            this.pnlTheLoai.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTheLoai.Location = new System.Drawing.Point(0, 0);
            this.pnlTheLoai.Name = "pnlTheLoai";
            this.pnlTheLoai.Size = new System.Drawing.Size(200, 90);
            this.pnlTheLoai.TabIndex = 0;
            // 
            // lblTheLoai
            // 
            this.lblTheLoai.AutoSize = true;
            this.lblTheLoai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTheLoai.ForeColor = System.Drawing.Color.White;
            this.lblTheLoai.Location = new System.Drawing.Point(10, 10);
            this.lblTheLoai.Name = "lblTheLoai";
            this.lblTheLoai.Size = new System.Drawing.Size(86, 23);
            this.lblTheLoai.TabIndex = 0;
            this.lblTheLoai.Text = "THỂ LOẠI";
            // 
            // pnlInput
            // 
            this.pnlInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInput.Controls.Add(this.txtSoLuong);
            this.pnlInput.Controls.Add(this.lblSoLuongInput);
            this.pnlInput.Controls.Add(this.cboMaNXB);
            this.pnlInput.Controls.Add(this.lblMaNXB);
            this.pnlInput.Controls.Add(this.txtNamXuatBan);
            this.pnlInput.Controls.Add(this.lblNamXuatBan);
            this.pnlInput.Controls.Add(this.cboMaTheLoai);
            this.pnlInput.Controls.Add(this.lblMaTheLoai);
            this.pnlInput.Controls.Add(this.cboMaTacGia);
            this.pnlInput.Controls.Add(this.lblMaTacGia);
            this.pnlInput.Controls.Add(this.txtTenSach);
            this.pnlInput.Controls.Add(this.lblTenSach);
            this.pnlInput.Controls.Add(this.txtMaSach);
            this.pnlInput.Controls.Add(this.lblMaSach);
            this.pnlInput.Controls.Add(this.btnTimKiem);
            this.pnlInput.Controls.Add(this.txtTimKiem);
            this.pnlInput.Location = new System.Drawing.Point(180, 50);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(790, 250);
            this.pnlInput.TabIndex = 4;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoLuong.Location = new System.Drawing.Point(580, 190);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(180, 22);
            this.txtSoLuong.TabIndex = 15;
            // 
            // lblSoLuongInput
            // 
            this.lblSoLuongInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSoLuongInput.AutoSize = true;
            this.lblSoLuongInput.Location = new System.Drawing.Point(450, 193);
            this.lblSoLuongInput.Name = "lblSoLuongInput";
            this.lblSoLuongInput.Size = new System.Drawing.Size(63, 16);
            this.lblSoLuongInput.TabIndex = 14;
            this.lblSoLuongInput.Text = "Số lượng:";
            // 
            // cboMaNXB
            // 
            this.cboMaNXB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMaNXB.FormattingEnabled = true;
            this.cboMaNXB.Location = new System.Drawing.Point(580, 110);
            this.cboMaNXB.Name = "cboMaNXB";
            this.cboMaNXB.Size = new System.Drawing.Size(180, 24);
            this.cboMaNXB.TabIndex = 13;
            // 
            // lblMaNXB
            // 
            this.lblMaNXB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaNXB.AutoSize = true;
            this.lblMaNXB.Location = new System.Drawing.Point(450, 113);
            this.lblMaNXB.Name = "lblMaNXB";
            this.lblMaNXB.Size = new System.Drawing.Size(59, 16);
            this.lblMaNXB.TabIndex = 12;
            this.lblMaNXB.Text = "Mã NXB:";
            // 
            // txtNamXuatBan
            // 
            this.txtNamXuatBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNamXuatBan.Location = new System.Drawing.Point(580, 150);
            this.txtNamXuatBan.Name = "txtNamXuatBan";
            this.txtNamXuatBan.Size = new System.Drawing.Size(180, 22);
            this.txtNamXuatBan.TabIndex = 11;
            // 
            // lblNamXuatBan
            // 
            this.lblNamXuatBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNamXuatBan.AutoSize = true;
            this.lblNamXuatBan.Location = new System.Drawing.Point(450, 153);
            this.lblNamXuatBan.Name = "lblNamXuatBan";
            this.lblNamXuatBan.Size = new System.Drawing.Size(95, 16);
            this.lblNamXuatBan.TabIndex = 10;
            this.lblNamXuatBan.Text = "Năm Xuất Bản:";
            // 
            // cboMaTheLoai
            // 
            this.cboMaTheLoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMaTheLoai.FormattingEnabled = true;
            this.cboMaTheLoai.Location = new System.Drawing.Point(580, 70);
            this.cboMaTheLoai.Name = "cboMaTheLoai";
            this.cboMaTheLoai.Size = new System.Drawing.Size(180, 24);
            this.cboMaTheLoai.TabIndex = 9;
            // 
            // lblMaTheLoai
            // 
            this.lblMaTheLoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaTheLoai.AutoSize = true;
            this.lblMaTheLoai.Location = new System.Drawing.Point(450, 73);
            this.lblMaTheLoai.Name = "lblMaTheLoai";
            this.lblMaTheLoai.Size = new System.Drawing.Size(85, 16);
            this.lblMaTheLoai.TabIndex = 8;
            this.lblMaTheLoai.Text = "Mã Thể Loại:";
            // 
            // cboMaTacGia
            // 
            this.cboMaTacGia.Location = new System.Drawing.Point(120, 150);
            this.cboMaTacGia.Name = "cboMaTacGia";
            this.cboMaTacGia.Size = new System.Drawing.Size(180, 24);
            this.cboMaTacGia.TabIndex = 7;
            // 
            // lblMaTacGia
            // 
            this.lblMaTacGia.AutoSize = true;
            this.lblMaTacGia.Location = new System.Drawing.Point(20, 153);
            this.lblMaTacGia.Name = "lblMaTacGia";
            this.lblMaTacGia.Size = new System.Drawing.Size(80, 16);
            this.lblMaTacGia.TabIndex = 6;
            this.lblMaTacGia.Text = "Mã Tác Giả:";
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(120, 110);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(180, 22);
            this.txtTenSach.TabIndex = 5;
            // 
            // lblTenSach
            // 
            this.lblTenSach.AutoSize = true;
            this.lblTenSach.Location = new System.Drawing.Point(20, 113);
            this.lblTenSach.Name = "lblTenSach";
            this.lblTenSach.Size = new System.Drawing.Size(73, 16);
            this.lblTenSach.TabIndex = 4;
            this.lblTenSach.Text = "Tên Sách*:";
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(120, 70);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(180, 22);
            this.txtMaSach.TabIndex = 3;
            // 
            // lblMaSach
            // 
            this.lblMaSach.AutoSize = true;
            this.lblMaSach.Location = new System.Drawing.Point(20, 73);
            this.lblMaSach.Name = "lblMaSach";
            this.lblMaSach.Size = new System.Drawing.Size(68, 16);
            this.lblMaSach.TabIndex = 2;
            this.lblMaSach.Text = "Mã Sách*:";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(340, 20);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(30, 30);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "🔍";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(120, 25);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(210, 22);
            this.txtTimKiem.TabIndex = 0;
            // 
            // pnlImage
            // 
            this.pnlImage.Location = new System.Drawing.Point(20, 50);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(150, 200);
            this.pnlImage.TabIndex = 3;
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(20, 260);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(150, 30);
            this.btnChooseFile.TabIndex = 2;
            this.btnChooseFile.Text = "Choose file";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblHeader.Location = new System.Drawing.Point(20, 10);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(254, 38);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "THÔNG TIN SÁCH";
            // 
            // FormQLTatCaSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQLTatCaSach";
            this.Text = "FormQLTatCaSach";
            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            this.pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            this.pnlRightControls.ResumeLayout(false);
            this.pnlCount.ResumeLayout(false);
            this.pnlCount.PerformLayout();
            this.pnlNXB.ResumeLayout(false);
            this.pnlNXB.PerformLayout();
            this.pnlTheLoai.ResumeLayout(false);
            this.pnlTheLoai.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // Khai báo các controls (Giữ nguyên)
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label lblMaSach;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.Label lblTenSach;
        private System.Windows.Forms.Label lblMaTacGia;
        private System.Windows.Forms.ComboBox cboMaTacGia;
        private System.Windows.Forms.ComboBox cboMaTheLoai;
        private System.Windows.Forms.Label lblMaTheLoai;
        private System.Windows.Forms.TextBox txtNamXuatBan;
        private System.Windows.Forms.Label lblNamXuatBan;
        private System.Windows.Forms.ComboBox cboMaNXB;
        private System.Windows.Forms.Label lblMaNXB;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblSoLuongInput;
        private System.Windows.Forms.Panel pnlRightControls;
        private System.Windows.Forms.Panel pnlTheLoai;
        private System.Windows.Forms.Label lblTheLoai;
        private System.Windows.Forms.Panel pnlNXB;
        private System.Windows.Forms.Label lblNXB;
        private System.Windows.Forms.Panel pnlCount;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Panel pnlGridContainer;
        private System.Windows.Forms.DataGridView dgvSach;
    }
}