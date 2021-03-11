<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebBanHang.cms.frontend.GioHang.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Gio hang
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <!-- Breadcrumb Section Begin -->
    <div class="breacrumb-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="breadcrumb-text product-more">
                        <a href="/Home.aspx"><i class="fa fa-home"></i> Trang chủ</a>
                        <span>Giỏ hàng</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Breadcrumb Section Begin -->

    <!-- Shopping Cart Section Begin -->
    <section class="shopping-cart spad">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="cart-table">
                        <table>
                            <thead>
                                <tr>
                                    <th>Ảnh</th>
                                    <th class="p-name">Tên sản phẩm</th>
                                    <th>Giá (VNĐ)</th>
                                    <th>Số lượng</th>
                                    <th>Tổng (VNĐ)</th>
                                    <th><i class="ti-close"></i></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal ID="listGioHang" runat="server"></asp:Literal>
                                
                                
                            </tbody>
                        </table>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="cart-buttons">
                                <%--<a href="#" onclick="return getAllCart()" class="primary-btn continue-shop">Continue shopping</a>--%>
                                <a href="#" onclick="return updatecart()"  class="primary-btn up-cart">Cập nhật giỏ hàng</a>
                            </div>
                            <%--<div class="discount-coupon">
                                <h6>Discount Codes</h6>
                                <form action="#" class="coupon-form">
                                    <input type="text" placeholder="Enter your codes">
                                    <button type="submit" class="site-btn coupon-btn">Apply</button>
                                </form>
                            </div>--%>
                        </div>
                        <div class="col-lg-4 offset-lg-4">
                            <div class="proceed-checkout">
                                <ul>
                                    <li class="subtotal">Tổng giá trị đơn hàng: 
                                         <asp:Label ID="subtotal" runat="server"></asp:Label>
                                    </li>
                                    <li class="cart-total">Số tiền phải thanh toán: 
                                        <asp:Label ID="carttotal" runat="server"></asp:Label>
                                    </li>
                                </ul>
                                <a href="/cms/frontend/GioHang/ThanhToan.aspx" onclick="return updatecart()" class="proceed-btn">THANH TOÁN</a>
                            </div>
                        </div>
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
                        <img src="" alt="">
                    </div>
                </div>
                <div class="logo-item">
                    <div class="tablecell-inner">
                        <img src="" alt="">
                    </div>
                </div>
                <div class="logo-item">
                    <div class="tablecell-inner">
                        <img src="" alt="">
                    </div>
                </div>
                <div class="logo-item">
                    <div class="tablecell-inner">
                        <img src="" alt="">
                    </div>
                </div>
                <div class="logo-item">
                    <div class="tablecell-inner">
                        <img src="" alt="">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Partner Logo Section End -->
</asp:Content>
<asp:Content ID="js" ContentPlaceHolderID="js" runat="server">
    <script>
        $(document).ready(function () {
            var proQty = $('.pro-qty');
            var totalAll1 = $('.subtotal span');
            var totalAll2 = $('.cart-total span');
            var totalNum = Number(currencyToNumber(totalAll1.html()));
            proQty.prepend('<span class="dec qtybtn">-</span>');
            proQty.append('<span class="inc qtybtn">+</span>');
            proQty.on('click', '.qtybtn', function () {
                var $button = $(this);
                var oldValue = $button.parent().find('input').val();
                var parent = $button.parent().parent().parent().parent();
                var total_price = Number(currencyToNumber(parent.find('.total-price').html()));
                var price = Number(currencyToNumber(parent.find('.p-price').html()));
                var isDelete = false;
                if ($button.hasClass('inc')) {
                    var newVal = parseFloat(oldValue) + 1;
                    total_price += price;
                    totalNum += price;
                } else {
                    // Don't allow decrementing below zero
                    var newVal = 1;
                    if (oldValue > 1) {
                        newVal = parseFloat(oldValue) - 1;
                        total_price -= price;
                        totalNum -= price;
                    } else {
                        if (confirm('Xac nhan xoa')) {
                            isDelete = true;
                            totalNum -= price;
                            parent.remove();
                        }
                    }
                }
                if (!isDelete) {
                    $button.parent().find('input').val(newVal);
                    parent.find('.total-price').html(numberWithCommas(total_price));
                }
                totalAll1.html(numberWithCommas(totalNum));
                totalAll2.html(numberWithCommas(totalNum));
            });

            var closeOne = $('.close-td i');
            var closeAll = $('th .ti-close');
            closeOne.click(function () {
                var totalPrice = Number(currencyToNumber($(this).parent().parent().find('.total-price').html()));
                totalNum -= totalPrice;
                totalAll1.html(numberWithCommas(totalNum));
                totalAll2.html(numberWithCommas(totalNum));
                var dsSanPham = [];
                var item = { "maSP": Number($(this).closest('tr').find('.maSP').html()) };
                dsSanPham.push(item);
                xoaGioHangItem(dsSanPham);
                $(this).parent().parent().remove();

            })
            closeAll.click(function () {
                var dsSanPham = [];
                $('.cart-table tbody tr').each(function () {
                    var item = { "maSP": Number($(this).find('.maSP').html()) };
                    dsSanPham.push(item);
                    $(this).remove();
                })
                xoaGioHangItem(dsSanPham);
                totalAll1.html(numberWithCommas(0));
                totalAll2.html(numberWithCommas(0));
            })
            //update cart to db
            function numberWithCommas(x) {
                return x.toString().replace(/\B(?<!\.\d*)(?=(\d{3})+(?!\d))/g, ",");
            }

            function currencyToNumber(cur) {
                return Number(cur.replaceAll(",", "").replaceAll(".", "").replaceAll("$", ""));
            }


            
        })
    </script>
</asp:Content>
