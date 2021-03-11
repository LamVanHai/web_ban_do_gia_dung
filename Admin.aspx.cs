using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang
{
    public partial class Home : System.Web.UI.Page
    {
        WebQuanLyDuAnNhom3Entities db = new WebQuanLyDuAnNhom3Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["DangNhap"] == null)
            {
                //Response.Redirect("/Login.aspx");
            }
            else
            {
                int mataikhoan = int.Parse(Session["maTaiKhoan"].ToString());
                TAIKHOAN taiKhoan = db.TAIKHOAN.FirstOrDefault(m => m.MaTaiKhoan == mataikhoan);
                ltlTen1.Text = taiKhoan.Ten;
                ltlTen2.Text = taiKhoan.Ten;
                ltlSDT.Text = taiKhoan.SoDienThoai;
            }
        }

        protected string DanhDau(string tenModul)
        {
            string s = "";
            string modul = ""; //Biến lưu giá trị của querstring modul
            if (Request.QueryString["m"] != null)
                modul = Request.QueryString["m"];
            if (tenModul == modul)
                s = "current";
            return s;
        }

        protected void DangXuat(object sender, EventArgs e)
        {
            Session["DangNhap"] = null;
            Session["maTaiKhoan"] = null;
            Response.Redirect("/Login.aspx");
        }
    }
}