using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsForm_QLTV;

namespace WindowsForm_QLTV
{
    public class FormTuongTacDocGia : Form
    {
        // --- KHAI BÁO CÁC CONTROL ---
        private TabControl tabControl;
        private TabPage tabGuiCauHoi;
        private TabPage tabLichSu;
        private TabPage tabGuiGopY;

        // Tab 1: Hỏi đáp
        private TextBox txtCauHoi;
        private Button btnGuiCauHoi;
        private Label lblHuongDanHoi;

        // Tab 2: Lịch sử
        private DataGridView dgvLichSu;

        // Tab 3: Góp ý
        private TextBox txtGopY;
        private ComboBox cmbLoaiGopY;
        private Button btnGuiGopY;
        private Label lblHuongDanGopY;
        private Label lblLoaiGopY;

        // Biến lưu mã sinh viên đăng nhập
        private int _maSV;

        public FormTuongTacDocGia(int maSV)
        {
            _maSV = maSV;

            // 1. Khởi tạo giao diện bằng Code
            InitializeCustomComponents();

            // 2. Load dữ liệu ban đầu
            LoadLichSuHoiDap();
        }

        // --- PHẦN 1: CODE DỰNG GIAO DIỆN (UI) ---
        private void InitializeCustomComponents()
        {
            this.Text = "Tương tác Độc giả - Thư viện";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // 1. Tab Control
            tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;

            // --- TAB 1: GỬI CÂU HỎI ---
            tabGuiCauHoi = new TabPage("Gửi Câu Hỏi");
            tabGuiCauHoi.BackColor = Color.WhiteSmoke;

            lblHuongDanHoi = new Label() { Text = "Nhập câu hỏi của bạn gửi đến thủ thư:", Location = new Point(20, 20), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
            txtCauHoi = new TextBox() { Location = new Point(20, 50), Size = new Size(720, 200), Multiline = true, Font = new Font("Arial", 10) };
            btnGuiCauHoi = new Button() { Text = "Gửi câu hỏi", Location = new Point(20, 270), Size = new Size(150, 40), BackColor = Color.DodgerBlue, ForeColor = Color.White, Font = new Font("Arial", 10, FontStyle.Bold) };
            btnGuiCauHoi.Click += BtnGuiCauHoi_Click; // Gắn sự kiện click

            tabGuiCauHoi.Controls.Add(lblHuongDanHoi);
            tabGuiCauHoi.Controls.Add(txtCauHoi);
            tabGuiCauHoi.Controls.Add(btnGuiCauHoi);

            // --- TAB 2: LỊCH SỬ ---
            tabLichSu = new TabPage("Lịch Sử Hỏi Đáp");
            dgvLichSu = new DataGridView();
            dgvLichSu.Dock = DockStyle.Fill;
            dgvLichSu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichSu.ReadOnly = true;
            dgvLichSu.AllowUserToAddRows = false;
            tabLichSu.Controls.Add(dgvLichSu);

            // --- TAB 3: GỬI GÓP Ý ---
            tabGuiGopY = new TabPage("Gửi Góp Ý");
            tabGuiGopY.BackColor = Color.WhiteSmoke;

            lblHuongDanGopY = new Label() { Text = "Nội dung góp ý:", Location = new Point(20, 20), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
            txtGopY = new TextBox() { Location = new Point(20, 50), Size = new Size(720, 200), Multiline = true, Font = new Font("Arial", 10) };

            lblLoaiGopY = new Label() { Text = "Loại góp ý:", Location = new Point(20, 270), AutoSize = true };
            cmbLoaiGopY = new ComboBox() { Location = new Point(100, 265), Size = new Size(200, 30), DropDownStyle = ComboBoxStyle.DropDownList };
            // Thêm dữ liệu cứng cho ComboBox
            cmbLoaiGopY.Items.AddRange(new string[] { "Cơ sở vật chất", "Thái độ phục vụ", "Tài liệu sách", "Khác" });
            cmbLoaiGopY.SelectedIndex = 0;

            btnGuiGopY = new Button() { Text = "Gửi góp ý", Location = new Point(20, 310), Size = new Size(150, 40), BackColor = Color.ForestGreen, ForeColor = Color.White, Font = new Font("Arial", 10, FontStyle.Bold) };
            btnGuiGopY.Click += BtnGuiGopY_Click; // Gắn sự kiện click

            tabGuiGopY.Controls.Add(lblHuongDanGopY);
            tabGuiGopY.Controls.Add(txtGopY);
            tabGuiGopY.Controls.Add(lblLoaiGopY);
            tabGuiGopY.Controls.Add(cmbLoaiGopY);
            tabGuiGopY.Controls.Add(btnGuiGopY);

            // Thêm các tab vào TabControl
            tabControl.TabPages.Add(tabGuiCauHoi);
            tabControl.TabPages.Add(tabLichSu);
            tabControl.TabPages.Add(tabGuiGopY);

            // Thêm TabControl vào Form
            this.Controls.Add(tabControl);
        }


        // --- PHẦN 2: XỬ LÝ LOGIC (DATABASE) ---

        // Xử lý sự kiện Gửi câu hỏi
        private void BtnGuiCauHoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCauHoi.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung câu hỏi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new Model1())
                {
                    var hoidap = new HOIDAP
                    {
                        MASV = _maSV,
                        CAUHOI = txtCauHoi.Text.Trim(),
                        TRANGTHAI = "Chờ trả lời",
                        THOIGIANHOI = DateTime.Now
                    };

                    db.HOIDAPs.Add(hoidap);
                    db.SaveChanges();
                }

                MessageBox.Show("Gửi câu hỏi thành công! Bạn có thể xem trạng thái ở tab Lịch Sử.", "Thông báo");
                txtCauHoi.Clear();
                LoadLichSuHoiDap(); // Refresh lại tab lịch sử
                tabControl.SelectedTab = tabLichSu; // Tự động chuyển qua tab lịch sử để xem
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi câu hỏi: " + ex.Message);
            }
        }

