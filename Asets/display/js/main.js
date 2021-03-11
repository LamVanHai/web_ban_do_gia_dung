/*  ---------------------------------------------------
    Template Name: Fashi
    Description: Fashi eCommerce HTML Template
    Author: Colorlib
    Author URI: https://colorlib.com/
    Version: 1.0
    Created: Colorlib
---------------------------------------------------------  */

'use strict';

(function ($) {

    /*------------------
        Preloader
    --------------------*/
    $(window).on('load', function () {
        $(".loader").fadeOut();
        $("#preloder").delay(200).fadeOut("slow");
    });

    /*------------------
        Background Set
    --------------------*/
    $('.set-bg').each(function () {
        var bg = $(this).data('setbg');
        $(this).css('background-image', 'url(' + bg + ')');
    });

    /*------------------
		Navigation
	--------------------*/
    $(".mobile-menu").slicknav({
        prependTo: '#mobile-menu-wrap',
        allowParentLinks: true
    });

    /*------------------
        Hero Slider
    --------------------*/
    $(".hero-items").owlCarousel({
        loop: true,
        margin: 0,
        nav: true,
        items: 1,
        dots: false,
        animateOut: 'fadeOut',
        animateIn: 'fadeIn',
        navText: ['<i class="ti-angle-left"></i>', '<i class="ti-angle-right"></i>'],
        smartSpeed: 1200,
        autoHeight: false,
        autoplay: true,
    });

    /*------------------
        Product Slider
    --------------------*/
   $(".product-slider").owlCarousel({
        loop: true,
        margin: 25,
        nav: true,
        items: 4,
        dots: true,
        navText: ['<i class="ti-angle-left"></i>', '<i class="ti-angle-right"></i>'],
        smartSpeed: 1200,
        autoHeight: false,
        autoplay: true,
        responsive: {
            0: {
                items: 1,
            },
            576: {
                items: 2,
            },
            992: {
                items: 2,
            },
            1200: {
                items: 3,
            }
        }
    });

    /*------------------
       logo Carousel
    --------------------*/
    $(".logo-carousel").owlCarousel({
        loop: false,
        margin: 30,
        nav: false,
        items: 5,
        dots: false,
        navText: ['<i class="ti-angle-left"></i>', '<i class="ti-angle-right"></i>'],
        smartSpeed: 1200,
        autoHeight: false,
        mouseDrag: false,
        autoplay: true,
        responsive: {
            0: {
                items: 3,
            },
            768: {
                items: 5,
            }
        }
    });

    /*-----------------------
       Product Single Slider
    -------------------------*/
    $(".ps-slider").owlCarousel({
        loop: false,
        margin: 10,
        nav: true,
        items: 3,
        dots: false,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        smartSpeed: 1200,
        autoHeight: false,
        autoplay: true,
    });
    
    /*------------------
        CountDown
    --------------------*/
    // For demo preview
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    if(mm == 12) {
        mm = '01';
        yyyy = yyyy + 1;
    } else {
        mm = parseInt(mm) + 1;
        mm = String(mm).padStart(2, '0');
    }
    var timerdate = mm + '/' + dd + '/' + yyyy;
    // For demo preview end

    // Use this for real timer date
    /* var timerdate = "2020/01/01"; */

	$("#countdown").countdown(timerdate, function(event) {
        $(this).html(event.strftime("<div class='cd-item'><span>%D</span> <p>Days</p> </div>" + "<div class='cd-item'><span>%H</span> <p>Hrs</p> </div>" + "<div class='cd-item'><span>%M</span> <p>Mins</p> </div>" + "<div class='cd-item'><span>%S</span> <p>Secs</p> </div>"));
    });

        
    /*----------------------------------------------------
     Language Flag js 
    ----------------------------------------------------*/
    $(document).ready(function(e) {
    //no use
    try {
        var pages = $("#pages").msDropdown({on:{change:function(data, ui) {
            var val = data.value;
            if(val!="")
                window.location = val;
        }}}).data("dd");

        var pagename = document.location.pathname.toString();
        pagename = pagename.split("/");
        pages.setIndexByValue(pagename[pagename.length-1]);
        $("#ver").html(msBeautify.version.msDropdown);
    } catch(e) {
        // console.log(e);
    }
    $("#ver").html(msBeautify.version.msDropdown);

    //convert
    $(".language_drop").msDropdown({roundedBorder:false});
        $("#tech").data("dd");
    });
    /*-------------------
		Range Slider
	--------------------- */
	var rangeSlider = $(".price-range"),
		minamount = $("#minamount"),
		maxamount = $("#maxamount"),
		minPrice = rangeSlider.data('min'),
		maxPrice = rangeSlider.data('max');
	    rangeSlider.slider({
		range: true,
		min: minPrice,
        max: maxPrice,
		values: [minPrice, maxPrice],
		slide: function (event, ui) {
			minamount.val('$' + ui.values[0]);
			maxamount.val('$' + ui.values[1]);
		}
	});
	minamount.val('$' + rangeSlider.slider("values", 0));
    maxamount.val('$' + rangeSlider.slider("values", 1));

    /*-------------------
		Radio Btn
	--------------------- */
    $(".fw-size-choose .sc-item label, .pd-size-choose .sc-item label").on('click', function () {
        $(".fw-size-choose .sc-item label, .pd-size-choose .sc-item label").removeClass('active');
        $(this).addClass('active');
    });
    
    /*-------------------
		Nice Select
    --------------------- */
    $('.sorting, .p-show').niceSelect();

    /*------------------
		Single Product
	--------------------*/
	$('.product-thumbs-track .pt').on('click', function(){
		$('.product-thumbs-track .pt').removeClass('active');
		$(this).addClass('active');
		var imgurl = $(this).data('imgbigurl');
		var bigImg = $('.product-big-img').attr('src');
		if(imgurl != bigImg) {
			$('.product-big-img').attr({src: imgurl});
			$('.zoomImg').attr({src: imgurl});
		}
	});

    $('.product-pic-zoom').zoom();
    
    /*-------------------
		Quantity change
	--------------------- */
   

    $('.inner-header .ti-close').click(function () {
        var total_html = $('.cart-icon-total');
        var total = currencyToNumber(total_html.html());
        console.log("asdsadsadsadsad");
        var price = Number(currencyToNumber($(this).closest("tr").find(".cart-icon-pr").html()));
        var quantity = Number($(this).closest("tr").find(".cart-icon-quan").html());
        var maSP = Number($(this).closest('tr').find('.maSP').html());
        console.log([price, quantity, maSP]);
        total -= price * quantity;
        var dsSanPham = [];
        var item = { "maSP": maSP };
        dsSanPham.push(item);
        xoaGioHangItem(dsSanPham);
        $(this).closest("tr").remove();
        total_html.html(numberWithCommas(total));
    })
    
})(jQuery);
function reload_js(src) {
    $('script[src="' + src + '"]').remove();
    $('<script>').attr('src', src).appendTo('head');
}

