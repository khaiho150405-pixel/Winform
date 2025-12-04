using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm_QLTV
{
    public class Session
    {
        // Tên đăng nhập hiện tại
        public static string CurrentUsername { get; set; }

        // Vai trò (Quyền): ADMIN, THỦ THƯ, ĐỘC GIẢ...
        public static string CurrentRole { get; set; }

        // Mã sinh viên (nếu là độc giả)
        public static int CurrentMaSV { get; set; }

        // Mã thủ thư (nếu là thủ thư hoặc admin liên kết)
        public static int CurrentMaTT { get; set; }

        // Hàm xóa session khi đăng xuất
        public static void Clear()
        {
            CurrentUsername = null;
            CurrentRole = null;
            CurrentMaSV = 0;
            CurrentMaTT = 0;
        }

        // Kiểm tra xem có phải Admin không
        public static bool IsAdmin()
        {
            return !string.IsNullOrEmpty(CurrentRole) &&
                   (CurrentRole.Trim().ToUpper() == "ADMIN" || CurrentRole.Trim().ToUpper() == "QUẢN TRỊ VIÊN");
        }
    }
}
