<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebBanHang.Home1" %>

<%@ Register Src="~/cms/display/WebNguoiDungControl.ascx" TagPrefix="uc1" TagName="UserLoadControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8"/>
    <meta name="description" content="Fashi Template"/>
    <meta name="keywords" content="Fashi, unica, creative, html"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <title>Trang chủ</title>

    <!-- Google Font -->
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet"/>
	
    <link href="Asets/admin/css/font-face.css" rel="stylesheet" media="all"/>
    <link href="Asets/admin/vendor/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet" media="all"/>
    <link href="Asets/admin/vendor/font-awesome-5/css/fontawesome-all.min.css" rel="stylesheet" media="all"/>
    <link href="Asets/admin/vendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all" />
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

    <!-- Css Styles -->
    <link rel="stylesheet" href="Asets/display/css/bootstrap.min.css" type="text/css"/>
    <link rel="stylesheet" href="Asets/display/css/font-awesome.min.css" type="text/css"/>
    <link rel="stylesheet" href="Asets/display/css/themify-icons.css" type="text/css"/>
    <link rel="stylesheet" href="Asets/display/css/elegant-icons.css" type="text/css"/>
    <link rel="stylesheet" href="Asets/display/css/owl.carousel.min.css" type="text/css"/>
    <link rel="stylesheet" href="Asets/display/css/nice-select.css" type="text/css"/>
    <link rel="stylesheet" href="Asets/display/css/jquery-ui.min.css" type="text/css"/>
    <link rel="stylesheet" href="Asets/display/css/slicknav.min.css" type="text/css"/>
    <link rel="stylesheet" href="Asets/display/css/style.css" type="text/css"/>
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

