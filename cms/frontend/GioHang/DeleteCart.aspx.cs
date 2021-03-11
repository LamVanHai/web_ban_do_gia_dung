using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang.cms.frontend.GioHang
{
    public partial class DeleteCart : System.Web.UI.Page
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
            XoaGioHang();
        }

        private void XoaGioHang()
        {
            try
            {
                int maSP;
                int soLuong;

                string[] paramKeys = Request.Params.AllKeys;
                //System.Diagnostics.Debug.WriteLine("Hello tao day");
                if (Request.ContentType.Contains("json"))
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
                    string line = "";
                    line = sr.ReadToEnd();
                    //System.Diagnostics.Debug.WriteLine(line);
                    JArray a = JArray.Parse(line);

                    foreach (JObject item in a)
                    {
                        maSP = int.Parse(item.GetValue("maSP").ToString());
                        DONHANG donhang = db.DONHANG.FirstOrDefault(m => m.TrangThai == "giohang" && m.MaKhachHang == mtk);
                        if (donhang != null)
                        {
                            int maDonHang = donhang.MaDonHang;
                            CHITIETDONHANG chitietdonhang = db.CHITIETDONHANG.Where(m => m.MaDonHang == maDonHang).Where(m => m.MaSanPham == maSP).SingleOrDefault();
                            if(chitietdonhang != null)
                            {
                                db.CHITIETDONHANG.Remove(chitietdonhang);
                                db.SaveChanges();
                            }
                        }
                    }
                }
                string msg = "Xoa hang thanh cong";
                CompleteAjax(msg, 200);
            }
            catch (Exception e)
            {
                CompleteAjax("Xoa hang loi", 503);
                return;
            }
        }

        private void CompleteAjax(string message, int status_code)
        {
            Response.Clear();
            Response.StatusCode = status_code;
            Response.Write(message);
            Response.OutputStream.Close();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}