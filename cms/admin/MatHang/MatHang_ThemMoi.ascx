<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MatHang_ThemMoi.ascx.cs" Inherits="WebBanHang.cms.admin.MatHang.MatHang_ThemMoi" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<div class="row m-t-100">
    <div class="col-lg-3"></div>
    <div class="col-lg-6">
        <div class="card">
            <div class="card-header">
                <asp:Literal ID="ltlHeader" runat="server">Thêm mới</asp:Literal>
            </div>
            <div class="card-body">
                <div class="card-title">
                    <h3 class="text-center title-2">Thông tin mặt hàng</h3>
                </div>
                <hr>
                <form  method="post" novalidate="novalidate">
                    <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Tên Sản phẩm</label>
                        <asp:TextBox ID="txtSanPham" runat="server"  CssClass="form-control" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtSanPham" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Danh muc</label>
                        <asp:DropDownList ID="txtDanhMuc" runat="server">                           
                            <asp:ListItem>Đồ gia dụng</asp:ListItem>
                            <asp:ListItem>Thực Phẩm</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtDanhMuc" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Màu</label>
                        <asp:DropDownList ID="txtMau" runat="server">
                            <asp:ListItem>Đỏ</asp:ListItem>
                            <asp:ListItem>Cam</asp:ListItem>
                            <asp:ListItem>Vàng</asp:ListItem>
                            <asp:ListItem>Lục</asp:ListItem>
                            <asp:ListItem>Lam</asp:ListItem>
                            <asp:ListItem>Chàm</asp:ListItem>
                            <asp:ListItem>Tím</asp:ListItem>
                            <asp:ListItem>Đen</asp:ListItem>
                            <asp:ListItem>Trắng</asp:ListItem>
                        </asp:DropDownList> 
                    </div>
                    <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Ảnh sản phẩm</label>
                        <div>
                            <asp:Literal ID="ltrAnh" runat="server"></asp:Literal>
                        </div>
                        <asp:FileUpload ID="flAnh" runat="server" />
                    </div>
                    <div class="form-group">
                        <div>
                            <label for="cc-payment" class="control-label mb-1">Miêu tả</label>&nbsp;&nbsp;&nbsp;
                            <CKEditor:CKEditorControl ID="txtMieuTa" runat="server" CssClass="form-control"></CKEditor:CKEditorControl>
                        </div>
                    </div>
                    <div class="form-group">
                        <div>
                            <label for="cc-payment" class="control-label mb-1">Giá</label> &nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtGia" runat="server"  CssClass="form-control" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtGia" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Số lượng trong kho</label>
                        <asp:TextBox ID="txtSoLuong" runat="server"  CssClass="form-control" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtSoLuong" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Hạn sử dụng</label>  
                        <div>
                            <label for="cc-payment" class="control-label mb-1">Hạn sử dụng:</label>&nbsp;&nbsp;&nbsp;
                            Ngày<asp:DropDownList ID="lbNgay" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;Tháng<asp:DropDownList ID="lbThang" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;Năm<asp:DropDownList ID="lbNam" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div>
                         <asp:Button ID="btnThemMoi" runat="server" CssClass="btn btn-lg btn-info btn-block" Text="Thêm mới" OnClick="btnUpdate_Click" />
                    </div>
                </form>
            </div>
        </div>
    </div>
    <div class="col-lg-3"></div>
</div>