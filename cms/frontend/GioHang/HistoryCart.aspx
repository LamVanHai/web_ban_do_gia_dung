<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="HistoryCart.aspx.cs" Inherits="WebBanHang.cms.frontend.GioHang.HistoryCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Lịch sử mua hàng
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
        <!-- Breadcrumb Section Begin -->
    <div class="breacrumb-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="breadcrumb-text product-more">
                        <a href="/Home.aspx"><i class="fa fa-home"></i> Trang chủ</a>
                        <span>Lịch sử mua hàng</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Breadcrumb Section Begin -->

    <!-- Shopping Cart Section Begin -->
    <section class="shopping-cart spad">
        <div class="container">
            <asp:Label ID="list_cart_history" runat="server"></asp:Label>
            <div class='row'>
                <div class="col-lg-12">
                    <div class="cart-table">
                        <table>
                            <thead>
                                <tr>
                                    <th colspan="3"  class="text-left pl-5 text-left">
                                        Đơn hàng asd : Kim Vương - 0938200696 - 4 Văn Tì, Hà Nội. Ngày tạo: 30/11/2020 
                                    </th>
                                    
                                    <th style="text-align:left!important;text-transform:none!important">Trạng thái: <br />
                                        <span class="text-danger">Đã giao hàng<span></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td class="cart-pic first-row"><img src="img/cart-page/product-1.jpg" alt=""></td>
                                    <td class="cart-title first-row"><h5>Pure Pineapple</h5></td>
                                    <td class="p-price first-row">$60.00</td>
                                    <td class="qua-col first-row">x 1</td>
                                </tr>
                                <tr>
                                    <td class="cart-title first-row"></td> 
                                    <td class="cart-title first-row" ><h5><b>Tổng tiền</b><h5></td>
                                    <td class="qua-col first-row" >100000</td>
                                    <td colspan="2"></td>  
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Shopping Cart Section End -->

    <!-- Partner Logo Section Begin -->
    <div class="partner-logo">
        <div class="container">
            <div class="logo-carousel owl-carousel">
                <div class="logo-item">
                    <div class="tablecell-inner">
                        <img src="img/logo-carousel/logo-1.png" alt="">
                    </div>
                </div>
                <div class="logo-item">
                    <div class="tablecell-inner">
                        <img src="img/logo-carousel/logo-2.png" alt="">
                    </div>
                </div>
                <div class="logo-item">
                    <div class="tablecell-inner">
                        <img src="img/logo-carousel/logo-3.png" alt="">
                    </div>
                </div>
                <div class="logo-item">
                    <div class="tablecell-inner">
                        <img src="img/logo-carousel/logo-4.png" alt="">
                    </div>
                </div>
                <div class="logo-item">
                    <div class="tablecell-inner">
                        <img src="img/logo-carousel/logo-5.png" alt="">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Partner Logo Section End -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="js" runat="server">
</asp:Content>
