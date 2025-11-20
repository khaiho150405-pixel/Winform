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
            // Khởi tạo các Controls
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
            // Thiết lập Form (Login)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke; // Nền Form
            this.ClientSize = new System.Drawing.Size(450, 500);
            this.Controls.Add(this.pnlMainContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập Hệ Thống";
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);

            // 
            // pnlMainContainer (Căn giữa nội dung)
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
            this.pnlMainContainer.Size = new System.Drawing.Size(350, 420);

            // 
            // lblTitle (Tiêu đề chính)
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(0, 30);
            this.lblTitle.Size = new System.Drawing.Size(350, 40);
            this.lblTitle.Text = "Đăng Nhập";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblTentaikhoan
            // 
            this.lblTentaikhoan.AutoSize = true;
            this.lblTentaikhoan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTentaikhoan.Location = new System.Drawing.Point(30, 95);
            this.lblTentaikhoan.Text = "Tên Tài Khoản";
            this.lblTentaikhoan.ForeColor = System.Drawing.Color.Gray;

            // 
            // txtTentaikhoan
            // 
            this.txtTentaikhoan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTentaikhoan.Location = new System.Drawing.Point(30, 118);
            this.txtTentaikhoan.Size = new System.Drawing.Size(290, 34);
            this.txtTentaikhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // 
            // lblMatkhau
            // 
            this.lblMatkhau.AutoSize = true;
            this.lblMatkhau.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatkhau.Location = new System.Drawing.Point(30, 175);
            this.lblMatkhau.Text = "Mật Khẩu";
            this.lblMatkhau.ForeColor = System.Drawing.Color.Gray;

            // 
            // txtMatkhau
            // 
            this.txtMatkhau.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatkhau.Location = new System.Drawing.Point(30, 198);
            this.txtMatkhau.Size = new System.Drawing.Size(290, 34);
            this.txtMatkhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatkhau.PasswordChar = '•';

            // 
            // btnDangnhap (Nút Chính)
            // 
            this.btnDangnhap.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDangnhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangnhap.FlatAppearance.BorderSize = 0;
            this.btnDangnhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangnhap.ForeColor = System.Drawing.Color.White;
            this.btnDangnhap.Location = new System.Drawing.Point(30, 270);
            this.btnDangnhap.Size = new System.Drawing.Size(290, 45);
            this.btnDangnhap.Text = "ĐĂNG NHẬP";
            this.btnDangnhap.UseVisualStyleBackColor = false;
            this.btnDangnhap.Click += new System.EventHandler(this.btnDangnhap_Click);

            // 
            // btnThoat (Nút Phụ/Hủy)
            // 
            this.btnThoat.BackColor = System.Drawing.Color.White;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnThoat.FlatAppearance.BorderSize = 1;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnThoat.Location = new System.Drawing.Point(30, 325);
            this.btnThoat.Size = new System.Drawing.Size(290, 40);
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // 
            // lblDangkyHint
            // 
            this.lblDangkyHint.AutoSize = true;
            this.lblDangkyHint.Location = new System.Drawing.Point(70, 385);
            this.lblDangkyHint.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangkyHint.Text = "Chưa có tài khoản?";

            // 
            // btnDangky
            // 
            this.btnDangky.BackColor = System.Drawing.Color.Transparent;
            this.btnDangky.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangky.FlatAppearance.BorderSize = 0;
            this.btnDangky.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangky.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnDangky.Location = new System.Drawing.Point(200, 380);
            this.btnDangky.Size = new System.Drawing.Size(80, 30);
            this.btnDangky.Text = "Đăng Ký";
            this.btnDangky.UseVisualStyleBackColor = true;

            // Kết thúc
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlMainContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Khai báo lại các controls ở cuối file Designer
        // (Chúng tôi đã khai báo chúng ở đầu file này, nên phần này thường chỉ là để ghi lại cấu trúc)
    }
}