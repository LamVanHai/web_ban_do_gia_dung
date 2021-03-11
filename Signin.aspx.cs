using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Documents;

namespace WebBanHang
{
    public partial class Signin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DangKy"] == null)
            {
                btnDangNhap.Visible = false;
                txtTen.Visible = true;
                txtDiaChi.Visible = true;
                txtDienThoai.Visible = true;
                txtMatKhau.Visible = true;
                txtMatKhau1.Visible = true;
                txtTenDangNhap.Visible = true;
                btnDangKy.Visible = true;
                Label1.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;
                Label4.Visible = true;
                Label5.Visible = true;
            }
            else
            {
                btnDangNhap.Visible = true;
                txtTen.Visible = false;
                txtDiaChi.Visible = false;
                txtDienThoai.Visible = false;
                txtMatKhau.Visible = false;
                txtMatKhau1.Visible = false;
                txtTenDangNhap.Visible = false;
                btnDangKy.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                Label4.Visible = false;
                Label5.Visible = false;
                Label6.Text = "Đăng nhập vào hệ thống";
            }
        }
        WebQuanLyDuAnNhom3Entities db = new WebQuanLyDuAnNhom3Entities();
        protected void DangKy(object sender, EventArgs e)
        {
            string ten, tendangnhap, matkhau, sdt, diachi;
            ten = txtTen.Text;
            tendangnhap = txtTenDangNhap.Text;
            matkhau = txtMatKhau.Text;
            sdt = txtDienThoai.Text;
            diachi = txtDiaChi.Text;

            if (ten.Trim() != "" && tendangnhap.Trim() != "" && matkhau.Trim() != "" && sdt.Trim() != "" && diachi.Trim() != "")
            {
                if (checkUsername(tendangnhap))
                {
                    TAIKHOAN taikhoan = new TAIKHOAN();
                    taikhoan.Ten = ten;
                    taikhoan.TenTaiKhoan = tendangnhap;
                    if (txtMatKhau.Text == txtMatKhau1.Text)
                    {
                        taikhoan.MatKhau = CreateMD5(matkhau);
                        taikhoan.DiaChi = diachi;
                        taikhoan.SoDienThoai = sdt;
                        taikhoan.Check_admin = 2;
                        taikhoan.NgayTao = DateTime.Now;
                        db.TAIKHOAN.Add(taikhoan);
                        db.SaveChanges();
                        Response.Write(("<SCRIPT LANGUAGE='JavaScript'>alert('Đăng ký tài khoản thành công')</SCRIPT>"));
                        Session["DangKy"] = "1";
                    }
                    else
                    {
                        Response.Write(("<SCRIPT LANGUAGE='JavaScript'>alert('Mật khẩu không khớp, Vui lòng nhập lại ')</SCRIPT>"));
                    }
                }
                else
                {
                    Response.Write(("<SCRIPT LANGUAGE='JavaScript'>alert('Tên đăng nhập đã tồn tại! Vui lòng nhập tên khác ')</SCRIPT>"));

                }
                Page_Load(sender, e);
            }
        }
        protected void DangNhap(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx");
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
        public Boolean checkUsername(String userName)
        {
            List<TAIKHOAN> listTk = db.TAIKHOAN.ToList();

            foreach(TAIKHOAN i in listTk)
            {
                if (userName.Equals(i.TenTaiKhoan))
                {
                    return false;
                }
            }
            return true;
        }
    }
}