using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang.cms.frontend.GioHang
{
    public partial class index : System.Web.UI.Page
    {
        WebQuanLyDuAnNhom3Entities db = new WebQuanLyDuAnNhom3Entities(); // biến db đển kết nối đến csdl
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DangNhap"] != null)
            {
                int maTK = int.Parse(Session["maTaiKhoan"].ToString());
                List<DONHANG> listDH = db.DONHANG.Where(m => m.MaKhachHang == maTK).Where(m => m.TrangThai == "giohang").ToList();
                listGioHang.Text = "";
                foreach (DONHANG dh in listDH)
                {
                    int maDH = int.Parse(dh.MaDonHang.ToString());
                    List<CHITIETDONHANG> listCTDH = db.CHITIETDONHANG.Where(m => m.MaDonHang == maDH).ToList();
                    
                    decimal total = 0;
                    foreach (CHITIETDONHANG CTDH in listCTDH)
                    {
                        SANPHAM sp = db.SANPHAM.FirstOrDefault(m => m.MaSanPham == CTDH.MaSanPham);
                        total += sp.Gia * CTDH.SoLuong;
                        listGioHang.Text += @"<tr>
                    <td style='display:none' class='maSP'>" + sp.MaSanPham + @"</td>
                    <td class='cart-pic first-row'><img src = '" + sp.Anh + @"' alt=''></td>
                    <td class='cart-title first-row'>
                        <h5>" + sp.TenSanPham + @"</h5>
                    </td>
                    <td class='p-price first-row'>" + string.Format("{0:n0}", sp.Gia) + @"</td>
                    <td class='qua-col first-row'>
                        <div class='quantity'>
                            <div class='pro-qty'>
                                <input type = 'text' value='" + CTDH.SoLuong + @"'>
                            </div>
                        </div>
                    </td>
                    <td class='total-price first-row'>" + string.Format("{0:n0}", sp.Gia * CTDH.SoLuong) + @"</td>
                    <td class='close-td first-row'><i class='ti-close'></i></td>
                </tr>";
                    }
                    subtotal.Text = string.Format("{0:n0}", total);
                    carttotal.Text = string.Format("{0:n0}", total);
                }
                
           
            }
            else
            {
                Response.Write("<script>alert('Bạn chưa đăng nhập')</script>");
                Response.Redirect("/Login.aspx");
            }    

            if(Request.QueryString["id"] != null)
            {

            }
        }
    }
}