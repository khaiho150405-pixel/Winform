using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.IO; // Cần thiết cho xử lý file

namespace WindowsForm_QLTV
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
            this.Load += TrangChu_Load;

            // Gán sự kiện cho các Controls lọc
            cmbTheLoai.SelectedIndexChanged += cmbTheLoai_SelectedIndexChanged;
            cmbNXB.SelectedIndexChanged += cmbNXB_SelectedIndexChanged;
            btnSearch.Click += btnSearch_Click;
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            LoadTheLoaiComboBox();
            LoadNhaXuatBanComboBox();
            LoadBookCards();
        }

        // =========================================================
        // LOGIC TẢI COMBOBOX (Giữ nguyên)
        // =========================================================
        private void LoadTheLoaiComboBox()
        {
            cmbTheLoai.Items.Clear();
            cmbTheLoai.Items.Add("Tất cả");

            try
            {
                using (var db = new Model1())
                {
                    var theLoais = db.SACHes
                                     .AsNoTracking()
                                     .Where(s => s.THELOAI != null && s.THELOAI != "")
                                     .Select(s => s.THELOAI)
                                     .Distinct()
                                     .OrderBy(tl => tl)
                                     .ToList();

                    foreach (var theLoai in theLoais)
                    {
                        cmbTheLoai.Items.Add(theLoai);
                    }
                }
                cmbTheLoai.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách Thể Loại: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNhaXuatBanComboBox()
        {
            cmbNXB.Items.Clear();
            cmbNXB.Items.Add("Tất cả");

            try
            {
                using (var db = new Model1())
                {
                    var nxbNames = db.NHAXUATBANs
                                     .AsNoTracking()
                                     .Select(n => n.TENNXB)
                                     .OrderBy(n => n)
                                     .ToList();

                    foreach (var name in nxbNames)
                    {
                        cmbNXB.Items.Add(name);
                    }
                }
                cmbNXB.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách Nhà Xuất Bản: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // XỬ LÝ SỰ KIỆN LỌC (Giữ nguyên)
        // =========================================================
        private void cmbTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            TriggerBookLoad();
        }

        private void cmbNXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            TriggerBookLoad();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            TriggerBookLoad();
        }

        private void TriggerBookLoad()
        {
            string category = cmbTheLoai.SelectedItem?.ToString();
            string nxbName = cmbNXB.SelectedItem?.ToString();
            string search = txtSearchBook.Text.Trim();

            if (category == "Tất cả") category = null;
            if (nxbName == "Tất cả") nxbName = null;

            LoadBookCards(category, nxbName, search);
        }

        // =========================================================
        // LOGIC TẢI VÀ HIỂN THỊ BOOK CARDS
        // =========================================================
        private void LoadBookCards(string theLoaiFilter = null, string nxbFilter = null, string searchFilter = null)
        {
            pnlBookCardsContainer.Controls.Clear();

            try
            {
                using (var db = new Model1())
                {
                    var query = db.SACHes.AsNoTracking()
                                         .Where(s => s.TRANGTHAI == "Có sẵn");

                    // Áp dụng bộ lọc
                    if (!string.IsNullOrEmpty(theLoaiFilter))
                        query = query.Where(s => s.THELOAI == theLoaiFilter);
                    if (!string.IsNullOrEmpty(nxbFilter))
                        query = query.Where(s => s.NHAXUATBAN.TENNXB == nxbFilter);
                    if (!string.IsNullOrEmpty(searchFilter) && searchFilter != "Tìm tên sách...")
                        query = query.Where(s => s.TENSACH.Contains(searchFilter));

                    // Lấy dữ liệu và chiếu (Projection) sang BookItem
                    var books = query.Select(s => new BookItem
                    {
                        MaSach = s.MASACH,
                        Title = s.TENSACH ?? "Không tên",
                        Subtitle = s.THELOAI ?? "",
                        HinhAnh = s.HINHANH ?? "", // LẤY ĐƯỜNG DẪN ẢNH TỪ DB
                        // Bỏ ImageColor
                    })
                    .OrderByDescending(s => s.MaSach)
                    .ToList();

                    // Hiển thị Cards
                    foreach (var book in books)
                    {
                        Panel card = CreateBookCard(book);
                        pnlBookCardsContainer.Controls.Add(card);
                    }

                    if (!books.Any())
                    {
                        Label lblNoResults = new Label { Text = "Không tìm thấy sách phù hợp.", AutoSize = true, Font = new Font("Segoe UI", 12F) };
                        pnlBookCardsContainer.Controls.Add(lblNoResults);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"LỖI TRUY VẤN: Vui lòng kiểm tra dữ liệu hoặc cấu trúc DB. Chi tiết: {ex.Message}", "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // HÀM TẠO CARD SÁCH VỚI PICTUREBOX
        // =========================================================
        private Panel CreateBookCard(BookItem book)
        {
            int width = 200;
            int height = 350;

            Panel pnl = new Panel();
            pnl.Size = new Size(width, height);
            pnl.Margin = new Padding(10, 10, 10, 10);
            pnl.BackColor = Color.White;
            pnl.BorderStyle = BorderStyle.FixedSingle;

            // 1. PictureBox chứa ảnh
            PictureBox pbImage = new PictureBox();
            pbImage.Size = new Size(width - 20, 200);
            pbImage.Location = new Point(10, 10);
            pbImage.BackColor = Color.LightGray; // Màu nền dự phòng (chứ không phải màu ngẫu nhiên)
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage; // Lấp đầy khung

            // Logic tải ảnh từ HinhAnh (tên file ảnh)
            if (!string.IsNullOrEmpty(book.HinhAnh))
            {
                LoadImageFromLocalFolder(pbImage, book.HinhAnh);
            }
            pnl.Controls.Add(pbImage);


            // 2. Tiêu đề sách
            Label lblTitle = new Label();
            lblTitle.Text = book.Title;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 220);
            lblTitle.Size = new Size(width - 20, 20);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            pnl.Controls.Add(lblTitle);

            // 3. Mô tả/Thể loại
            Label lblSubtitle = new Label();
            lblSubtitle.Text = "Thể loại: " + book.Subtitle;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.Location = new Point(10, 245);
            lblSubtitle.Size = new Size(width - 20, 20);
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            pnl.Controls.Add(lblSubtitle);

            // 4. Nút Chi tiết
            Button btnDetail = new Button();
            btnDetail.Text = "Xem chi tiết";
            btnDetail.BackColor = Color.FromArgb(41, 128, 185);
            btnDetail.ForeColor = Color.White;
            btnDetail.FlatStyle = FlatStyle.Flat;
            btnDetail.FlatAppearance.BorderSize = 0;
            btnDetail.Location = new Point(10, height - 45);
            btnDetail.Size = new Size(width - 20, 35);
            btnDetail.Tag = book.MaSach;
            btnDetail.Click += BtnDetail_Click;
            pnl.Controls.Add(btnDetail);

            return pnl;
        }

        // =========================================================
        // HÀM HỖ TRỢ TẢI ẢNH TỪ THƯ MỤC CỤC BỘ "images" (Giữ nguyên)
        // =========================================================
        private void LoadImageFromLocalFolder(PictureBox pb, string imageFileName)
        {
            if (string.IsNullOrWhiteSpace(imageFileName)) return;

            string fullPath = string.Empty;

            try
            {
                // Tùy chọn 1: Thử đường dẫn Project Root (..\..\images)
                string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                string path1 = Path.Combine(projectRoot, "images", imageFileName);

                // Tùy chọn 2: Thử đường dẫn Executable Root (imagse)
                string path2 = Path.Combine(Application.StartupPath, "images", imageFileName);

                if (File.Exists(path1))
                {
                    fullPath = path1;
                }
                else if (File.Exists(path2))
                {
                    fullPath = path2;
                }
                else
                {
                    pb.Image = null;
                    return;
                }

                // Load ảnh từ MemoryStream để không khóa file
                using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                {
                    using (var ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        ms.Position = 0;
                        pb.Image = Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                pb.Image = null; // Đặt lại nếu lỗi
            }
        }


        private void BtnDetail_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            // Kiểm tra xem Tag có chứa Mã Sách (int) không
            if (btn != null && btn.Tag != null)
            {
                if (int.TryParse(btn.Tag.ToString(), out int maSach))
                {
                    // Khởi tạo form chi tiết và hiển thị dưới dạng Dialog (cửa sổ con)
                    FormChiTietSach formChiTiet = new FormChiTietSach(maSach);
                    formChiTiet.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không lấy được mã sách hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}