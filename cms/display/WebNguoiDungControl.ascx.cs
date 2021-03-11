using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang.cms.display
{
    public partial class WebNguoiDungControl : System.Web.UI.UserControl
    {
        string m = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["m"] != null)
            {
                m = Request.QueryString["m"];
            }

            switch (m)
            {
                case "Xem":
                    plNguoiDungLoadControl.Controls.Add(LoadControl("ChiTiet.ascx"));
                    break;
                default:
                    plNguoiDungLoadControl.Controls.Add(LoadControl("TrangChu.ascx"));
                    break;
            }
        }
    }
}