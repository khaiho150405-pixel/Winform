using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.IO;

namespace WindowsForm_QLTV
{
    public partial class FormQLSach : Form
    {
        public FormQLSach()
        {
            InitializeComponent();
            this.Load += FormQLSach_Load;

            // Gán sự kiện cho các nút Dashboard
            btnQLSach.Click += DashboardButton_Click;
            btnTacGia.Click += DashboardButton_Click;
            btnNhaXuatBan.Click += DashboardButton_Click;

            // Đã bỏ btnQuayLai
        }

        private void FormQLSach_Load(object sender, EventArgs e)
        {
            LoadBookCards();
        }

        // Hàm LoadSubForm và DashboardButton_Click (Giữ nguyên)

        private void LoadSubForm(Type formType)
        {
            Panel pnlContent = this.Parent as Panel;

            if (pnlContent != null)
            {
                try
                {
                    Form form = (Form)Activator.CreateInstance(formType);
                    pnlContent.Controls.Clear();
                    form.TopLevel = false;
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.Dock = DockStyle.Fill;
                    pnlContent.Controls.Add(form);
                    form.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi tải Form {formType.Name}: {ex.Message}\nĐảm bảo Form đã được biên dịch.", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy Panel nội dung chính (pnlContent).", "Lỗi Cấu trúc Form");
            }
        }


        private void DashboardButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                string buttonText = clickedButton.Text.Trim();

                switch (buttonText)
                {
                    case "Quản Lý Sách":
                        LoadSubForm(typeof(EditSach));
                        break;
                    case "Tác Giả":
                        LoadSubForm(typeof(FormQLTacGia));
                        break;
                    case "Nhà Xuất Bản":
                        LoadSubForm(typeof(FormQLNXB));
                        break;
                    default:
                        break;
                }
            }
        }

        // LOGIC TẢI CARD SÁCH (Đã bỏ ImageColor)
        private void LoadBookCards()
        {
            pnlCardContainer.Controls.Clear();

            List<BookItem> books = new List<BookItem>();

            try
            {
                using (var db = new Model1())
                {
                    var queriedBooks = db.SACHes.AsNoTracking()
                                                 .Where(s => s.TRANGTHAI == "Có sẵn")
                                                 .OrderByDescending(s => s.MASACH)
                                                 .ToList();

                    foreach (var book in queriedBooks)
                    {
                        books.Add(new BookItem
                        {
                            Title = book.TENSACH,
                            Subtitle = book.THELOAI,
                            HinhAnh = book.HINHANH, // LẤY ĐƯỜNG DẪN ẢNH TỪ DB
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu sách từ CSDL: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // PHẦN HIỂN THỊ THẺ SÁCH (Giữ nguyên bố cục)
            int x = 10;
            int y = 10;
            int cardWidth = 200;
            int cardHeight = 350;
            int padding = 20;
            int cardsPerRow = 4;
            int cardIndex = 0;

            foreach (var book in books)
            {
                Panel card = CreateBookCard(book, cardWidth, cardHeight);
                card.Location = new Point(x, y);
                pnlCardContainer.Controls.Add(card);

                x += cardWidth + padding;
                cardIndex++;

                if (cardIndex % cardsPerRow == 0)
                {
                    x = 10;
                    y += cardHeight + padding;
                }
            }
        }

        // HÀM TẠO CARD SÁCH (Đã bỏ ImageColor)
        private Panel CreateBookCard(BookItem book, int width, int height)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(width, height);
            pnl.BackColor = Color.White;
            pnl.BorderStyle = BorderStyle.FixedSingle;

            // 1. PictureBox chứa ảnh
            PictureBox pbImage = new PictureBox();
            pbImage.Size = new Size(width - 20, 200);
            pbImage.Location = new Point(10, 10);
            pbImage.BackColor = Color.WhiteSmoke; // Màu nền trung tính dự phòng
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage; // Lấp đầy khung

            // Logic tải ảnh từ HinhAnh (tên file ảnh)
            if (!string.IsNullOrEmpty(book.HinhAnh))
            {
                LoadImageFromLocalFolder(pbImage, book.HinhAnh);
            }
            pnl.Controls.Add(pbImage);

            // 2. Tiêu đề sách (Giữ nguyên)
            Label lblTitle = new Label();
            lblTitle.Text = book.Title;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 220);
            lblTitle.Size = new Size(width - 20, 20);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            pnl.Controls.Add(lblTitle);

            // 3. Mô tả/Thể loại (Giữ nguyên)
            Label lblSubtitle = new Label();
            lblSubtitle.Text = "Thể loại: " + book.Subtitle;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.Location = new Point(10, 245);
            lblSubtitle.Size = new Size(width - 20, 20);
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            pnl.Controls.Add(lblSubtitle);

            // 4. Nút Chi tiết (Giữ nguyên)
            Button btnDetail = new Button();
            btnDetail.Text = "Xem chi tiết";
            btnDetail.BackColor = Color.FromArgb(39, 174, 96);
            btnDetail.ForeColor = Color.White;
            btnDetail.FlatStyle = FlatStyle.Flat;
            btnDetail.FlatAppearance.BorderSize = 0;
            btnDetail.Location = new Point(10, height - 45);
            btnDetail.Size = new Size(width - 20, 35);
            btnDetail.Tag = book.Title;
            btnDetail.Click += BtnDetail_Click;
            pnl.Controls.Add(btnDetail);

            return pnl;
        }

        // HÀM HỖ TRỢ TẢI ẢNH TỪ THƯ MỤC CỤC BỘ "images" (Giữ nguyên)
        private void LoadImageFromLocalFolder(PictureBox pb, string imageFileName)
        {
            if (string.IsNullOrWhiteSpace(imageFileName)) return;

            string fullPath = string.Empty;

            try
            {
                // Tùy chọn 1: Thử đường dẫn Project Root (..\..\images)
                string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                string path1 = Path.Combine(projectRoot, "images", imageFileName);

                // Tùy chọn 2: Thử đường dẫn Executable Root (images)
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
            MessageBox.Show($"Xem chi tiết sách: {btn.Tag}", "Thông báo");
            // TODO: Thêm logic để mở Form chỉnh sửa sách
        }

        // ĐÃ BỎ HÀM GetRandomColor
    }
}