namespace WindowsForm_QLTV
{
    partial class FormQLTaiKhoan
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
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.btnTrangCuoi = new System.Windows.Forms.Button();
            this.btnTrangSau = new System.Windows.Forms.Button();
            this.lblTrangHienTai = new System.Windows.Forms.Label();
            this.btnTrangTruoc = new System.Windows.Forms.Button();
            this.btnTrangDau = new System.Windows.Forms.Button();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTaoMoi = new System.Windows.Forms.Button();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.txtHoVaTen = new System.Windows.Forms.TextBox();
            this.lblHoVaTen = new System.Windows.Forms.Label();
            this.txtMaTK = new System.Windows.Forms.TextBox();
            this.lblMaTK = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlBackground.SuspendLayout();
            this.pnlDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.pnlPagination.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBackground.Controls.Add(this.pnlDataGrid);
            this.pnlBackground.Controls.Add(this.pnlSearch);
            this.pnlBackground.Controls.Add(this.pnlControl);
            this.pnlBackground.Controls.Add(this.pnlInput);
            this.pnlBackground.Controls.Add(this.lblHeader);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(1200, 700); // Kích thước mới
            this.pnlBackground.TabIndex = 0;
            // 
            // pnlDataGrid
            // 
            this.pnlDataGrid.Controls.Add(this.dgvTaiKhoan);
            this.pnlDataGrid.Controls.Add(this.pnlPagination);
            this.pnlDataGrid.Location = new System.Drawing.Point(340, 100); // Dịch chuyển lên 60px
            this.pnlDataGrid.Name = "pnlDataGrid";
            this.pnlDataGrid.Size = new System.Drawing.Size(840, 560); // Tăng chiều rộng và chiều cao
            this.pnlDataGrid.TabIndex = 4;
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTaiKhoan.Location = new System.Drawing.Point(0, 0);
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.RowHeadersWidth = 51;
            this.dgvTaiKhoan.RowTemplate.Height = 24;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(840, 510);
            this.dgvTaiKhoan.TabIndex = 1;
            // 
            // pnlPagination
            // 
            this.pnlPagination.Controls.Add(this.btnTrangCuoi);
            this.pnlPagination.Controls.Add(this.btnTrangSau);
            this.pnlPagination.Controls.Add(this.lblTrangHienTai);
            this.pnlPagination.Controls.Add(this.btnTrangTruoc);
            this.pnlPagination.Controls.Add(this.btnTrangDau);
            this.pnlPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPagination.Location = new System.Drawing.Point(0, 510);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(840, 50);
            this.pnlPagination.TabIndex = 0;
            // 
            // btnTrangCuoi
            // 
            this.btnTrangCuoi.Location = new System.Drawing.Point(640, 10);
            this.btnTrangCuoi.Name = "btnTrangCuoi";
            this.btnTrangCuoi.Size = new System.Drawing.Size(90, 30);
            this.btnTrangCuoi.TabIndex = 4;
            this.btnTrangCuoi.Text = "Trang cuối";
            this.btnTrangCuoi.UseVisualStyleBackColor = true;
            // 
            // btnTrangSau
            // 
            this.btnTrangSau.Location = new System.Drawing.Point(540, 10);
            this.btnTrangSau.Name = "btnTrangSau";
            this.btnTrangSau.Size = new System.Drawing.Size(90, 30);
            this.btnTrangSau.TabIndex = 3;
            this.btnTrangSau.Text = "Trang sau";
            this.btnTrangSau.UseVisualStyleBackColor = true;
            // 
            // lblTrangHienTai
            // 
            this.lblTrangHienTai.AutoSize = true;
            this.lblTrangHienTai.Location = new System.Drawing.Point(400, 17);
            this.lblTrangHienTai.Name = "lblTrangHienTai";
            this.lblTrangHienTai.Size = new System.Drawing.Size(70, 16);
            this.lblTrangHienTai.TabIndex = 2;
            this.lblTrangHienTai.Text = "Trang: 1/N";
            // 
            // btnTrangTruoc
            // 
            this.btnTrangTruoc.Location = new System.Drawing.Point(240, 10);
            this.btnTrangTruoc.Name = "btnTrangTruoc";
            this.btnTrangTruoc.Size = new System.Drawing.Size(90, 30);
            this.btnTrangTruoc.TabIndex = 1;
            this.btnTrangTruoc.Text = "Trang trước";
            this.btnTrangTruoc.UseVisualStyleBackColor = true;
            // 
            // btnTrangDau
            // 
            this.btnTrangDau.Location = new System.Drawing.Point(140, 10);
            this.btnTrangDau.Name = "btnTrangDau";
            this.btnTrangDau.Size = new System.Drawing.Size(90, 30);
            this.btnTrangDau.TabIndex = 0;
            this.btnTrangDau.Text = "Trang đầu";
            this.btnTrangDau.UseVisualStyleBackColor = true;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.btnTimKiem);
            this.pnlSearch.Controls.Add(this.txtTimKiem);
            this.pnlSearch.Controls.Add(this.lblTimKiem);
            this.pnlSearch.Location = new System.Drawing.Point(340, 50);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(840, 40); // Chiều rộng mới, chiều cao giảm
            this.pnlSearch.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(750, 5);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(80, 30);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(520, 10);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(220, 22);
            this.txtTimKiem.TabIndex = 5;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(450, 13);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(63, 16);
            this.lblTimKiem.TabIndex = 4;
            this.lblTimKiem.Text = "Họ và tên";
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnLuu);
            this.pnlControl.Controls.Add(this.btnXoa);
            this.pnlControl.Controls.Add(this.btnTaoMoi);
            this.pnlControl.Location = new System.Drawing.Point(30, 360); // Dịch chuyển lên
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(290, 50);
            this.pnlControl.TabIndex = 2;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(200, 10);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(80, 30);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(110, 10);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 30);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTaoMoi.FlatAppearance.BorderSize = 0;
            this.btnTaoMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTaoMoi.ForeColor = System.Drawing.Color.White;
            this.btnTaoMoi.Location = new System.Drawing.Point(20, 10);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(80, 30);
            this.btnTaoMoi.TabIndex = 0;
            this.btnTaoMoi.Text = "Tạo mới";
            this.btnTaoMoi.UseVisualStyleBackColor = false;
            // 
            // pnlInput
            // 
            this.pnlInput.Controls.Add(this.cboRole);
            this.pnlInput.Controls.Add(this.lblRole);
            this.pnlInput.Controls.Add(this.txtEmail);
            this.pnlInput.Controls.Add(this.lblEmail);
            this.pnlInput.Controls.Add(this.txtSDT);
            this.pnlInput.Controls.Add(this.lblSDT);
            this.pnlInput.Controls.Add(this.dtpNgaySinh);
            this.pnlInput.Controls.Add(this.cboGioiTinh);
            this.pnlInput.Controls.Add(this.lblNgaySinh);
            this.pnlInput.Controls.Add(this.lblGioiTinh);
            this.pnlInput.Controls.Add(this.txtHoVaTen);
            this.pnlInput.Controls.Add(this.lblHoVaTen);
            this.pnlInput.Controls.Add(this.txtMaTK);
            this.pnlInput.Controls.Add(this.lblMaTK);
            this.pnlInput.Location = new System.Drawing.Point(30, 50);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(290, 300); // Chiều cao giảm
            this.pnlInput.TabIndex = 1;
            // 
            // cboRole
            // 
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Items.AddRange(new object[] {
            "Admin",
            "Thủ thư",
            "Độc giả"});
            this.cboRole.Location = new System.Drawing.Point(120, 260); // Dịch chuyển lên
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(150, 24);
            this.cboRole.TabIndex = 13;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(20, 263); // Dịch chuyển lên
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(64, 16);
            this.lblRole.TabIndex = 12;
            this.lblRole.Text = "Chức vụ:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(120, 220); // Dịch chuyển lên
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(150, 22);
            this.txtEmail.TabIndex = 11;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 223); // Dịch chuyển lên
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 16);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email:";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(120, 180); // Dịch chuyển lên
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(150, 22);
            this.txtSDT.TabIndex = 9;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(20, 183); // Dịch chuyển lên
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(37, 16);
            this.lblSDT.TabIndex = 8;
            this.lblSDT.Text = "SĐT:";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(120, 140); // Dịch chuyển lên
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(150, 22);
            this.dtpNgaySinh.TabIndex = 7;
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cboGioiTinh.Location = new System.Drawing.Point(120, 100); // Dịch chuyển lên
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(150, 24);
            this.cboGioiTinh.TabIndex = 6;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(20, 143); // Dịch chuyển lên
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(71, 16);
            this.lblNgaySinh.TabIndex = 5;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(20, 103); // Dịch chuyển lên
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(57, 16);
            this.lblGioiTinh.TabIndex = 4;
            this.lblGioiTinh.Text = "Giới tính:";
            // 
            // txtHoVaTen
            // 
            this.txtHoVaTen.Location = new System.Drawing.Point(120, 60);
            this.txtHoVaTen.Name = "txtHoVaTen";
            this.txtHoVaTen.Size = new System.Drawing.Size(150, 22);
            this.txtHoVaTen.TabIndex = 3;
            // 
            // lblHoVaTen
            // 
            this.lblHoVaTen.AutoSize = true;
            this.lblHoVaTen.Location = new System.Drawing.Point(20, 63);
            this.lblHoVaTen.Name = "lblHoVaTen";
            this.lblHoVaTen.Size = new System.Drawing.Size(68, 16);
            this.lblHoVaTen.TabIndex = 2;
            this.lblHoVaTen.Text = "Họ và tên:";
            // 
            // txtMaTK
            // 
            this.txtMaTK.Location = new System.Drawing.Point(120, 20);
            this.txtMaTK.Name = "txtMaTK";
            this.txtMaTK.ReadOnly = true;
            this.txtMaTK.Size = new System.Drawing.Size(150, 22);
            this.txtMaTK.TabIndex = 1;
            // 
            // lblMaTK
            // 
            this.lblMaTK.AutoSize = true;
            this.lblMaTK.Location = new System.Drawing.Point(20, 23);
            this.lblMaTK.Name = "lblMaTK";
            this.lblMaTK.Size = new System.Drawing.Size(87, 16);
            this.lblMaTK.TabIndex = 0;
            this.lblMaTK.Text = "Mã tài khoản:";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblHeader.Location = new System.Drawing.Point(30, 10);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(325, 38);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "QUẢN LÝ TÀI KHOẢN";
            // 
            // FormQLTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700); // Chiều rộng Form mới
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQLTaiKhoan";
            this.Text = "FormQLTaiKhoan";
            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            this.pnlDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.pnlPagination.ResumeLayout(false);
            this.pnlPagination.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTaoMoi;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlDataGrid;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Button btnTrangCuoi;
        private System.Windows.Forms.Button btnTrangSau;
        private System.Windows.Forms.Label lblTrangHienTai;
        private System.Windows.Forms.Button btnTrangTruoc;
        private System.Windows.Forms.Button btnTrangDau;
        private System.Windows.Forms.TextBox txtHoVaTen;
        private System.Windows.Forms.Label lblHoVaTen;
        private System.Windows.Forms.TextBox txtMaTK;
        private System.Windows.Forms.Label lblMaTK;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
    }
}