using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForm_QLTV
{
    public partial class FormQLMuonTra : Form
    {
        public FormQLMuonTra()
        {
            InitializeComponent();
            this.Load += FormQLMuonTra_Load;

            // Gán sự kiện cho các nút chức năng
            btnMuonSach.Click += BtnMuonTra_Click;
            btnTraSach.Click += BtnMuonTra_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
        }

        private void FormQLMuonTra_Load(object sender, EventArgs e)
        {
            // Thiết lập Placeholder cho ô tìm kiếm
            txtSearch.Text = "Nhập mã sách hoặc thông tin người mượn...";
            txtSearch.ForeColor = Color.Gray;

            txtSearch.Enter += TxtSearch_Enter;
            txtSearch.Leave += TxtSearch_Leave;

            // Mặc định load nội dung tìm kiếm (Giả lập)
            DisplayDefaultContent();
        }

        // Xử lý sự kiện Placeholder
        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập mã sách hoặc thông tin người mượn...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Nhập mã sách hoặc thông tin người mượn...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void BtnMuonTra_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                string action = clickedButton.Text.Trim();
                Type targetFormType = null;

                // Xác định Form cần load
                if (action == "MƯỢN SÁCH")
                {
                    targetFormType = typeof(FormMuonSach);
                }
                else if (action == "TRẢ SÁCH")
                {
                    targetFormType = typeof(FormTraSach);
                }

                if (targetFormType != null)
                {
                    try
                    {
                        // 1. Khởi tạo Form mới
                        Form newForm = (Form)Activator.CreateInstance(targetFormType);

                        // 2. Xóa tất cả controls hiện tại (Dashboard, Search, Content)
                        this.pnlBackground.Controls.Clear();

                        // 3. Thiết lập Form con mới
                        newForm.TopLevel = false;
                        newForm.FormBorderStyle = FormBorderStyle.None;
                        newForm.Dock = DockStyle.Fill;

                        // 4. Thêm và hiển thị Form mới, nó sẽ chiếm toàn bộ FormQLMuonTra
                        this.pnlBackground.Controls.Add(newForm);
                        newForm.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi tải Form {targetFormType.Name}: {ex.Message}\nĐảm bảo Form đã được biên dịch.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (keyword == "Nhập mã sách hoặc thông tin người mượn..." || string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo");
                return;
            }

            MessageBox.Show($"Tìm kiếm thông tin sách/mượn trả với từ khóa: {keyword}", "Tìm kiếm");
            // TODO: Hiển thị kết quả tìm kiếm trong pnlMainContent
        }

        private void DisplayDefaultContent()
        {
            pnlMainContent.Controls.Clear();
            Label lbl = new Label();
            lbl.Text = "Kết quả tìm kiếm sẽ hiển thị tại đây...";
            lbl.Font = new Font("Segoe UI", 12F);
            lbl.AutoSize = true;
            lbl.Location = new Point(20, 20);
            pnlMainContent.Controls.Add(lbl);
        }
    }
}