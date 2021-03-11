using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang
{
    public partial class Home1 : System.Web.UI.Page
    {
        WebQuanLyDuAnNhom3Entities db = new WebQuanLyDuAnNhom3Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DangNhap"] == null)
            {
                //Response.Redirect("/Login.aspx");
                plhDaDangNhap.Visible = false;
                plhChuaDangNhap.Visible = true;
            }
            else
            {
                //Literal tenTK = (Literal)Page.Master.FindControl("tenTK");
                //Literal ltlSDT = (Literal)Page.Master.FindControl("ltlSDT");
                plhDaDangNhap.Visible = true;
                plhChuaDangNhap.Visible = false;
                int mataikhoan = int.Parse(Session["maTaiKhoan"].ToString());
                TAIKHOAN taiKhoan = db.TAIKHOAN.FirstOrDefault(m => m.MaTaiKhoan == mataikhoan);
                ltlTen2.Text = taiKhoan.Ten;
                ltlTen1.Text = taiKhoan.Ten;
                ltlSDT1.Text = taiKhoan.SoDienThoai;
            }
        }

        protected void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            Response.Redirect("ThongTinCaNhan.aspx");
        }

        protected void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            Response.Redirect("DoiMatKhau.aspx");
        }

        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            Session["DangNhap"] = null;
            Session["maTaiKhoan"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signin.aspx");

        }


        protected void btnTimKiem_Click1(object sender, EventArgs e)
        {

            Session["timkiem"] = txtTimKiem.Text;
        }
        /*
        protected void btnDangNhap_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnDangKy_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Signin.aspx");
        }

        protected void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            Response.Redirect("DoiMatKhau.aspx");
        }

        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            Session["DangNhap"] = null;
            Session["maTaiKhoan"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            Response.Redirect("ThongTinCaNhan.aspx");
        }*/
    }
}