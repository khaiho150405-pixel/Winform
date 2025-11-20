namespace WindowsForm_QLTV
{
    partial class MainForm
    {
        // KHAI BÁO CÁC CONTROLS CẦN CÓ Ở ĐẦU LỚP
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslUsername;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Button btnSach;
        private System.Windows.Forms.Button btnTacGia;
        private System.Windows.Forms.Button btnNhaXuatBan;
        private System.Windows.Forms.Button btnQLMuonTra; // QUẢN LÝ CHUNG
        private System.Windows.Forms.Button btnMuonTra;   // CHỨC NĂNG PHỤ
        private System.Windows.Forms.Button btnThongTinCaNhan;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Panel pnlUserInfoSidebar;
        private System.Windows.Forms.Label lblUserRoleHeader;
        private System.Windows.Forms.Label lblUserNameHeader;
        private System.Windows.Forms.Panel pnlIconHeader;
        private System.Windows.Forms.Label lblLogoText;


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
            // Khởi tạo Controls
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThongTinCaNhan = new System.Windows.Forms.Button();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnMuonTra = new System.Windows.Forms.Button();
            this.btnQLMuonTra = new System.Windows.Forms.Button();
            this.btnSach = new System.Windows.Forms.Button();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.pnlUserInfoSidebar = new System.Windows.Forms.Panel();
            this.lblUserNameHeader = new System.Windows.Forms.Label();
            this.lblUserRoleHeader = new System.Windows.Forms.Label();
            this.pnlIconHeader = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLogoText = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslUsername = new System.Windows.Forms.ToolStripStatusLabel();
            // Khai báo các control cũ không dùng
            this.btnTacGia = new System.Windows.Forms.Button();
            this.btnNhaXuatBan = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();

            this.pnlSidebar.SuspendLayout();
            this.pnlUserInfoSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainForm Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Text = "Hệ Thống Quản Lý Thư Viện";
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            // ----------------------------------------------------------------
            // --- Cấu hình pnlSidebar (Panel bên trái - Menu) ---
            // ----------------------------------------------------------------
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Width = 240;

            // Controls được thêm theo thứ tự logic mới
            this.pnlSidebar.Controls.Add(this.btnThoat);
            this.pnlSidebar.Controls.Add(this.btnThongTinCaNhan);
            this.pnlSidebar.Controls.Add(this.btnTaiKhoan);
            this.pnlSidebar.Controls.Add(this.btnMuonTra);
            this.pnlSidebar.Controls.Add(this.btnQLMuonTra);
            this.pnlSidebar.Controls.Add(this.btnSach);
            this.pnlSidebar.Controls.Add(this.btnTrangChu);
            this.pnlSidebar.Controls.Add(this.pnlUserInfoSidebar);

            this.pnlSidebar.Location = new System.Drawing.Point(0, 50);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(240, 700);
            this.pnlSidebar.TabIndex = 2;

            // Cấu hình Buttons trong Sidebar 
            System.Drawing.Font buttonFont = new System.Drawing.Font("Segoe UI", 10F);
            System.Drawing.Color defaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));

            // Cấu hình btnThoat
            this.btnThoat.Text = " 🚪 Thoát";
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThoat.Height = 50;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.BackColor = defaultBackColor;
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Font = buttonFont;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; // ĐÃ SỬA LỖI Ở ĐÂY
            this.btnThoat.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);

            // Cấu hình btnThongTinCaNhan
            this.btnThongTinCaNhan.Text = " 👤 Thông tin cá nhân";
            this.btnThongTinCaNhan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongTinCaNhan.Height = 50;
            this.btnThongTinCaNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongTinCaNhan.FlatAppearance.BorderSize = 0;
            this.btnThongTinCaNhan.BackColor = defaultBackColor;
            this.btnThongTinCaNhan.ForeColor = System.Drawing.Color.White;
            this.btnThongTinCaNhan.Font = buttonFont;
            this.btnThongTinCaNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongTinCaNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; // ĐÃ SỬA LỖI Ở ĐÂY
            this.btnThongTinCaNhan.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);

            // Cấu hình btnTaiKhoan (Quản lý tài khoản)
            this.btnTaiKhoan.Text = " 🔑 Quản lý tài khoản";
            this.btnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTaiKhoan.Height = 50;
            this.btnTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnTaiKhoan.BackColor = defaultBackColor;
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnTaiKhoan.Font = buttonFont;
            this.btnTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; // ĐÃ SỬA LỖI Ở ĐÂY
            this.btnTaiKhoan.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);

            // Cấu hình btnMuonTra (MƯỢN TRẢ SÁCH - Chức năng trực tiếp)
            this.btnMuonTra.Text = " 📚 Mượn trả sách";
            this.btnMuonTra.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMuonTra.Height = 50;
            this.btnMuonTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuonTra.FlatAppearance.BorderSize = 0;
            this.btnMuonTra.BackColor = defaultBackColor;
            this.btnMuonTra.ForeColor = System.Drawing.Color.White;
            this.btnMuonTra.Font = buttonFont;
            this.btnMuonTra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMuonTra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; // ĐÃ SỬA LỖI Ở ĐÂY
            this.btnMuonTra.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);

            // Cấu hình btnQLMuonTra (QUẢN LÝ MƯỢN TRẢ)
            this.btnQLMuonTra.Text = " 📜 Quản lý mượn trả";
            this.btnQLMuonTra.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLMuonTra.Height = 50;
            this.btnQLMuonTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLMuonTra.FlatAppearance.BorderSize = 0;
            this.btnQLMuonTra.BackColor = defaultBackColor;
            this.btnQLMuonTra.ForeColor = System.Drawing.Color.White;
            this.btnQLMuonTra.Font = buttonFont;
            this.btnQLMuonTra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLMuonTra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; // ĐÃ SỬA LỖI Ở ĐÂY
            this.btnQLMuonTra.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);

            // Cấu hình btnSach (Quản lý sách)
            this.btnSach.Text = " 📖 Quản lý sách";
            this.btnSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSach.Height = 50;
            this.btnSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSach.FlatAppearance.BorderSize = 0;
            this.btnSach.BackColor = defaultBackColor;
            this.btnSach.ForeColor = System.Drawing.Color.White;
            this.btnSach.Font = buttonFont;
            this.btnSach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; // ĐÃ SỬA LỖI Ở ĐÂY
            this.btnSach.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);

            // Cấu hình btnTrangChu
            this.btnTrangChu.Text = " 🏠 Trang chủ";
            this.btnTrangChu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTrangChu.Height = 50;
            this.btnTrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangChu.FlatAppearance.BorderSize = 0;
            this.btnTrangChu.BackColor = defaultBackColor;
            this.btnTrangChu.ForeColor = System.Drawing.Color.White;
            this.btnTrangChu.Font = buttonFont;
            this.btnTrangChu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrangChu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; // ĐÃ SỬA LỖI Ở ĐÂY
            this.btnTrangChu.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);


            // --- Cấu hình pnlUserInfoSidebar (Khu vực Chào mừng) ---
            this.pnlUserInfoSidebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUserInfoSidebar.Height = 70;
            this.pnlUserInfoSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlUserInfoSidebar.Controls.Add(this.lblUserNameHeader);
            this.pnlUserInfoSidebar.Controls.Add(this.lblUserRoleHeader);

            // Cấu hình lblUserNameHeader (Mã tài khoản)
            this.lblUserNameHeader.AutoSize = true;
            this.lblUserNameHeader.Location = new System.Drawing.Point(10, 15);
            this.lblUserNameHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserNameHeader.ForeColor = System.Drawing.Color.White;
            this.lblUserNameHeader.Text = "MÃ TK: [USERNAME]";

            // Cấu hình lblUserRoleHeader (Vai trò)
            this.lblUserRoleHeader.AutoSize = true;
            this.lblUserRoleHeader.Location = new System.Drawing.Point(10, 40);
            this.lblUserRoleHeader.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUserRoleHeader.ForeColor = System.Drawing.Color.LightGray;
            this.lblUserRoleHeader.Text = "Vai trò: [ROLE]";


            // ----------------------------------------------------------------
            // --- Cấu hình pnlHeader (Panel trên cùng) ---
            // ----------------------------------------------------------------
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 50;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblLogoText);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 50);
            this.pnlHeader.TabIndex = 1;

            // Cấu hình lblLogoText (Phần THƯ VIỆN/LOGO bên trái Header)
            this.lblLogoText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblLogoText.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLogoText.Width = 240; // Chiều rộng mới
            this.lblLogoText.Text = "THƯ VIỆN";
            this.lblLogoText.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLogoText.ForeColor = System.Drawing.Color.White;
            this.lblLogoText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogoText.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);

            // Cấu hình lblTitle (Tiêu đề chính)
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ THƯ VIỆN TRƯỜNG ĐẠI HỌC CÔNG THƯƠNG";
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;

            // ----------------------------------------------------------------
            // --- Cấu hình pnlContent (Khu vực nội dung chính) ---
            // ----------------------------------------------------------------
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(240, 50); // Location mới
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(960, 700); // Size mới (1200 - 240 = 960)
            this.pnlContent.BackColor = System.Drawing.Color.White;

            // ----------------------------------------------------------------
            // --- Cấu hình statusStrip1 (Không hiển thị, nhưng giữ lại) ---
            // ----------------------------------------------------------------
            this.statusStrip1.Visible = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tsslUsername});
            // ----------------------------------------------------------------
            // --- Thêm các Control chính vào Form ---
            // ----------------------------------------------------------------
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.statusStrip1);

            // Bố cục kết thúc
            this.pnlSidebar.ResumeLayout(false);
            this.pnlUserInfoSidebar.ResumeLayout(false);
            this.pnlUserInfoSidebar.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            // Xóa các control không dùng để tránh lỗi biên dịch/Designer
            this.btnTacGia.Dispose();
            this.btnNhaXuatBan.Dispose();
            this.btnBaoCao.Dispose();
            this.pnlIconHeader.Dispose();
        }

        #endregion
    }
}