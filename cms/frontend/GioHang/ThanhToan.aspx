<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="ThanhToan.aspx.cs" Inherits="WebBanHang.cms.frontend.GioHang.ThanhToan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Thanh toán
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <!-- Breadcrumb Section Begin -->
    <div class="breacrumb-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="breadcrumb-text product-more">
                        <a href="/Home.aspx"><i class="fa fa-home"></i> Trang chủ</a>
                        <span>Thanh toán</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Breadcrumb Section Begin -->

    <!-- Shopping Cart Section Begin -->
    <section class="checkout-section spad">
        <div class="container">
            <form action="#" class="checkout-form" runat="server">
                <div class="row">
                    <div class="col-lg-6">
                        <div class="checkout-content">
                            <a href="/Login.aspx" class="content-btn">Đăng nhập bạn êi</a>
                        </div>
                        <h4>Biiling Details</h4>
                        <div class="row">
                            <div class="col-lg-12">
                                <label for="fir">Tên người nhận<span>*</span></label>
                                    <br />
                                <%--<input type="text" id="fir">--%>
                                <asp:Label ID="errTen" runat="server" Font-Italic="true" Font-Size="Small" ForeColor="Red"></asp:Label>
                                <asp:TextBox ID="txtTen" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-lg-12">
                                <label for="cun-name">Số điện thoại</label>
                                    <br />
                                <asp:Label ID="errSDT" runat="server" Font-Italic="true" Font-Size="Small" ForeColor="Red"></asp:Label>
                                <asp:TextBox ID="txtSdt" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-lg-12">
                                <label for="cun">Địa chỉ<span>*</span></label>
                                    <br />
                                <asp:Label ID="errDiaChi" runat="server" Font-Italic="true" Font-Size="Small" ForeColor="Red"></asp:Label>
                                <asp:TextBox ID="txtDiaChi" runat="server"></asp:TextBox>

                            </div>
                            <%--<div class="col-lg-12">
                                <div class="create-item">
                                    <label for="acc-create">
                                        Create an account?
                                        <input type="checkbox" id="acc-create">
                                        <span class="checkmark"></span>
                                    </label>
                                </div>
                            </div>--%>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="checkout-content">
                            <input type="text" placeholder="Nhập mã giảm giá">
                        </div>
                        <div class="place-order">
                            <h4>Your Order</h4>
                            <div class="order-total">
                                <ul class="order-table">
                                    <li>Sản phẩm <span>Tổng</span></li>
                                    <asp:Literal ID="listGioHang" runat="server"></asp:Literal>
                                    <li class="total-price">Số tiền phải thanh toán (VNĐ): <span><asp:Label ID="subtotal1" runat="server"></asp:Label></span></li>
                                </ul>
                                <div class="payment-check">
                                    <div class="pc-item">
                                         <asp:RadioButton ID="online" GroupName="payment" runat="server" Checked="true"/>
                                        <label for="pc-check">
                                            Chuyển khoản
                                        </label>

                                    </div>
                                    <div class="pc-item">
                                        <asp:RadioButton ID="offline" GroupName="payment" runat="server" />
                                        <label for="pc-paypal">
                                            Thanh toán khi nhận hàng
                                        </label>

                                    </div>
                                </div>
                                <div class="order-btn">
                                    <asp:Button CssClass="site-btn place-btn" Text="Xác nhận" runat="server" OnClick="Unnamed1_Click" />
                                    <%--<button type="submit" class="site-btn place-btn">Place Order</button>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
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
