<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThongTinGioHang.ascx.cs" Inherits="WebBanHang.cms.admin.QLGioHang.ThongTinGioHang" %>
<div class="main-content">
    <div class="section__content section__content--p30">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="overview-wrap row">
                        <div class="col-md-4">
                            <h2 class="title-1">Quản lý giỏ hàng</h2>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="table-responsive table--no-card m-t-20 table-giohang-admin ">
                      
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="MaDonHang" OnRowCommand="GridView1_RowCommand" >
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Button Text="Xác nhận đơn hàng" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nội dung">
                                    <ItemTemplate>
                                    <asp:Label Text="" ID="chitiet" runat="server" />
                                  </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="TenKhachHang" HeaderText="TenKhachHang" SortExpression="TenKhachHang" />
                                <asp:BoundField DataField="ThanhToan" HeaderText="ThanhToan" SortExpression="ThanhToan" />
                                <asp:BoundField DataField="NgayDatHang" HeaderText="NgayDatHang" SortExpression="NgayDatHang" />
                                <asp:BoundField DataField="TrangThai" HeaderText="TrangThai" SortExpression="TrangThai" />
                                <asp:BoundField DataField="DiaChi" HeaderText="DiaChi" SortExpression="DiaChi" />
                                <asp:BoundField DataField="SoDienThoai" HeaderText="SoDienThoai" SortExpression="SoDienThoai" />
                                <asp:BoundField DataField="MaDonHang" HeaderText="MaDonHang" InsertVisible="False" ReadOnly="True" SortExpression="MaDonHang" />
                            </Columns>
                        </asp:GridView>
                        
                      
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
    
</div>
    <script src="Asets/admin/vendor/jquery-3.2.1.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        var trs = $('.table-giohang-admin tr');
        for (var i = 1; i < trs.length; i++) {
            console.log("a");
            var t = trs.eq(i);
            if (i % 2 == 0)
                t.css({ "background-color": "rgb(245, 245, 245)" })
            else
                t.css({ "background-color": "white" })
        }
    })
</script>