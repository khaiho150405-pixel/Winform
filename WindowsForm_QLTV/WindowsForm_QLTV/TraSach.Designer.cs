namespace WindowsForm_QLTV
{
    partial class FormTraSach
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
            this.dgvPhieuMuon = new System.Windows.Forms.DataGridView();
            this.pnlRightControls = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnTraSach = new System.Windows.Forms.Button();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.pnlThongTinTra = new System.Windows.Forms.Panel();
            this.txtTienPhat = new System.Windows.Forms.TextBox();
            this.lblTienPhat = new System.Windows.Forms.Label();
            this.cboTinhTrangTra = new System.Windows.Forms.ComboBox();
            this.lblTinhTrangTra = new System.Windows.Forms.Label();
            this.dtpNgayTraThucTe = new System.Windows.Forms.DateTimePicker();
            this.lblNgayTraThucTe = new System.Windows.Forms.Label();
            this.dtpHenTra = new System.Windows.Forms.DateTimePicker();
            this.lblHenTra = new System.Windows.Forms.Label();
            this.txtMaPhieuMuon = new System.Windows.Forms.TextBox();
            this.lblMaPhieuMuon = new System.Windows.Forms.Label();
            this.lblThongTinTraHeader = new System.Windows.Forms.Label();
            this.pnlThongTinSach = new System.Windows.Forms.Panel();
            this.txtTenTacGia = new System.Windows.Forms.TextBox();
            this.lblTenTacGia = new System.Windows.Forms.Label();
            this.txtSoLuongCon = new System.Windows.Forms.TextBox();
            this.lblSoLuongCon = new System.Windows.Forms.Label();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.lblTenSach = new System.Windows.Forms.Label();
            this.txtMaDocGia = new System.Windows.Forms.TextBox();
            this.lblMaDocGia = new System.Windows.Forms.Label();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.lblMaSach = new System.Windows.Forms.Label();
            this.lblThongTinSachHeader = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnLoadDanhSach = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblNhapThongTin = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlBackground.SuspendLayout();
            this.pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuon)).BeginInit();
            this.pnlRightControls.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.pnlThongTinTra.SuspendLayout();
            this.pnlThongTinSach.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBackground.Controls.Add(this.pnlGridContainer);
            this.pnlBackground.Controls.Add(this.pnlRightControls);
            this.pnlBackground.Controls.Add(this.pnlInput);
            this.pnlBackground.Controls.Add(this.pnlSearch);
            this.pnlBackground.Controls.Add(this.pnlHeader);
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
            this.pnlGridContainer.Controls.Add(this.dgvPhieuMuon);
            this.pnlGridContainer.Location = new System.Drawing.Point(20, 350);
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.pnlGridContainer.Size = new System.Drawing.Size(950, 380);
            this.pnlGridContainer.TabIndex = 4;
            // 
            // dgvPhieuMuon
            // 
            this.dgvPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuMuon.Location = new System.Drawing.Point(0, 0);
            this.dgvPhieuMuon.Name = "dgvPhieuMuon";
            this.dgvPhieuMuon.RowHeadersWidth = 51;
            this.dgvPhieuMuon.RowTemplate.Height = 24;
            this.dgvPhieuMuon.Size = new System.Drawing.Size(950, 380);
            this.dgvPhieuMuon.TabIndex = 0;
            // 
            // pnlRightControls
            // 
            this.pnlRightControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRightControls.Controls.Add(this.btnHuy);
            this.pnlRightControls.Controls.Add(this.btnXoa);
            this.pnlRightControls.Controls.Add(this.btnSua);
            this.pnlRightControls.Controls.Add(this.btnTraSach);
            this.pnlRightControls.Location = new System.Drawing.Point(980, 140);
            this.pnlRightControls.Name = "pnlRightControls";
            this.pnlRightControls.Size = new System.Drawing.Size(200, 590);
            this.pnlRightControls.TabIndex = 3;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Gray;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(20, 240);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(160, 40);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(20, 180);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(160, 40);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(20, 120);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(160, 40);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnTraSach
            // 
            this.btnTraSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnTraSach.FlatAppearance.BorderSize = 0;
            this.btnTraSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTraSach.ForeColor = System.Drawing.Color.White;
            this.btnTraSach.Location = new System.Drawing.Point(20, 60);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(160, 40);
            this.btnTraSach.TabIndex = 0;
            this.btnTraSach.Text = "Trả";
            this.btnTraSach.UseVisualStyleBackColor = false;
            // 
            // pnlInput
            // 
            this.pnlInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInput.Controls.Add(this.pnlThongTinTra);
            this.pnlInput.Controls.Add(this.pnlThongTinSach);
            this.pnlInput.Location = new System.Drawing.Point(20, 140);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(950, 200);
            this.pnlInput.TabIndex = 2;
            // 
            // pnlThongTinTra
            // 
            this.pnlThongTinTra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThongTinTra.Controls.Add(this.txtTienPhat);
            this.pnlThongTinTra.Controls.Add(this.lblTienPhat);
            this.pnlThongTinTra.Controls.Add(this.cboTinhTrangTra);
            this.pnlThongTinTra.Controls.Add(this.lblTinhTrangTra);
            this.pnlThongTinTra.Controls.Add(this.dtpNgayTraThucTe);
            this.pnlThongTinTra.Controls.Add(this.lblNgayTraThucTe);
            this.pnlThongTinTra.Controls.Add(this.dtpHenTra);
            this.pnlThongTinTra.Controls.Add(this.lblHenTra);
            this.pnlThongTinTra.Controls.Add(this.txtMaPhieuMuon);
            this.pnlThongTinTra.Controls.Add(this.lblMaPhieuMuon);
            this.pnlThongTinTra.Controls.Add(this.lblThongTinTraHeader);
            this.pnlThongTinTra.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlThongTinTra.Location = new System.Drawing.Point(480, 0);
            this.pnlThongTinTra.Name = "pnlThongTinTra";
            this.pnlThongTinTra.Size = new System.Drawing.Size(470, 200);
            this.pnlThongTinTra.TabIndex = 1;
            // 
            // txtTienPhat
            // 
            this.txtTienPhat.Location = new System.Drawing.Point(340, 125);
            this.txtTienPhat.Name = "txtTienPhat";
            this.txtTienPhat.Size = new System.Drawing.Size(115, 22);
            this.txtTienPhat.TabIndex = 16;
            // 
            // lblTienPhat
            // 
            this.lblTienPhat.AutoSize = true;
            this.lblTienPhat.Location = new System.Drawing.Point(235, 128);
            this.lblTienPhat.Name = "lblTienPhat";
            this.lblTienPhat.Size = new System.Drawing.Size(64, 16);
            this.lblTienPhat.TabIndex = 15;
            this.lblTienPhat.Text = "Tiền Phạt";
            // 
            // cboTinhTrangTra
            // 
            this.cboTinhTrangTra.Location = new System.Drawing.Point(130, 125);
            this.cboTinhTrangTra.Name = "cboTinhTrangTra";
            this.cboTinhTrangTra.Size = new System.Drawing.Size(115, 24);
            this.cboTinhTrangTra.TabIndex = 14;
            // 
            // lblTinhTrangTra
            // 
            this.lblTinhTrangTra.AutoSize = true;
            this.lblTinhTrangTra.Location = new System.Drawing.Point(10, 128);
            this.lblTinhTrangTra.Name = "lblTinhTrangTra";
            this.lblTinhTrangTra.Size = new System.Drawing.Size(96, 16);
            this.lblTinhTrangTra.TabIndex = 13;
            this.lblTinhTrangTra.Text = "Tình Trạng Trả";
            // 
            // dtpNgayTraThucTe
            // 
            this.dtpNgayTraThucTe.CustomFormat = "MM/dd/yyyy";
            this.dtpNgayTraThucTe.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayTraThucTe.Location = new System.Drawing.Point(340, 65);
            this.dtpNgayTraThucTe.Name = "dtpNgayTraThucTe";
            this.dtpNgayTraThucTe.Size = new System.Drawing.Size(115, 22);
            this.dtpNgayTraThucTe.TabIndex = 12;
            // 
            // lblNgayTraThucTe
            // 
            this.lblNgayTraThucTe.AutoSize = true;
            this.lblNgayTraThucTe.Location = new System.Drawing.Point(235, 68);
            this.lblNgayTraThucTe.Name = "lblNgayTraThucTe";
            this.lblNgayTraThucTe.Size = new System.Drawing.Size(85, 16);
            this.lblNgayTraThucTe.TabIndex = 11;
            this.lblNgayTraThucTe.Text = "Ngày Trả TT";
            // 
            // dtpHenTra
            // 
            this.dtpHenTra.CustomFormat = "MM/dd/yyyy";
            this.dtpHenTra.Enabled = false;
            this.dtpHenTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHenTra.Location = new System.Drawing.Point(130, 95);
            this.dtpHenTra.Name = "dtpHenTra";
            this.dtpHenTra.Size = new System.Drawing.Size(115, 22);
            this.dtpHenTra.TabIndex = 10;
            // 
            // lblHenTra
            // 
            this.lblHenTra.AutoSize = true;
            this.lblHenTra.Location = new System.Drawing.Point(10, 98);
            this.lblHenTra.Name = "lblHenTra";
            this.lblHenTra.Size = new System.Drawing.Size(50, 16);
            this.lblHenTra.TabIndex = 9;
            this.lblHenTra.Text = "Hẹn trả";
            // 
            // txtMaPhieuMuon
            // 
            this.txtMaPhieuMuon.Location = new System.Drawing.Point(130, 65);
            this.txtMaPhieuMuon.Name = "txtMaPhieuMuon";
            this.txtMaPhieuMuon.ReadOnly = true;
            this.txtMaPhieuMuon.Size = new System.Drawing.Size(115, 22);
            this.txtMaPhieuMuon.TabIndex = 2;
            // 
            // lblMaPhieuMuon
            // 
            this.lblMaPhieuMuon.AutoSize = true;
            this.lblMaPhieuMuon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaPhieuMuon.Location = new System.Drawing.Point(10, 68);
            this.lblMaPhieuMuon.Name = "lblMaPhieuMuon";
            this.lblMaPhieuMuon.Size = new System.Drawing.Size(58, 20);
            this.lblMaPhieuMuon.TabIndex = 1;
            this.lblMaPhieuMuon.Text = "Mã PM";
            // 
            // lblThongTinTraHeader
            // 
            this.lblThongTinTraHeader.AutoSize = true;
            this.lblThongTinTraHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblThongTinTraHeader.Location = new System.Drawing.Point(10, 10);
            this.lblThongTinTraHeader.Name = "lblThongTinTraHeader";
            this.lblThongTinTraHeader.Size = new System.Drawing.Size(143, 28);
            this.lblThongTinTraHeader.TabIndex = 0;
            this.lblThongTinTraHeader.Text = "Thông Tin Trả";
            // 
            // pnlThongTinSach
            // 
            this.pnlThongTinSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThongTinSach.Controls.Add(this.txtTenTacGia);
            this.pnlThongTinSach.Controls.Add(this.lblTenTacGia);
            this.pnlThongTinSach.Controls.Add(this.txtSoLuongCon);
            this.pnlThongTinSach.Controls.Add(this.lblSoLuongCon);
            this.pnlThongTinSach.Controls.Add(this.txtTenSach);
            this.pnlThongTinSach.Controls.Add(this.lblTenSach);
            this.pnlThongTinSach.Controls.Add(this.txtMaDocGia);
            this.pnlThongTinSach.Controls.Add(this.lblMaDocGia);
            this.pnlThongTinSach.Controls.Add(this.txtMaSach);
            this.pnlThongTinSach.Controls.Add(this.lblMaSach);
            this.pnlThongTinSach.Controls.Add(this.lblThongTinSachHeader);
            this.pnlThongTinSach.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlThongTinSach.Location = new System.Drawing.Point(0, 0);
            this.pnlThongTinSach.Name = "pnlThongTinSach";
            this.pnlThongTinSach.Size = new System.Drawing.Size(470, 200);
            this.pnlThongTinSach.TabIndex = 0;
            // 
            // txtTenTacGia
            // 
            this.txtTenTacGia.Location = new System.Drawing.Point(340, 155);
            this.txtTenTacGia.Name = "txtTenTacGia";
            this.txtTenTacGia.ReadOnly = true;
            this.txtTenTacGia.Size = new System.Drawing.Size(115, 22);
            this.txtTenTacGia.TabIndex = 9;
            // 
            // lblTenTacGia
            // 
            this.lblTenTacGia.AutoSize = true;
            this.lblTenTacGia.Location = new System.Drawing.Point(235, 158);
            this.lblTenTacGia.Name = "lblTenTacGia";
            this.lblTenTacGia.Size = new System.Drawing.Size(82, 16);
            this.lblTenTacGia.TabIndex = 8;
            this.lblTenTacGia.Text = "Tên Tác Giả";
            // 
            // txtSoLuongCon
            // 
            this.txtSoLuongCon.Location = new System.Drawing.Point(340, 125);
            this.txtSoLuongCon.Name = "txtSoLuongCon";
            this.txtSoLuongCon.ReadOnly = true;
            this.txtSoLuongCon.Size = new System.Drawing.Size(115, 22);
            this.txtSoLuongCon.TabIndex = 7;
            // 
            // lblSoLuongCon
            // 
            this.lblSoLuongCon.AutoSize = true;
            this.lblSoLuongCon.Location = new System.Drawing.Point(235, 128);
            this.lblSoLuongCon.Name = "lblSoLuongCon";
            this.lblSoLuongCon.Size = new System.Drawing.Size(89, 16);
            this.lblSoLuongCon.TabIndex = 6;
            this.lblSoLuongCon.Text = "Số Lượng còn";
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(110, 155);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.ReadOnly = true;
            this.txtTenSach.Size = new System.Drawing.Size(115, 22);
            this.txtTenSach.TabIndex = 5;
            // 
            // lblTenSach
            // 
            this.lblTenSach.AutoSize = true;
            this.lblTenSach.Location = new System.Drawing.Point(10, 158);
            this.lblTenSach.Name = "lblTenSach";
            this.lblTenSach.Size = new System.Drawing.Size(65, 16);
            this.lblTenSach.TabIndex = 4;
            this.lblTenSach.Text = "Tên Sách";
            // 
            // txtMaDocGia
            // 
            this.txtMaDocGia.Location = new System.Drawing.Point(110, 95);
            this.txtMaDocGia.Name = "txtMaDocGia";
            this.txtMaDocGia.ReadOnly = true;
            this.txtMaDocGia.Size = new System.Drawing.Size(115, 22);
            this.txtMaDocGia.TabIndex = 3;
            // 
            // lblMaDocGia
            // 
            this.lblMaDocGia.AutoSize = true;
            this.lblMaDocGia.Location = new System.Drawing.Point(10, 98);
            this.lblMaDocGia.Name = "lblMaDocGia";
            this.lblMaDocGia.Size = new System.Drawing.Size(75, 16);
            this.lblMaDocGia.TabIndex = 2;
            this.lblMaDocGia.Text = "Mã Độc giả";
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(110, 65);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.ReadOnly = true;
            this.txtMaSach.Size = new System.Drawing.Size(115, 22);
            this.txtMaSach.TabIndex = 1;
            // 
            // lblMaSach
            // 
            this.lblMaSach.AutoSize = true;
            this.lblMaSach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaSach.Location = new System.Drawing.Point(10, 68);
            this.lblMaSach.Name = "lblMaSach";
            this.lblMaSach.Size = new System.Drawing.Size(74, 20);
            this.lblMaSach.TabIndex = 0;
            this.lblMaSach.Text = "Mã Sách*";
            // 
            // lblThongTinSachHeader
            // 
            this.lblThongTinSachHeader.AutoSize = true;
            this.lblThongTinSachHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblThongTinSachHeader.Location = new System.Drawing.Point(10, 10);
            this.lblThongTinSachHeader.Name = "lblThongTinSachHeader";
            this.lblThongTinSachHeader.Size = new System.Drawing.Size(152, 28);
            this.lblThongTinSachHeader.TabIndex = 0;
            this.lblThongTinSachHeader.Text = "Thông tin sách";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.Controls.Add(this.btnLoadDanhSach);
            this.pnlSearch.Controls.Add(this.btnTimKiem);
            this.pnlSearch.Controls.Add(this.txtTimKiem);
            this.pnlSearch.Controls.Add(this.lblNhapThongTin);
            this.pnlSearch.Location = new System.Drawing.Point(20, 50);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(950, 70);
            this.pnlSearch.TabIndex = 1;
            // 
            // btnLoadDanhSach
            // 
            this.btnLoadDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadDanhSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnLoadDanhSach.FlatAppearance.BorderSize = 0;
            this.btnLoadDanhSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDanhSach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoadDanhSach.ForeColor = System.Drawing.Color.White;
            this.btnLoadDanhSach.Location = new System.Drawing.Point(820, 20);
            this.btnLoadDanhSach.Name = "btnLoadDanhSach";
            this.btnLoadDanhSach.Size = new System.Drawing.Size(120, 30);
            this.btnLoadDanhSach.TabIndex = 7;
            this.btnLoadDanhSach.Text = "Load";
            this.btnLoadDanhSach.UseVisualStyleBackColor = false;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(730, 20);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(80, 30);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Location = new System.Drawing.Point(150, 25);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(570, 22);
            this.txtTimKiem.TabIndex = 4;
            this.txtTimKiem.Text = "Search...";
            // 
            // lblNhapThongTin
            // 
            this.lblNhapThongTin.AutoSize = true;
            this.lblNhapThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNhapThongTin.Location = new System.Drawing.Point(10, 25);
            this.lblNhapThongTin.Name = "lblNhapThongTin";
            this.lblNhapThongTin.Size = new System.Drawing.Size(139, 23);
            this.lblNhapThongTin.TabIndex = 1;
            this.lblNhapThongTin.Text = "Nhập Thông Tin";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.pnlHeader.Controls.Add(this.lblFormTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 40);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(10, 6);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(227, 28);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "THÔNG TIN TRẢ SÁCH";
            // 
            // FormTraSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTraSach";
            this.Text = "FormTraSach";
            this.pnlBackground.ResumeLayout(false);
            this.pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuon)).EndInit();
            this.pnlRightControls.ResumeLayout(false);
            this.pnlInput.ResumeLayout(false);
            this.pnlThongTinTra.ResumeLayout(false);
            this.pnlThongTinTra.PerformLayout();
            this.pnlThongTinSach.ResumeLayout(false);
            this.pnlThongTinSach.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblNhapThongTin;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLoadDanhSach;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Panel pnlThongTinSach;
        private System.Windows.Forms.Label lblThongTinSachHeader;
        private System.Windows.Forms.Panel pnlThongTinTra;
        private System.Windows.Forms.Label lblThongTinTraHeader;
        private System.Windows.Forms.Panel pnlRightControls;
        private System.Windows.Forms.Button btnTraSach;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Panel pnlGridContainer;
        private System.Windows.Forms.DataGridView dgvPhieuMuon;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.Label lblMaSach;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.Label lblTenSach;
        private System.Windows.Forms.TextBox txtMaDocGia;
        private System.Windows.Forms.Label lblMaDocGia;
        private System.Windows.Forms.TextBox txtTenTacGia;
        private System.Windows.Forms.Label lblTenTacGia;
        private System.Windows.Forms.TextBox txtSoLuongCon;
        private System.Windows.Forms.Label lblSoLuongCon;
        private System.Windows.Forms.TextBox txtMaPhieuMuon;
        private System.Windows.Forms.Label lblMaPhieuMuon;
        private System.Windows.Forms.DateTimePicker dtpHenTra;
        private System.Windows.Forms.Label lblHenTra;
        private System.Windows.Forms.DateTimePicker dtpNgayTraThucTe;
        private System.Windows.Forms.Label lblNgayTraThucTe;
        private System.Windows.Forms.TextBox txtTienPhat;
        private System.Windows.Forms.Label lblTienPhat;
        private System.Windows.Forms.ComboBox cboTinhTrangTra;
        private System.Windows.Forms.Label lblTinhTrangTra;
    }
}