<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThongKe.ascx.cs" Inherits="WebBanHang.cms.admin.ThongKe.ThongKe" %>

<!-- MAIN CONTENT-->
<div class="main-content">
    <div class="section__content section__content--p30">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-9">
                    <h3 class="title-5 m-b-15">Các sản phẩm bán gần đây</h3>
                    <div class="table-responsive table--no-card m-b-30">
                        <table class="table table-borderless table-striped table-earning">
                            <thead>
                                <tr>
                                    <th class="text-center">Tên sản phẩm</th>
                                    <th class="text-center">Ảnh</th>
                                    <th class="text-center">Giá</th>
                                    <th class="text-center">Số lượng bán</th>
                                    <th class="text-center">Tổng tiền</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal ID="ltlCacSanPhamBanGanDay" runat="server"></asp:Literal>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="col-lg-3">
                    <h3 class="title-5 m-b-15">Các sản phẩm bán chạy</h3>
                    <div class="au-card au-card--bg-blue au-card-top-countries m-b-30">
                        <div class="au-card-inner">
                            <div class="table-responsive">
                                <table class="table table-top-countries">
                                    <tbody>
                                        <asp:Literal ID="ltlCacSanPhamBanChay" runat="server"></asp:Literal>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <!-- DATA TABLE -->
                    <h3 class="title-5 m-b-15">Thống kê sản phẩm đã bán</h3>
                    <div class="table-data__tool">
                        <div class="table-data__tool-left">
                            <div class="rs-select2--light rs-select2--md">
                                <asp:DropDownList ID="ddlDanhMuc" runat="server" class="au-btn-filter"></asp:DropDownList>
                            </div>
                            <div class="rs-select2--light rs-select2--sm">
                                <asp:DropDownList ID="ddlThoiGian" runat="server" class="au-btn-filter"></asp:DropDownList>
                            </div>
                            <asp:Button ID="btnLoc" runat="server" Text="Lọc" class="au-btn-filter" OnClick="Loc" />
                        
                        </div>
                    </div>
                    <div class="table-responsive table-responsive-data2">
                        <table class="table table-data2">
                            <thead>
                                <tr>
                                    <th class="text-center">Tên sản phẩm</th>
                                    <th class="text-center">Ảnh</th>
                                    <th class="text-center">Giá</th>
                                    <th class="text-center">Số lượng bán</th>
                                    <th class="text-center">Tổng tiền</th>
                                    <th class="text-center">Khách hàng mua</th>
                                    <th class="text-center">Ngày bán hàng</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal ID="ltlThongKeSanPhamDaBan" runat="server"></asp:Literal>
                            </tbody>
                        </table>
                        <div class="row">
                            <div class="col-md-8">
                                <ul class="pagination">
                                    <asp:Literal ID="ltlPageThongKeSanPhamDaBan" runat="server"></asp:Literal>
                                </ul>
                            </div>
                            <div class="col-md-4"><span style="font-size:20px;">Tổng tiền: &nbsp;</span>
                                <asp:Label ID="lbTongTien3" runat="server" Text="" Font-Size="25px" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <!-- END DATA TABLE -->
                </div>
            </div>
            <div class="row m-t-30">
                <div class="col-md-12">
                    <h3 class="title-5 m-b-15">Các sản phẩm còn lại trong kho</h3>
                    <!-- DATA TABLE-->
                    <div class="table-responsive m-b-40">
                        <table class="table table-borderless table-data3">
                            <thead>
                                <tr>
                                    <th style="width:30%;" class="text-center">Tên sản phẩm</th>
                                    <th style="width:20%;" class="text-center">Ảnh</th>
                                    <th style="width:15%;" class="text-center">Giá</th>
                                    <th style="width:10%;" class="text-center">Số lượng</th>
                                    <th style="width:25%;" class="text-center">Hạn sử dụng</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal ID="ltlSanPhamConLaiTrongKho" runat="server"></asp:Literal>
                            </tbody>
                        </table>
                        <ul class="pagination">
                            <asp:Literal ID="ltlPageSanPhamConLaiTrongKho" runat="server"></asp:Literal>
                        </ul>
                    </div>
                    <!-- END DATA TABLE-->
                </div>
            </div>
        </div>
    </div>
</div>