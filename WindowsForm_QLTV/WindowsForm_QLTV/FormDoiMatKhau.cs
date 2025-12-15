using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace WindowsForm_QLTV
{
    public partial class FormDoiMatKhau : Form
    {
        public FormDoiMatKhau()
        {
            InitializeComponent();
            this.Load += FormDoiMatKhau_Load;
            btnDoiMatKhau.Click += BtnDoiMatKhau_Click;
            btnHuy.Click += BtnHuy_Click;
        }

        private void FormDoiMatKhau_Load(object sender, EventArgs e)
        {
            // Hi?n th? thông tin ng??i dùng hi?n t?i
            lblTenDangNhap.Text = $"Tài kho?n: {Session.CurrentUsername}";
            txtMatKhauCu.Focus();
        }

        private void BtnDoiMatKhau_Click(object sender, EventArgs e)
        {
            // 1. Ki?m tra ??u vào
            string matKhauCu = txtMatKhauCu.Text;
            string matKhauMoi = txtMatKhauMoi.Text;
            string xacNhanMatKhau = txtXacNhanMatKhau.Text;

            if (string.IsNullOrWhiteSpace(matKhauCu))
            {
                MessageBox.Show("Vui lòng nh?p m?t kh?u c?.", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauCu.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(matKhauMoi))
            {
                MessageBox.Show("Vui lòng nh?p m?t kh?u m?i.", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            if (matKhauMoi.Length < 6)
            {
                MessageBox.Show("M?t kh?u m?i ph?i có ít nh?t 6 ký t?.", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            if (matKhauMoi != xacNhanMatKhau)
            {
                MessageBox.Show("M?t kh?u xác nh?n không kh?p v?i m?t kh?u m?i.", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMatKhau.Focus();
                return;
            }

            if (matKhauCu == matKhauMoi)
            {
                MessageBox.Show("M?t kh?u m?i ph?i khác m?t kh?u c?.", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            // 2. Xác th?c và ??i m?t kh?u
            try
            {
                using (var db = new Model1())
                {
                    // Tìm tài kho?n hi?n t?i
                    var taiKhoan = db.TAIKHOANs.FirstOrDefault(tk => tk.TENDANGNHAP == Session.CurrentUsername);

                    if (taiKhoan == null)
                    {
                        MessageBox.Show("Không tìm th?y tài kho?n. Vui lòng ??ng nh?p l?i.", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Ki?m tra m?t kh?u c?
                    if (taiKhoan.MATKHAU != matKhauCu)
                    {
                        MessageBox.Show("M?t kh?u c? không ?úng.", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMatKhauCu.Clear();
                        txtMatKhauCu.Focus();
                        return;
                    }

                    // C?p nh?t m?t kh?u m?i
                    taiKhoan.MATKHAU = matKhauMoi;
                    db.SaveChanges();

                    MessageBox.Show("??i m?t kh?u thành công!\nVui lòng s? d?ng m?t kh?u m?i cho l?n ??ng nh?p ti?p theo.", 
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i khi ??i m?t kh?u: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #region Designer

        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnDoiMatKhau = new System.Windows.Forms.Button();
            this.txtXacNhanMatKhau = new System.Windows.Forms.TextBox();
            this.lblXacNhanMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.lblMatKhauMoi = new System.Windows.Forms.Label();
            this.txtMatKhauCu = new System.Windows.Forms.TextBox();
            this.lblMatKhauCu = new System.Windows.Forms.Label();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.btnHuy);
            this.pnlMain.Controls.Add(this.btnDoiMatKhau);
            this.pnlMain.Controls.Add(this.txtXacNhanMatKhau);
            this.pnlMain.Controls.Add(this.lblXacNhanMatKhau);
            this.pnlMain.Controls.Add(this.txtMatKhauMoi);
            this.pnlMain.Controls.Add(this.lblMatKhauMoi);
            this.pnlMain.Controls.Add(this.txtMatKhauCu);
            this.pnlMain.Controls.Add(this.lblMatKhauCu);
            this.pnlMain.Controls.Add(this.lblTenDangNhap);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(400, 320);
            this.pnlMain.TabIndex = 0;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(210, 260);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 35);
            this.btnHuy.TabIndex = 9;
            this.btnHuy.Text = "H?y";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnDoiMatKhau.FlatAppearance.BorderSize = 0;
            this.btnDoiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoiMatKhau.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDoiMatKhau.ForeColor = System.Drawing.Color.White;
            this.btnDoiMatKhau.Location = new System.Drawing.Point(90, 260);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(110, 35);
            this.btnDoiMatKhau.TabIndex = 8;
            this.btnDoiMatKhau.Text = "??i m?t kh?u";
            this.btnDoiMatKhau.UseVisualStyleBackColor = false;
            // 
            // txtXacNhanMatKhau
            // 
            this.txtXacNhanMatKhau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtXacNhanMatKhau.Location = new System.Drawing.Point(160, 210);
            this.txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            this.txtXacNhanMatKhau.PasswordChar = '?';
            this.txtXacNhanMatKhau.Size = new System.Drawing.Size(200, 30);
            this.txtXacNhanMatKhau.TabIndex = 7;
            // 
            // lblXacNhanMatKhau
            // 
            this.lblXacNhanMatKhau.AutoSize = true;
            this.lblXacNhanMatKhau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblXacNhanMatKhau.Location = new System.Drawing.Point(30, 213);
            this.lblXacNhanMatKhau.Name = "lblXacNhanMatKhau";
            this.lblXacNhanMatKhau.Size = new System.Drawing.Size(124, 23);
            this.lblXacNhanMatKhau.TabIndex = 6;
            this.lblXacNhanMatKhau.Text = "Xác nh?n MK:";
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMatKhauMoi.Location = new System.Drawing.Point(160, 160);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.PasswordChar = '?';
            this.txtMatKhauMoi.Size = new System.Drawing.Size(200, 30);
            this.txtMatKhauMoi.TabIndex = 5;
            // 
            // lblMatKhauMoi
            // 
            this.lblMatKhauMoi.AutoSize = true;
            this.lblMatKhauMoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMatKhauMoi.Location = new System.Drawing.Point(30, 163);
            this.lblMatKhauMoi.Name = "lblMatKhauMoi";
            this.lblMatKhauMoi.Size = new System.Drawing.Size(118, 23);
            this.lblMatKhauMoi.TabIndex = 4;
            this.lblMatKhauMoi.Text = "M?t kh?u m?i:";
            // 
            // txtMatKhauCu
            // 
            this.txtMatKhauCu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMatKhauCu.Location = new System.Drawing.Point(160, 110);
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.PasswordChar = '?';
            this.txtMatKhauCu.Size = new System.Drawing.Size(200, 30);
            this.txtMatKhauCu.TabIndex = 3;
            // 
            // lblMatKhauCu
            // 
            this.lblMatKhauCu.AutoSize = true;
            this.lblMatKhauCu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMatKhauCu.Location = new System.Drawing.Point(30, 113);
            this.lblMatKhauCu.Name = "lblMatKhauCu";
            this.lblMatKhauCu.Size = new System.Drawing.Size(111, 23);
            this.lblMatKhauCu.TabIndex = 2;
            this.lblMatKhauCu.Text = "M?t kh?u c?:";
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTenDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTenDangNhap.Location = new System.Drawing.Point(30, 65);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(150, 23);
            this.lblTenDangNhap.TabIndex = 1;
            this.lblTenDangNhap.Text = "Tài kho?n: [username]";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblTitle.Location = new System.Drawing.Point(100, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(195, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "?? ??I M?T KH?U";
            // 
            // FormDoiMatKhau
            // 
            this.AcceptButton = this.btnDoiMatKhau;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 320);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "??i M?t Kh?u";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtMatKhauCu;
        private System.Windows.Forms.Label lblMatKhauCu;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.Label lblMatKhauMoi;
        private System.Windows.Forms.TextBox txtXacNhanMatKhau;
        private System.Windows.Forms.Label lblXacNhanMatKhau;
        private System.Windows.Forms.Button btnDoiMatKhau;
        private System.Windows.Forms.Button btnHuy;

        #endregion
    }
}