function updatecart() {
    if ($('.notlogin').length != 1) {
        var dsSanPham = [];
        $('.cart-table tbody tr').each(function () {
            var item = { "maSP": Number($(this).find('.maSP').html()), "soLuong": Number($(this).find('.qua-col input').val()) };
            dsSanPham.push(item);
        })
        $.ajax({
            type: 'post',
            url: '/cms/frontend/GioHang/UpdateCart.aspx',
            data: JSON.stringify(dsSanPham),
            contentType: "application/json;charset=utf-8",
            success: function (response) {
                var a = response;
                alert(response);
                getAllCart();
            },
            error: function (response) {
                var a = response;
                alert(response.responseText);
            }
        });
    } else {
        alert("chua dang nhap");
    }
    
}

function getAllCart() {
    $.ajax({
        type: 'post',
        url: '/cms/frontend/GioHang/GetAllCart.aspx',
        data: '',
        success: function (response) {
            var a = response;
            cartJsonToView(response);
        },
        error: function (response) {
            var a = response;
            alert(response);
        }
    }).done(function () {
        reload_js('/Asets/display/js/main.js');
    });
}
function numberWithCommas(x) {
    return x.toString().replace(/\B(?<!\.\d*)(?=(\d{3})+(?!\d))/g, ",");
}

function currencyToNumber(cur) {
    return Number(cur.replaceAll(",", "").replaceAll(".", "").replaceAll("$", ""));
}

function cartJsonToView(json) {
    var table = $('.select-items table');
    var total_html = $('.cart-icon-total');
    var total = 0;
    table.find("tbody tr").remove();
    json.forEach(element => {
        var html = "<tr><td class= 'si-pic' > <img src='"
        html += element.anhSP + "' alt='' /></td ><td class='si-text'><div class='product-selected'><p>$<span class='cart-icon-pr'>";
        html += numberWithCommas(element.gia) + "</span> x <span class='cart-icon-quan' >" + element.soLuong + "</span ></p >";
        html += "<h6>" + element.tenSP + "</h6></div> </td><td class='si-close'><i class='ti-close'  ></i ></td ><td class='maSP' style='display:none'>" + element.maSP+"</td></tr > ";
        table.append(html);
        total += Number(element.gia) * Number(element.soLuong);
    });
    var number_cart_icon = $('.cart-icon-number');
    number_cart_icon.html(json.length);
    total_html.html(numberWithCommas(total));
}
function xoaGioHangItem(json) {
    $.ajax({
        type: 'post',
        url: '/cms/frontend/GioHang/DeleteCart.aspx',
        data: JSON.stringify(json),
        contentType: "application/json;charset=utf-8",
        success: function (response) {
            var a = response;
            alert(response);
        },
        error: function (response) {
            var a = response;
            alert(response.responseText);
        }
    });
}