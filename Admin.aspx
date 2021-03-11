<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebBanHang.Home" %>

<%@ Register Src="~/cms/admin/AdminLoadControl.ascx" TagPrefix="uc1" TagName="AdminLoadControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags-->
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content="au theme template"/>
    <meta name="author" content="Hau Nguyen"/>
    <meta name="keywords" content="au theme template"/>

    <!-- Title Page-->
    <title>Admin</title>

    <!-- Fontfaces CSS-->
    <link href="Asets/admin/css/font-face.css" rel="stylesheet" media="all"/>
    <link href="Asets/admin/vendor/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet" media="all"/>
    <link href="Asets/admin/vendor/font-awesome-5/css/fontawesome-all.min.css" rel="stylesheet" media="all"/>
    <link href="Asets/admin/vendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all"/>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet">
    <!-- Bootstrap CSS-->
    <link href="Asets/admin/vendor/bootstrap-4.1/bootstrap.min.css" rel="stylesheet" media="all"/>

    <!-- Vendor CSS-->
    <link href="Asets/admin/vendor/animsition/animsition.min.css" rel="stylesheet" media="all"/>
    <link href="Asets/admin/vendor/bootstrap-progressbar/bootstrap-progressbar-3.3.4.min.css" rel="stylesheet" media="all"/>
    <link href="Asets/admin/vendor/wow/animate.css" rel="stylesheet" media="all"/>
    <link href="Asets/admin/vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" media="all"/>
    <link href="Asets/admin/vendor/slick/slick.css" rel="stylesheet" media="all"/>
    <link href="Asets/admin/vendor/select2/select2.min.css" rel="stylesheet" media="all"/>
    <link href="Asets/admin/vendor/perfect-scrollbar/perfect-scrollbar.css" rel="stylesheet" media="all"/>

    <!-- Main CSS-->
    <link href="Asets/admin/css/theme.css" rel="stylesheet" />
    <link href="Asets/admin/css/style.css" rel="stylesheet" />
</head>

