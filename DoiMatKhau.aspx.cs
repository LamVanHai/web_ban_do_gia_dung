using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang
{
    public partial class DoiMatKhau : System.Web.UI.Page
    {
        WebQuanLyDuAnNhom3Entities db = new WebQuanLyDuAnNhom3Entities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Doi(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text.Trim() == "")
            {
                lbMatKhauCu.Text = "*";
                return;
            }
            else
            {
                lbMatKhauCu.Text = "";
            }
            if (txtMatKhauMoi.Text.Trim() == "")
            {
                lbMatKhauMoi.Text = "*";
                return;
            }
            else
            {
                lbMatKhauMoi.Text = "";
            }
            if (txtXacNhan.Text.Trim() == "")
            {
                lbXacNhan.Text = "*";
                return;
            }
            else
            {
                lbXacNhan.Text = "";
            }

            string matkhaucu = CreateMD5(txtMatKhauCu.Text);
            string matkhaumoi = CreateMD5(txtMatKhauMoi.Text);
            string xacnhan = CreateMD5(txtXacNhan.Text);
            int mataikhoan = -1;
            if (Session["maTaiKhoan"] != null)
            {
                mataikhoan = int.Parse(Session["mataikhoan"].ToString());
            }
            else
            {
                return;
            }
            TAIKHOAN taiKhoan = db.TAIKHOAN.FirstOrDefault(m=>m.MaTaiKhoan == mataikhoan);
            if (taiKhoan == null)
            {
                return;
            }
            else
            {
                if(matkhaucu != taiKhoan.MatKhau)
                {
                    lbMatKhauCu.Text = "<div style=\"color:red;\">Mật khẩu cũ không đúng!</div>";
                    return;
                }
                if(matkhaumoi != xacnhan)
                {
                    ltlThongBao.Text = "<div style=\"color:red;\">Mật khẩu mới và xác nhận mật khẩu mới không khớp!</div>";
                    return;
                }
                taiKhoan.MatKhau = matkhaumoi;
                db.SaveChanges();
                Response.Redirect("/Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
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