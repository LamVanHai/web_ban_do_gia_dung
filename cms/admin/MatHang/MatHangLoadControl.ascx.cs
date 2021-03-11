using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang.cms.admin.MatHang
{
    public partial class MatHangLoadControl : System.Web.UI.UserControl
    {
        string tt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["tt"] != null)
            {
                tt = Request.QueryString["tt"];
            }

            switch (tt)
            {
                case "ThemMoi":
                case "ChinhSua":
                    plMatHangLoadControl.Controls.Add(LoadControl("MatHang_ThemMoi.ascx"));
                    break;
                case "HienThi":
                    plMatHangLoadControl.Controls.Add(LoadControl("MatHang_HienThi.ascx"));
                    break;
                default:
                    plMatHangLoadControl.Controls.Add(LoadControl("MatHang_HienThi.ascx"));
                    break;
            }
        }
    }
}