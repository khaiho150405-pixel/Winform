using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowsForm_QLTV
{
    // ====================================================
    // PHẦN MÔ HÌNH DỮ LIỆU (STRUCT ĐƠN GIẢN)
    // ====================================================
    public struct BookItem
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public Color ImageColor { get; set; }
    }


    // ====================================================
    // PHẦN LOGIC (PARTIAL CLASS)
    // ====================================================
    public partial class UC_TrangChu : UserControl
    {
        public UC_TrangChu()
        {
            InitializeComponent();
            this.Load += UC_TrangChu_Load;
        }

        private void UC_TrangChu_Load(object sender, EventArgs e)
        {
            // Thiết lập Banner
            pnlBanner.Height = 200;

            // Load các thẻ sách (Card) mẫu
            LoadBookCards();
        }

        private void LoadBookCards()
        {
            pnlBookContainer.Controls.Clear();

            // Dữ liệu giả lập
            List<BookItem> books = new List<BookItem>
            {
                new BookItem { Title = "Lập trình C#", Subtitle = "Nguyễn Văn A", ImageColor = Color.Teal },
                new BookItem { Title = "Cơ sở dữ liệu", Subtitle = "Phạm Văn B", ImageColor = Color.LightGreen },
                new BookItem { Title = "Thiết kế UI/UX", Subtitle = "Trần Thị C", ImageColor = Color.Orange },
                new BookItem { Title = "Kinh tế học", Subtitle = "Lê Văn D", ImageColor = Color.MediumPurple },
                new BookItem { Title = "Marketing số", Subtitle = "Hoàng Thị E", ImageColor = Color.Gray },
            };

            int x = 0;
            int y = 0;
            int cardWidth = 200;
            int cardHeight = 300;
            int padding = 20;
            int cardsPerRow = 4;
            int cardIndex = 0;

            foreach (var book in books)
            {
                Panel card = CreateBookCard(book, cardWidth, cardHeight);
                card.Location = new Point(x, y);
                pnlBookContainer.Controls.Add(card);

                x += cardWidth + padding;
                cardIndex++;

                if (cardIndex % cardsPerRow == 0)
                {
                    x = 0;
                    y += cardHeight + padding;
                }
            }
            // Điều chỉnh chiều cao của pnlBookContainer để tránh cuộn kép
            this.pnlBookContainer.Height = y + cardHeight + 10;
        }

        private Panel CreateBookCard(BookItem book, int width, int height)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(width, height);
            pnl.BackColor = Color.White;
            pnl.BorderStyle = BorderStyle.FixedSingle;

            // 1. Panel chứa ảnh (mô phỏng bìa sách)
            Panel pnlImage = new Panel();
            pnlImage.Size = new Size(width, 200);
            pnlImage.Location = new Point(0, 0);
            pnlImage.BackColor = book.ImageColor;
            pnl.Controls.Add(pnlImage);

            // 2. Tiêu đề sách
            Label lblTitle = new Label();
            lblTitle.Text = book.Title;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 210);
            lblTitle.Size = new Size(width - 20, 20);
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            pnl.Controls.Add(lblTitle);

            // 3. Mô tả/Tác giả
            Label lblSubtitle = new Label();
            lblSubtitle.Text = book.Subtitle;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.Location = new Point(10, 235);
            lblSubtitle.Size = new Size(width - 20, 20);
            lblSubtitle.TextAlign = ContentAlignment.MiddleLeft;
            pnl.Controls.Add(lblSubtitle);

            // 4. Nút Chi tiết (đã đơn giản hóa)
            Button btnDetail = new Button();
            btnDetail.Text = "Chi tiết";
            btnDetail.BackColor = Color.FromArgb(52, 152, 219);
            btnDetail.ForeColor = Color.White;
            btnDetail.FlatStyle = FlatStyle.Flat;
            btnDetail.FlatAppearance.BorderSize = 0;
            btnDetail.Location = new Point(50, height - 35);
            btnDetail.Size = new Size(100, 30);
            btnDetail.Tag = book.Title;
            pnl.Controls.Add(btnDetail);

            return pnl;
        }
    }
}