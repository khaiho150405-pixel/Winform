using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using System.IO;

namespace WindowsForm_QLTV
{
    public partial class FormThanhLySachDonGian : Form
    {
        private int currentMaSach = 0;

        // Controls
        private DataGridView dgvSach;
        private TextBox txtTimKiem, txtSoLuongThanhLy, txtLyDo;
        private Button btnTimKiem, btnThanhLy, btnDong;
        private Label lblMaSach, lblTenSach, lblSoLuongHienTai;
        private Panel pnlImage;

        public FormThanhLySachDonGian()
        {
            InitializeComponent();
            this.Load += FormThanhLySachDonGian_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "THANH LÝ SÁCH";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Title
            Label lblTitle = new Label
            {
                Text = "🗑️ THANH LÝ SÁCH",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(231, 76, 60),
                AutoSize = true,
                Location = new Point(20, 15)
            };
            this.Controls.Add(lblTitle);

            // Search
            Label lblSearch = new Label { Text = "Tìm kiếm:", Location = new Point(20, 70), AutoSize = true };
            txtTimKiem = new TextBox { Location = new Point(100, 67), Size = new Size(220, 25) };
            btnTimKiem = new Button
            {
                Text = "🔍",
                Location = new Point(330, 65),
                Size = new Size(40, 28),
                Cursor = Cursors.Hand
            };
            btnTimKiem.Click += btnTimKiem_Click;
            this.Controls.AddRange(new Control[] { lblSearch, txtTimKiem, btnTimKiem });

            // DataGridView
            dgvSach = new DataGridView
            {
                Location = new Point(20, 110),
                Size = new Size(580, 420),
                AutoGenerateColumns = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                RowTemplate = { Height = 30 }
            };
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaSach", HeaderText = "Mã Sách", DataPropertyName = "MaSach", Width = 70 });
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenSach", HeaderText = "Tên Sách", DataPropertyName = "TenSach", Width = 220 });
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenTacGia", HeaderText = "Tác Giả", DataPropertyName = "TenTacGia", Width = 130 });
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoLuongTon", HeaderText = "SL Tồn", DataPropertyName = "SoLuongTon", Width = 70 });
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai", HeaderText = "Trạng Thái", DataPropertyName = "TrangThai", Width = 90 });
            dgvSach.CellClick += dgvSach_CellClick;
            this.Controls.Add(dgvSach);

            // Panel thông tin sách được chọn
            GroupBox grpSachChon = new GroupBox
            {
                Text = "Sách được chọn để thanh lý",
                Location = new Point(620, 110),
                Size = new Size(350, 230),
                Font = new Font("Segoe UI", 10F)
            };

            // Ảnh sách
            pnlImage = new Panel
            {
                Location = new Point(15, 30),
                Size = new Size(90, 110),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };
            grpSachChon.Controls.Add(pnlImage);

            Label lbl1 = new Label { Text = "Mã Sách:", Location = new Point(120, 35), AutoSize = true };
            lblMaSach = new Label { Text = "...", Location = new Point(200, 35), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.FromArgb(192, 57, 43) };

            Label lbl2 = new Label { Text = "Tên Sách:", Location = new Point(120, 65), AutoSize = true };
            lblTenSach = new Label { Text = "...", Location = new Point(200, 65), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), MaximumSize = new Size(140, 0) };

            Label lbl3 = new Label { Text = "SL Hiện Tại:", Location = new Point(120, 110), AutoSize = true };
            lblSoLuongHienTai = new Label { Text = "...", Location = new Point(210, 110), AutoSize = true, Font = new Font("Segoe UI", 12F, FontStyle.Bold), ForeColor = Color.FromArgb(52, 152, 219) };

            grpSachChon.Controls.AddRange(new Control[] { lbl1, lblMaSach, lbl2, lblTenSach, lbl3, lblSoLuongHienTai });

            Label lbl4 = new Label { Text = "Số lượng thanh lý:", Location = new Point(15, 160), AutoSize = true };
            txtSoLuongThanhLy = new TextBox { Location = new Point(155, 157), Size = new Size(80, 25), Text = "0" };
            grpSachChon.Controls.AddRange(new Control[] { lbl4, txtSoLuongThanhLy });

            Label lbl5 = new Label { Text = "Lý do:", Location = new Point(15, 195), AutoSize = true };
            txtLyDo = new TextBox { Location = new Point(75, 192), Size = new Size(260, 25) };
            grpSachChon.Controls.AddRange(new Control[] { lbl5, txtLyDo });

            this.Controls.Add(grpSachChon);

            // Nút thanh lý
            btnThanhLy = new Button
            {
                Text = "🗑️ THANH LÝ SÁCH",
                Location = new Point(620, 360),
                Size = new Size(350, 55),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnThanhLy.FlatAppearance.BorderSize = 0;
            btnThanhLy.Click += btnThanhLy_Click;
            this.Controls.Add(btnThanhLy);

            // Nút đóng
            btnDong = new Button
            {
                Text = "✖ Đóng",
                Location = new Point(620, 430),
                Size = new Size(350, 45),
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
                Text = "⚠️ Lưu ý: Thanh lý sẽ trừ số lượng tồn kho. Nếu thanh lý toàn bộ, sách sẽ bị xóa khỏi hệ thống.",
                Location = new Point(620, 490),
                Size = new Size(350, 50),
                ForeColor = Color.FromArgb(192, 57, 43),
                Font = new Font("Segoe UI", 9F, FontStyle.Italic)
            };
            this.Controls.Add(lblCanhBao);
        }

