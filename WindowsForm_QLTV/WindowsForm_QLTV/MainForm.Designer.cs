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
        // Các nút menu chính
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Button btnSach;
        private System.Windows.Forms.Button btnQLMuonTra;
        private System.Windows.Forms.Button btnMuonTra;
        private System.Windows.Forms.Button btnThongTinCaNhan;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTrangChu;
        // Các nút đã bị xóa trong thiết kế ban đầu
        private System.Windows.Forms.Button btnTacGia;
        private System.Windows.Forms.Button btnNhaXuatBan;
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
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnNhaXuatBan = new System.Windows.Forms.Button();
            this.btnTacGia = new System.Windows.Forms.Button();
            this.pnlIconHeader = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLogoText = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslUsername = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlSidebar.SuspendLayout();
            this.pnlUserInfoSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlSidebar.Controls.Add(this.btnThoat);
            this.pnlSidebar.Controls.Add(this.btnThongTinCaNhan);
            this.pnlSidebar.Controls.Add(this.btnTaiKhoan);
            this.pnlSidebar.Controls.Add(this.btnMuonTra);
            this.pnlSidebar.Controls.Add(this.btnQLMuonTra);
            this.pnlSidebar.Controls.Add(this.btnSach);
            this.pnlSidebar.Controls.Add(this.btnTrangChu);
            this.pnlSidebar.Controls.Add(this.pnlUserInfoSidebar);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 50);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(240, 592);
            this.pnlSidebar.TabIndex = 2;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(0, 370);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnThoat.Size = new System.Drawing.Size(240, 50);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.UseVisualStyleBackColor = false;
            // 
            // btnThongTinCaNhan
            // 
            this.btnThongTinCaNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnThongTinCaNhan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongTinCaNhan.FlatAppearance.BorderSize = 0;
            this.btnThongTinCaNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongTinCaNhan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnThongTinCaNhan.ForeColor = System.Drawing.Color.White;
            this.btnThongTinCaNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongTinCaNhan.Location = new System.Drawing.Point(0, 320);
            this.btnThongTinCaNhan.Name = "btnThongTinCaNhan";
            this.btnThongTinCaNhan.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnThongTinCaNhan.Size = new System.Drawing.Size(240, 50);
            this.btnThongTinCaNhan.TabIndex = 1;
            this.btnThongTinCaNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongTinCaNhan.UseVisualStyleBackColor = false;
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.Location = new System.Drawing.Point(0, 270);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTaiKhoan.Size = new System.Drawing.Size(240, 50);
            this.btnTaiKhoan.TabIndex = 2;
            this.btnTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.UseVisualStyleBackColor = false;
            // 
            // btnMuonTra
            // 
            this.btnMuonTra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnMuonTra.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMuonTra.FlatAppearance.BorderSize = 0;
            this.btnMuonTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuonTra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMuonTra.ForeColor = System.Drawing.Color.White;
            this.btnMuonTra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMuonTra.Location = new System.Drawing.Point(0, 220);
            this.btnMuonTra.Name = "btnMuonTra";
            this.btnMuonTra.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMuonTra.Size = new System.Drawing.Size(240, 50);
            this.btnMuonTra.TabIndex = 3;
            this.btnMuonTra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMuonTra.UseVisualStyleBackColor = false;
            // 
            // btnQLMuonTra
            // 
            this.btnQLMuonTra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnQLMuonTra.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLMuonTra.FlatAppearance.BorderSize = 0;
            this.btnQLMuonTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLMuonTra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnQLMuonTra.ForeColor = System.Drawing.Color.White;
            this.btnQLMuonTra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLMuonTra.Location = new System.Drawing.Point(0, 170);
            this.btnQLMuonTra.Name = "btnQLMuonTra";
            this.btnQLMuonTra.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnQLMuonTra.Size = new System.Drawing.Size(240, 50);
            this.btnQLMuonTra.TabIndex = 4;
            this.btnQLMuonTra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLMuonTra.UseVisualStyleBackColor = false;
            // 
            // btnSach
            // 
            this.btnSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSach.FlatAppearance.BorderSize = 0;
            this.btnSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSach.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSach.ForeColor = System.Drawing.Color.White;
            this.btnSach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSach.Location = new System.Drawing.Point(0, 120);
            this.btnSach.Name = "btnSach";
            this.btnSach.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSach.Size = new System.Drawing.Size(240, 50);
            this.btnSach.TabIndex = 5;
            this.btnSach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSach.UseVisualStyleBackColor = false;
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnTrangChu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTrangChu.FlatAppearance.BorderSize = 0;
            this.btnTrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangChu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTrangChu.ForeColor = System.Drawing.Color.White;
            this.btnTrangChu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrangChu.Location = new System.Drawing.Point(0, 70);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTrangChu.Size = new System.Drawing.Size(240, 50);
            this.btnTrangChu.TabIndex = 6;
            this.btnTrangChu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrangChu.UseVisualStyleBackColor = false;
            // 
            // pnlUserInfoSidebar
            // 
            this.pnlUserInfoSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlUserInfoSidebar.Controls.Add(this.lblUserNameHeader);
            this.pnlUserInfoSidebar.Controls.Add(this.lblUserRoleHeader);
            this.pnlUserInfoSidebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUserInfoSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlUserInfoSidebar.Name = "pnlUserInfoSidebar";
            this.pnlUserInfoSidebar.Size = new System.Drawing.Size(240, 70);
            this.pnlUserInfoSidebar.TabIndex = 7;
            // 
            // lblUserNameHeader
            // 
            this.lblUserNameHeader.AutoSize = true;
            this.lblUserNameHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserNameHeader.ForeColor = System.Drawing.Color.White;
            this.lblUserNameHeader.Location = new System.Drawing.Point(10, 15);
            this.lblUserNameHeader.Name = "lblUserNameHeader";
            this.lblUserNameHeader.Size = new System.Drawing.Size(178, 23);
            this.lblUserNameHeader.TabIndex = 0;
            this.lblUserNameHeader.Text = "MÃ TK: [USERNAME]";
            // 
            // lblUserRoleHeader
            // 
            this.lblUserRoleHeader.AutoSize = true;
            this.lblUserRoleHeader.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUserRoleHeader.ForeColor = System.Drawing.Color.LightGray;
            this.lblUserRoleHeader.Location = new System.Drawing.Point(10, 40);
            this.lblUserRoleHeader.Name = "lblUserRoleHeader";
            this.lblUserRoleHeader.Size = new System.Drawing.Size(104, 20);
            this.lblUserRoleHeader.TabIndex = 1;
            this.lblUserRoleHeader.Text = "Vai trò: [ROLE]";
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCao.Location = new System.Drawing.Point(0, 0);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(75, 50);
            this.btnBaoCao.TabIndex = 0;
            // 
            // btnNhaXuatBan
            // 
            this.btnNhaXuatBan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhaXuatBan.Location = new System.Drawing.Point(0, 0);
            this.btnNhaXuatBan.Name = "btnNhaXuatBan";
            this.btnNhaXuatBan.Size = new System.Drawing.Size(75, 50);
            this.btnNhaXuatBan.TabIndex = 0;
            // 
            // btnTacGia
            // 
            this.btnTacGia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTacGia.Location = new System.Drawing.Point(0, 0);
            this.btnTacGia.Name = "btnTacGia";
            this.btnTacGia.Size = new System.Drawing.Size(75, 50);
            this.btnTacGia.TabIndex = 0;
            // 
            // pnlIconHeader
            // 
            this.pnlIconHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlIconHeader.Name = "pnlIconHeader";
            this.pnlIconHeader.Size = new System.Drawing.Size(200, 100);
            this.pnlIconHeader.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblLogoText);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1223, 50);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(240, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(983, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ THƯ VIỆN TRƯỜNG ĐẠI HỌC CÔNG THƯƠNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLogoText
            // 
            this.lblLogoText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblLogoText.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLogoText.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLogoText.ForeColor = System.Drawing.Color.White;
            this.lblLogoText.Location = new System.Drawing.Point(0, 0);
            this.lblLogoText.Name = "lblLogoText";
            this.lblLogoText.Size = new System.Drawing.Size(240, 50);
            this.lblLogoText.TabIndex = 1;
            this.lblLogoText.Text = "THƯ VIỆN";
            this.lblLogoText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(240, 50);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(983, 592);
            this.pnlContent.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslUsername});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(200, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Visible = false;
            // 
            // tsslUsername
            // 
            this.tsslUsername.Name = "tsslUsername";
            this.tsslUsername.Size = new System.Drawing.Size(0, 16);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1223, 642);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSidebar.ResumeLayout(false);
            this.pnlUserInfoSidebar.ResumeLayout(false);
            this.pnlUserInfoSidebar.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}