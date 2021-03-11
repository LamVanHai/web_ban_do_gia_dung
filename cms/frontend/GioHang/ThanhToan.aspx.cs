using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang.cms.frontend.GioHang
{
    public partial class ThanhToan : System.Web.UI.Page
    {
        WebQuanLyDuAnNhom3Entities db = new WebQuanLyDuAnNhom3Entities(); // biến db đển kết nối đến csdl
        protected void Page_Load(object sender, EventArgs e)
        {
            int maTK = int.Parse(Session["maTaiKhoan"].ToString());
            if(maTK == null)
            {
                Response.Redirect("/Login.aspx",false);
                return;
            }
            DONHANG dh = db.DONHANG.Where(m => m.MaKhachHang == maTK).Where(m => m.TrangThai == "giohang").SingleOrDefault();
            int maDH = int.Parse(dh.MaDonHang.ToString());
            List<CHITIETDONHANG> listCTDH = db.CHITIETDONHANG.Where(m => m.MaDonHang == maDH).ToList();
            if(listCTDH.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Giỏ hàng trống không')", true);
                Response.Redirect("/Home.aspx", false);
            }
            listGioHang.Text = "";
            decimal total = 0;
            foreach (CHITIETDONHANG CTDH in listCTDH)
            {
                SANPHAM sp = db.SANPHAM.FirstOrDefault(m => m.MaSanPham == CTDH.MaSanPham);
                total += sp.Gia * CTDH.SoLuong;
                listGioHang.Text += @"<li class='fw-normal'>"+sp.TenSanPham+" x "+CTDH.SoLuong+" <span>"+ string.Format("{0:n0}", sp.Gia * CTDH.SoLuong) +"</span></li>";
            }
            subtotal1.Text = string.Format("{0:n0}", total);
            TAIKHOAN tk = db.TAIKHOAN.FirstOrDefault(m => m.MaTaiKhoan == maTK);
            txtTen.Text = tk.Ten;
            txtDiaChi.Text = tk.DiaChi;
            txtSdt.Text = tk.SoDienThoai;
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            bool validate = true;
            if(txtTen.Text == "")
            {
                errTen.Text = "Chưa nhập tên người nhận";
                validate = false;
            }
            
            if(txtSdt.Text == "")
            {
                errSDT.Text = "Chưa nhập số điện thoại";
                validate = false;
            }

            if (txtDiaChi.Text == "")
            {
                errDiaChi.Text = "Chưa nhập địa chỉ";
                validate = false;
            }
            if (!validate) return;
            int maTK = int.Parse(Session["maTaiKhoan"].ToString());
            DONHANG dh = db.DONHANG.Where(m => m.MaKhachHang == maTK).Where(m => m.TrangThai == "giohang").SingleOrDefault();
            dh.TenKhachHang = txtTen.Text;
            dh.DiaChi = txtDiaChi.Text;
            dh.SoDienThoai = txtSdt.Text;
            if (online.Checked)
            {
                dh.ThanhToan = "Chuyển khoản";
            }
            else
            {
                dh.ThanhToan = "Thanh toán khi nhận";
            }
            dh.TrangThai = "Chờ xác nhận";
            dh.NgayDatHang = DateTime.Now;
            db.SaveChanges();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Khởi tạo đơn hành thành công')", true);
            Response.Redirect("/cms/frontend/GioHang/HistoryCart.aspx",false);
        }
    }
}