        private void FormThanhLySachDonGian_Load(object sender, EventArgs e)
        {
            LoadDataSach();
        }

        private void LoadDataSach(string keyword = null)
        {
            try
            {
                using (var db = new Model1())
                {
                    IQueryable<SACH> query = db.SACHes.AsNoTracking();

                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query = query.Where(s => s.TENSACH.Contains(keyword) || s.MASACH.ToString() == keyword);
                    }

                    var sachList = query.Select(s => new SachDetailItem
                    {
                        MaSach = s.MASACH,
                        TenSach = s.TENSACH,
                        TenTacGia = s.TACGIA.TENTG,
                        TenNXB = s.NHAXUATBAN.TENNXB,
                        TheLoai = s.THELOAI,
                        SoLuongTon = s.SOLUONGTON,
                        GiaMuon = s.GIAMUON,
                        TrangThai = s.TRANGTHAI,
                        MoTa = s.MOTA,
                        HinhAnhPath = s.HINHANH,
                        MaTacGiaFK = s.MATG,
                        MaNXBFK = s.MANXB
                    }).ToList();

                    dgvSach.DataSource = sachList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var sachDetail = dgvSach.Rows[e.RowIndex].DataBoundItem as SachDetailItem;
                if (sachDetail != null)
                {
                    currentMaSach = sachDetail.MaSach;
                    lblMaSach.Text = sachDetail.MaSach.ToString();
                    lblTenSach.Text = sachDetail.TenSach;
                    lblSoLuongHienTai.Text = sachDetail.SoLuongTon.ToString();
                    txtSoLuongThanhLy.Text = "0";
                    txtLyDo.Text = "";

                    // Load ảnh
                    pnlImage.BackgroundImage = LoadImageFromLocalFolder(sachDetail.HinhAnhPath);
                    pnlImage.BackgroundImageLayout = ImageLayout.Zoom;
                }
            }
        }

        private Image LoadImageFromLocalFolder(string imageFileName)
        {
            if (string.IsNullOrWhiteSpace(imageFileName)) return null;
            try
            {
                string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
                string path1 = Path.Combine(projectRoot, "images", imageFileName);
                string path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", imageFileName);

                string fullPath = File.Exists(path1) ? path1 : (File.Exists(path2) ? path2 : null);
                if (fullPath == null) return null;

                using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                using (var ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    ms.Position = 0;
                    return Image.FromStream(ms);
                }
            }
            catch { return null; }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDataSach(txtTimKiem.Text.Trim());
        }

        private void btnThanhLy_Click(object sender, EventArgs e)
        {
            if (currentMaSach <= 0)
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSoLuongThanhLy.Text, out int soLuongThanhLy) || soLuongThanhLy <= 0)
            {
                MessageBox.Show("Số lượng thanh lý phải là số nguyên dương!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(lblSoLuongHienTai.Text, out int soLuongHienTai))
            {
                MessageBox.Show("Lỗi đọc số lượng hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (soLuongThanhLy > soLuongHienTai)
            {
                MessageBox.Show($"Số lượng thanh lý ({soLuongThanhLy}) không thể lớn hơn số lượng hiện tại ({soLuongHienTai})!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenSach = lblTenSach.Text;
            bool xoaHoanToan = (soLuongThanhLy == soLuongHienTai);

            string confirmMsg = xoaHoanToan
                ? $"Bạn đang thanh lý TOÀN BỘ {soLuongThanhLy} cuốn sách \"{tenSach}\".\n\n⚠️ Sách sẽ bị XÓA HOÀN TOÀN khỏi hệ thống!\n\nBạn có chắc chắn?"
                : $"Bạn có chắc muốn thanh lý {soLuongThanhLy} cuốn sách \"{tenSach}\"?\n\nSố lượng còn lại: {soLuongHienTai - soLuongThanhLy}";

            if (MessageBox.Show(confirmMsg, "Xác nhận thanh lý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (var db = new Model1())
                    {
                        var sachToUpdate = db.SACHes.Find(currentMaSach);
                        if (sachToUpdate != null)
                        {
                            if (xoaHoanToan)
                            {
                                // Xóa hoàn toàn sách
                                db.SACHes.Remove(sachToUpdate);
                                db.SaveChanges();
                                MessageBox.Show($"✅ Đã thanh lý và xóa hoàn toàn sách \"{tenSach}\" khỏi hệ thống!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                // Trừ số lượng
                                sachToUpdate.SOLUONGTON -= soLuongThanhLy;
                                
                                // Cập nhật trạng thái nếu hết sách
                                if (sachToUpdate.SOLUONGTON == 0)
                                {
                                    sachToUpdate.TRANGTHAI = "Hết sách";
                                }

                                db.Entry(sachToUpdate).State = EntityState.Modified;
                                db.SaveChanges();
                                MessageBox.Show($"✅ Đã thanh lý {soLuongThanhLy} cuốn sách \"{tenSach}\".\nSố lượng còn lại: {sachToUpdate.SOLUONGTON}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            LoadDataSach();
                            ClearInputs();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sách trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thanh lý: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearInputs()
        {
            currentMaSach = 0;
            lblMaSach.Text = "...";
            lblTenSach.Text = "...";
            lblSoLuongHienTai.Text = "...";
            txtSoLuongThanhLy.Text = "0";
            txtLyDo.Text = "";
            pnlImage.BackgroundImage = null;
        }
    }
}
