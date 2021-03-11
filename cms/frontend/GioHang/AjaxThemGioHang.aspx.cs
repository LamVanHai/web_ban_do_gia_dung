using System;
using System.Transactions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace WebBanHang.cms.frontend.GioHang
{
    public partial class AjaxThemGioHang : System.Web.UI.Page
    {
        WebQuanLyDuAnNhom3Entities db = new WebQuanLyDuAnNhom3Entities();
        int mtk;
        int status_code = 200;
        string msg = "";
        int maDonHang = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DangNhap"] == null )
            {
                Response.Redirect("/Login.aspx");
                return;
            }
            mtk = int.Parse(Session["maTaiKhoan"].ToString());
            ThemGioHang();
            List<CHITIETDONHANG> listCTDH = db.CHITIETDONHANG.Where(m => m.MaDonHang == maDonHang).ToList();
            string listGioHang = "";
            decimal total = 0;
            foreach (CHITIETDONHANG CTDH in listCTDH)
            {
                SANPHAM sp = db.SANPHAM.FirstOrDefault(m => m.MaSanPham == CTDH.MaSanPham);
                total += sp.Gia * CTDH.SoLuong;
                listGioHang += @"<tr>
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
            CompleteAjax(msg, status_code);
        }
        private void CompleteAjax(string message, int status_code)
        {
            Response.Clear();
            Response.StatusCode = status_code;
            Response.Write(message);
            Response.OutputStream.Close();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        private void ThemGioHang()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                int maHang;
                int soLuong;
                decimal giaBan;
                
                
                try
                {
                    if (Request.ContentType.Contains("json"))
                    {
                        System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
                        string line = "";
                        line = sr.ReadToEnd();
                        
                        JObject a = JObject.Parse(line);
                        System.Diagnostics.Debug.WriteLine(a);
                        maHang = int.Parse((string)a["maHang"]);
                        soLuong = int.Parse((string)a["soluong"]);
                        SANPHAM sanpham = db.SANPHAM.FirstOrDefault(m => m.MaSanPham == maHang);
                        giaBan = sanpham.Gia;
                        DONHANG donhang = db.DONHANG.FirstOrDefault(m => m.TrangThai == "giohang" && m.MaKhachHang == mtk);
                        if (donhang == null)
                        {
                            donhang = new DONHANG();
                            donhang.MaKhachHang = int.Parse(Session["maTaiKhoan"].ToString());
                            donhang.TrangThai = "giohang";
                            db.DONHANG.Add(donhang);
                            db.SaveChanges();
                        }
                        donhang = db.DONHANG.FirstOrDefault(m => m.TrangThai == "giohang" && m.MaKhachHang == mtk);
                        maDonHang = donhang.MaDonHang;

                        CHITIETDONHANG chitietdonhang = db.CHITIETDONHANG.Where(m => m.MaDonHang == maDonHang).Where(m => m.MaSanPham == maHang).SingleOrDefault();
                        if (chitietdonhang == null)
                        {
                            chitietdonhang = new CHITIETDONHANG();
                            chitietdonhang.MaDonHang = maDonHang;
                            chitietdonhang.MaSanPham = maHang;
                            chitietdonhang.SoLuong = soLuong;
                            chitietdonhang.GiaBan = giaBan;
                            chitietdonhang.TongTien = soLuong * giaBan;
                            db.CHITIETDONHANG.Add(chitietdonhang);
                        }
                        else
                        {
                            chitietdonhang.SoLuong += soLuong;
                            chitietdonhang.GiaBan = giaBan;
                            chitietdonhang.TongTien += soLuong * giaBan;
                        }
                        db.SaveChanges();
                        transaction.Complete();
                        msg = @"Them gio hang thanh cong";
                        
                    }
                }
                catch (Exception e)
                {
                    msg = e.InnerException.InnerException.Message.Split('\n')[1];
                    status_code = 503;
                    //System.Diagnostics.Debug.WriteLine(e.InnerException.InnerException.Message.Split('\n')[1]);
                }
            }
        }
    }
}