        // Xử lý sự kiện Gửi góp ý
        private void BtnGuiGopY_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGopY.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung góp ý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new Model1())
                {
                    var gopy = new GOPY
                    {
                        MASV = _maSV,
                        NOIDUNG = txtGopY.Text.Trim(),
                        LOAIGOPY = cmbLoaiGopY.SelectedItem.ToString(),
                        TRANGTHAI = "Mới tiếp nhận",
                        THOIGIANGUI = DateTime.Now
                    };

                    db.GOPies.Add(gopy);
                    db.SaveChanges();
                }

                MessageBox.Show("Cảm ơn bạn đã đóng góp ý kiến!", "Thông báo");
                txtGopY.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi góp ý: " + ex.Message);
            }
        }

        // Hàm load lịch sử lên DataGridView
        private void LoadLichSuHoiDap()
        {
            try
            {
                using (var db = new Model1())
                {
                    // Truy vấn dữ liệu từ DB (Bảng HOIDAP)
                    var history = db.HOIDAPs
                        .Where(h => h.MASV == _maSV)
                        .OrderByDescending(h => h.THOIGIANHOI)
                        .Select(h => new
                        {
                            CauHoi = h.CAUHOI,
                            TraLoi = h.TRALOI,
                            TrangThai = h.TRANGTHAI,
                            NgayHoi = h.THOIGIANHOI
                        })
                        .ToList();

                    dgvLichSu.DataSource = history;

                    // Đặt tên cột tiếng Việt cho đẹp
                    if (dgvLichSu.Columns["CauHoi"] != null) dgvLichSu.Columns["CauHoi"].HeaderText = "Câu hỏi";
                    if (dgvLichSu.Columns["TraLoi"] != null) dgvLichSu.Columns["TraLoi"].HeaderText = "Trả lời của thủ thư";
                    if (dgvLichSu.Columns["TrangThai"] != null) dgvLichSu.Columns["TrangThai"].HeaderText = "Trạng thái";
                    if (dgvLichSu.Columns["NgayHoi"] != null) dgvLichSu.Columns["NgayHoi"].HeaderText = "Ngày gửi";
                }
            }
            catch (Exception ex)
            {
                // Bỏ qua lỗi nếu chưa có dữ liệu hoặc DB chưa sẵn sàng
            }
        }
    }
}