<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrangChu.ascx.cs" Inherits="WebBanHang.cms.display.TrangChu" %>

<style>
    .title-containt{
        width : 100%;
    }

    .pagination{
        width : 40%;
        margin : auto;
    }
</style>

<section class="women-banner spad">
    <div class="container-fluid">
	    <div class="title-containt">Sản phẩm mới</div>
            <div class="row">
                <div class="col-lg-10 offset-lg-1">
                    <div class="filter-control">
                        <ul>
                            <li ><asp:Button ID="btnDoThucPham" runat="server" Text="Đồ thực phẩm"  OnClick="btnDoThucPham_Click"  BorderStyle="Solid"/></li>
                            <li ><asp:Button ID="btnDoGiaDung" runat="server" Text="Đồ gia dụng"  OnClick="btnDoGiaDung_Click" BorderStyle="Solid"/></li>
                        </ul>
                </div>
                  <
                <div class="row" style="width:100%;">
                    <asp:Literal ID="ltlSanPham" runat="server"></asp:Literal>
                </div>
                <ul class="pagination">
                    <asp:Literal ID="ltlPageSanPhamConLaiTrongKho" runat="server"></asp:Literal>
                </ul>
            </div>
        </div>
    </div> 
</section>



