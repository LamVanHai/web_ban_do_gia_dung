using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang.cms.admin.QLGioHang
{
    public partial class ThongTinGioHang : System.Web.UI.UserControl
    {
        WebQuanLyDuAnNhom3Entities db = new WebQuanLyDuAnNhom3Entities(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            List<DONHANG> list_DH = db.DONHANG.Where(m => m.TrangThai == "Chờ xác nhận").OrderByDescending(m => m.NgayDatHang).ToList();
            GridView1.DataSource = list_DH;
            GridView1.DataBind();

            var rows = GridView1.Rows;
            foreach (GridViewRow row in rows)
            {
                int maDH = int.Parse(row.Cells[8].Text);
                string info = "";
                List<CHITIETDONHANG> list_CTDH = db.CHITIETDONHANG.Where(m => m.MaDonHang == maDH).ToList();
                decimal tong = 0;
                foreach (var CTDH in list_CTDH)
                {
                    SANPHAM sp = db.SANPHAM.FirstOrDefault(m => m.MaSanPham == CTDH.MaSanPham);
                    info += sp.TenSanPham + "(" + string.Format("{0:n0}", CTDH.GiaBan) + " VND) x " + CTDH.SoLuong + "<br> ";
                    tong += CTDH.GiaBan * CTDH.SoLuong;
                }
                info += "<b>Tong:" + string.Format("{0:n0}",tong) + "</b>";
                Label ct = (Label)row.FindControl("chitiet");
                ct.Text = info;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                int maHang = int.Parse(row.Cells[8].Text.ToString());
                DONHANG dh = db.DONHANG.FirstOrDefault(m => m.MaDonHang == maHang);
                dh.TrangThai = "Xác nhận";
                db.SaveChanges();
                GridView1.Rows[rowIndex].Visible = false;
            }
        }

    }
}