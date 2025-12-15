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
            this.cboLocVaiTro = new System.Windows.Forms.ComboBox();
            this.lblLocVaiTro = new System.Windows.Forms.Label();
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
            this.pnlBackground.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(1350, 875);
            this.pnlBackground.TabIndex = 0;
            // 
            // pnlDataGrid
            // 
            this.pnlDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDataGrid.Controls.Add(this.dgvTaiKhoan);
            this.pnlDataGrid.Controls.Add(this.pnlPagination);
            this.pnlDataGrid.Location = new System.Drawing.Point(382, 125);
            this.pnlDataGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDataGrid.Name = "pnlDataGrid";
            this.pnlDataGrid.Size = new System.Drawing.Size(945, 700);
            this.pnlDataGrid.TabIndex = 4;
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTaiKhoan.Location = new System.Drawing.Point(0, 0);
            this.dgvTaiKhoan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.RowHeadersWidth = 51;
            this.dgvTaiKhoan.RowTemplate.Height = 24;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(945, 638);
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
            this.pnlPagination.Location = new System.Drawing.Point(0, 638);
            this.pnlPagination.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(945, 62);
            this.pnlPagination.TabIndex = 0;
            // 
            // btnTrangCuoi
            // 
            this.btnTrangCuoi.Location = new System.Drawing.Point(720, 12);
            this.btnTrangCuoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTrangCuoi.Name = "btnTrangCuoi";
            this.btnTrangCuoi.Size = new System.Drawing.Size(101, 38);
            this.btnTrangCuoi.TabIndex = 4;
            this.btnTrangCuoi.Text = "Trang cuối";
            this.btnTrangCuoi.UseVisualStyleBackColor = true;
            // 
            // btnTrangSau
            // 
            this.btnTrangSau.Location = new System.Drawing.Point(608, 12);
            this.btnTrangSau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTrangSau.Name = "btnTrangSau";
            this.btnTrangSau.Size = new System.Drawing.Size(101, 38);
            this.btnTrangSau.TabIndex = 3;
            this.btnTrangSau.Text = "Trang sau";
            this.btnTrangSau.UseVisualStyleBackColor = true;
            // 
            // lblTrangHienTai
            // 
            this.lblTrangHienTai.AutoSize = true;
            this.lblTrangHienTai.Location = new System.Drawing.Point(450, 21);
            this.lblTrangHienTai.Name = "lblTrangHienTai";
            this.lblTrangHienTai.Size = new System.Drawing.Size(82, 20);
            this.lblTrangHienTai.TabIndex = 2;
            this.lblTrangHienTai.Text = "Trang: 1/N";
            // 
            // btnTrangTruoc
            // 
            this.btnTrangTruoc.Location = new System.Drawing.Point(270, 12);
            this.btnTrangTruoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTrangTruoc.Name = "btnTrangTruoc";
            this.btnTrangTruoc.Size = new System.Drawing.Size(101, 38);
            this.btnTrangTruoc.TabIndex = 1;
            this.btnTrangTruoc.Text = "Trang trước";
            this.btnTrangTruoc.UseVisualStyleBackColor = true;
            // 
            // btnTrangDau
            // 
            this.btnTrangDau.Location = new System.Drawing.Point(158, 12);
            this.btnTrangDau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTrangDau.Name = "btnTrangDau";
            this.btnTrangDau.Size = new System.Drawing.Size(101, 38);
            this.btnTrangDau.TabIndex = 0;
            this.btnTrangDau.Text = "Trang đầu";
            this.btnTrangDau.UseVisualStyleBackColor = true;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.Controls.Add(this.cboLocVaiTro);
            this.pnlSearch.Controls.Add(this.lblLocVaiTro);
            this.pnlSearch.Controls.Add(this.btnTimKiem);
            this.pnlSearch.Controls.Add(this.txtTimKiem);
            this.pnlSearch.Controls.Add(this.lblTimKiem);
            this.pnlSearch.Location = new System.Drawing.Point(382, 62);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(945, 50);
            this.pnlSearch.TabIndex = 3;
            // 
            // cboLocVaiTro
            // 
            this.cboLocVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocVaiTro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboLocVaiTro.FormattingEnabled = true;
            this.cboLocVaiTro.Location = new System.Drawing.Point(90, 10);
            this.cboLocVaiTro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboLocVaiTro.Name = "cboLocVaiTro";
            this.cboLocVaiTro.Size = new System.Drawing.Size(146, 33);
            this.cboLocVaiTro.TabIndex = 7;
            // 
            // lblLocVaiTro
            // 
            this.lblLocVaiTro.AutoSize = true;
            this.lblLocVaiTro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLocVaiTro.Location = new System.Drawing.Point(11, 15);
            this.lblLocVaiTro.Name = "lblLocVaiTro";
            this.lblLocVaiTro.Size = new System.Drawing.Size(67, 25);
            this.lblLocVaiTro.TabIndex = 6;
            this.lblLocVaiTro.Text = "Vai trò:";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(844, 6);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(90, 38);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.Location = new System.Drawing.Point(472, 10);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(360, 31);
            this.txtTimKiem.TabIndex = 5;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimKiem.Location = new System.Drawing.Point(378, 15);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(88, 25);
            this.lblTimKiem.TabIndex = 4;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnLuu);
            this.pnlControl.Controls.Add(this.btnXoa);
            this.pnlControl.Controls.Add(this.btnTaoMoi);
            this.pnlControl.Location = new System.Drawing.Point(34, 450);
            this.pnlControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(326, 62);
            this.pnlControl.TabIndex = 2;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(225, 12);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(90, 38);
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
            this.btnXoa.Location = new System.Drawing.Point(124, 12);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 38);
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
            this.btnTaoMoi.Location = new System.Drawing.Point(22, 12);
            this.btnTaoMoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(90, 38);
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
            this.pnlInput.Location = new System.Drawing.Point(34, 62);
            this.pnlInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(326, 375);
            this.pnlInput.TabIndex = 1;
            // 
            // cboRole
            // 
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(135, 325);
            this.cboRole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(168, 28);
            this.cboRole.TabIndex = 13;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(22, 329);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(70, 20);
            this.lblRole.TabIndex = 12;
            this.lblRole.Text = "Chức vụ:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(135, 275);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(168, 26);
            this.txtEmail.TabIndex = 11;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(22, 279);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(52, 20);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email:";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(135, 225);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(168, 26);
            this.txtSDT.TabIndex = 9;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(22, 229);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(45, 20);
            this.lblSDT.TabIndex = 8;
            this.lblSDT.Text = "SĐT:";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(135, 175);
            this.dtpNgaySinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(168, 26);
            this.dtpNgaySinh.TabIndex = 7;
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cboGioiTinh.Location = new System.Drawing.Point(135, 125);
            this.cboGioiTinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(168, 28);
            this.cboGioiTinh.TabIndex = 6;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(22, 179);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(82, 20);
            this.lblNgaySinh.TabIndex = 5;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(22, 129);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(71, 20);
            this.lblGioiTinh.TabIndex = 4;
            this.lblGioiTinh.Text = "Giới tính:";
            // 
            // txtHoVaTen
            // 
            this.txtHoVaTen.Location = new System.Drawing.Point(135, 75);
            this.txtHoVaTen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHoVaTen.Name = "txtHoVaTen";
            this.txtHoVaTen.Size = new System.Drawing.Size(168, 26);
            this.txtHoVaTen.TabIndex = 3;
            // 
            // lblHoVaTen
            // 
            this.lblHoVaTen.AutoSize = true;
            this.lblHoVaTen.Location = new System.Drawing.Point(22, 79);
            this.lblHoVaTen.Name = "lblHoVaTen";
            this.lblHoVaTen.Size = new System.Drawing.Size(81, 20);
            this.lblHoVaTen.TabIndex = 2;
            this.lblHoVaTen.Text = "Họ và tên:";
            // 
            // txtMaTK
            // 
            this.txtMaTK.Location = new System.Drawing.Point(135, 25);
            this.txtMaTK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaTK.Name = "txtMaTK";
            this.txtMaTK.ReadOnly = true;
            this.txtMaTK.Size = new System.Drawing.Size(168, 26);
            this.txtMaTK.TabIndex = 1;
            // 
            // lblMaTK
            // 
            this.lblMaTK.AutoSize = true;
            this.lblMaTK.Location = new System.Drawing.Point(22, 29);
            this.lblMaTK.Name = "lblMaTK";
            this.lblMaTK.Size = new System.Drawing.Size(104, 20);
            this.lblMaTK.TabIndex = 0;
            this.lblMaTK.Text = "Mã tài khoản:";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblHeader.Location = new System.Drawing.Point(34, 12);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(350, 45);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "QUẢN LÝ TÀI KHOẢN";
            // 
            // FormQLTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 875);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.ComboBox cboLocVaiTro;
        private System.Windows.Forms.Label lblLocVaiTro;
    }
}