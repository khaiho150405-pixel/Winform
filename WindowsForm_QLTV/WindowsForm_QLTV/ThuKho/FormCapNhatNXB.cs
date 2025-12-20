using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;

namespace WindowsForm_QLTV
{
    public partial class FormCapNhatNXB : Form
    {
        private int currentMaNXB = 0;

        // Controls
        private DataGridView dgvNXB;
        private TextBox txtTimKiem, txtTenNXB, txtDiaChi, txtSDT;
        private Button btnTimKiem, btnCapNhat, btnDong, btnLamMoi;
        private Label lblMaNXB;

        public FormCapNhatNXB()
        {
            InitializeComponent();
            this.Load += FormCapNhatNXB_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "CẬP NHẬT NHÀ XUẤT BẢN";
            this.Size = new Size(950, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Title
            Label lblTitle = new Label
            {
                Text = "📝 CẬP NHẬT THÔNG TIN NHÀ XUẤT BẢN",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
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
                Size = new Size(500, 440),
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
            dgvNXB.Columns.Add(new DataGridViewTextBoxColumn { Name = "DIACHI", HeaderText = "Địa Chỉ", DataPropertyName = "DIACHI", Width = 130 });
            dgvNXB.CellClick += dgvNXB_CellClick;
            this.Controls.Add(dgvNXB);

            // GroupBox cập nhật
            GroupBox grpCapNhat = new GroupBox
            {
                Text = "Thông tin cần cập nhật",
                Location = new Point(540, 100),
                Size = new Size(380, 350),
                Font = new Font("Segoe UI", 10F)
            };

            int y = 35;
            Label lbl0 = new Label { Text = "Mã NXB:", Location = new Point(20, y), AutoSize = true };
            lblMaNXB = new Label { Text = "...", Location = new Point(130, y), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.FromArgb(192, 57, 43) };
            grpCapNhat.Controls.AddRange(new Control[] { lbl0, lblMaNXB });

            y += 40;
            Label lbl1 = new Label { Text = "Tên NXB*:", Location = new Point(20, y), AutoSize = true };
            txtTenNXB = new TextBox { Location = new Point(130, y - 3), Size = new Size(220, 25) };
            grpCapNhat.Controls.AddRange(new Control[] { lbl1, txtTenNXB });

            y += 40;
            Label lbl2 = new Label { Text = "Số Điện Thoại:", Location = new Point(20, y), AutoSize = true };
            txtSDT = new TextBox { Location = new Point(130, y - 3), Size = new Size(150, 25) };
            grpCapNhat.Controls.AddRange(new Control[] { lbl2, txtSDT });

            y += 40;
            Label lbl3 = new Label { Text = "Địa Chỉ:", Location = new Point(20, y), AutoSize = true };
            txtDiaChi = new TextBox { Location = new Point(130, y - 3), Size = new Size(220, 80), Multiline = true };
            grpCapNhat.Controls.AddRange(new Control[] { lbl3, txtDiaChi });

            this.Controls.Add(grpCapNhat);

            // Buttons
            btnCapNhat = new Button
            {
                Text = "✅ CẬP NHẬT",
                Location = new Point(540, 470),
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
                Location = new Point(685, 470),
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
                Location = new Point(810, 470),
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

        private void FormCapNhatNXB_Load(object sender, EventArgs e)
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
                    txtTenNXB.Text = nxb.TENNXB;
                    txtSDT.Text = nxb.SDT;
                    txtDiaChi.Text = nxb.DIACHI;
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDataNXB(txtTimKiem.Text.Trim());
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (currentMaNXB <= 0)
            {
                MessageBox.Show("Vui lòng chọn một NXB từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenNXB.Text))
            {
                MessageBox.Show("Tên NXB không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new Model1())
                {
                    var nxbToUpdate = db.NHAXUATBANs.Find(currentMaNXB);
                    if (nxbToUpdate != null)
                    {
                        nxbToUpdate.TENNXB = txtTenNXB.Text.Trim();
                        nxbToUpdate.SDT = txtSDT.Text.Trim();
                        nxbToUpdate.DIACHI = txtDiaChi.Text.Trim();

                        db.Entry(nxbToUpdate).State = EntityState.Modified;
                        db.SaveChanges();

                        MessageBox.Show($"✅ Cập nhật NXB \"{nxbToUpdate.TENNXB}\" thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataNXB();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy NXB trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            currentMaNXB = 0;
            lblMaNXB.Text = "...";
            txtTenNXB.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
        }
    }
}
