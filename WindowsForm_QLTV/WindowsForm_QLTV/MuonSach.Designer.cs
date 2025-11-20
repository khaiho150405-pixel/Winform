namespace WindowsForm_QLTV
{
    partial class FormMuonSach
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
            this.dgvMuonSach = new System.Windows.Forms.DataGridView();
            this.pnlRightControls = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnMuon = new System.Windows.Forms.Button();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.pnlThongTinMuon = new System.Windows.Forms.Panel();
            this.cboTinhTrang = new System.Windows.Forms.ComboBox();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.dtpHenTra = new System.Windows.Forms.DateTimePicker();
            this.lblHenTra = new System.Windows.Forms.Label();
            this.dtpNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.lblNgayMuon = new System.Windows.Forms.Label();
            this.txtSLMuon = new System.Windows.Forms.TextBox();
            this.lblSLMuon = new System.Windows.Forms.Label();
            this.cboMaDocGia = new System.Windows.Forms.ComboBox();
            this.lblMaDocGia = new System.Windows.Forms.Label();
            this.txtMaPhieuMuon = new System.Windows.Forms.TextBox();
            this.lblMaPhieuMuon = new System.Windows.Forms.Label();
            this.lblThongTinMuonHeader = new System.Windows.Forms.Label();
            this.pnlThongTinSach = new System.Windows.Forms.Panel();
            this.txtTenTacGia = new System.Windows.Forms.TextBox();
            this.lblTenTacGia = new System.Windows.Forms.Label();
            this.txtSoLuongCon = new System.Windows.Forms.TextBox();
            this.lblSoLuongCon = new System.Windows.Forms.Label();
            this.cboTenSach = new System.Windows.Forms.ComboBox();
            this.lblTenSach = new System.Windows.Forms.Label();
            this.btnTimSach = new System.Windows.Forms.Button();
            this.cboMaSach = new System.Windows.Forms.ComboBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvMuonSach)).BeginInit();
            this.pnlRightControls.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.pnlThongTinMuon.SuspendLayout();
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
            this.pnlGridContainer.Controls.Add(this.dgvMuonSach);
            this.pnlGridContainer.Location = new System.Drawing.Point(20, 350);
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.pnlGridContainer.Size = new System.Drawing.Size(950, 380);
            this.pnlGridContainer.TabIndex = 4;
            // 
            // dgvMuonSach
            // 
            this.dgvMuonSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMuonSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMuonSach.Location = new System.Drawing.Point(0, 0);
            this.dgvMuonSach.Name = "dgvMuonSach";
            this.dgvMuonSach.RowHeadersWidth = 51;
            this.dgvMuonSach.RowTemplate.Height = 24;
            this.dgvMuonSach.Size = new System.Drawing.Size(950, 380);
            this.dgvMuonSach.TabIndex = 0;
            // 
            // pnlRightControls
            // 
            this.pnlRightControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRightControls.Controls.Add(this.btnHuy);
            this.pnlRightControls.Controls.Add(this.btnXoa);
            this.pnlRightControls.Controls.Add(this.btnSua);
            this.pnlRightControls.Controls.Add(this.btnMuon);
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
            // btnMuon
            // 
            this.btnMuon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnMuon.FlatAppearance.BorderSize = 0;
            this.btnMuon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMuon.ForeColor = System.Drawing.Color.White;
            this.btnMuon.Location = new System.Drawing.Point(20, 60);
            this.btnMuon.Name = "btnMuon";
            this.btnMuon.Size = new System.Drawing.Size(160, 40);
            this.btnMuon.TabIndex = 0;
            this.btnMuon.Text = "Mượn";
            this.btnMuon.UseVisualStyleBackColor = false;
            // 
            // pnlInput
            // 
            this.pnlInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInput.Controls.Add(this.pnlThongTinMuon);
            this.pnlInput.Controls.Add(this.pnlThongTinSach);
            this.pnlInput.Location = new System.Drawing.Point(20, 140);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(950, 200);
            this.pnlInput.TabIndex = 2;
            // 
            // pnlThongTinMuon
            // 
            this.pnlThongTinMuon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThongTinMuon.Controls.Add(this.cboTinhTrang);
            this.pnlThongTinMuon.Controls.Add(this.lblTinhTrang);
            this.pnlThongTinMuon.Controls.Add(this.dtpHenTra);
            this.pnlThongTinMuon.Controls.Add(this.lblHenTra);
            this.pnlThongTinMuon.Controls.Add(this.dtpNgayMuon);
            this.pnlThongTinMuon.Controls.Add(this.lblNgayMuon);
            this.pnlThongTinMuon.Controls.Add(this.txtSLMuon);
            this.pnlThongTinMuon.Controls.Add(this.lblSLMuon);
            this.pnlThongTinMuon.Controls.Add(this.cboMaDocGia);
            this.pnlThongTinMuon.Controls.Add(this.lblMaDocGia);
            this.pnlThongTinMuon.Controls.Add(this.txtMaPhieuMuon);
            this.pnlThongTinMuon.Controls.Add(this.lblMaPhieuMuon);
            this.pnlThongTinMuon.Controls.Add(this.lblThongTinMuonHeader);
            this.pnlThongTinMuon.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlThongTinMuon.Location = new System.Drawing.Point(480, 0);
            this.pnlThongTinMuon.Name = "pnlThongTinMuon";
            this.pnlThongTinMuon.Size = new System.Drawing.Size(470, 200);
            this.pnlThongTinMuon.TabIndex = 1;
            // 
            // cboTinhTrang
            // 
            this.cboTinhTrang.Location = new System.Drawing.Point(340, 125);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(115, 24);
            this.cboTinhTrang.TabIndex = 14;
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.Location = new System.Drawing.Point(235, 128);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(69, 16);
            this.lblTinhTrang.TabIndex = 13;
            this.lblTinhTrang.Text = "Tình trạng";
            // 
            // dtpHenTra
            // 
            this.dtpHenTra.CustomFormat = "MM/dd/yyyy";
            this.dtpHenTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHenTra.Location = new System.Drawing.Point(340, 95);
            this.dtpHenTra.Name = "dtpHenTra";
            this.dtpHenTra.Size = new System.Drawing.Size(115, 22);
            this.dtpHenTra.TabIndex = 12;
            // 
            // lblHenTra
            // 
            this.lblHenTra.AutoSize = true;
            this.lblHenTra.Location = new System.Drawing.Point(235, 98);
            this.lblHenTra.Name = "lblHenTra";
            this.lblHenTra.Size = new System.Drawing.Size(53, 16);
            this.lblHenTra.TabIndex = 11;
            this.lblHenTra.Text = "Hẹn trả";
            // 
            // dtpNgayMuon
            // 
            this.dtpNgayMuon.CustomFormat = "MM/dd/yyyy";
            this.dtpNgayMuon.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayMuon.Location = new System.Drawing.Point(340, 65);
            this.dtpNgayMuon.Name = "dtpNgayMuon";
            this.dtpNgayMuon.Size = new System.Drawing.Size(115, 22);
            this.dtpNgayMuon.TabIndex = 10;
            // 
            // lblNgayMuon
            // 
            this.lblNgayMuon.AutoSize = true;
            this.lblNgayMuon.Location = new System.Drawing.Point(235, 68);
            this.lblNgayMuon.Name = "lblNgayMuon";
            this.lblNgayMuon.Size = new System.Drawing.Size(76, 16);
            this.lblNgayMuon.TabIndex = 9;
            this.lblNgayMuon.Text = "Ngày Mượn";
            // 
            // txtSLMuon
            // 
            this.txtSLMuon.Location = new System.Drawing.Point(100, 125); // Vị trí mới
            this.txtSLMuon.Name = "txtSLMuon";
            this.txtSLMuon.Size = new System.Drawing.Size(115, 22);
            this.txtSLMuon.TabIndex = 8;
            // 
            // lblSLMuon
            // 
            this.lblSLMuon.AutoSize = true;
            this.lblSLMuon.Location = new System.Drawing.Point(10, 128); // Vị trí mới
            this.lblSLMuon.Name = "lblSLMuon";
            this.lblSLMuon.Size = new System.Drawing.Size(76, 16);
            this.lblSLMuon.TabIndex = 7;
            this.lblSLMuon.Text = "SL Mượn";
            // 
            // cboMaDocGia
            // 
            this.cboMaDocGia.Location = new System.Drawing.Point(100, 95); // Vị trí mới
            this.cboMaDocGia.Name = "cboMaDocGia";
            this.cboMaDocGia.Size = new System.Drawing.Size(115, 24);
            this.cboMaDocGia.TabIndex = 6;
            // 
            // lblMaDocGia
            // 
            this.lblMaDocGia.AutoSize = true;
            this.lblMaDocGia.Location = new System.Drawing.Point(10, 98); // Vị trí mới
            this.lblMaDocGia.Name = "lblMaDocGia";
            this.lblMaDocGia.Size = new System.Drawing.Size(63, 16);
            this.lblMaDocGia.TabIndex = 5;
            this.lblMaDocGia.Text = "Mã Độc giả";
            // 
            // txtMaPhieuMuon
            // 
            this.txtMaPhieuMuon.Location = new System.Drawing.Point(100, 65);
            this.txtMaPhieuMuon.Name = "txtMaPhieuMuon";
            this.txtMaPhieuMuon.Size = new System.Drawing.Size(115, 22);
            this.txtMaPhieuMuon.TabIndex = 2;
            // 
            // lblMaPhieuMuon
            // 
            this.lblMaPhieuMuon.AutoSize = true;
            this.lblMaPhieuMuon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaPhieuMuon.Location = new System.Drawing.Point(10, 68);
            this.lblMaPhieuMuon.Name = "lblMaPhieuMuon";
            this.lblMaPhieuMuon.Size = new System.Drawing.Size(116, 20);
            this.lblMaPhieuMuon.TabIndex = 1;
            this.lblMaPhieuMuon.Text = "Mã PM*";
            // 
            // lblThongTinMuonHeader
            // 
            this.lblThongTinMuonHeader.AutoSize = true;
            this.lblThongTinMuonHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblThongTinMuonHeader.Location = new System.Drawing.Point(10, 10);
            this.lblThongTinMuonHeader.Name = "lblThongTinMuonHeader";
            this.lblThongTinMuonHeader.Size = new System.Drawing.Size(175, 28);
            this.lblThongTinMuonHeader.TabIndex = 0;
            this.lblThongTinMuonHeader.Text = "Thông Tin Mượn";
            // 
            // pnlThongTinSach
            // 
            this.pnlThongTinSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThongTinSach.Controls.Add(this.txtTenTacGia);
            this.pnlThongTinSach.Controls.Add(this.lblTenTacGia);
            this.pnlThongTinSach.Controls.Add(this.txtSoLuongCon);
            this.pnlThongTinSach.Controls.Add(this.lblSoLuongCon);
            this.pnlThongTinSach.Controls.Add(this.cboTenSach);
            this.pnlThongTinSach.Controls.Add(this.lblTenSach);
            this.pnlThongTinSach.Controls.Add(this.btnTimSach);
            this.pnlThongTinSach.Controls.Add(this.cboMaSach);
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
            this.txtTenTacGia.Location = new System.Drawing.Point(120, 155);
            this.txtTenTacGia.Name = "txtTenTacGia";
            this.txtTenTacGia.ReadOnly = true;
            this.txtTenTacGia.Size = new System.Drawing.Size(300, 22);
            this.txtTenTacGia.TabIndex = 9;
            // 
            // lblTenTacGia
            // 
            this.lblTenTacGia.AutoSize = true;
            this.lblTenTacGia.Location = new System.Drawing.Point(10, 158);
            this.lblTenTacGia.Name = "lblTenTacGia";
            this.lblTenTacGia.Size = new System.Drawing.Size(73, 16);
            this.lblTenTacGia.TabIndex = 8;
            this.lblTenTacGia.Text = "Tên Tác Giả";
            // 
            // txtSoLuongCon
            // 
            this.txtSoLuongCon.Location = new System.Drawing.Point(120, 125);
            this.txtSoLuongCon.Name = "txtSoLuongCon";
            this.txtSoLuongCon.ReadOnly = true;
            this.txtSoLuongCon.Size = new System.Drawing.Size(300, 22);
            this.txtSoLuongCon.TabIndex = 7;
            // 
            // lblSoLuongCon
            // 
            this.lblSoLuongCon.AutoSize = true;
            this.lblSoLuongCon.Location = new System.Drawing.Point(10, 128);
            this.lblSoLuongCon.Name = "lblSoLuongCon";
            this.lblSoLuongCon.Size = new System.Drawing.Size(89, 16);
            this.lblSoLuongCon.TabIndex = 6;
            this.lblSoLuongCon.Text = "Số Lượng còn";
            // 
            // cboTenSach
            // 
            this.cboTenSach.Location = new System.Drawing.Point(120, 95);
            this.cboTenSach.Name = "cboTenSach";
            this.cboTenSach.Size = new System.Drawing.Size(300, 24);
            this.cboTenSach.TabIndex = 5;
            // 
            // lblTenSach
            // 
            this.lblTenSach.AutoSize = true;
            this.lblTenSach.Location = new System.Drawing.Point(10, 98);
            this.lblTenSach.Name = "lblTenSach";
            this.lblTenSach.Size = new System.Drawing.Size(63, 16);
            this.lblTenSach.TabIndex = 4;
            this.lblTenSach.Text = "Tên Sách";
            // 
            // btnTimSach
            // 
            this.btnTimSach.Location = new System.Drawing.Point(430, 65);
            this.btnTimSach.Name = "btnTimSach";
            this.btnTimSach.Size = new System.Drawing.Size(30, 24);
            this.btnTimSach.TabIndex = 3;
            this.btnTimSach.Text = "🔍";
            this.btnTimSach.UseVisualStyleBackColor = true;
            // 
            // cboMaSach
            // 
            this.cboMaSach.Location = new System.Drawing.Point(120, 65);
            this.cboMaSach.Name = "cboMaSach";
            this.cboMaSach.Size = new System.Drawing.Size(300, 24);
            this.cboMaSach.TabIndex = 2;
            // 
            // lblMaSach
            // 
            this.lblMaSach.AutoSize = true;
            this.lblMaSach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaSach.Location = new System.Drawing.Point(10, 68);
            this.lblMaSach.Name = "lblMaSach";
            this.lblMaSach.Size = new System.Drawing.Size(67, 20);
            this.lblMaSach.TabIndex = 1;
            this.lblMaSach.Text = "Mã Sách*";
            // 
            // lblThongTinSachHeader
            // 
            this.lblThongTinSachHeader.AutoSize = true;
            this.lblThongTinSachHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblThongTinSachHeader.Location = new System.Drawing.Point(10, 10);
            this.lblThongTinSachHeader.Name = "lblThongTinSachHeader";
            this.lblThongTinSachHeader.Size = new System.Drawing.Size(161, 28);
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
            this.txtTimKiem.Location = new System.Drawing.Point(150, 25); // Vị trí mới
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(570, 22); // Kích thước mở rộng
            this.txtTimKiem.TabIndex = 4;
            this.txtTimKiem.Text = "Search...";
            // 
            // lblNhapThongTin
            // 
            this.lblNhapThongTin.AutoSize = true;
            this.lblNhapThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNhapThongTin.Location = new System.Drawing.Point(10, 25); // Vị trí mới
            this.lblNhapThongTin.Name = "lblNhapThongTin";
            this.lblNhapThongTin.Size = new System.Drawing.Size(134, 23);
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
            this.lblFormTitle.Size = new System.Drawing.Size(193, 28);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "THÔNG TIN MƯỢN SÁCH";
            // 
            // FormMuonSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMuonSach";
            this.Text = "FormMuonSach";
            this.pnlBackground.ResumeLayout(false);
            this.pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMuonSach)).EndInit();
            this.pnlRightControls.ResumeLayout(false);
            this.pnlInput.ResumeLayout(false);
            this.pnlThongTinMuon.ResumeLayout(false);
            this.pnlThongTinMuon.PerformLayout();
            this.pnlThongTinSach.ResumeLayout(false);
            this.pnlThongTinSach.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // Khai báo lại các controls
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
        private System.Windows.Forms.Panel pnlThongTinMuon;
        private System.Windows.Forms.Label lblThongTinMuonHeader;
        private System.Windows.Forms.Panel pnlRightControls;
        private System.Windows.Forms.Button btnMuon;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Panel pnlGridContainer;
        private System.Windows.Forms.DataGridView dgvMuonSach;
        private System.Windows.Forms.ComboBox cboMaSach;
        private System.Windows.Forms.Label lblMaSach;
        private System.Windows.Forms.Button btnTimSach;
        private System.Windows.Forms.ComboBox cboTenSach;
        private System.Windows.Forms.Label lblTenSach;
        private System.Windows.Forms.TextBox txtTenTacGia;
        private System.Windows.Forms.Label lblTenTacGia;
        private System.Windows.Forms.TextBox txtSoLuongCon;
        private System.Windows.Forms.Label lblSoLuongCon;
        private System.Windows.Forms.TextBox txtMaPhieuMuon;
        private System.Windows.Forms.Label lblMaPhieuMuon;
        private System.Windows.Forms.ComboBox cboMaDocGia;
        private System.Windows.Forms.Label lblMaDocGia;
        private System.Windows.Forms.TextBox txtSLMuon;
        private System.Windows.Forms.Label lblSLMuon;
        private System.Windows.Forms.DateTimePicker dtpNgayMuon;
        private System.Windows.Forms.Label lblNgayMuon;
        private System.Windows.Forms.DateTimePicker dtpHenTra;
        private System.Windows.Forms.Label lblHenTra;
        private System.Windows.Forms.ComboBox cboTinhTrang;
        private System.Windows.Forms.Label lblTinhTrang;
    }
}