using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang.cms.admin.ThongKe
{
    public partial class ThongKe : System.Web.UI.UserControl
    {
        WebQuanLyDuAnNhom3Entities db = new WebQuanLyDuAnNhom3Entities();
        List<ThongKeTheoNgay> listDay = new List<ThongKeTheoNgay>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlDanhMuc.Items.Clear();
                ddlDanhMuc.Items.Add("Tất cả");
                ddlDanhMuc.Items.Add("Thực phẩm");
                ddlDanhMuc.Items.Add("Đồ gia dụng");

                ddlThoiGian.Items.Clear();
                ddlThoiGian.Items.Add("Tất cả");
                ddlThoiGian.Items.Add("Hôm nay");
                ddlThoiGian.Items.Add("Tuần này");
                ddlThoiGian.Items.Add("Tháng này");
                ddlThoiGian.Items.Add("Năm này");

                CacSanPhamBanGanDay();
                CacSanPhamBanChay();
                ThongKeSanPhamDaBan();
                LaySanPhamConLaiTrongKho();
            }
        }

        protected void Loc(object sender, EventArgs e)
        {
            ThongKeSanPhamDaBan();
        }

        protected void CacSanPhamBanGanDay()
        {

            List<CacSanPhamDaBan> listSanPham = new List<CacSanPhamDaBan>();

            listSanPham = (from sp in db.SANPHAM
                           join dm in db.DANHMUC on sp.MaDanhMuc equals dm.MaDanhMuc
                           join ctdh in db.CHITIETDONHANG on sp.MaSanPham equals ctdh.MaSanPham
                           join dh in db.DONHANG on ctdh.MaDonHang equals dh.MaDonHang
                           join tk in db.TAIKHOAN on dh.MaKhachHang equals tk.MaTaiKhoan
                           orderby dh.NgayDatHang descending
                           select new CacSanPhamDaBan
                           {
                               id = dh.MaDonHang,
                               maDanhMuc = dm.MaDanhMuc,
                               tenSanPham = sp.TenSanPham,
                               anh = sp.Anh,
                               gia = ctdh.GiaBan,
                               soLuongBan = ctdh.SoLuong,
                               tongTien = ctdh.TongTien,
                               maKhachHangMua = tk.MaTaiKhoan,
                               ngayBan = dh.NgayDatHang
                           }).ToList();

            ltlCacSanPhamBanGanDay.Text = "";
            int i = 0, sl=listSanPham.Count;
            if (listSanPham.Count > 10)
            {
                sl = 10;
            }
            for (; i < sl; i++)
            {
                ltlCacSanPhamBanGanDay.Text += @"
                    <tr>
                        <td>" + listSanPham[i].tenSanPham + @"</td>
                        <td class='text-center cotAnh'>
                            <img class='anhDaiDien' src='/images/SanPham/" + listSanPham[i].anh + @"'/>
                            <img class='anhDaiDienHover' src='/images/SanPham/" + listSanPham[i].anh + @"'/>
                        </td>
                        <td>" + tien(listSanPham[i].gia) + @" VNĐ</td>
                        <td>" + listSanPham[i].soLuongBan + @"</td>
                        <td>" + tien(listSanPham[i].tongTien )+ @" VNĐ</ td >
                    </ tr >
                  ";
            }
        }

        protected void CacSanPhamBanChay()
        {
            List<SANPHAM> listSanPham = new List<SANPHAM>();

            listSanPham = db.SANPHAM.ToList();
            List<CacSanPhamBanChay> list = new List<CacSanPhamBanChay>();

            foreach(SANPHAM s in listSanPham)
            {
                List<int> ldh = new List<int>();
                ldh = db.CHITIETDONHANG.Where(m => m.MaSanPham == s.MaSanPham).Select(m => m.SoLuong).ToList();
                int slc = 0;
                foreach(int j in ldh)
                {
                    slc += j;
                }
                CacSanPhamBanChay x = new CacSanPhamBanChay();
                x.tenSanPham = s.TenSanPham;
                x.soLuong = slc;
                list.Add(x);
            }
            int i = 0;
            for(i = 0; i < list.Count - 1; i++)
            {
                for(int j = i + 1; j < list.Count; j++)
                {
                    if (list[i].soLuong < list[j].soLuong)
                    {
                        CacSanPhamBanChay x = list[i];
                        list[i] = list[j];
                        list[j] = x;
                    }
                }
            }

            ltlCacSanPhamBanChay.Text = "";
            i = 0;
            int sl=list.Count;
            if (list.Count > 10)
            {
                sl = 10;
            }
            for (; i < sl; i++)
            {
                ltlCacSanPhamBanChay.Text += @"
                    <tr>
                        <td>" + list[i].tenSanPham + @"</td>
                        <td>" + list[i].soLuong + @"</td>
                    </ tr >
                  ";
            }
        }

        protected void ThongKeSanPhamDaBan()
        {
            sinhDay();
            List<CacSanPhamDaBan> listSanPham = new List<CacSanPhamDaBan>();

            listSanPham = (from sp in db.SANPHAM
                           join dm in db.DANHMUC on sp.MaDanhMuc equals dm.MaDanhMuc
                           join ctdh in db.CHITIETDONHANG on sp.MaSanPham equals ctdh.MaSanPham
                           join dh in db.DONHANG on ctdh.MaDonHang equals dh.MaDonHang
                           join tk in db.TAIKHOAN on dh.MaKhachHang equals tk.MaTaiKhoan
                           orderby dh.NgayDatHang descending
                           select new CacSanPhamDaBan
                           {
                               id = dh.MaDonHang,
                               maDanhMuc = dm.MaDanhMuc,
                               tenSanPham = sp.TenSanPham,
                               anh = sp.Anh,
                               gia = ctdh.GiaBan,
                               soLuongBan = ctdh.SoLuong,
                               tongTien = ctdh.TongTien,
                               maKhachHangMua = tk.MaTaiKhoan,
                               ngayBan = dh.NgayDatHang
                           }).ToList();

            if (ddlDanhMuc.SelectedIndex != 0)
            {
                int vt = ddlDanhMuc.SelectedIndex;
                int madm;
                if (vt == 1) { 
                    madm = db.DANHMUC.Where(m => m.TenDanhMuc == "Thuc pham").Select(m => m.MaDanhMuc).FirstOrDefault(); 
                }
                else
                {
                    madm = db.DANHMUC.Where(m => m.TenDanhMuc == "Do gia dung").Select(m => m.MaDanhMuc).FirstOrDefault();
                }
                listSanPham = listSanPham.Where(m => m.maDanhMuc == madm).ToList();
            }
            if (ddlThoiGian.SelectedIndex != 0)
            {
                int vt = ddlThoiGian.SelectedIndex;
                if (vt == 1)
                {
                    DateTime? hn = DateTime.Now;
                    listSanPham = listSanPham.Where(m => m.ngayBan == hn).ToList();
                }
                else if (vt == 2)
                {
                    int ind = 0;
                    DateTime hn = DateTime.Now;
                    for (int t = 0; t < listDay.Count; t++)
                    {
                        if(listDay[t].ngay == hn.Day && listDay[t].thang == hn.Month && listDay[t].nam == hn.Year)
                        {
                            int thu = listDay[t].thu;
                            int kc = thu - 2;
                            ind = t - kc;
                            break;
                        }
                    }
                    DateTime bg = new DateTime(listDay[ind].nam, listDay[ind].thang, listDay[ind].ngay);
                    listSanPham = listSanPham.Where(m => m.ngayBan >= bg && m.ngayBan<=hn).ToList();
                }
                else if (vt == 3)
                {
                    int ind = 0;
                    DateTime hn = DateTime.Now;
                    for (int t = 0; t < listDay.Count; t++)
                    {
                        if (listDay[t].thang == hn.Month && listDay[t].nam == hn.Year)
                        {
                            ind = t;
                            break;
                        }
                    }
                    DateTime bg = new DateTime(listDay[ind].nam, listDay[ind].thang, listDay[ind].ngay);
                    listSanPham = listSanPham.Where(m => m.ngayBan >= bg && m.ngayBan <= hn).ToList();
                }
                else
                {
                    int ind = 0;
                    DateTime hn = DateTime.Now;
                    for (int t = 0; t < listDay.Count; t++)
                    {
                        if (listDay[t].nam == hn.Year)
                        {
                            ind = t;
                            break;
                        }
                    }
                    DateTime bg = new DateTime(listDay[ind].nam, listDay[ind].thang, listDay[ind].ngay);
                    listSanPham = listSanPham.Where(m => m.ngayBan >= bg && m.ngayBan <= hn).ToList();
                }
            }

            ltlPageThongKeSanPhamDaBan.Text = "";
            int page = listSanPham.Count() / 10;
            if (listSanPham.Count() % 10 != 0)
            {
                page = page + 1;
            }
            int pg = 1;
            if (Request.QueryString["pg3"] != null)
                pg = int.Parse(Request.QueryString["pg3"]);

            for (int j = 1; j <= page; j++)
            {
                if (j == pg)
                {
                    ltlPageThongKeSanPhamDaBan.Text += @"
                         <li class='page-item active'><a class='page-link' href='Admin.aspx?m=ThongKe&pg3=" + j + @"'>" + j + @"</a></li>
                    ";
                }
                else
                {
                    ltlPageThongKeSanPhamDaBan.Text += @"
                         <li class='page-item'><a class='page-link' href='Admin.aspx?m=ThongKe&pg3=" + j + @"'>" + j + @"</a></li>
                    ";
                }
            }

            int spg = pg * 10;
            int ed = spg;
            int i = ed - 10;
            if (spg > listSanPham.Count)
            {
                ed = listSanPham.Count;
            }
            if (i < 0)
            {
                i = 0;
            }

            ltlThongKeSanPhamDaBan.Text = "";
            decimal tongtien = 0;
            for (; i < ed; i++)
            {
                int matk = listSanPham[i].maKhachHangMua;
                TAIKHOAN tk = db.TAIKHOAN.Where(m => m.MaTaiKhoan == matk).FirstOrDefault();
                ltlThongKeSanPhamDaBan.Text += @"
                    <tr>
                        <td>" + listSanPham[i].tenSanPham + @"</td>
                        <td class='text-center cotAnh'>
                            <img class='anhDaiDien' src='/images/SanPham/" + listSanPham[i].anh + @"'/>
                            <img class='anhDaiDienHover' src='/images/SanPham/" + listSanPham[i].anh + @"'/>
                        </td>
                        <td>" + tien(listSanPham[i].gia) + @" VNĐ</td>
                        <td>" + listSanPham[i].soLuongBan + @"</td>
                        <td>" + tien(listSanPham[i].tongTien) + @" VNĐ</ td >
                        <td>" + tk.Ten + @"</ td >
                        <td>" + listSanPham[i].ngayBan + @"</ td >
                    </ tr >
                  ";
                tongtien += listSanPham[i].tongTien;
            }

            lbTongTien3.Text = tien(tongtien) + " VNĐ";
        }

        protected void LaySanPhamConLaiTrongKho()
        {
            List<SANPHAM> listSanPham = new List<SANPHAM>();

            listSanPham = db.SANPHAM.ToList();

            ltlPageSanPhamConLaiTrongKho.Text = "";
            int page = listSanPham.Count() / 10;
            if (listSanPham.Count() % 10 != 0)
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
                         <li class='page-item active'><a class='page-link' href='Admin.aspx?m=ThongKe&pg4=" + j + @"'>" + j + @"</a></li>
                    ";
                }
                else
                {
                    ltlPageSanPhamConLaiTrongKho.Text += @"
                         <li class='page-item'><a class='page-link' href='Admin.aspx?m=ThongKe&pg4=" + j + @"'>" + j + @"</a></li>
                    ";
                }
            }

            ltlSanPhamConLaiTrongKho.Text = "";
            int spg = pg * 10;
            int ed = spg;
            int i = ed - 10;
            if (spg > listSanPham.Count)
            {
                ed = listSanPham.Count;
            }
            if (i < 0)
            {
                i = 0;
            }
            for (; i < ed; i++)
            {
                ltlSanPhamConLaiTrongKho.Text += @"
                    <tr>
                        <td>" + listSanPham[i].TenSanPham + @"</td>
                        <td class='text-center cotAnh'>
                            <img class='anhDaiDien' src='/images/SanPham/" + listSanPham[i].Anh + @"'/>
                            <img class='anhDaiDienHover' src='/images/SanPham/" + listSanPham[i].Anh + @"'/>
                        </td>
                        <td>" + tien(listSanPham[i].Gia) + @" VNĐ</td>
                        <td>" + listSanPham[i].SoLuongTrongKho + @"</td>
                        <td>" + listSanPham[i].HanSuDung + @"</ td >
                    </ tr >
                  ";
            }
        }

        private string tien(decimal t)
        {
            string s = "";
            string st = t.ToString();
            int x = st.Length % 3;
            for(int i = 0; i < st.Length; i++)
            {
                if (i % 3 == x && i!=0 && i!=st.Length)
                {
                    s += '.';
                }
                s += st[i];
            }
            return s;
        }

        private bool checkDay(ThongKeTheoNgay x)
        {
            int d, m, y;
            d = x.ngay;
            m = x.thang;
            y = x.nam;
            if ((y % 4 == 0 && y % 100 != 0) || y % 400 == 0)
            {
                if (m == 2)
                {
                    if (d <= 29)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if( d == 4 || d == 6 || d == 9 || d == 11)
                {
                    if (d <= 30)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (m == 2)
                {
                    if (d <= 28)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (d == 4 || d == 6 || d == 9 || d == 11)
                {
                    if (d <= 30)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
        }

        private void sinhDay()
        {
            listDay.Clear();
            int th = 4;
            for (int y = 2019; y <= 2100; y++)
            {
                for (int m = 1; m <= 12; m++)
                {
                    for (int d = 1; d <= 31; d++)
                    {
                        ThongKeTheoNgay x = new ThongKeTheoNgay();
                        x.ngay = d;
                        x.thang = m;
                        x.nam = y;
                        if (checkDay(x))
                        {
                            x.thu = th;
                            th++;
                            if (th == 9)
                            {
                                th = 2;
                            }
                            listDay.Add(x);
                        }
                    }
                }
            }
        }
    }
}