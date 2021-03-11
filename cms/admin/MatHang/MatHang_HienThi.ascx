<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MatHang_HienThi.ascx.cs" Inherits="WebBanHang.cms.admin.MatHang.MatHang_HienThi" %>


<!-- MAIN CONTENT-->
<div class="main-content">
    <div class="section__content section__content--p30">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="overview-wrap row">
                        <div class="col-md-4">
                            <h2 class="title-1">Quản lý mặt hàng</h2>
                        </div>
                        <div class="col-md-5">
                            <form class="form-header" method="POST">
                                <asp:TextBox ID="txtTenMatHangTimKiem" runat="server" CssClass="au-input au-input--xl" placeholder="Tên mặt hàng"></asp:TextBox>
                                <asp:Button ID="lbTimKiem" runat="server" OnClick="TimKiem"  Text="Tìm" CssClass="au-btn au-btn-icon au-btn--blue zmdi zmdi-search" />
                            </form>
                        </div>
                        <div class="col-md-3" style="float:right;">
                            <a class="au-btn au-btn-icon au-btn--blue" href="/Admin.aspx?m=MatHang&tt=ThemMoi">
                                <i class="zmdi zmdi-plus"></i>Thêm mặt hàng
                            </a>
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
                                    <th class="text-center">Mã :</th>
                                    <th class="text-center">Danh mục:</th>
                                    <th class="text-center">Tên sản phẩm:</th>
                                    <th class="text-center">Ảnh:</th>
                                    <th class="text-center">Màu:</th>                                  
                                    <th class="text-center">Miêu tả:</th>
                                    <th class="text-center">Giá:</th>-
                                    <th class="text-center">Số lượng trong kho:</th>
                                    <th class="text-center">Hạn sử dụng:</th>
                                    <th class="text-center">Ngày thêm:</th>
                                    <th class="text-center">Công cụ:</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal ID="ltlMatHang" runat="server"></asp:Literal>
                            </tbody>
                        </table>
                    </div>
                    <ul class="pagination">
                             <asp:Literal ID="ltlPageMatHang" runat="server"></asp:Literal>
                        </ul>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function XoaSanPham(MaSanPham) {
            if (confirm("Bạn chắc chắn muốn xóa sản phẩm này không?")) {
                //Viết code xóa danh mục tại đây

                $.post("cms/admin/MatHang/Ajax/XoaSanPham.aspx",
                    {
                        "ThaoTac": "XoaSanPham",
                        "maSanPham": MaSanPham
                    },
                    function (data, status) {
                        //alert("Data :" + data + "\n Status :" + status);
                        if (data == 1) {
                            //thực hiện thành công => ẩn dòng vừa xóa đi
                            $("#maDong" + MaSanPham).slideUp();

                        }
                    });
            }
        }
    </script>
</div>
<!-- END MAIN CONTENT-->