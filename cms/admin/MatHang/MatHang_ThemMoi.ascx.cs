using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang.cms.admin.MatHang
{
    public partial class MatHang_ThemMoi : System.Web.UI.UserControl
    {
        WebQuanLyDuAnNhom3Entities db = new WebQuanLyDuAnNhom3Entities();
        int maMatHang = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 2020; i < 2050; i++)
            {
                lbNam.Items.Add(i.ToString());
            }
            for (int i = 1; i < 13; i++)
            {
                lbThang.Items.Add(i.ToString());
            }
            for (int i = 1; i < 32; i++)
            {
                lbNgay.Items.Add(i.ToString());
            }
            if (Request.QueryString["id"] != null)
            {
                maMatHang = int.Parse(Request.QueryString["id"]);
                SANPHAM sanPham = db.SANPHAM.Where(m => m.MaSanPham == maMatHang).FirstOrDefault();
                String tenDanhMuc = db.DANHMUC.Where(m => m.MaDanhMuc == sanPham.MaDanhMuc).Select(m => m.TenDanhMuc).FirstOrDefault();
                if (tenDanhMuc.Equals("Thuc pham"))
                {
                    txtDanhMuc.SelectedIndex = 2;
                }
                else
                {
                    txtDanhMuc.SelectedIndex = 1;
                }
                txtSanPham.Text = sanPham.TenSanPham;
                txtMau.SelectedValue = sanPham.Mau;
                txtMieuTa.Text = sanPham.MieuTa;
                txtSoLuong.Text = sanPham.SoLuongTrongKho.ToString();
                txtGia.Text = sanPham.Gia.ToString();
                DateTime hsd = DateTime.Parse(sanPham.HanSuDung.ToString());
                lbNgay.Text = hsd.Day.ToString();
                lbThang.Text = hsd.Month.ToString();
                lbNam.Text = hsd.Year.ToString();
                btnThemMoi.Text = "Chỉnh sửa";
            }
        }
        SANPHAM sanphamUpdate = null;
        public void update()
        {
            try
            {
                string tenanh = "";
                if (flAnh.FileContent.Length > 0)
                {
                    if (flAnh.FileName.EndsWith(".jpeg") || flAnh.FileName.EndsWith(".jfif") || flAnh.FileName.EndsWith(".jpg") || flAnh.FileName.EndsWith(".png") || flAnh.FileName.EndsWith(".gif"))
                    {
                        flAnh.SaveAs(Server.MapPath("images/MatHang/") + flAnh.FileName);
                        tenanh = flAnh.FileName;
                    }
                }
                sanphamUpdate = db.SANPHAM.Single(n => n.MaSanPham == maMatHang);
                sanphamUpdate.TenSanPham = txtSanPham.Text;
                sanphamUpdate.MieuTa = txtMieuTa.Text;
                sanphamUpdate.SoLuongTrongKho = int.Parse(txtSoLuong.Text);
                sanphamUpdate.Gia = decimal.Parse(txtGia.Text);
                sanphamUpdate.Anh = tenanh;
                if (txtDanhMuc.SelectedIndex == 1)
                {
                    sanphamUpdate.MaDanhMuc = 1;
                }
                else
                {
                    sanphamUpdate.MaDanhMuc = 2;
                }
                if (txtMau.SelectedIndex == 1)
                {
                    sanphamUpdate.Mau = "Đỏ";
                }
                else if (txtMau.SelectedIndex == 2)
                {
                    sanphamUpdate.Mau = "Cam";
                }
                else if (txtMau.SelectedIndex == 3)
                {
                    sanphamUpdate.Mau = "Vàng";
                }
                else if (txtMau.SelectedIndex == 4)
                {
                    sanphamUpdate.Mau = "Lục";
                }
                else if (txtMau.SelectedIndex == 5)
                {
                    sanphamUpdate.Mau = "Lam";
                }
                else if (txtMau.SelectedIndex == 6)
                {
                    sanphamUpdate.Mau = "Chàm";
                }
                else if (txtMau.SelectedIndex == 7)
                {
                    sanphamUpdate.Mau = "Tím";
                }
                else if (txtMau.SelectedIndex == 8)
                {
                    sanphamUpdate.Mau = "Đen";
                }
                else
                {
                    sanphamUpdate.Mau = "Trắng";
                }
                sanphamUpdate.HanSuDung = DateTime.Parse(checkHanSuDung(int.Parse(lbThang.SelectedValue.ToString()), int.Parse(lbNgay.SelectedValue.ToString()), int.Parse(lbNam.SelectedValue.ToString())));
                db.SaveChanges();
                Response.Write("<Script>alert('Chỉnh sửa thành công!!')</Script>");
            }
            catch
            {
                Response.Write("<Script>alert('Chỉnh sửa thất bại!!')</Script>");
            }

        }
        public String checkHanSuDung(int ngay, int thang, int nam)
        {
            if (thang == 4 || thang == 6 || thang == 9 || thang == 11)
            {
                if (ngay <= 30)
                {
                    return ngay + "/" + thang + "/" + nam;
                }
                else
                {
                    return null;
                }
            }

            if (thang == 2)
            {
                if (nam % 400 == 0 || (nam % 4 == 0 && nam % 100 > 0))
                {
                    if (ngay <= 29)
                    {
                        return ngay + "/" + thang + "/" + nam;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    if (ngay <= 28)
                    {
                        return ngay + "/" + thang + "/" + nam;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return ngay + "/" + thang + "/" + nam;
        }

        public void insert()
        {
            try
            {
                string tenanh = "";
                if (flAnh.FileContent.Length > 0)
                {
                    if (flAnh.FileName.EndsWith(".jpeg") || flAnh.FileName.EndsWith(".jfif") || flAnh.FileName.EndsWith(".jpg") || flAnh.FileName.EndsWith(".png") || flAnh.FileName.EndsWith(".gif"))
                    {
                        flAnh.SaveAs(Server.MapPath("images/MatHang/") + flAnh.FileName);
                        tenanh = flAnh.FileName;
                    }
                }
                sanphamUpdate = new SANPHAM();
                sanphamUpdate.TenSanPham = txtSanPham.Text;
                sanphamUpdate.MieuTa = txtMieuTa.Text;
                sanphamUpdate.SoLuongTrongKho = int.Parse(txtSoLuong.Text);
                sanphamUpdate.Gia = decimal.Parse(txtGia.Text);
                sanphamUpdate.Anh = tenanh;
                if (txtDanhMuc.SelectedIndex == 1)
                {
                    sanphamUpdate.MaDanhMuc = 1;
                }
                else
                {
                    sanphamUpdate.MaDanhMuc = 2;
                }
                if (txtMau.SelectedIndex == 1)
                {
                    sanphamUpdate.Mau = "Đỏ";
                }
                else if (txtMau.SelectedIndex == 2)
                {
                    sanphamUpdate.Mau = "Cam";
                }
                else if (txtMau.SelectedIndex == 3)
                {
                    sanphamUpdate.Mau = "Vàng";
                }
                else if (txtMau.SelectedIndex == 4)
                {
                    sanphamUpdate.Mau = "Lục";
                }
                else if (txtMau.SelectedIndex == 5)
                {
                    sanphamUpdate.Mau = "Lam";
                }
                else if (txtMau.SelectedIndex == 6)
                {
                    sanphamUpdate.Mau = "Chàm";
                }
                else if (txtMau.SelectedIndex == 7)
                {
                    sanphamUpdate.Mau = "Tím";
                }
                else if (txtMau.SelectedIndex == 8)
                {
                    sanphamUpdate.Mau = "Đen";
                }
                else
                {
                    sanphamUpdate.Mau = "Trắng";
                }
                sanphamUpdate.NgayThem = DateTime.Now;
                sanphamUpdate.HanSuDung = DateTime.Parse(checkHanSuDung(int.Parse(lbThang.SelectedValue.ToString()), int.Parse(lbNgay.SelectedValue.ToString()), int.Parse(lbNam.SelectedValue.ToString())));
                db.SANPHAM.Add(sanphamUpdate);
                db.SaveChanges();
                Response.Write("<Script>alert('Thêm mặt hàng thành công ')</Script>");
            }
            catch
            {
                Response.Write("<Script>alert('Thêm mặt hàng thất bại!!!')</Script>");
            }

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnThemMoi.Text.Equals("Chỉnh sửa"))
            {
                update();

            }
            else
            {
                insert();
            }
        }
    }
}