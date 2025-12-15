using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace WindowsForm_QLTV
{
    public partial class FormDoiMatKhau : Form
    {
        private string _tenDangNhap;

        public FormDoiMatKhau(string tenDangNhap)
        {
            _tenDangNhap = tenDangNhap;
            InitializeComponent();
            this.Load += FormDoiMatKhau_Load;
            btnDoiMatKhau.Click += BtnDoiMatKhau_Click;
            btnHuy.Click += BtnHuy_Click;
        }

        private void FormDoiMatKhau_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin người dùng hiện tại
            lblTenDangNhap.Text = $"Tài khoản: {_tenDangNhap}";
            txtMatKhauCu.Focus();
        }

        private void BtnDoiMatKhau_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đầu vào
            string matKhauCu = txtMatKhauCu.Text;
            string matKhauMoi = txtMatKhauMoi.Text;
            string xacNhanMatKhau = txtXacNhanMatKhau.Text;

            if (string.IsNullOrWhiteSpace(matKhauCu))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauCu.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(matKhauMoi))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            if (matKhauMoi.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            if (matKhauMoi != xacNhanMatKhau)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp với mật khẩu mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMatKhau.Focus();
                return;
            }

            if (matKhauCu == matKhauMoi)
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu cũ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            // 2. Xác thực và đổi mật khẩu
            try
            {
                using (var db = new Model1())
                {
                    // Tìm tài khoản hiện tại
                    var taiKhoan = db.TAIKHOANs.FirstOrDefault(tk => tk.TENDANGNHAP == _tenDangNhap);

                    if (taiKhoan == null)
                    {
                        MessageBox.Show("Không tìm thấy tài khoản. Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Kiểm tra mật khẩu cũ
                    if (taiKhoan.MATKHAU != matKhauCu)
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMatKhauCu.Clear();
                        txtMatKhauCu.Focus();
                        return;
                    }

                    // Cập nhật mật khẩu mới
                    taiKhoan.MATKHAU = matKhauMoi;
                    db.SaveChanges();

                    MessageBox.Show("Đổi mật khẩu thành công!\nVui lòng sử dụng mật khẩu mới cho lần đăng nhập tiếp theo.",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đổi mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #region Designer

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
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(22, 25, 22, 25);
            this.pnlMain.Size = new System.Drawing.Size(450, 438);
            this.pnlMain.TabIndex = 0;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(292, 362);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(112, 44);
            this.btnHuy.TabIndex = 9;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnDoiMatKhau.FlatAppearance.BorderSize = 0;
            this.btnDoiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoiMatKhau.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDoiMatKhau.ForeColor = System.Drawing.Color.White;
            this.btnDoiMatKhau.Location = new System.Drawing.Point(82, 362);
            this.btnDoiMatKhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(169, 44);
            this.btnDoiMatKhau.TabIndex = 8;
            this.btnDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnDoiMatKhau.UseVisualStyleBackColor = false;
            // 
            // txtXacNhanMatKhau
            // 
            this.txtXacNhanMatKhau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtXacNhanMatKhau.Location = new System.Drawing.Point(180, 288);
            this.txtXacNhanMatKhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            this.txtXacNhanMatKhau.PasswordChar = '●';
            this.txtXacNhanMatKhau.Size = new System.Drawing.Size(224, 34);
            this.txtXacNhanMatKhau.TabIndex = 7;
            // 
            // lblXacNhanMatKhau
            // 
            this.lblXacNhanMatKhau.AutoSize = true;
            this.lblXacNhanMatKhau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblXacNhanMatKhau.Location = new System.Drawing.Point(34, 291);
            this.lblXacNhanMatKhau.Name = "lblXacNhanMatKhau";
            this.lblXacNhanMatKhau.Size = new System.Drawing.Size(130, 28);
            this.lblXacNhanMatKhau.TabIndex = 6;
            this.lblXacNhanMatKhau.Text = "Xác nhận MK:";
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMatKhauMoi.Location = new System.Drawing.Point(180, 225);
            this.txtMatKhauMoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.PasswordChar = '●';
            this.txtMatKhauMoi.Size = new System.Drawing.Size(224, 34);
            this.txtMatKhauMoi.TabIndex = 5;
            // 
            // lblMatKhauMoi
            // 
            this.lblMatKhauMoi.AutoSize = true;
            this.lblMatKhauMoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMatKhauMoi.Location = new System.Drawing.Point(34, 229);
            this.lblMatKhauMoi.Name = "lblMatKhauMoi";
            this.lblMatKhauMoi.Size = new System.Drawing.Size(137, 28);
            this.lblMatKhauMoi.TabIndex = 4;
            this.lblMatKhauMoi.Text = "Mật khẩu mới:";
            // 
            // txtMatKhauCu
            // 
            this.txtMatKhauCu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMatKhauCu.Location = new System.Drawing.Point(180, 162);
            this.txtMatKhauCu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.PasswordChar = '●';
            this.txtMatKhauCu.Size = new System.Drawing.Size(224, 34);
            this.txtMatKhauCu.TabIndex = 3;
            // 
            // lblMatKhauCu
            // 
            this.lblMatKhauCu.AutoSize = true;
            this.lblMatKhauCu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMatKhauCu.Location = new System.Drawing.Point(34, 166);
            this.lblMatKhauCu.Name = "lblMatKhauCu";
            this.lblMatKhauCu.Size = new System.Drawing.Size(128, 28);
            this.lblMatKhauCu.TabIndex = 2;
            this.lblMatKhauCu.Text = "Mật khẩu cũ: ";
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTenDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTenDangNhap.Location = new System.Drawing.Point(34, 100);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(199, 28);
            this.lblTenDangNhap.TabIndex = 1;
            this.lblTenDangNhap.Text = "Tài khoản: [username]";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblTitle.Location = new System.Drawing.Point(75, 38);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(273, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔑 ĐỔI MẬT KHẨU";
            // 
            // FormDoiMatKhau
            // 
            this.AcceptButton = this.btnDoiMatKhau;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 438);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi Mật Khẩu";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
