using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;

namespace WindowsForm_QLTV
{
    public partial class FormXoaTacGia : Form
    {
        private int currentMaTacGia = 0;

        // Controls
        private DataGridView dgvTacGia;
        private TextBox txtTimKiem;
        private Button btnTimKiem, btnXoa, btnDong;
        private Label lblMaTacGia, lblTenTacGia, lblQuocTich, lblSoSach;

        public FormXoaTacGia()
        {
            InitializeComponent();
            this.Load += FormXoaTacGia_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "XÓA TÁC GIẢ";
            this.Size = new Size(850, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Title
            Label lblTitle = new Label
            {
                Text = "🗑️ XÓA TÁC GIẢ",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(231, 76, 60),
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
                Size = new Size(480, 380),
                AutoGenerateColumns = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                RowTemplate = { Height = 30 }
            };
            dgvTacGia.Columns.Add(new DataGridViewTextBoxColumn { Name = "MATG", HeaderText = "Mã TG", DataPropertyName = "MATG", Width = 70 });
            dgvTacGia.Columns.Add(new DataGridViewTextBoxColumn { Name = "TENTG", HeaderText = "Tên Tác Giả", DataPropertyName = "TENTG", Width = 200 });
            dgvTacGia.Columns.Add(new DataGridViewTextBoxColumn { Name = "QUOCTICH", HeaderText = "Quốc Tịch", DataPropertyName = "QUOCTICH", Width = 120 });
            dgvTacGia.Columns.Add(new DataGridViewTextBoxColumn { Name = "MOTA", HeaderText = "Mô Tả", DataPropertyName = "MOTA", Width = 90 });
            dgvTacGia.CellClick += dgvTacGia_CellClick;
            this.Controls.Add(dgvTacGia);

            // GroupBox thông tin tác giả được chọn
            GroupBox grpTacGiaChon = new GroupBox
            {
                Text = "Tác giả được chọn để xóa",
                Location = new Point(520, 100),
                Size = new Size(300, 200),
                Font = new Font("Segoe UI", 10F)
            };

            int y = 35;
            Label lbl1 = new Label { Text = "Mã TG:", Location = new Point(20, y), AutoSize = true };
            lblMaTacGia = new Label { Text = "...", Location = new Point(120, y), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.FromArgb(192, 57, 43) };
            grpTacGiaChon.Controls.AddRange(new Control[] { lbl1, lblMaTacGia });

            y += 35;
            Label lbl2 = new Label { Text = "Tên Tác Giả:", Location = new Point(20, y), AutoSize = true };
            lblTenTacGia = new Label { Text = "...", Location = new Point(120, y), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), MaximumSize = new Size(170, 0) };
            grpTacGiaChon.Controls.AddRange(new Control[] { lbl2, lblTenTacGia });

            y += 35;
            Label lbl3 = new Label { Text = "Quốc Tịch:", Location = new Point(20, y), AutoSize = true };
            lblQuocTich = new Label { Text = "...", Location = new Point(120, y), AutoSize = true };
            grpTacGiaChon.Controls.AddRange(new Control[] { lbl3, lblQuocTich });

            y += 35;
            Label lbl4 = new Label { Text = "Số Sách:", Location = new Point(20, y), AutoSize = true };
            lblSoSach = new Label { Text = "...", Location = new Point(120, y), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.FromArgb(52, 152, 219) };
            grpTacGiaChon.Controls.AddRange(new Control[] { lbl4, lblSoSach });

            this.Controls.Add(grpTacGiaChon);

            // Nút xóa
            btnXoa = new Button
            {
                Text = "🗑️ XÓA TÁC GIẢ",
                Location = new Point(520, 320),
                Size = new Size(300, 55),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.Click += btnXoa_Click;
            this.Controls.Add(btnXoa);

            // Nút đóng
            btnDong = new Button
            {
                Text = "✖ Đóng",
                Location = new Point(520, 390),
                Size = new Size(300, 45),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnDong.FlatAppearance.BorderSize = 0;
            btnDong.Click += (s, e) => this.Close();
            this.Controls.Add(btnDong);

            // Cảnh báo
            Label lblCanhBao = new Label
            {
                Text = "⚠️ Lưu ý: Xóa tác giả sẽ ảnh hưởng đến tất cả sách liên quan!",
                Location = new Point(520, 450),
                Size = new Size(300, 40),
                ForeColor = Color.FromArgb(192, 57, 43),
                Font = new Font("Segoe UI", 9F, FontStyle.Italic)
            };
            this.Controls.Add(lblCanhBao);
        }

        private void FormXoaTacGia_Load(object sender, EventArgs e)
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
                    lblTenTacGia.Text = tacGia.TENTG;
                    lblQuocTich.Text = tacGia.QUOCTICH ?? "Chưa có";

                    // Đếm số sách của tác giả
                    try
                    {
                        using (var db = new Model1())
                        {
                            int soSach = db.SACHes.Count(s => s.MATG == tacGia.MATG);
                            lblSoSach.Text = soSach.ToString() + " cuốn";
                            lblSoSach.ForeColor = soSach > 0 ? Color.FromArgb(231, 76, 60) : Color.FromArgb(46, 204, 113);
                        }
                    }
                    catch
                    {
                        lblSoSach.Text = "?";
                    }
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDataTacGia(txtTimKiem.Text.Trim());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentMaTacGia <= 0)
            {
                MessageBox.Show("Vui lòng chọn một tác giả từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenTacGia = lblTenTacGia.Text;

            // Kiểm tra số sách liên quan
            int soSach = 0;
            try
            {
                using (var db = new Model1())
                {
                    soSach = db.SACHes.Count(s => s.MATG == currentMaTacGia);
                }
            }
            catch { }

            string confirmMsg = soSach > 0
                ? $"Tác giả \"{tenTacGia}\" có {soSach} cuốn sách liên quan.\n\n⚠️ Bạn cần xóa hoặc chuyển các sách này sang tác giả khác trước khi xóa!\n\nBạn có chắc muốn tiếp tục?"
                : $"Bạn có chắc muốn xóa tác giả \"{tenTacGia}\"?";

            if (MessageBox.Show(confirmMsg, "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (var db = new Model1())
                    {
                        var tacGiaToDelete = db.TACGIAs.Find(currentMaTacGia);
                        if (tacGiaToDelete != null)
                        {
                            db.TACGIAs.Remove(tacGiaToDelete);
                            db.SaveChanges();

                            MessageBox.Show($"✅ Đã xóa tác giả \"{tenTacGia}\" thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataTacGia();
                            ClearInputs();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy tác giả trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa tác giả: " + ex.Message + "\n\nCó thể do tác giả này còn sách liên quan.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearInputs()
        {
            currentMaTacGia = 0;
            lblMaTacGia.Text = "...";
            lblTenTacGia.Text = "...";
            lblQuocTich.Text = "...";
            lblSoSach.Text = "...";
        }
    }
}