<body class="animsition">
    <form runat="server">
    <div class="page-wrapper">
        <!-- HEADER MOBILE-->
        <header class="header-mobile d-block d-lg-none">
            <div class="header-mobile__bar">
                <div class="container-fluid">
                    <div class="header-mobile-inner">
                        <a class="logo" href="index.html">
                            <img src="images/icon/preview.png" alt="Admin"  style="width:50px; height:50px;" /> &nbsp; Admin
                        </a>
                        <button class="hamburger hamburger--slider" type="button">
                            <span class="hamburger-box">
                                <span class="hamburger-inner"></span>
                            </span>
                        </button>
                    </div>
                </div>
            </div>
            <nav class="navbar-mobile">
                <div class="container-fluid">
                    <ul class="navbar-mobile__list list-unstyled">
                        <li class="has-sub">
                            <a class="js-arrow" href="#">
                                <i class="fas fa-tachometer-alt"></i>Quản lý người dùng
                            </a>
                        </li>
                        <li>
                            <a class="js-arrow" href="#">
                                <i class="fas fa-table"></i>Quản lý mặt hàng</a>
                        </li>
                        <li>
                            <a class="js-arrow" href="#">
                                <i class="far fa-check-square"></i>Quản lý đơn hàng</a>
                            <ul class="navbar-mobile-sub__list list-unstyled js-sub-list">
                                    <li>
                                        <a href="#">Thêm đơn hàng</a>
                                    </li>
                            </ul>
                        </li>
                        <li>
                            <a class="js-arrow" href="#">
                                <i class="fas fa-calendar-alt"></i>Quản lý giỏ hàng</a>
                            <ul class="navbar-mobile-sub__list list-unstyled js-sub-list">
                                    <li>
                                        <a href="#">Thêm giỏ hàng</a>
                                    </li>
                            </ul>
                        </li>
                        <li>
                            <a class="js-arrow" href="#">
                                <i class="fas fa-calendar-check"></i>Thống kê</a>
                            <ul class="navbar-mobile-sub__list list-unstyled js-sub-list">
                                    <li>
                                        <a href="#">Thống kê</a>
                                    </li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </nav>
        </header>
        <!-- END HEADER MOBILE-->

        <!-- MENU SIDEBAR-->
        <aside class="menu-sidebar d-none d-lg-block">
            <div class="logo">
                <a href="#">
                    <img src="images/icon/preview.png" alt="Admin" style="width:50px; height:50px;" /> &nbsp; Admin
                </a>
            </div>
            <div class="menu-sidebar__content js-scrollbar1">
                <nav class="navbar-sidebar">
                    <ul class="list-unstyled navbar__list">
                        <li class="has-sub">
                            <a class="<%=DanhDau("NguoiDung")%>" href="Admin.aspx?m=NguoiDung">
                                <i class="fas fa-user"></i>Quản lý người dùng
                            </a>
                        </li>
                        <li>
                            <a class="<%=DanhDau("MatHang")%>" href="Admin.aspx?m=MatHang">
                                <i class="fas fa-chart-bar"></i>Quản lý mặt hàng</a>
                        </li>
                        <li>
                            <a class="<%=DanhDau("GioHang")%>" href="Admin.aspx?m=GioHang">
                                <i class="fas fa-table"></i>Quản lý giỏ hàng</a>
                        </li>
                        <li>
                            <a class="<%=DanhDau("ThongKe")%>" href="Admin.aspx?m=ThongKe">
                                <i class="fas fa-calendar-alt"></i>Thống kê</a>
                        </li>
                    </ul>
                </nav>
            </div>
        </aside>
        <!-- END MENU SIDEBAR-->

        <!-- PAGE CONTAINER-->
        <div class="page-container">
            <!-- HEADER DESKTOP-->
            <header class="header-desktop">
                <div class="section__content section__content--p30">
                    <div class="container-fluid">
                        <div class="header-wrap"  style="float:right;">
                            <div class="header-button">
                                <div class="account-wrap">
                                    <div class="account-item clearfix js-item-menu">
                                        <div class="image">
                                            <img src="images/icon/user.jpg" />
                                        </div>
                                        <div class="content">
                                            <a class="js-acc-btn" href="#"><asp:Literal ID="ltlTen1" runat="server"></asp:Literal></a>
                                        </div>
                                        <div class="account-dropdown js-dropdown">
                                            <div class="info clearfix">
                                                <div class="image">
                                                    <a href="#">
                                                        <img src="images/icon/user.jpg" />
                                                    </a>
                                                </div>
                                                <div class="content">
                                                    <h5 class="name">
                                                        <a href="#"><asp:Literal ID="ltlTen2" runat="server"></asp:Literal></a>
                                                    </h5>
                                                    <span class="email"><asp:Literal ID="ltlSDT" runat="server"></asp:Literal></span>
                                                </div>
                                            </div>
                                            <div class="account-dropdown__body">
                                                <div class="account-dropdown__item">
                                                    <a href="#">
                                                        <i class="zmdi zmdi-account"></i>
                                                        <asp:Button ID="btnDoiMatKhau" runat="server" Text="Đổi mật khẩu" /></a>
                                                </div>
                                            </div>
                                            <div class="account-dropdown__footer">
                                                <a href="#">
                                                    <i class="zmdi zmdi-power"></i>
                                                    <asp:Button ID="btnDangXuat" runat="server" Text="Đăng xuất" CssClass="bDangXuat" OnClick="DangXuat"/>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </header>
            <!-- HEADER DESKTOP-->
            <uc1:AdminLoadControl runat="server" id="AdminLoadControl" />
            <!-- END PAGE CONTAINER-->
        </div>
        </div>
    </form>
    <!-- Jquery JS-->
    <script src="Asets/admin/vendor/jquery-3.2.1.min.js"></script>
    <!-- Bootstrap JS-->
    <script src="Asets/admin/vendor/bootstrap-4.1/popper.min.js"></script>
    <script src="Asets/admin/vendor/bootstrap-4.1/bootstrap.min.js"></script>
    <!-- Vendor JS       -->
    <script src="Asets/admin/vendor/slick/slick.min.js">
    </script>
    <script src="Asets/admin/vendor/wow/wow.min.js"></script>
    <script src="Asets/admin/vendor/animsition/animsition.min.js"></script>
    <script src="Asets/admin/vendor/bootstrap-progressbar/bootstrap-progressbar.min.js">
    </script>
    <script src="Asets/admin/vendor/counter-up/jquery.waypoints.min.js"></script>
    <script src="Asets/admin/vendor/counter-up/jquery.counterup.min.js">
    </script>
    <script src="Asets/admin/vendor/circle-progress/circle-progress.min.js"></script>
    <script src="Asets/admin/vendor/perfect-scrollbar/perfect-scrollbar.js"></script>
    <script src="Asets/admin/vendor/chartjs/Chart.bundle.min.js"></script>
    <script src="Asets/admin/vendor/select2/select2.min.js">
    </script>

    <!-- Main JS-->
    <script src="Asets/admin/js/main.js"></script>
</body>

</html>
<!-- end document-->
