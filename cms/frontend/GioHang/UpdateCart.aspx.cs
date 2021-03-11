using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace WebBanHang.cms.frontend.GioHang
{
public partial class UpdateCart : System.Web.UI.Page
    {
        WebQuanLyDuAnNhom3Entities db = new WebQuanLyDuAnNhom3Entities();
        string thaotac = "";
        int mtk;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DangNhap"] == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }
            mtk = int.Parse(Session["maTaiKhoan"].ToString());
            CapNhatGioHang();
        }

        private void CompleteAjax(string message,int status_code)
        {
            Response.Clear();
            Response.StatusCode = status_code;
            Response.Write(message);
            Response.OutputStream.Close();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        private void CapNhatGioHang() 
        {
                try
                {
                    int maSP;
                    int soLuong;

                    string[] paramKeys = Request.Params.AllKeys;
                    //System.Diagnostics.Debug.WriteLine("Hello tao day");
                    if (Request.ContentType.Contains("json"))
                    {
                        System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
                        string line = "";
                        line = sr.ReadToEnd();
                        //System.Diagnostics.Debug.WriteLine(line);
                        JArray a = JArray.Parse(line);

                        foreach (JObject item in a)
                        {
                            maSP = int.Parse(item.GetValue("maSP").ToString());
                            soLuong = int.Parse(item.GetValue("soLuong").ToString());
                            SANPHAM sanpham = db.SANPHAM.FirstOrDefault(m => m.MaSanPham == maSP);
                            decimal giaBan = sanpham.Gia;
                            DONHANG donhang = db.DONHANG.FirstOrDefault(m => m.TrangThai == "giohang" && m.MaKhachHang == mtk);
                            if (donhang == null)
                            {
                                donhang = new DONHANG();
                                donhang.MaKhachHang = int.Parse(Session["maTaiKhoan"].ToString());
                                donhang.TrangThai = "giohang";
                                db.DONHANG.Add(donhang);
                                db.SaveChanges();
                            }
                            donhang = db.DONHANG.FirstOrDefault(m => m.TrangThai == "giohang" && m.MaKhachHang == mtk);
                            int maDonHang = donhang.MaDonHang;

                            CHITIETDONHANG chitietdonhang = db.CHITIETDONHANG.Where(m => m.MaDonHang == maDonHang).Where(m => m.MaSanPham == maSP).SingleOrDefault();
                            if (chitietdonhang == null)
                            {
                                chitietdonhang = new CHITIETDONHANG();
                                chitietdonhang.MaDonHang = maDonHang;
                                chitietdonhang.MaSanPham = maSP;
                                chitietdonhang.SoLuong = soLuong;
                                chitietdonhang.GiaBan = giaBan;
                                chitietdonhang.TongTien = soLuong * giaBan;
                                sanpham.SoLuongTrongKho = sanpham.SoLuongTrongKho - soLuong;
                                db.CHITIETDONHANG.Add(chitietdonhang);
                            }
                            else
                            {
                                sanpham.SoLuongTrongKho = sanpham.SoLuongTrongKho + chitietdonhang.SoLuong - soLuong;
                                chitietdonhang.SoLuong = soLuong;
                                chitietdonhang.GiaBan = giaBan;
                                chitietdonhang.TongTien = soLuong * giaBan;
                            }

                            db.SaveChanges();
                        }
                    }
                string msg = "Cap nhat gio hang thanh cong";
                CompleteAjax(msg,200);
                }
                catch (Exception e)
                {
                    CompleteAjax(e.InnerException.InnerException.Message.Split('\n')[1],503);
                    return;
                }


        }


    }
}