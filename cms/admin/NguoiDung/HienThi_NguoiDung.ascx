<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HienThi_NguoiDung.ascx.cs" Inherits="WebBanHang.cms.admin.NguoiDung.HienThi_NguoiDung" %>

<!-- MAIN CONTENT-->
<div class="main-content">
    <div class="section__content section__content--p30">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="overview-wrap row">
                        <div class="col-md-5">
                            <h2 class="title-1">Quản lý người dùng</h2>
                        </div>
                        <div class="col-md-7">
                            <form class="form-header" method="POST">
                                <asp:TextBox ID="txtTenNguoiDungTimKiem" runat="server" CssClass="au-input au-input--xl" placeholder="Tên người dùng"></asp:TextBox>
                                <asp:Button ID="lbTimKiem" runat="server" OnClick="TimKiem" Text="Tìm" CssClass="au-btn au-btn-icon au-btn--blue zmdi zmdi-search" />
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="table-responsive table--no-card m-t-20">
                        <table class="table table-borderless table-striped table-earning">
                            <thead>
                                <tr>
                                    <th class="text-center">Mã</th>
                                    <th class="text-center">Họ tên</th>
                                    <th class="text-center">Tên đăng nhập</th>
                                    <th class="text-center">Địa chỉ</th>
                                    <th class="text-center">Điện thoại</th>
                                    <th class="text-center">Ngày đăng ký</th>
                                    <th class="text-center">Công cụ</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal ID="ltlNguoiDung" runat="server"></asp:Literal>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="copyright">
                        <p>Copyright © 2018 Colorlib. All rights reserved. Template by <a href="https://colorlib.com">Colorlib</a>.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function XoaNguoiDung(maTaiKhoan) {
            if (confirm("Bạn chắc chắn muốn xóa tài khoản này không")) {
                //Viết code xóa danh mục tại đây

                $.post("cms/admin/NguoiDung/Ajax/XoaNguoiDung.aspx",
                    {
                        "ThaoTac": "XoaNguoiDung",
                        "maTaiKhoan": maTaiKhoan
                    },
                    function (data, status) {
                        //alert("Data :" + data + "\n Status :" + status);
                        if (data == 1) {
                            //thực hiện thành công => ẩn dòng vừa xóa đi
                            $("#maDong" + maTaiKhoan).slideUp();

                        }
                    });
            }
        }
    </script>
</div>
<!-- END MAIN CONTENT-->