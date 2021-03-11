<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThongTinCaNhan.aspx.cs" Inherits="WebBanHang.ThongTinCaNhan" %>

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
                                <h2><asp:Label ID="Label6" runat="server" Text="Sửa thông tin cá nhân"></asp:Label></h2>
                            </a>
                        </div>
                        <div class="login-form">
                            <form method="post" runat="server">
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server">Tên đăng nhập</asp:Label>
                                    <asp:TextBox ID="txtTenDangNhap" runat="server"  class="au-input au-input--full" Font-Bold="true" Enabled="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtTenDangNhap" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server">Tên<br/></asp:Label>
                                    <asp:Label ID="lbTentk" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtTentk" runat="server"  class="au-input au-input--full"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtTentk" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server">Địa chỉ<br/></asp:Label>
                                    <asp:Label ID="lbDiaChi" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtDiaChi" runat="server"  class="au-input au-input--full"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtDiaChi" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label5" runat="server">Số điện thoại<br/></asp:Label>
                                    <asp:Label ID="lbSoDienThoai" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtDienThoai" runat="server"  class="au-input au-input--full"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtDienThoai" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <asp:Literal ID="ltlThongBao" runat="server"></asp:Literal>
                                
                                <asp:Button ID="btnLuu" runat="server" Text="Lưu" class="au-btn au-btn--block au-btn--green m-b-20" OnClick="btnLuu_Click" />
                                    
                                <div class="au-btn au-btn--block au-btn--green m-b-20"><a href="Home.aspx" ><h5  style="position:center; padding-left:190px;color:white">Hủy</h5></a></div>
                                    
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
<!-