using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang.cms.admin.QLGioHang
{
    public partial class GioHangLoadControl : System.Web.UI.UserControl
    {
        private string tt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["tt"] != "")
            {
                tt = Request.QueryString["tt"];
            }
            switch (tt)
            {
                case "HienThi":
                    plDonHangLoadControl.Controls.Add(LoadControl("ThongTinGioHang.ascx"));
                    break;
                default:
                    plDonHangLoadControl.Controls.Add(LoadControl("ThongTinGioHang.ascx"));
                    break;
            }
        }
    }
}