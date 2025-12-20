using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;

namespace WindowsForm_QLTV
{
    public partial class FormThemTacGia : Form
    {
        // Controls
        private TextBox txtTenTacGia, txtQuocTich, txtMoTa;
        private Button btnThem, btnDong, btnLamMoi;

        public FormThemTacGia()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "THÊM TÁC GIẢ MỚI";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Title
            Label lblTitle = new Label
            {
                Text = "📝 THÊM TÁC GIẢ MỚI",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 152, 219),
                AutoSize = true,
                Location = new Point(20, 20)
            };
            this.Controls.Add(lblTitle);

            // GroupBox thông tin
            GroupBox grpThongTin = new GroupBox
            {
                Text = "Thông tin tác giả",
                Location = new Point(20, 70),
                Size = new Size(440, 200),
                Font = new Font("Segoe UI", 10F)
            };

            int y = 35;
            Label lbl1 = new Label { Text = "Tên Tác Giả*:", Location = new Point(20, y), AutoSize = true };
            txtTenTacGia = new TextBox { Location = new Point(140, y - 3), Size = new Size(270, 25) };
            grpThongTin.Controls.AddRange(new Control[] { lbl1, txtTenTacGia });

            y += 45;
            Label lbl2 = new Label { Text = "Quốc Tịch*:", Location = new Point(20, y), AutoSize = true };
            txtQuocTich = new TextBox { Location = new Point(140, y - 3), Size = new Size(200, 25) };
            grpThongTin.Controls.AddRange(new Control[] { lbl2, txtQuocTich });

            y += 45;
            Label lbl3 = new Label { Text = "Mô Tả:", Location = new Point(20, y), AutoSize = true };
            txtMoTa = new TextBox { Location = new Point(140, y - 3), Size = new Size(270, 60), Multiline = true };
            grpThongTin.Controls.AddRange(new Control[] { lbl3, txtMoTa });

            this.Controls.Add(grpThongTin);

            // Buttons
            btnThem = new Button
            {
                Text = "✅ THÊM",
                Location = new Point(20, 290),
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
                Location = new Point(175, 290),
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
                Location = new Point(330, 290),
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
            if (string.IsNullOrWhiteSpace(txtTenTacGia.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Tác Giả!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTacGia.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuocTich.Text))
            {
                MessageBox.Show("Vui lòng nhập Quốc Tịch!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuocTich.Focus();
                return;
            }

            try
            {
                using (var db = new Model1())
                {
                    string tenTacGia = txtTenTacGia.Text.Trim();

                    // Kiểm tra tác giả đã tồn tại chưa
                    var tacGiaTonTai = db.TACGIAs.FirstOrDefault(tg => tg.TENTG == tenTacGia);
                    if (tacGiaTonTai != null)
                    {
                        MessageBox.Show($"Tác giả \"{tenTacGia}\" đã tồn tại trong hệ thống với mã: {tacGiaTonTai.MATG}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Thêm mới
                    var newTacGia = new TACGIA
                    {
                        TENTG = tenTacGia,
                        QUOCTICH = txtQuocTich.Text.Trim(),
                        MOTA = txtMoTa.Text.Trim()
                    };

                    db.TACGIAs.Add(newTacGia);
                    db.SaveChanges();

                    MessageBox.Show($"✅ Đã thêm tác giả \"{tenTacGia}\" thành công!\nMã tác giả: {newTacGia.MATG}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tác giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtTenTacGia.Text = "";
            txtQuocTich.Text = "";
            txtMoTa.Text = "";
            txtTenTacGia.Focus();
        }
    }
}
