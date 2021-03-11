using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.cms.admin.ThongKe
{
    public class CacSanPhamDaBan
    {
        public int id { get; set; }
        public int maDanhMuc { get; set; }
        public string tenSanPham { get; set; }
        public string anh { get; set; }
        public decimal gia { get; set; }
        public int soLuongBan { get; set; }
        public decimal tongTien { get; set; }
        public int maKhachHangMua { get; set; }
        public DateTime? ngayBan { get; set; }
        public int page { get; set; }
    }
}