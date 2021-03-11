<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebBanHang.Login" %>

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
    <title>Login</title>

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
    <link href="Asets/admin/css/theme.css" rel="stylesheet" media="all"/>

</head>

<body class="animsition">
    <div class="page-wrapper">
        <div class="page-content--bge5">
            <div class="container">
                <div class="login-wrap">
                    <div class="login-content">
                        <div class="login-logo">
                            <a href="#">
                                <h2>Đăng nhập</h2>
                            </a>
                        </div>
                        <div class="login-form">
                            <form method="post" runat="server">
                                <div class="form-group">
                                    <label>Tên đăng nhập</label>
                                    <asp:TextBox ID="txtTenDangNhap" runat="server"  class="au-input au-input--full"></asp:TextBox>
                                    <asp:Label ID="lbTenDangNhap" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label>Mật khẩu</label>
                                    <asp:TextBox ID="txtMatKhau" runat="server" class="au-input au-input--full" TextMode="Password"></asp:TextBox>
                                    <asp:Label ID="lbMatKhau" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </div>
                                <asp:Literal ID="ltlThongBao" runat="server"></asp:Literal>
                                <div class="login-checkbox">
                                    <label>
                                        <input type="checkbox" name="remember" />Nhớ tài khoản
                                    </label>
                                    <label>
                                        <a href="#">Quên mật khẩu?</a>
                                    </label>
                                </div>
                                <asp:Button ID="btnDangNhap" runat="server" Text="Đăng nhập" class="au-btn au-btn--block au-btn--green m-b-20" OnClick="DangNhap"/>
                            
                                <div class="register-link">
                                    <p>
                                        Bạn chưa có tài khoản?
                                        <asp:LinkButton ID="lbDangKy" runat="server" OnClick="DangKy">Đăng ký</asp:LinkButton>
                                    </p>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

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