using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;

namespace WindowsForm_QLTV
{
    public partial class FormThemNXB : Form
    {
        // Controls
        private TextBox txtTenNXB, txtDiaChi, txtSDT;
        private Button btnThem, btnDong, btnLamMoi;

        public FormThemNXB()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "THÊM NHÀ XUẤT BẢN MỚI";
            this.Size = new Size(500, 380);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Title
            Label lblTitle = new Label
            {
                Text = "📚 THÊM NHÀ XUẤT BẢN MỚI",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                AutoSize = true,
                Location = new Point(20, 20)
            };
            this.Controls.Add(lblTitle);

            // GroupBox thông tin
            GroupBox grpThongTin = new GroupBox
            {
                Text = "Thông tin NXB",
                Location = new Point(20, 70),
                Size = new Size(440, 180),
                Font = new Font("Segoe UI", 10F)
            };

            int y = 35;
            Label lbl1 = new Label { Text = "Tên NXB*:", Location = new Point(20, y), AutoSize = true };
            txtTenNXB = new TextBox { Location = new Point(120, y - 3), Size = new Size(290, 25) };
            grpThongTin.Controls.AddRange(new Control[] { lbl1, txtTenNXB });

            y += 45;
            Label lbl2 = new Label { Text = "Số Điện Thoại:", Location = new Point(20, y), AutoSize = true };
            txtSDT = new TextBox { Location = new Point(120, y - 3), Size = new Size(150, 25) };
            grpThongTin.Controls.AddRange(new Control[] { lbl2, txtSDT });

            y += 45;
            Label lbl3 = new Label { Text = "Địa Chỉ:", Location = new Point(20, y), AutoSize = true };
            txtDiaChi = new TextBox { Location = new Point(120, y - 3), Size = new Size(290, 50), Multiline = true };
            grpThongTin.Controls.AddRange(new Control[] { lbl3, txtDiaChi });

            this.Controls.Add(grpThongTin);

            // Buttons
            btnThem = new Button
            {
                Text = "✅ THÊM",
                Location = new Point(20, 270),
                Size = new Size(140, 50),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.Click += btnThem_Click;
            this.Controls.Add(btnThem);

            btnLamMoi = new Button
            {
                Text = "🔄 Làm Mới",
                Location = new Point(175, 270),
                Size = new Size(140, 50),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.Click += (s, e) => ClearInputs();
            this.Controls.Add(btnLamMoi);

            btnDong = new Button
            {
                Text = "✖ Đóng",
                Location = new Point(330, 270),
                Size = new Size(130, 50),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnDong.FlatAppearance.BorderSize = 0;
            btnDong.Click += (s, e) => this.Close();
            this.Controls.Add(btnDong);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtTenNXB.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Nhà Xuất Bản!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNXB.Focus();
                return;
            }

            try
            {
                using (var db = new Model1())
                {
                    string tenNXB = txtTenNXB.Text.Trim();

                    // Kiểm tra NXB đã tồn tại chưa
                    var nxbTonTai = db.NHAXUATBANs.FirstOrDefault(n => n.TENNXB == tenNXB);
                    if (nxbTonTai != null)
                    {
                        MessageBox.Show($"Nhà xuất bản \"{tenNXB}\" đã tồn tại trong hệ thống với mã: {nxbTonTai.MANXB}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Thêm mới
                    var newNXB = new NHAXUATBAN
                    {
                        TENNXB = tenNXB,
                        SDT = txtSDT.Text.Trim(),
                        DIACHI = txtDiaChi.Text.Trim()
                    };

                    db.NHAXUATBANs.Add(newNXB);
                    db.SaveChanges();

                    MessageBox.Show($"✅ Đã thêm NXB \"{tenNXB}\" thành công!\nMã NXB: {newNXB.MANXB}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm NXB: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtTenNXB.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtTenNXB.Focus();
        }
    }
}
