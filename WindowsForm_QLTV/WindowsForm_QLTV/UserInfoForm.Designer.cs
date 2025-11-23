namespace WindowsForm_QLTV
{
    partial class UserInfoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.Label lblHoVaTen;
        private System.Windows.Forms.Label lblMaUser;

        // Các control thay thế
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnEditSave; // Nút Chỉnh sửa/Lưu
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.TextBox txtHoVaTen;
        private System.Windows.Forms.TextBox txtMaUserDetail;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.Label lblTenDangNhapValue;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblRoleValue;


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
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnEditSave = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.txtHoVaTen = new System.Windows.Forms.TextBox();
            this.txtMaUserDetail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblHoVaTen = new System.Windows.Forms.Label();
            this.lblMaUser = new System.Windows.Forms.Label();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.lblTenDangNhapValue = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblRoleValue = new System.Windows.Forms.Label();

            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblHeader.Location = new System.Drawing.Point(30, 30);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(262, 41);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "THÔNG TIN CÁ NHÂN";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.btnEditSave);
            this.pnlMain.Controls.Add(this.btnLogout);
            this.pnlMain.Controls.Add(this.txtEmail);
            this.pnlMain.Controls.Add(this.txtSDT);
            this.pnlMain.Controls.Add(this.dtpNgaySinh);
            this.pnlMain.Controls.Add(this.cboGioiTinh);
            this.pnlMain.Controls.Add(this.txtHoVaTen);
            this.pnlMain.Controls.Add(this.txtMaUserDetail);
            this.pnlMain.Controls.Add(this.lblEmail);
            this.pnlMain.Controls.Add(this.lblSDT);
            this.pnlMain.Controls.Add(this.lblNgaySinh);
            this.pnlMain.Controls.Add(this.lblGioiTinh);
            this.pnlMain.Controls.Add(this.lblHoVaTen);
            this.pnlMain.Controls.Add(this.lblMaUser);
            this.pnlMain.Controls.Add(this.lblTenDangNhap);
            this.pnlMain.Controls.Add(this.lblTenDangNhapValue);
            this.pnlMain.Controls.Add(this.lblRole);
            this.pnlMain.Controls.Add(this.lblRoleValue);
            this.pnlMain.Location = new System.Drawing.Point(30, 90);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(700, 500);
            this.pnlMain.TabIndex = 1;

            // --- Giá trị không đổi (Status) ---

            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTenDangNhap.Location = new System.Drawing.Point(30, 70);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(130, 23);
            this.lblTenDangNhap.TabIndex = 1;
            this.lblTenDangNhap.Text = "Tên đăng nhập:";

            // 
            // lblTenDangNhapValue
            // 
            this.lblTenDangNhapValue.AutoSize = true;
            this.lblTenDangNhapValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTenDangNhapValue.ForeColor = System.Drawing.Color.Black;
            this.lblTenDangNhapValue.Location = new System.Drawing.Point(230, 70);
            this.lblTenDangNhapValue.Name = "lblTenDangNhapValue";
            this.lblTenDangNhapValue.Size = new System.Drawing.Size(100, 23);
            this.lblTenDangNhapValue.TabIndex = 8;
            this.lblTenDangNhapValue.Text = "[username]";

            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRole.Location = new System.Drawing.Point(30, 30);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(70, 23);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Chức vụ:";

            // 
            // lblRoleValue
            // 
            this.lblRoleValue.AutoSize = true;
            this.lblRoleValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRoleValue.ForeColor = System.Drawing.Color.Black;
            this.lblRoleValue.Location = new System.Drawing.Point(230, 30);
            this.lblRoleValue.Name = "lblRoleValue";
            this.lblRoleValue.Size = new System.Drawing.Size(55, 23);
            this.lblRoleValue.TabIndex = 8;
            this.lblRoleValue.Text = "[Role]";

            // 
            // lblMaUser
            // 
            this.lblMaUser.AutoSize = true;
            this.lblMaUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaUser.Location = new System.Drawing.Point(30, 110);
            this.lblMaUser.Name = "lblMaUser";
            this.lblMaUser.Size = new System.Drawing.Size(120, 23);
            this.lblMaUser.TabIndex = 1;
            this.lblMaUser.Text = "Mã Người Dùng:";

            // 
            // txtMaUserDetail
            // 
            this.txtMaUserDetail.Location = new System.Drawing.Point(230, 110);
            this.txtMaUserDetail.Name = "txtMaUserDetail";
            this.txtMaUserDetail.ReadOnly = true;
            this.txtMaUserDetail.Size = new System.Drawing.Size(200, 22);
            this.txtMaUserDetail.TabIndex = 8;

            // --- Giá trị có thể thay đổi (Editable) ---

            // 
            // lblHoVaTen
            // 
            this.lblHoVaTen.AutoSize = true;
            this.lblHoVaTen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHoVaTen.Location = new System.Drawing.Point(30, 150);
            this.lblHoVaTen.Name = "lblHoVaTen";
            this.lblHoVaTen.Size = new System.Drawing.Size(95, 23);
            this.lblHoVaTen.TabIndex = 2;
            this.lblHoVaTen.Text = "Họ và Tên:";

            // 
            // txtHoVaTen
            // 
            this.txtHoVaTen.Location = new System.Drawing.Point(230, 150);
            this.txtHoVaTen.Name = "txtHoVaTen";
            this.txtHoVaTen.Size = new System.Drawing.Size(250, 22);
            this.txtHoVaTen.TabIndex = 9;

            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGioiTinh.Location = new System.Drawing.Point(30, 190);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(83, 23);
            this.lblGioiTinh.TabIndex = 3;
            this.lblGioiTinh.Text = "Giới tính:";

            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cboGioiTinh.Location = new System.Drawing.Point(230, 190);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(150, 24);
            this.cboGioiTinh.TabIndex = 10;

            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNgaySinh.Location = new System.Drawing.Point(30, 230);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(95, 23);
            this.lblNgaySinh.TabIndex = 4;
            this.lblNgaySinh.Text = "Ngày sinh:";

            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(230, 230);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(150, 22);
            this.dtpNgaySinh.TabIndex = 11;

            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSDT.Location = new System.Drawing.Point(30, 270);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(125, 23);
            this.lblSDT.TabIndex = 5;
            this.lblSDT.Text = "Số điện thoại:";

            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(230, 270);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(250, 22);
            this.txtSDT.TabIndex = 12;

            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Location = new System.Drawing.Point(30, 310);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(60, 23);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";

            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(230, 310);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 22);
            this.txtEmail.TabIndex = 13;

            // --- Nút Chức năng ---

            // 
            // btnEditSave
            // 
            this.btnEditSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219))))); // Xanh dương
            this.btnEditSave.FlatAppearance.BorderSize = 0;
            this.btnEditSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditSave.ForeColor = System.Drawing.Color.White;
            this.btnEditSave.Location = new System.Drawing.Point(30, 380);
            this.btnEditSave.Name = "btnEditSave";
            this.btnEditSave.Size = new System.Drawing.Size(150, 40);
            this.btnEditSave.TabIndex = 15;
            this.btnEditSave.Text = "Chỉnh Sửa";
            this.btnEditSave.UseVisualStyleBackColor = false;

            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Crimson;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(520, 380);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(150, 40);
            this.btnLogout.TabIndex = 14;
            this.btnLogout.Text = "Đăng Xuất";
            this.btnLogout.UseVisualStyleBackColor = false;

            // 
            // UserInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserInfoForm";
            this.Text = "UserInfoForm";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}