<body>
<form runat ="server">
    <!-- Page Preloder -->
    <div id="preloder">
        <div class="loader"></div>
    </div>

    <!-- Header Section Begin -->
    <header class="header-section">
        <div class="header-top">
            <div class="container">
                <div class="ht-left">
                    <div class="mail-service">
                        <i class=" fa fa-envelope"></i>
                        <asp:Literal ID="ltlGmail" runat="server"></asp:Literal>
                    </div>
                    <div class="phone-service">
                        <i class=" fa fa-phone"></i>
                        <asp:Literal ID="ltlSDT" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="ht-right">
                    <div class="login-panel">
                        <div class="section__content section__content--p30">                          
                            <div  class="container-fluid"> 
                                <asp:PlaceHolder ID="plhDaDangNhap" runat="server" Visible="false">
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
                                                                <span class="email"><asp:Literal ID="ltlSDT1" runat="server"></asp:Literal></span>
                                                            </div>
                                                        </div>
                                                        <div class="account-dropdown__body">
                                                            <div class="account-dropdown__item">
                                                                <a href="#">
                                                                    <i class="zmdi zmdi-account"></i>
                                                                    <asp:Button ID="btnThongTinCaNhan" runat="server" Text="Thông tin cá nhân" OnClick="btnThongTinCaNhan_Click"/>
                                                                </a>
                                                            </div>
                                                        </div>
                                                        <div class="account-dropdown__body">
                                                            <div class="account-dropdown__item">
                                                                <a href="#">
                                                                    <i class="zmdi zmdi-account"></i>
                                                                    <asp:Button ID="btnDoiMatKhau" runat="server" Text="Đổi mật khẩu" OnClick="btnDoiMatKhau_Click"/>
                                                                </a>
                                                            </div>
                                                        </div>
                                                        <div class="account-dropdown__footer">
                                                            <a href="#">
                                                                <i class="zmdi zmdi-power"></i>
                                                                <asp:Button ID="btnDangXuat" runat="server" Text="Đăng xuất" CssClass="bDangXuat" OnClick="btnDangXuat_Click"/>
                                                            </a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div> 
                                 </asp:PlaceHolder>
                            </div>
                        </div>
                            <asp:PlaceHolder ID="plhChuaDangNhap" runat="server" >
                                <asp:Button ID="btnDangNhap"  runat="server" Text="Đăng nhập" OnClick="btnDangNhap_Click" CssClass="buttonDangNhap" />
                                &nbsp&nbsp;
                                <asp:Button ID="btnDangKy"  runat="server" Text="Đăng ký" OnClick="btnDangKy_Click" CssClass="buttonDangNhap" />
                            </asp:PlaceHolder>
                    </div>
                    <div class="top-social">
                        <a href="#"><i class="ti-facebook"></i></a>
                        <a href="#"><i class="ti-twitter-alt"></i></a>
                        <a href="#"><i class="ti-linkedin"></i></a>
                        <a href="#"><i class="ti-pinterest"></i></a>
                    </div>
                </div>
            </div>
        </div>

        <div class="container">
            <div class="inner-header">
                <div class="row">
                    <div class="col-lg-3 col-md-3">
                        <div class="logo">
                            <a href="./index.html">
                                <img src="/images/Display/logo.png" alt=""/>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6">
                        <div class="advanced-search">
                            <button type="button" class="category-btn" >Tên</button>
                            <div class="input-group">
                                <asp:TextBox ID="txtTimKiem" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3">
                            
                         <asp:Button ID="btnTimKiem" CssClass="au-btn au-btn-icon au-btn--blue zmdi zmdi-search" runat="server" Text="Tìm kiếm" OnClick="btnTimKiem_Click1"/>
                            
                    </div>
                </div>
            </div>
        </div>

       
        <div class="nav-item">
            <div class="container">
                <div class="nav-depart">
                    <div class="depart-btn">
                        <i class="ti-menu"></i>
                        <span>Tất cả danh mục</span>
                        <ul class="depart-hover">
                            <li class="active"><a href="#">Đồ thực phẩm</a></li>
                            <li class="active" ><a href="#">Đồ gia dụng</a></li>
                        </ul>
                    </div>
                </div>
                <nav class="nav-menu mobile-menu">
                    <ul>
                        <li class="active"><a href="Home.aspx">Trang chủ</a></li>
                        <li><a href="Home.aspx">Sản phẩm</a></li>
                    </ul>
                </nav>
                <div id="mobile-menu-wrap"></div>
            </div>
        </div>
  

    </header>


    <uc1:UserLoadControl runat="server" id="UserLoadControl" /> <!-- đây là phần trang chủ được thêm vào -->

    <footer class="footer-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-4">
                    <div class="footer-left">
                        <div class="footer-logo">
                            <a href="#"><img src="/images/Display/footer-logo.png" alt=""/></a>
                        </div>
                        <ul>
                            <li>Địa chỉ: 298 Cầu Diễn, Bắc Từ Liêm, Hà Nội</li>
                            <li>Điện thoại: 0974.198.943</li>
                            <li>Email: phunghaiduong.99@gmail.com</li>
                        </ul>
                        <div class="footer-social">
                            <a href="#"><i class="fa fa-facebook"></i></a>
                            <a href="#"><i class="fa fa-instagram"></i></a>
                            <a href="#"><i class="fa fa-twitter"></i></a>
                            <a href="#"><i class="fa fa-pinterest"></i></a>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2">
                    <div class="footer-widget">
                        <h5>Thông tin</h5>
                        <ul>
                            <li><a href="#">Thông tin</a></li>
                            <li><a href="#">Thanh toán</a></li>
                            <li><a href="#">Liên hệ</a></li>
                            <li><a href="#">Điều khoản sử dụng</a></li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-2">
                    <div class="footer-widget">
                        <h5>Tài khoản</h5>
                        <ul>
                            <li><a href="#">Tài khoản của tôi</a></li>
                            <li><a href="#">Liên hệ</a></li>
                            <li><a href="#">Giỏ hàng</a></li>
                            <li><a href="#">Sảm phẩm của bạn</a></li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="newslatter-item">
                        <h5>Tham gia cùng chúng tôi</h5>
                        <p>Cập nhật email mới nhất để tham gia các hoạt động của chúng tôi</p>
                        <form action="#" class="subscribe-form">
                            <input type="text" placeholder="Email của bạn">
                            <button type="button">Đăng ký</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        
    </footer>
    <!-- Footer Section End -->

    <!-- Js Plugins -->
    <script src="Asets/display/js/jquery-3.3.1.min.js"></script>
    <script src="Asets/display/js/bootstrap.min.js"></script>
    <script src="Asets/display/js/jquery-ui.min.js"></script>
    <script src="Asets/display/js/jquery.countdown.min.js"></script>
    <script src="Asets/display/js/jquery.nice-select.min.js"></script>
    <script src="Asets/display/js/jquery.zoom.min.js"></script>
    <script src="Asets/display/js/jquery.dd.min.js"></script>
    <script src="Asets/display/js/jquery.slicknav.js"></script>
    <script src="Asets/display/js/owl.carousel.min.js"></script>
    <script src="Asets/display/js/main.js"></script>

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
</form>
</body>
</html>