namespace WindowsForm_QLTV
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Khai báo các Control cần thiết
        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTentaikhoan;
        private System.Windows.Forms.TextBox txtTentaikhoan;
        private System.Windows.Forms.Label lblMatkhau;
        private System.Windows.Forms.TextBox txtMatkhau;
        private System.Windows.Forms.Button btnDangnhap;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblDangkyHint;
        private System.Windows.Forms.Button btnDangky;

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
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.btnDangky = new System.Windows.Forms.Button();
            this.lblDangkyHint = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDangnhap = new System.Windows.Forms.Button();
            this.txtMatkhau = new System.Windows.Forms.TextBox();
            this.lblMatkhau = new System.Windows.Forms.Label();
            this.txtTentaikhoan = new System.Windows.Forms.TextBox();
            this.lblTentaikhoan = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlMainContainer.BackColor = System.Drawing.Color.White;
            this.pnlMainContainer.Controls.Add(this.btnDangky);
            this.pnlMainContainer.Controls.Add(this.lblDangkyHint);
            this.pnlMainContainer.Controls.Add(this.btnThoat);
            this.pnlMainContainer.Controls.Add(this.btnDangnhap);
            this.pnlMainContainer.Controls.Add(this.txtMatkhau);
            this.pnlMainContainer.Controls.Add(this.lblMatkhau);
            this.pnlMainContainer.Controls.Add(this.txtTentaikhoan);
            this.pnlMainContainer.Controls.Add(this.lblTentaikhoan);
            this.pnlMainContainer.Controls.Add(this.lblTitle);
            this.pnlMainContainer.Location = new System.Drawing.Point(50, 40);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(350, 420);
            this.pnlMainContainer.TabIndex = 0;
            // 
            // btnDangky
            // 
            this.btnDangky.BackColor = System.Drawing.Color.Transparent;
            this.btnDangky.FlatAppearance.BorderSize = 0;
            this.btnDangky.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangky.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangky.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnDangky.Location = new System.Drawing.Point(200, 380);
            this.btnDangky.Name = "btnDangky";
            this.btnDangky.Size = new System.Drawing.Size(80, 30);
            this.btnDangky.TabIndex = 0;
            this.btnDangky.Text = "Đăng Ký";
            this.btnDangky.UseVisualStyleBackColor = true;
            this.btnDangky.Click += new System.EventHandler(this.btnDangky_Click);
            // 
            // lblDangkyHint
            // 
            this.lblDangkyHint.AutoSize = true;
            this.lblDangkyHint.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangkyHint.Location = new System.Drawing.Point(70, 385);
            this.lblDangkyHint.Name = "lblDangkyHint";
            this.lblDangkyHint.Size = new System.Drawing.Size(157, 23);
            this.lblDangkyHint.TabIndex = 1;
            this.lblDangkyHint.Text = "Chưa có tài khoản?";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.White;
            this.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnThoat.Location = new System.Drawing.Point(30, 325);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(290, 40);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangnhap
            // 
            this.btnDangnhap.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDangnhap.FlatAppearance.BorderSize = 0;
            this.btnDangnhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangnhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangnhap.ForeColor = System.Drawing.Color.White;
            this.btnDangnhap.Location = new System.Drawing.Point(30, 270);
            this.btnDangnhap.Name = "btnDangnhap";
            this.btnDangnhap.Size = new System.Drawing.Size(290, 45);
            this.btnDangnhap.TabIndex = 3;
            this.btnDangnhap.Text = "ĐĂNG NHẬP";
            this.btnDangnhap.UseVisualStyleBackColor = false;
            this.btnDangnhap.Click += new System.EventHandler(this.btnDangnhap_Click);
            // 
            // txtMatkhau
            // 
            this.txtMatkhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatkhau.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatkhau.Location = new System.Drawing.Point(30, 198);
            this.txtMatkhau.Name = "txtMatkhau";
            this.txtMatkhau.PasswordChar = '•';
            this.txtMatkhau.Size = new System.Drawing.Size(290, 34);
            this.txtMatkhau.TabIndex = 4;
            // 
            // lblMatkhau
            // 
            this.lblMatkhau.AutoSize = true;
            this.lblMatkhau.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatkhau.ForeColor = System.Drawing.Color.Gray;
            this.lblMatkhau.Location = new System.Drawing.Point(30, 175);
            this.lblMatkhau.Name = "lblMatkhau";
            this.lblMatkhau.Size = new System.Drawing.Size(84, 23);
            this.lblMatkhau.TabIndex = 5;
            this.lblMatkhau.Text = "Mật Khẩu";
            // 
            // txtTentaikhoan
            // 
            this.txtTentaikhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTentaikhoan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTentaikhoan.Location = new System.Drawing.Point(30, 118);
            this.txtTentaikhoan.Name = "txtTentaikhoan";
            this.txtTentaikhoan.Size = new System.Drawing.Size(290, 34);
            this.txtTentaikhoan.TabIndex = 6;
            // 
            // lblTentaikhoan
            // 
            this.lblTentaikhoan.AutoSize = true;
            this.lblTentaikhoan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTentaikhoan.ForeColor = System.Drawing.Color.Gray;
            this.lblTentaikhoan.Location = new System.Drawing.Point(30, 95);
            this.lblTentaikhoan.Name = "lblTentaikhoan";
            this.lblTentaikhoan.Size = new System.Drawing.Size(115, 23);
            this.lblTentaikhoan.TabIndex = 7;
            this.lblTentaikhoan.Text = "Tên Tài Khoản";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(0, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(350, 40);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Đăng Nhập";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(450, 500);
            this.Controls.Add(this.pnlMainContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập Hệ Thống";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlMainContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // Khai báo lại các controls ở cuối file Designer
        // (Chúng tôi đã khai báo chúng ở đầu file này, nên phần này thường chỉ là để ghi lại cấu trúc)
    }
}