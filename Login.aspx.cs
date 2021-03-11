using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang
{
    public partial class Login : System.Web.UI.Page
    {
        WebQuanLyDuAnNhom3Entities db = new WebQuanLyDuAnNhom3Entities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DangNhap(object sender, EventArgs e)
        {
            if(txtTenDangNhap.Text.Trim() == "")
            {
                lbTenDangNhap.Text = "*";
                return;
            }
            else
            {
                lbTenDangNhap.Text = "";
            }
            if(txtMatKhau.Text.Trim() == "")
            {
                lbMatKhau.Text = "*";
                return;
            }
            else
            {
                lbTenDangNhap.Text = "";
            }

            string tendangnhap = txtTenDangNhap.Text;
            string matkhau = CreateMD5(txtMatKhau.Text);
            
            TAIKHOAN taiKhoan = db.TAIKHOAN.SingleOrDefault(m => m.TenTaiKhoan == tendangnhap && m.MatKhau == matkhau);
            if(taiKhoan == null)
            {
                ltlThongBao.Text = "<div style=\"color:red;\">Tài khoản hoặc mật khẩu không chính xác!</div>";
            }
            else
            {
                Session["DangNhap"] = "1";
                Session["maTaiKhoan"] = taiKhoan.MaTaiKhoan;
                Session["tenTaiKhoan"] = taiKhoan.TenTaiKhoan;
                Session["ten"] = taiKhoan.Ten;
                if (taiKhoan.Check_admin == 1)
                {
                    Response.Redirect("/Admin.aspx",false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    Response.Redirect("/Home.aspx",false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }
        protected void DangKy(object sender, EventArgs e)
        {
            Response.Redirect("/Signin.aspx",false);
            Context.ApplicationInstance.CompleteRequest();
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}