using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;

namespace WindowsForm_QLTV
{
    public partial class FormXoaNXB : Form
    {
        private int currentMaNXB = 0;

        // Controls
        private DataGridView dgvNXB;
        private TextBox txtTimKiem;
        private Button btnTimKiem, btnXoa, btnDong;
        private Label lblMaNXB, lblTenNXB, lblSDT, lblSoSach;

        public FormXoaNXB()
        {
            InitializeComponent();
            this.Load += FormXoaNXB_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "XÓA NHÀ XUẤT BẢN";
            this.Size = new Size(850, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Title
            Label lblTitle = new Label
            {
                Text = "🗑️ XÓA NHÀ XUẤT BẢN",
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
            dgvNXB = new DataGridView
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
            dgvNXB.Columns.Add(new DataGridViewTextBoxColumn { Name = "MANXB", HeaderText = "Mã NXB", DataPropertyName = "MANXB", Width = 70 });
            dgvNXB.Columns.Add(new DataGridViewTextBoxColumn { Name = "TENNXB", HeaderText = "Tên NXB", DataPropertyName = "TENNXB", Width = 200 });
            dgvNXB.Columns.Add(new DataGridViewTextBoxColumn { Name = "SDT", HeaderText = "SĐT", DataPropertyName = "SDT", Width = 100 });
            dgvNXB.Columns.Add(new DataGridViewTextBoxColumn { Name = "DIACHI", HeaderText = "Địa Chỉ", DataPropertyName = "DIACHI", Width = 110 });
            dgvNXB.CellClick += dgvNXB_CellClick;
            this.Controls.Add(dgvNXB);

            // GroupBox thông tin NXB được chọn
            GroupBox grpNXBChon = new GroupBox
            {
                Text = "NXB được chọn để xóa",
                Location = new Point(520, 100),
                Size = new Size(300, 200),
                Font = new Font("Segoe UI", 10F)
            };

            int y = 35;
            Label lbl1 = new Label { Text = "Mã NXB:", Location = new Point(20, y), AutoSize = true };
            lblMaNXB = new Label { Text = "...", Location = new Point(120, y), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.FromArgb(192, 57, 43) };
            grpNXBChon.Controls.AddRange(new Control[] { lbl1, lblMaNXB });

            y += 35;
            Label lbl2 = new Label { Text = "Tên NXB:", Location = new Point(20, y), AutoSize = true };
            lblTenNXB = new Label { Text = "...", Location = new Point(120, y), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), MaximumSize = new Size(170, 0) };
            grpNXBChon.Controls.AddRange(new Control[] { lbl2, lblTenNXB });

            y += 35;
            Label lbl3 = new Label { Text = "SĐT:", Location = new Point(20, y), AutoSize = true };
            lblSDT = new Label { Text = "...", Location = new Point(120, y), AutoSize = true };
            grpNXBChon.Controls.AddRange(new Control[] { lbl3, lblSDT });

            y += 35;
            Label lbl4 = new Label { Text = "Số Sách:", Location = new Point(20, y), AutoSize = true };
            lblSoSach = new Label { Text = "...", Location = new Point(120, y), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.FromArgb(52, 152, 219) };
            grpNXBChon.Controls.AddRange(new Control[] { lbl4, lblSoSach });

            this.Controls.Add(grpNXBChon);

            // Nút xóa
            btnXoa = new Button
            {
                Text = "🗑️ XÓA NXB",
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
                Text = "⚠️ Lưu ý: Xóa NXB sẽ ảnh hưởng đến tất cả sách liên quan!",
                Location = new Point(520, 450),
                Size = new Size(300, 40),
                ForeColor = Color.FromArgb(192, 57, 43),
                Font = new Font("Segoe UI", 9F, FontStyle.Italic)
            };
            this.Controls.Add(lblCanhBao);
        }

        private void FormXoaNXB_Load(object sender, EventArgs e)
        {
            LoadDataNXB();
        }

        private void LoadDataNXB(string keyword = null)
        {
            try
            {
                using (var db = new Model1())
                {
                    var query = db.NHAXUATBANs.AsNoTracking().AsQueryable();

                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query = query.Where(n => n.TENNXB.Contains(keyword) || n.MANXB.ToString() == keyword);
                    }

                    dgvNXB.DataSource = query.OrderBy(n => n.MANXB).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var nxb = dgvNXB.Rows[e.RowIndex].DataBoundItem as NHAXUATBAN;
                if (nxb != null)
                {
                    currentMaNXB = nxb.MANXB;
                    lblMaNXB.Text = nxb.MANXB.ToString();
                    lblTenNXB.Text = nxb.TENNXB;
                    lblSDT.Text = nxb.SDT ?? "Chưa có";

                    // Đếm số sách của NXB
                    try
                    {
                        using (var db = new Model1())
                        {
                            int soSach = db.SACHes.Count(s => s.MANXB == nxb.MANXB);
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
            LoadDataNXB(txtTimKiem.Text.Trim());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentMaNXB <= 0)
            {
                MessageBox.Show("Vui lòng chọn một NXB từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenNXB = lblTenNXB.Text;

            // Kiểm tra số sách liên quan
            int soSach = 0;
            try
            {
                using (var db = new Model1())
                {
                    soSach = db.SACHes.Count(s => s.MANXB == currentMaNXB);
                }
            }
            catch { }

            string confirmMsg = soSach > 0
                ? $"NXB \"{tenNXB}\" có {soSach} cuốn sách liên quan.\n\n⚠️ Bạn cần xóa hoặc chuyển các sách này sang NXB khác trước khi xóa!\n\nBạn có chắc muốn tiếp tục?"
                : $"Bạn có chắc muốn xóa NXB \"{tenNXB}\"?";

            if (MessageBox.Show(confirmMsg, "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (var db = new Model1())
                    {
                        var nxbToDelete = db.NHAXUATBANs.Find(currentMaNXB);
                        if (nxbToDelete != null)
                        {
                            db.NHAXUATBANs.Remove(nxbToDelete);
                            db.SaveChanges();

                            MessageBox.Show($"✅ Đã xóa NXB \"{tenNXB}\" thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataNXB();
                            ClearInputs();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy NXB trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa NXB: " + ex.Message + "\n\nCó thể do NXB này còn sách liên quan.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearInputs()
        {
            currentMaNXB = 0;
            lblMaNXB.Text = "...";
            lblTenNXB.Text = "...";
            lblSDT.Text = "...";
            lblSoSach.Text = "...";
        }
    }
}
