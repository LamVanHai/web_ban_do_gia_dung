using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang.cms.admin.MatHang
{
    public partial class MatHang_HienThi : System.Web.UI.UserControl
    {
        WebQuanLyDuAnNhom3Entities db = new WebQuanLyDuAnNhom3Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                layMatHang("");
            }
        }
        public void layMatHang(string tenMatHang)
        {
            List<SANPHAM> sanPhams = new List<SANPHAM>();
            if (tenMatHang.Equals(""))
            {
                sanPhams = db.SANPHAM.ToList();
            }
            else
            {
                sanPhams = db.SANPHAM.Where(m => m.TenSanPham.Contains(tenMatHang)).ToList();
            }

            ltlPageMatHang.Text = "";
            int pag = sanPhams.Count() / 5;
            if (sanPhams.Count() % 5 != 0)
            {
                pag = pag + 1;
            }
            int page = 1;
            if (Request.QueryString["page"] != null)
                page = int.Parse(Request.QueryString["page"]);

            for (int j = 1; j <= pag; j++)
            {
                if (j == page)
                {
                    ltlPageMatHang.Text += @"
                         <li class='page-item active'><a class='page-link' href='Admin.aspx?m=MatHang&page=" + j + @"'>" + j + @"</a></li>
                    ";
                }
                else
                {
                    ltlPageMatHang.Text += @"
                         <li class='page-item'><a class='page-link' href='Admin.aspx?m=MatHang&page=" + j + @"'>" + j + @"</a></li>
                    ";
                }
            }
            int spg = page * 5;
            int ed = spg;
            int i = ed - 5;
            if (spg > sanPhams.Count)
            {
                ed = sanPhams.Count;
            }
            if (i < 0)
            {
                i = 0;
            }
            ltlMatHang.Text = "";

            for(;i<ed;i++)
            {
                String tenDanhMu = tenDanhMuc(sanPhams[i].MaDanhMuc);
                ltlMatHang.Text += @"
                    <tr id='maDong" + sanPhams[i].MaSanPham + @"'>
                        <td class='text-center'>" + sanPhams[i].MaSanPham + @"</td>
                        <td>" + tenDanhMu + @"</td>
                        <td>" + sanPhams[i].TenSanPham + @"</td>
                        <td class='text-center cotAnh'>
                            <img class='anhDaiDien' src='/images/MatHang/" + sanPhams[i].Anh + @"'/>
                            <img class='anhDaiDienHover' src='/images/MatHang/" + sanPhams[i].Anh + @"'/>
                        </td>
                        <td>" + sanPhams[i].Mau + @"</td>
                        <td>" + sanPhams[i].MieuTa + @"</td>
                        <td>" + sanPhams[i].Gia + @"</td>
                        <td>" + sanPhams[i].SoLuongTrongKho + @"</td>
                        <td>" + sanPhams[i].HanSuDung + @"</td>
                        <td>" + sanPhams[i].NgayThem + @"</td>
                        <td class='text-center'>
                            <a href='Admin.aspx?m=MatHang&tt=ChinhSua&id= " + sanPhams[i].MaSanPham + @"'><i class='zmdi zmdi-edit'></i></a>" + " - " + @"
                            <a href=javascript:XoaSanPham('" + sanPhams[i].MaSanPham + @"') ><i class='zmdi zmdi-delete'></i>" + @"</td></a>
                        </td>
                    </tr>
                ";
            }

        }
        protected void TimKiem(object sender, EventArgs e)
        {
            string ten = txtTenMatHangTimKiem.Text.Trim(); // lấy tên người dùng cần tìm kiếm
            layMatHang(ten); // gọi hàm đưa ra danh sách người dùng
        }
        protected String tenDanhMuc(int maDanhMuc)
        {
            if (maDanhMuc == 1)
            {
                return "Đồ gia dụng";
            }
            return "Thực phẩm";
        }
    }
}