using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang.cms.admin.NguoiDung.Ajax
{
    public partial class XoaNguoiDung : System.Web.UI.Page
    {
        WebQuanLyDuAnNhom3Entities db = new WebQuanLyDuAnNhom3Entities();
        string thaotac = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DangNhap"] != null && Session["DangNhap"].ToString() == "1")
            {
                //Đã đăng nhập
            }
            else
            {
                //Nếu chưa đăng nhập --> return để dừng không cho thực hiện các câu lệnh bên dưới
                return;
            }
            if (Request.Params["ThaoTac"] != null)
            {
                thaotac = Request.Params["ThaoTac"];
            }

            switch (thaotac)
            {
                case "XoaNguoiDung":
                    Xoa();
                    break;

            }
        }

        private void Xoa()
        {
            int mataikhoan;
            if (Request.Params["maTaiKhoan"] != null)
            {
                mataikhoan = int.Parse(Request.Params["maTaiKhoan"].ToString());

                //Thực hiện code xóa
                //B2: Xóa dữ liệu trên sqlserver
                TAIKHOAN taiKhoan = db.TAIKHOAN.FirstOrDefault(m => m.MaTaiKhoan == mataikhoan);
                db.TAIKHOAN.Remove(taiKhoan);
                db.SaveChanges();
                // Trả về thông báo 1 thực hiện thành công 2 thực hiện không thành công
                Response.Write("1");

            }
        }
    }
}