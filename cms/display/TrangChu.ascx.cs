using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang.cms.display
{
    public partial class TrangChu : System.Web.UI.UserControl
    {
        WebQuanLyDuAnNhom3Entities db = new WebQuanLyDuAnNhom3Entities();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LaySanPham("", 0);
                btnDoThucPham.BorderStyle = BorderStyle.Dashed;
            }
            if (Session["timkiem"] != null)
            {
                TimKiem(sender, e);
            }
        }

        private void LaySanPham(string tensp, int k)
        {
            List<SANPHAM> listSP = new List<SANPHAM>();

            if (tensp == "")
            {
                listSP = db.SANPHAM.ToList();
            }
            else
            {
                listSP = db.SANPHAM.Where(m => m.TenSanPham.Contains(tensp)).ToList();
            }
            if (k == 1)
            {
                listSP = listSP.Where(m => m.MaDanhMuc == 1).ToList();
            }
            else if (k == 2)
            {
                listSP = listSP.Where(m => m.MaDanhMuc == 2).ToList();
            }
            ltlSanPham.Text = "";
            int page = listSP.Count() / 4;
            if (listSP.Count() % 4 != 0)
            {
                page = page + 1;
            }
            int pg = 1;
            if (Request.QueryString["pg4"] != null)
                pg = int.Parse(Request.QueryString["pg4"]);

            for (int j = 1; j <= page; j++)
            {
                if (j == pg)
                {
                    ltlPageSanPhamConLaiTrongKho.Text += @"
                         <li class='page-item active'><a class='page-link' href='Home.aspx?m=TrangChu&pg4=" + j + @"'>" + j + @"</a></li>
                    ";
                }
                else
                {
                    ltlPageSanPhamConLaiTrongKho.Text += @"
                         <li class='page-item'><a class='page-link' href='Home.aspx?m=TrangChu&pg4=" + j + @"'>" + j + @"</a></li>
                    ";
                }
            }
            int spg = pg * 4;
            int ed = spg;
            int i = ed - 4;
            if (spg > listSP.Count)
            {
                ed = listSP.Count;
            }
            if (i < 0)
            {
                i = 0;
            }

            for (; i < ed; i++)
            {
                ltlSanPham.Text += @"
                     <div class='product-item'>
                        <div class='pi-pic'>
                            <img class='anhDaiDien1' src='/images/MatHang/" + listSP[i].Anh + @"'/>
                            <ul>
                           
                                <li class='quick-view'><a href='https:////localhost:44347//Home.aspx?m=Xem&id=" + listSP[i].MaSanPham + @"'> Xem chi tiết </a></li>  
                            </ul>
                        </div>
                        <div class='pi-text'>
                            <div>
                                " + listSP[i].TenSanPham + @"
                            </div>
                            <div class='catagory-name'>Giá</div>
                           
                            <div class='product-price'>
                                " + listSP[i].Gia + @"
                            </div>
                        </div>
                    </div>
                ";
            }
        }

        protected void btnDoGiaDung_Click(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LaySanPham("", 1);
                btnDoGiaDung.BorderStyle = BorderStyle.Dashed;
                btnDoThucPham.BorderStyle = BorderStyle.None;
            }
        }

        protected void btnDoThucPham_Click(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LaySanPham("", 2);
                btnDoGiaDung.BorderStyle = BorderStyle.None;
                btnDoThucPham.BorderStyle = BorderStyle.Dashed;
            }

        }
        protected void TimKiem(object sender, EventArgs e)
        {
            string ten = Session["timkiem"].ToString().Trim();
            for (int i = 1; i < 3; i++)
            {
                LaySanPham(ten, i);//LayNguoiDung(ten); // gọi hàm đưa ra danh sách người dùng
            }
        }
    }
}