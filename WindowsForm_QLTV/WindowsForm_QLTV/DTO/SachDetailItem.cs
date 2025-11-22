using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsForm_QLTV
{
    internal class SachDetailItem
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public string TenTacGia { get; set; }
        public string TenNXB { get; set; }
        public string TheLoai { get; set; }
        public int SoLuongTon { get; set; }
        public decimal GiaMuon { get; set; }
        public string TrangThai { get; set; }
        public string MoTa { get; set; }
        public Image CoverImage { get; set; }

        public int MaTacGiaFK { get; set; }
        public int MaNXBFK { get; set; }
        public string HinhAnhPath { get; set; }
    }
}
