namespace WindowsForm_QLTV
{
    partial class UserInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblEmailValue = new System.Windows.Forms.Label();
            this.lblSDTValue = new System.Windows.Forms.Label();
            this.lblNgaySinhValue = new System.Windows.Forms.Label();
            this.lblGioiTinhValue = new System.Windows.Forms.Label();
            this.lblHoVaTenValue = new System.Windows.Forms.Label();
            this.lblMaSVValue = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblHoVaTen = new System.Windows.Forms.Label();
            this.lblMaSV = new System.Windows.Forms.Label();
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
            this.pnlMain.Controls.Add(this.btnLogout);
            this.pnlMain.Controls.Add(this.lblEmailValue);
            this.pnlMain.Controls.Add(this.lblSDTValue);
            this.pnlMain.Controls.Add(this.lblNgaySinhValue);
            this.pnlMain.Controls.Add(this.lblGioiTinhValue);
            this.pnlMain.Controls.Add(this.lblHoVaTenValue);
            this.pnlMain.Controls.Add(this.lblMaSVValue);
            this.pnlMain.Controls.Add(this.lblEmail);
            this.pnlMain.Controls.Add(this.lblSDT);
            this.pnlMain.Controls.Add(this.lblNgaySinh);
            this.pnlMain.Controls.Add(this.lblGioiTinh);
            this.pnlMain.Controls.Add(this.lblHoVaTen);
            this.pnlMain.Controls.Add(this.lblMaSV);
            this.pnlMain.Location = new System.Drawing.Point(30, 90);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(700, 420);
            this.pnlMain.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Crimson;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(30, 350); // Đã dịch chuyển sang trái
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(150, 40);
            this.btnLogout.TabIndex = 14;
            this.btnLogout.Text = "Đăng Xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // lblEmailValue
            // 
            this.lblEmailValue.AutoSize = true;
            this.lblEmailValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmailValue.ForeColor = System.Drawing.Color.Black;
            this.lblEmailValue.Location = new System.Drawing.Point(230, 270); // Đã dịch chuyển
            this.lblEmailValue.Name = "lblEmailValue";
            this.lblEmailValue.Size = new System.Drawing.Size(89, 23);
            this.lblEmailValue.TabIndex = 13;
            this.lblEmailValue.Text = "[Email@...]";
            // 
            // lblSDTValue
            // 
            this.lblSDTValue.AutoSize = true;
            this.lblSDTValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSDTValue.ForeColor = System.Drawing.Color.Black;
            this.lblSDTValue.Location = new System.Drawing.Point(230, 230); // Đã dịch chuyển
            this.lblSDTValue.Name = "lblSDTValue";
            this.lblSDTValue.Size = new System.Drawing.Size(109, 23);
            this.lblSDTValue.TabIndex = 12;
            this.lblSDTValue.Text = "[09xxxxxxxx]";
            // 
            // lblNgaySinhValue
            // 
            this.lblNgaySinhValue.AutoSize = true;
            this.lblNgaySinhValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNgaySinhValue.ForeColor = System.Drawing.Color.Black;
            this.lblNgaySinhValue.Location = new System.Drawing.Point(230, 190); // Đã dịch chuyển
            this.lblNgaySinhValue.Name = "lblNgaySinhValue";
            this.lblNgaySinhValue.Size = new System.Drawing.Size(117, 23);
            this.lblNgaySinhValue.TabIndex = 11;
            this.lblNgaySinhValue.Text = "[DD/MM/YYYY]";
            // 
            // lblGioiTinhValue
            // 
            this.lblGioiTinhValue.AutoSize = true;
            this.lblGioiTinhValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGioiTinhValue.ForeColor = System.Drawing.Color.Black;
            this.lblGioiTinhValue.Location = new System.Drawing.Point(230, 150); // Đã dịch chuyển
            this.lblGioiTinhValue.Name = "lblGioiTinhValue";
            this.lblGioiTinhValue.Size = new System.Drawing.Size(65, 23);
            this.lblGioiTinhValue.TabIndex = 10;
            this.lblGioiTinhValue.Text = "[Nam/Nữ]";
            // 
            // lblHoVaTenValue
            // 
            this.lblHoVaTenValue.AutoSize = true;
            this.lblHoVaTenValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHoVaTenValue.ForeColor = System.Drawing.Color.Black;
            this.lblHoVaTenValue.Location = new System.Drawing.Point(230, 110); // Đã dịch chuyển
            this.lblHoVaTenValue.Name = "lblHoVaTenValue";
            this.lblHoVaTenValue.Size = new System.Drawing.Size(126, 23);
            this.lblHoVaTenValue.TabIndex = 9;
            this.lblHoVaTenValue.Text = "[Họ và Tên SV]";
            // 
            // lblMaSVValue
            // 
            this.lblMaSVValue.AutoSize = true;
            this.lblMaSVValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaSVValue.ForeColor = System.Drawing.Color.Black;
            this.lblMaSVValue.Location = new System.Drawing.Point(230, 70); // Đã dịch chuyển
            this.lblMaSVValue.Name = "lblMaSVValue";
            this.lblMaSVValue.Size = new System.Drawing.Size(53, 23);
            this.lblMaSVValue.TabIndex = 8;
            this.lblMaSVValue.Text = "[ID #]";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Location = new System.Drawing.Point(30, 270); // Đã dịch chuyển sang trái
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(60, 23);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSDT.Location = new System.Drawing.Point(30, 230); // Đã dịch chuyển sang trái
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(125, 23);
            this.lblSDT.TabIndex = 5;
            this.lblSDT.Text = "Số điện thoại:";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNgaySinh.Location = new System.Drawing.Point(30, 190); // Đã dịch chuyển sang trái
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(95, 23);
            this.lblNgaySinh.TabIndex = 4;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGioiTinh.Location = new System.Drawing.Point(30, 150); // Đã dịch chuyển sang trái
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(83, 23);
            this.lblGioiTinh.TabIndex = 3;
            this.lblGioiTinh.Text = "Giới tính:";
            // 
            // lblHoVaTen
            // 
            this.lblHoVaTen.AutoSize = true;
            this.lblHoVaTen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHoVaTen.Location = new System.Drawing.Point(30, 110); // Đã dịch chuyển sang trái
            this.lblHoVaTen.Name = "lblHoVaTen";
            this.lblHoVaTen.Size = new System.Drawing.Size(95, 23);
            this.lblHoVaTen.TabIndex = 2;
            this.lblHoVaTen.Text = "Họ và Tên:";
            // 
            // lblMaSV
            // 
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaSV.Location = new System.Drawing.Point(30, 70); // Đã dịch chuyển sang trái
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Size = new System.Drawing.Size(65, 23);
            this.lblMaSV.TabIndex = 1;
            this.lblMaSV.Text = "Mã SV:";
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

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlMain;
        // Bỏ Panel pnlImage
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.Label lblHoVaTen;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.Label lblMaSVValue;
        private System.Windows.Forms.Label lblEmailValue;
        private System.Windows.Forms.Label lblSDTValue;
        private System.Windows.Forms.Label lblNgaySinhValue;
        private System.Windows.Forms.Label lblGioiTinhValue;
        private System.Windows.Forms.Label lblHoVaTenValue;
        private System.Windows.Forms.Button btnLogout;
    }
}