using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang.cms.frontend.GioHang
{
    public partial class HistoryCart : System.Web.UI.Page
    {
        WebQuanLyDuAnNhom3Entities db = new WebQuanLyDuAnNhom3Entities();
        int mtk;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DangNhap"] == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }
            mtk = int.Parse(Session["maTaiKhoan"].ToString());
            List<DONHANG> list_dh = db.DONHANG.Where(m => m.MaKhachHang == mtk && m.TrangThai != "giohang").OrderByDescending(m => m.NgayDatHang).ToList();
            var list_dh_html = "<div class='row'>";
            foreach (var dh in list_dh)
            {
                List<CHITIETDONHANG> list_CTDH = db.CHITIETDONHANG.Where(m => m.MaDonHang == dh.MaDonHang).ToList();
                var dh_info_html = "<div class='col-lg-12'><div class='cart-table'><table><thead><tr style='background: lightgrey;                '><th colspan='3' class='text-left pl-5 text-left'>Đơn hàng: ";
                dh_info_html += dh.TenKhachHang + " - " + dh.SoDienThoai + " - " + dh.DiaChi +": "+dh.NgayDatHang +"</th><th style = 'text-align:left!important;text-transform:none!important' > ";
                dh_info_html += "Trạng thái: <br /><span class='text-danger'>" + dh.TrangThai + "<span></th> </tr></thead><tbody>";
                decimal tong = 0;
                foreach(var CTDN in list_CTDH)
                {
                    var item_info_html = "";
                    SANPHAM sp = db.SANPHAM.FirstOrDefault(m => m.MaSanPham == CTDN.MaSanPham);
                    item_info_html += "<tr ><td class='cart-pic first-row'><img src='" + sp.Anh + "' alt=''></td>";
                    item_info_html += "<td class='cart-title first-row'><h5>"+sp.TenSanPham+"</h5></td>";
                    item_info_html += "<td class='p-price first-row'>"+ string.Format("{0:n0}", CTDN.GiaBan) +"</td>";
                    item_info_html += "<td class='qua-col first-row'>x " + CTDN.SoLuong+ "</td></tr>";
                    dh_info_html += item_info_html;
                    tong += CTDN.GiaBan * CTDN.SoLuong;
                }
                dh_info_html += "<tr style='background: lemonchiffon;'><td class='cart-title first-row'></td> ";
                dh_info_html += "<td class='cart-title first-row' ><h5><b>Tổng tiền</b><h5></td>";
                dh_info_html += "<td class='qua-col first-row' >"+ string.Format("{0:n0}", tong) +"</td>";
                dh_info_html += "<td colspan='1'></td></tr></tbody></table></div></div>";
                list_dh_html += dh_info_html;

            }
            list_dh_html += "</div>";
            list_cart_history.Text = list_dh_html;
        }
    }
}