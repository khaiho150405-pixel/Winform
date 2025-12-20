using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;

namespace WindowsForm_QLTV
{
    public partial class FormCapNhatTacGia : Form
    {
        private int currentMaTacGia = 0;

        // Controls
        private DataGridView dgvTacGia;
        private TextBox txtTimKiem, txtTenTacGia, txtQuocTich, txtMoTa;
        private Button btnTimKiem, btnCapNhat, btnDong, btnLamMoi;
        private Label lblMaTacGia;

        public FormCapNhatTacGia()
        {
            InitializeComponent();
            this.Load += FormCapNhatTacGia_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "CẬP NHẬT TÁC GIẢ";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Title
            Label lblTitle = new Label
            {
                Text = "📝 CẬP NHẬT THÔNG TIN TÁC GIẢ",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 152, 219),
                AutoSize = true,
                Location = new Point(20, 15)
            };
            this.Controls.Add(lblTitle);

            // Search
            Label lblSearch = new Label { Text = "Tìm kiếm:", Location = new Point(20, 65), AutoSize = true };
            txtTimKiem = new TextBox { Location = new Point(100, 62), Size = new Size(200, 25) };
            btnTimKiem = new Button
            {
                Text = "🔍",
                Location = new Point(310, 60),
                Size = new Size(40, 28),
                Cursor = Cursors.Hand
            };
            btnTimKiem.Click += btnTimKiem_Click;
            this.Controls.AddRange(new Control[] { lblSearch, txtTimKiem, btnTimKiem });

            // DataGridView
            dgvTacGia = new DataGridView
            {
                Location = new Point(20, 100),
                Size = new Size(450, 440),
                AutoGenerateColumns = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                RowTemplate = { Height = 30 }
            };
            dgvTacGia.Columns.Add(new DataGridViewTextBoxColumn { Name = "MATG", HeaderText = "Mã TG", DataPropertyName = "MATG", Width = 70 });
            dgvTacGia.Columns.Add(new DataGridViewTextBoxColumn { Name = "TENTG", HeaderText = "Tên Tác Giả", DataPropertyName = "TENTG", Width = 180 });
            dgvTacGia.Columns.Add(new DataGridViewTextBoxColumn { Name = "QUOCTICH", HeaderText = "Quốc Tịch", DataPropertyName = "QUOCTICH", Width = 100 });
            dgvTacGia.Columns.Add(new DataGridViewTextBoxColumn { Name = "MOTA", HeaderText = "Mô Tả", DataPropertyName = "MOTA", Width = 100 });
            dgvTacGia.CellClick += dgvTacGia_CellClick;
            this.Controls.Add(dgvTacGia);

            // GroupBox cập nhật
            GroupBox grpCapNhat = new GroupBox
            {
                Text = "Thông tin cần cập nhật",
                Location = new Point(490, 100),
                Size = new Size(380, 350),
                Font = new Font("Segoe UI", 10F)
            };

            int y = 35;
            Label lbl0 = new Label { Text = "Mã Tác Giả:", Location = new Point(20, y), AutoSize = true };
            lblMaTacGia = new Label { Text = "...", Location = new Point(130, y), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.FromArgb(192, 57, 43) };
            grpCapNhat.Controls.AddRange(new Control[] { lbl0, lblMaTacGia });

            y += 40;
            Label lbl1 = new Label { Text = "Tên Tác Giả*:", Location = new Point(20, y), AutoSize = true };
            txtTenTacGia = new TextBox { Location = new Point(130, y - 3), Size = new Size(220, 25) };
            grpCapNhat.Controls.AddRange(new Control[] { lbl1, txtTenTacGia });

            y += 40;
            Label lbl2 = new Label { Text = "Quốc Tịch*:", Location = new Point(20, y), AutoSize = true };
            txtQuocTich = new TextBox { Location = new Point(130, y - 3), Size = new Size(150, 25) };
            grpCapNhat.Controls.AddRange(new Control[] { lbl2, txtQuocTich });

            y += 40;
            Label lbl3 = new Label { Text = "Mô Tả:", Location = new Point(20, y), AutoSize = true };
            txtMoTa = new TextBox { Location = new Point(130, y - 3), Size = new Size(220, 80), Multiline = true };
            grpCapNhat.Controls.AddRange(new Control[] { lbl3, txtMoTa });

            this.Controls.Add(grpCapNhat);

            // Buttons
            btnCapNhat = new Button
            {
                Text = "✅ CẬP NHẬT",
                Location = new Point(490, 470),
                Size = new Size(130, 45),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCapNhat.FlatAppearance.BorderSize = 0;
            btnCapNhat.Click += btnCapNhat_Click;
            this.Controls.Add(btnCapNhat);

            btnLamMoi = new Button
            {
                Text = "🔄 Làm Mới",
                Location = new Point(635, 470),
                Size = new Size(110, 45),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.Click += (s, e) => ClearInputs();
            this.Controls.Add(btnLamMoi);

            btnDong = new Button
            {
                Text = "✖ Đóng",
                Location = new Point(760, 470),
                Size = new Size(110, 45),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnDong.FlatAppearance.BorderSize = 0;
            btnDong.Click += (s, e) => this.Close();
            this.Controls.Add(btnDong);
        }

        private void FormCapNhatTacGia_Load(object sender, EventArgs e)
        {
            LoadDataTacGia();
        }

        private void LoadDataTacGia(string keyword = null)
        {
            try
            {
                using (var db = new Model1())
                {
                    var query = db.TACGIAs.AsNoTracking().AsQueryable();

                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query = query.Where(tg => tg.TENTG.Contains(keyword) || tg.MATG.ToString() == keyword);
                    }

                    dgvTacGia.DataSource = query.OrderBy(tg => tg.MATG).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var tacGia = dgvTacGia.Rows[e.RowIndex].DataBoundItem as TACGIA;
                if (tacGia != null)
                {
                    currentMaTacGia = tacGia.MATG;
                    lblMaTacGia.Text = tacGia.MATG.ToString();
                    txtTenTacGia.Text = tacGia.TENTG;
                    txtQuocTich.Text = tacGia.QUOCTICH;
                    txtMoTa.Text = tacGia.MOTA;
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDataTacGia(txtTimKiem.Text.Trim());
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (currentMaTacGia <= 0)
            {
                MessageBox.Show("Vui lòng chọn một tác giả từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenTacGia.Text))
            {
                MessageBox.Show("Tên Tác Giả không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuocTich.Text))
            {
                MessageBox.Show("Quốc Tịch không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new Model1())
                {
                    var tacGiaToUpdate = db.TACGIAs.Find(currentMaTacGia);
                    if (tacGiaToUpdate != null)
                    {
                        tacGiaToUpdate.TENTG = txtTenTacGia.Text.Trim();
                        tacGiaToUpdate.QUOCTICH = txtQuocTich.Text.Trim();
                        tacGiaToUpdate.MOTA = txtMoTa.Text.Trim();

                        db.Entry(tacGiaToUpdate).State = EntityState.Modified;
                        db.SaveChanges();

                        MessageBox.Show($"✅ Cập nhật tác giả \"{tacGiaToUpdate.TENTG}\" thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataTacGia();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tác giả trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            currentMaTacGia = 0;
            lblMaTacGia.Text = "...";
            txtTenTacGia.Text = "";
            txtQuocTich.Text = "";
            txtMoTa.Text = "";
        }
    }
}
