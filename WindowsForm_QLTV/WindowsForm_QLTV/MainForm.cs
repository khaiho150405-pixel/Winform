using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic; // Cần thiết cho List

namespace WindowsForm_QLTV
{
    public partial class MainForm : Form
    {
        // Constructor mặc định
        public MainForm()
        {
            InitializeComponent();
        }

        // Constructor quan trọng để truyền dữ liệu người dùng
        public MainForm(string username, string role) : this()
        {
            // Cập nhật thông tin vào Header Sidebar
            lblUserNameHeader.Text = $"MÃ TK: {username}";
            lblUserRoleHeader.Text = $"Vai trò: {role}";
            tsslUsername.Text = $"Đang đăng nhập: {username} | Quyền: {role}";

            AttachMenuEventHandlers();
            ApplyUserPermissions(role); // Áp dụng phân quyền sau khi gán sự kiện

            // Tải nội dung mặc định (Trang chủ)
            ShowContentControl("Trang chủ");
            HighlightButton(btnTrangChu);
        }

        private void ApplyUserPermissions(string role)
        {
            string normalizedRole = role.Trim().ToUpper();

            // Mặc định: Ẩn tất cả các nút quản lý trừ Trang Chủ và Thông tin cá nhân
            btnTrangChu.Visible = true;
            btnThongTinCaNhan.Visible = true;
            btnThoat.Visible = true;

            btnTaiKhoan.Visible = false;
            btnSach.Visible = false;
            btnQLMuonTra.Visible = false;
            btnMuonTra.Visible = false;

            // Các nút bị loại bỏ khỏi thiết kế nhưng vẫn tồn tại trong code logic
            btnBaoCao.Visible = false;
            btnTacGia.Visible = false;
            btnNhaXuatBan.Visible = false;

            switch (normalizedRole)
            {
                case "ADMIN":
                    // ADMIN: Full quyền
                    btnTaiKhoan.Visible = true;
                    btnSach.Visible = true;
                    btnQLMuonTra.Visible = true;
                    btnMuonTra.Visible = true;
                    break;

                case "THỦ THƯ":
                    // THỦ THƯ: Không có Quản lý Tài khoản, Quản lý Sách
                    btnQLMuonTra.Visible = true;
                    btnMuonTra.Visible = true;
                    break;

                case "THỦ KHO":
                    // THỦ KHO: Chỉ có Quản lý Sách, không có Quản lý Tài khoản và QL Mượn Trả
                    btnSach.Visible = true;
                    btnMuonTra.Visible = true;
                    break;

                case "ĐỘC GIẢ":
                    // ĐỘC GIẢ: Chỉ có Trang chủ, Thông tin cá nhân và Mượn trả sách
                    btnMuonTra.Visible = true;
                    break;

                default:
                    // Vai trò không xác định: Hầu hết đều ẩn, chỉ giữ lại các nút cơ bản
                    break;
            }
        }

        private void AttachMenuEventHandlers()
        {
            // Gán sự kiện Click cho các nút Sidebar
            btnTrangChu.Click += BtnItem_Click;
            btnSach.Click += BtnItem_Click;
            btnQLMuonTra.Click += BtnItem_Click;
            btnMuonTra.Click += BtnItem_Click;
            btnTaiKhoan.Click += BtnItem_Click;
            btnThongTinCaNhan.Click += BtnItem_Click;

            // Nút Thoát
            btnThoat.Click += BtnThoat_Click;

            // Đặt lại Text cho các Button (Giữ nguyên)
            btnTaiKhoan.Text = " 🔑 Quản lý tài khoản";
            btnSach.Text = " 📖 Quản lý sách";
            btnQLMuonTra.Text = " 📜 Quản lý mượn trả";
            btnMuonTra.Text = " 📚 Mượn trả sách";
            btnTrangChu.Text = " 🏠 Trang chủ";
            btnThongTinCaNhan.Text = " 👤 Thông tin cá nhân";
            btnThoat.Text = " 🚪 Thoát";
        }

        private void BtnItem_Click(object sender, EventArgs e)
        {
            Button btnItem = sender as Button;
            if (btnItem != null)
            {
                // Lấy tên chức năng chính xác bằng cách loại bỏ icon và khoảng trắng
                string controlName = btnItem.Text.Trim();
                // Loại bỏ icon (các ký tự không phải chữ cái, số, hoặc khoảng trắng)
                controlName = System.Text.RegularExpressions.Regex.Replace(controlName, @"\s*[\p{Cs}\p{So}][\p{Cs}\p{So}]?\s*", "").Trim();

                ShowContentControl(controlName);
                HighlightButton(btnItem);
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi hệ thống không?", "Xác nhận Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void HighlightButton(Button currentButton)
        {
            Color defaultBackColor = Color.FromArgb(44, 62, 80);
            Color highlightColor = Color.FromArgb(52, 152, 219);

            foreach (Control control in pnlSidebar.Controls)
            {
                if (control is Button btn)
                {
                    btn.BackColor = defaultBackColor;
                }
            }

            currentButton.BackColor = highlightColor;
        }

        // ********************************************************
        // HÀM TẠO VÀ HIỂN THỊ NỘI DUNG (CẬP NHẬT)
        // ********************************************************
        private void ShowContentControl(string controlName)
        {
            pnlContent.Controls.Clear();

            // Lấy thông tin người dùng từ StatusStrip để truyền vào các Form con
            string statusText = tsslUsername.Text;
            string username = statusText.Contains("Đang đăng nhập:") ? statusText.Split('|')[0].Replace("Đang đăng nhập:", "").Trim() : "N/A";
            string role = statusText.Contains("Quyền:") ? statusText.Split('|')[1].Replace("Quyền:", "").Trim() : "N/A";

            // KHỞI TẠO BIẾN CỤC BỘ VỚI GIÁ TRỊ MẶC ĐỊNH
            Control newContent = new Label { Text = $"Chức năng '{controlName}' không xác định hoặc không khả dụng.", AutoSize = true, Location = new Point(20, 20) };
            Type formType = null;

            try
            {
                switch (controlName)
                {
                    case "Trang chủ":
                        formType = typeof(TrangChu);
                        break;
                    case "Quản lý sách":
                        formType = typeof(FormQLSach);
                        break;
                    case "Quản lý mượn trả":
                        formType = typeof(FormQLMuonTra);
                        break;
                    case "Mượn trả sách":
                        formType = typeof(MuonTra);
                        break;
                    case "Quản lý tài khoản":
                        formType = typeof(FormQLTaiKhoan);
                        break;
                    case "Thông tin cá nhân":
                        newContent = new UserInfoForm(username, role);
                        break;
                }

                if (formType != null)
                {
                    // Tạo Form từ Type nếu nó là Form
                    newContent = (Form)Activator.CreateInstance(formType);
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi trong quá trình Activator.CreateInstance (ví dụ: Form không tồn tại)
                newContent = new Label { Text = $"Lỗi tải Form {controlName}: {ex.Message}", AutoSize = true, ForeColor = Color.Red, Location = new Point(20, 20) };
            }


            if (newContent is Form form)
            {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Show();
            }

            newContent.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(newContent);
        }
    }
}