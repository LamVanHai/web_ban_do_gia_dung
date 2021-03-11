using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang.cms.admin.NguoiDung
{
    public partial class NguoiDungLoadControl : System.Web.UI.UserControl
    {
        private string tt = ""; // khai báo biến xem thao tác của mình là gì
        protected void Page_Load(object sender, EventArgs e)
        {
            // kiểm tra xem thao tác hiện tại là gì
            if (Request.QueryString["tt"] != "")
            {
                tt = Request.QueryString["tt"];
            }

            // chuyển hướng theo thao tác
            switch (tt)
            {
                case "HienThi":
                    plNguoiDungLoadControl.Controls.Add(LoadControl("HienThi_NguoiDung.ascx"));
                    // nếu thao tác là hiển thị thì sẽ load đến trang hiển thị người dùng
                    break;
                default:
                    plNguoiDungLoadControl.Controls.Add(LoadControl("HienThi_NguoiDung.ascx"));
                    // mặc định sẽ load đến trang hiển thị người dùng
                    break;
            }
        }
    }
}