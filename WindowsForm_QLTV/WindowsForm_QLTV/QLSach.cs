using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

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
            btnTheLoai.Click += DashboardButton_Click;
            btnNhaXuatBan.Click += DashboardButton_Click;
        }

        private void FormQLSach_Load(object sender, EventArgs e)
        {
            // Load các thẻ sách (Card) mẫu
            LoadBookCards();
        }

        // Hàm chung để load Form con vào Panel cha (MainForm's pnlContent)
        private void LoadSubForm(Type formType)
        {
            // Lấy Panel cha (thường là pnlContent của MainForm)
            Panel pnlContent = this.Parent as Panel;

            if (pnlContent != null)
            {
                try
                {
                    // Khởi tạo Form mới bằng reflection
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
                        // Chuyển sang form chi tiết (Load FormQLTatCaSach)
                        LoadSubForm(typeof(FormQLTatCaSach));
                        break;
                    case "Tác Giả":
                        // Chuyển sang form Quản Lý Tác Giả
                        LoadSubForm(typeof(FormQLTacGia));
                        break;
                    case "Thể Loại":
                        // TODO: Chuyển sang form Quản Lý Thể Loại (Giả sử có FormQLTheLoai)
                        MessageBox.Show("Chuyển sang form Quản Lý Thể Loại (Chưa tạo code form).", "Thông báo");
                        break;
                    case "Nhà Xuất Bản":
                        // Chuyển sang form Quản Lý NXB
                        LoadSubForm(typeof(FormQLNXB));
                        break;
                    default:
                        break;
                }
            }
        }

        private void LoadBookCards()
        {
            pnlCardContainer.Controls.Clear();

            // Dữ liệu giả lập
            List<BookItem> books = new List<BookItem>
            {
                new BookItem { Title = "Đồng Lúa Chọn", Subtitle = "Khi còn trẻ", ImageColor = Color.Teal },
                new BookItem { Title = "J. K. Rowling", Subtitle = "Đừng quay đầu chiều", ImageColor = Color.LightGreen },
                new BookItem { Title = "Khí Chất", Subtitle = "Hạnh phúc", ImageColor = Color.Orange },
                new BookItem { Title = "Tuổi trẻ", Subtitle = "Như một bầu trời", ImageColor = Color.MediumPurple },
                new BookItem { Title = "Kiếm Tìm", Subtitle = "Đen Đáp", ImageColor = Color.Gray },
                new BookItem { Title = "Sách 6", Subtitle = "Mô tả 6", ImageColor = Color.DarkCyan }
            };

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

                // Nếu đã đủ số lượng thẻ trên 1 hàng, xuống hàng mới
                if (cardIndex % cardsPerRow == 0)
                {
                    x = 10;
                    y += cardHeight + padding;
                }
            }
        }

        private Panel CreateBookCard(BookItem book, int width, int height)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(width, height);
            pnl.BackColor = Color.White;
            pnl.BorderStyle = BorderStyle.FixedSingle;

            // 1. Panel chứa ảnh (mô phỏng bìa sách)
            Panel pnlImage = new Panel();
            pnlImage.Size = new Size(width - 20, 200);
            pnlImage.Location = new Point(10, 10);
            pnlImage.BackColor = book.ImageColor; // Màu nền mô phỏng ảnh bìa
            pnl.Controls.Add(pnlImage);

            // 2. Tiêu đề sách
            Label lblTitle = new Label();
            lblTitle.Text = book.Title;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 220);
            lblTitle.Size = new Size(width - 20, 20);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            pnl.Controls.Add(lblTitle);

            // 3. Mô tả/Tác giả
            Label lblSubtitle = new Label();
            lblSubtitle.Text = book.Subtitle;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.Location = new Point(10, 245);
            lblSubtitle.Size = new Size(width - 20, 20);
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            pnl.Controls.Add(lblSubtitle);

            // 4. Nút Chi tiết
            Button btnDetail = new Button();
            btnDetail.Text = "Xem chi tiết";
            btnDetail.BackColor = Color.FromArgb(39, 174, 96); // Màu xanh lá cây
            btnDetail.ForeColor = Color.White;
            btnDetail.FlatStyle = FlatStyle.Flat;
            btnDetail.FlatAppearance.BorderSize = 0;
            btnDetail.Location = new Point(10, height - 45);
            btnDetail.Size = new Size(width - 20, 35);
            btnDetail.Tag = book.Title; // Lưu tên sách để xử lý sự kiện
            btnDetail.Click += BtnDetail_Click;
            pnl.Controls.Add(btnDetail);

            return pnl;
        }

        private void BtnDetail_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            MessageBox.Show($"Xem chi tiết sách: {btn.Tag}", "Thông báo");
            // TODO: Thêm logic để mở Form chỉnh sửa sách
        }
    }

    // Class mô hình dữ liệu (Mẫu)
    public class BookItem
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public Color ImageColor { get; set; }
    }
}