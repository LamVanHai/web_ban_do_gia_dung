using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang.cms.display
{
    public partial class ChiTiet : System.Web.UI.UserControl
    {
        WebQuanLyDuAnNhom3Entities db = new WebQuanLyDuAnNhom3Entities();
        int id = -1;
        static int soLuong1 = 1;
        int soLuongTrongKho = 0;
        List<SANPHAM> listSP;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["id"] != null)
            {
                id = int.Parse(Request.QueryString["id"]);
            }
            LaySanPham(id);
        }
        private void LaySanPham(int id)
        {
            SANPHAM i = db.SANPHAM.Where(m => m.MaSanPham == id).FirstOrDefault();
            soLuongTrongKho = i.SoLuongTrongKho;
            lbLoaiSanPham.Text = "Đồ gia dụng";
            if (i.MaDanhMuc == 1)
            {
                lbLoaiSanPham.Text = "Đồ thực phẩm";
            }
            lbTenSanPham.Text = i.TenSanPham;
            lbGia.Text = i.Gia.ToString();
            lbMoTaSanPham.Text = i.MieuTa;
        }


        protected void btnThemVaoGioHang_Click(object sender, EventArgs e)
        {

            if (id != -1)
            {
                int maKhachHang = -1;
                SANPHAM i = db.SANPHAM.Where(m => m.MaSanPham == id).FirstOrDefault();
                if(Session["maTaiKhoan"] != null)
                {
                    maKhachHang = int.Parse(Session["maTaiKhoan"].ToString());
                }
                else
                {
                    Response.Redirect("/Login.aspx");
                }    

                String thanhToan = "Thanh toán khi nhận hàng";
                if (RadioButton1.Checked)
                {
                    thanhToan = "Chuyển khoản";
                }
                String trangThai = "giohang";
                DateTime ngayDatHang = DateTime.Now;
                TAIKHOAN tk = db.TAIKHOAN.Where(m => m.MaTaiKhoan == maKhachHang).FirstOrDefault();
                String tenKhachHang = tk.Ten;
                String diaChi = tk.DiaChi;
                String soDienThoai = tk.SoDienThoai;

                int maSanPham = id;
                int soLuong = 1;
                decimal giaBan = i.Gia;
                decimal tongTien = soLuong * giaBan;

                DONHANG donHang = new DONHANG();
                donHang.MaKhachHang = maKhachHang;
                donHang.ThanhToan = thanhToan;
                donHang.NgayDatHang = ngayDatHang;
                donHang.TrangThai = trangThai;
                donHang.TenKhachHang = tenKhachHang;
                donHang.DiaChi = diaChi;
                donHang.SoDienThoai = soDienThoai;
                db.DONHANG.Add(donHang);

                CHITIETDONHANG chiTiet = new CHITIETDONHANG();
                chiTiet.MaSanPham = maSanPham;
                chiTiet.SoLuong = soLuong;
                chiTiet.GiaBan = giaBan;
                chiTiet.TongTien = tongTien;
                db.CHITIETDONHANG.Add(chiTiet);

                db.SaveChanges();
                Response.Redirect("https:////localhost:44347//cms//frontend//GioHang//index.aspx");

            }
            
        }
    }
}