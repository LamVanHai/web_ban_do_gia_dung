<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChiTiet.ascx.cs" Inherits="WebBanHang.cms.display.ChiTiet" %>

<style>
    .wrapper{
        width: 80%;
        margin: auto;
        height: 800px;
    }
    .auto-style1 {
        height: 5px;
    }
</style>

<div class ="wrapper">
    <table>
        <tr>
            <td rowspan="6"><img src = '/images/Display/products/man-1.jpg' /></td>
        </tr>
        <tr>
            <td>Loại sản phẩm :</td>
            <td>
                <b><asp:Label ID="lbLoaiSanPham" runat="server" Text=""></asp:Label></b>
            </td>
        </tr>
        <tr>
            <td>Tên sản phẩm :</td>
            <td>
                <b><asp:Label ID="lbTenSanPham" runat="server" Text=""></asp:Label></b>
            </td>
        </tr>
        <tr>
            <td>Giá :</td>
            <td>
                <b><asp:Label ID="lbGia" runat="server" Text=""></asp:Label></b>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                phương thức thanh toán : <br />
                <b><asp:RadioButton ID="RadioButton1" runat="server" GroupName="phuongthuc" Text="Chuyển khoản" /></b> <br />
                <b><asp:RadioButton ID="RadioButton2" runat="server" GroupName="phuongthuc" Text="Thanh toán khi nhận hàng" Checked="true" /></b>
            </td>
        </tr>
       <tr>
            <td colspan="2">
                <b><asp:Button ID="btnThemVaoGioHang" runat="server" Text="Thêm vào giỏ hàng" OnClick="btnThemVaoGioHang_Click" /></b>
            </td>
        </tr>
        <tr>
            <td colspan="2">Mô tả sản phẩm :
                <b><asp:Label ID="lbMoTaSanPham" runat="server" Text=""></asp:Label></b>
            </td>
        </tr>
    </table>
</div>
