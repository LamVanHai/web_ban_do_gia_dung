function ThemVaoGioHang(maHang, soLuong) {
    var json = { "maHang": maHang, "soluong": soLuong };
    if ($('.notlogin').length != 1) {
        $.ajax({
            type: 'post',
            url: '/cms/frontend/GioHang/AjaxThemGioHang.aspx',
            data: JSON.stringify(json),
            contentType: "application/json;charset=utf-8",
            success: function (response) {
                var a = response;
                alert(response);
                getAllCart();
            },
            error: function (response) {
                var a = response;
                alert(response.responseText);
                getAllCart();
            }
        });
    } else {
        alert("Chua dang nhap");
    }
    
}