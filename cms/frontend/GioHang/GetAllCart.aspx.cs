using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang.cms.frontend.GioHang
{
    public partial class GetAllCart : System.Web.UI.Page
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
            getAllCart();
        }

        protected void getAllCart()
        {
            Response.Clear();
            Response.StatusCode = 200;
            Response.ContentType = "application/json";
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var listtemp = new List<dynamic>();
            DONHANG donhang = db.DONHANG.FirstOrDefault(m => m.TrangThai == "giohang" && m.MaKhachHang == mtk);
            if(donhang != null)
            {
                int maDH = int.Parse(donhang.MaDonHang.ToString());
                List<CHITIETDONHANG> listCTDH = db.CHITIETDONHANG.Where(m => m.MaDonHang == maDH).ToList();
                string json = "[";
                foreach (CHITIETDONHANG CTDH in listCTDH)
                {
                    json += "{'maSP':" + CTDH.MaSanPham + "},";
                }
                json += "]";
                json = json.Replace(",]", "]");
                
                foreach (CHITIETDONHANG CTDH in listCTDH)
                {
                    SANPHAM sp = db.SANPHAM.FirstOrDefault(m => m.MaSanPham == CTDH.MaSanPham);
                    listtemp.Add(new { maSP = CTDH.MaSanPham, anhSP = sp.Anh, gia = sp.Gia, soLuong = CTDH.SoLuong, tenSP = sp.TenSanPham });
                }
            }
            
            Response.Write(ser.Serialize(listtemp));
            Response.OutputStream.Close();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}