using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang
{
    public partial class ThongTinCaNhan : System.Web.UI.Page
    {
        WebQuanLyDuAnNhom3Entities db = new WebQuanLyDuAnNhom3Entities();
        int maTaiKhoan = 0;
        TAIKHOAN taikhoan = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            maTaiKhoan = int.Parse(Session["maTaiKhoan"].ToString());
            if (!IsPostBack)
            {
                taikhoan = db.TAIKHOAN.Where(m => m.MaTaiKhoan == maTaiKhoan).FirstOrDefault();
                lbTentk.Text = taikhoan.Ten;
                txtTenDangNhap.Text = taikhoan.TenTaiKhoan;
                lbSoDienThoai.Text = taikhoan.SoDienThoai;
                lbDiaChi.Text = taikhoan.DiaChi;
            }
        }
        protected void Update()
        {
            TAIKHOAN tk = db.TAIKHOAN.SingleOrDefault(m => m.MaTaiKhoan == maTaiKhoan);
            //Response.Write(txtTentk.Text);
            if (tk != null)
            {
                tk.TenTaiKhoan = txtTenDangNhap.Text;
                tk.Ten = txtTentk.Text;
                tk.DiaChi = txtDiaChi.Text;
                tk.SoDienThoai = txtDienThoai.Text;
                db.SaveChanges();
                // tk = db.TAIKHOAN.SingleOrDefault(m => m.MaTaiKhoan == maTaiKhoan);
                //Response.Write(tk.Ten);
                //Response.Redirect("Home.aspx");
                //Response.Write(("<SCRIPT LANGUAGE='JavaScript'>alert('Lưu thông tin thành công')</SCRIPT>"));
            }
            else
            {

            }
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                Update();
                Response.Redirect("Home.aspx");
                Response.Write(("<SCRIPT LANGUAGE='JavaScript'>alert('Lưu thông tin thành công')</SCRIPT>"));

            }
            catch (Exception)
            {
                Response.Write(("<SCRIPT LANGUAGE='JavaScript'>alert('Lỗi!!!')</SCRIPT>"));
            }
            Response.Redirect("Home.aspx");
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = "k";
            txtDienThoai.Text = "l";
            txtTenDangNhap.Text = "a";
            txtTentk.Text = "s";
            Response.Redirect("Home.aspx");
        }
        /*
protected void btnLuu_Click(object sender, EventArgs e)
{


try
{
Update();
Response.Redirect("Home.aspx");
Response.Write(("<SCRIPT LANGUAGE='JavaScript'>alert('Lưu thông tin thành công')</SCRIPT>"));

}
catch (Exception)
{
Response.Write(("<SCRIPT LANGUAGE='JavaScript'>alert('Lỗi!!!')</SCRIPT>"));
}


}

protected void btnHuy_Click(object sender, EventArgs e)
{
Response.Redirect("Home.aspx");
}
*/
    }
}