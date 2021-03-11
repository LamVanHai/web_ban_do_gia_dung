using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang.cms.admin
{
    public partial class AdminLoadControl : System.Web.UI.UserControl
    {
        private string modul = ""; //biến xem đang chuyển đến modul nào
        protected void Page_Load(object sender, EventArgs e)
        {
            //kiểm tra xem có đang chuyển đến modul nào hay không
            if (Request.QueryString["m"] != null)
            {
                modul = Request.QueryString["m"];
            }

            // load đến modul cần thiết
            switch (modul)
            {
                case "NguoiDung":
                    plAdminLoadControl.Controls.Add(LoadControl("NguoiDung/NguoiDungLoadControl.ascx"));
                    // nếu chuyển đến modul người dùng thì sẽ load đến trang quản lý người dùng
                    break;
                case "MatHang":
                    plAdminLoadControl.Controls.Add(LoadControl("MatHang/MatHangLoadControl.ascx"));
                    // nếu chuyển đến modul mặt hàng thì sẽ load đến trang quản lý mặt hàng
                    break;
                case "ThongKe":
                    plAdminLoadControl.Controls.Add(LoadControl("ThongKe/ThongKe.ascx"));
                    // nếu chuyển đến modul đơn hàng thì sẽ load đến trang quản lý đơn hàng
                    break;
                case "GioHang":
                    plAdminLoadControl.Controls.Add(LoadControl("QLGioHang/GioHangLoadControl.ascx"));
                    // nếu chuyển đến modul giỏ hàng thì sẽ load đến trang quản lý giỏ hàng
                    break;
                default:
                    plAdminLoadControl.Controls.Add(LoadControl("NguoiDung/NguoiDungLoadControl.ascx"));
                    // mặc định sẽ là chuyển đến trang quản lý người dùng
                    break;
            }
        }
    }
}