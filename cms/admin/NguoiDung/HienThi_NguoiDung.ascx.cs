using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang.cms.admin.NguoiDung
{
    public partial class HienThi_NguoiDung : System.Web.UI.UserControl
    {
        WebQuanLyDuAnNhom3Entities db = new WebQuanLyDuAnNhom3Entities(); // biến db đển kết nối đến csdl
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // gọi đến hàm lấy người dùng
                LayNguoiDung("");
            }
        }

        private void LayNguoiDung(string tenNguoiDung)
        {
            // tenNguoiDung là biến truyền vào cho ta biết người ta muốn tìm kiếm là ai

            List<TAIKHOAN> listTaiKhoan = new List<TAIKHOAN>(); // tạo list để nhận danh sách tài khoản trong csdl
            // kiểm tra xem đang lấy danh sách người dùng hay tìm kiếm danh sách người dùng theo tên
            // nếu tên = "" là lấy danh sách tất cả người dùng trừ người tài khoản admin chính
            // nếu tên != "" là lấy danh sách người dùng có tên giống với tenNguoiDung
            if(tenNguoiDung == "")
            {
                // lấy danh sách tài khoản trừ người admin chính
                listTaiKhoan = db.TAIKHOAN.Where(m => m.Check_admin != 1).ToList();
                // db là biến để thao tác với csdl
                // db.TAIKHOAN là chỉ bảng tài khoản trong csdl
                // db.TAIKHOAN.Where() là lấy bảng tài khoản trong csdl với điều kiện bên trong () 
                // m chỉ 1 hàng trong bảng TAIKHOAN
                // m. chỉ cột nào trong bảng TAIKHOAN
                // db.TAIKHOAN.Where().ToList() là để lấy danh sách các tài khoản thỏa mãn điều kiện
            }
            else
            {
                // lấy danh sách tài khoản có tên cần tìm kiếm trừ admin chính
                listTaiKhoan = db.TAIKHOAN.Where(m => m.Check_admin != 1 && m.Ten.Contains(tenNguoiDung)).ToList();
                // tương tự ở trên ở đây thêm điều kiện là người có tên giống với tên truyền vào sẽ được đưa là list
            }
            // xóa hết danh sách người dùng nếu có
            ltlNguoiDung.Text = "";
            // duyệt danh sách người dùng để đưa ra màn hình
            foreach(TAIKHOAN i in listTaiKhoan)
            {
                // gán các thuộc tính của bảng người dùng đưa vào Literal
                ltlNguoiDung.Text += @"
                    <tr id='maDong" + i.MaTaiKhoan + @"'>
                        <td class='text-center'>" + i.MaTaiKhoan + @"</td>
                        <td>" + i.Ten + @"</td>
                        <td>" + i.TenTaiKhoan + @"</td>
                        <td>" + i.DiaChi + @"</td>
                        <td>" + i.SoDienThoai + @"</td>
                        <td>" + i.NgayTao + @"</td>
                        <td class='text-center'>
                            <a href=javascript:XoaNguoiDung('" + i.MaTaiKhoan + @"')><i class='zmdi zmdi-delete'></i>" + @"</td></a>
                        </td>
                    </tr>
                ";
            }

        }

        protected void TimKiem(object sender, EventArgs e)
        {
            string ten = txtTenNguoiDungTimKiem.Text.Trim(); // lấy tên người dùng cần tìm kiếm
            LayNguoiDung(ten); // gọi hàm đưa ra danh sách người dùng
        }
    }
}