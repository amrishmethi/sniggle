/// <reference path="../angjs/angular.min.js" />

var app = angular.module('sniggleApp', ['angularUtils.directives.dirPagination']);
app.controller('masterController', function ($scope, $http) {



});

$(document).ready(function () {
    getCart();
    getWishList();
});

function addWishList(th) {
    var AttriID = $('#lblattIDquik').html();
    $.ajax({
        method: 'POST',
        url: '/FrontWeb.asmx/addToWishList',
        data: '{ProdID: "' + th + '", AttriID:"' + AttriID + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        if (response.d == "0") {
            tostpro("You must be logged in to manage your wishlist.", 'Error', 'error', 'mid-center', '3000');
        }
        else {
            if (response.d === "2") {
                tostpro("This product has already added in your wishlist.", 'Error', 'error', 'mid-center', '3000');
            }
            else {
                tostpro("The product was successfully added to your wishlist.", 'Success', 'success', 'mid-center', '3000');
            }
            getWishList();
        }
    }, function (error) {

    });
};

function addToCartOnDetail() {
    debugger
    var url = window.location.href;
    $('#SuccessModelID').html('');
    var AttriID = $('#lblattIDquik').html();
    var SKU = $('#skuquik').html();
    var Image1 = $('#lblImg').html();
    var ProductName = $('#productNamequik').html();
    var Qty = $('#Qty').val();
    var minQty = $('#minQty').html();
    var Price = $('#rpricequik').html();
    var DiscountPrice = $('#dispricequik').html();
    var Slug = $('#spCat').html();
    if (parseInt(Qty) < parseInt(minQty) || Qty == '' || Qty == null) {
        tostpro("Please enter above " + minQty + " minimum quantity", 'Error', 'error', 'mid-center', '2000');
        $('#Qty').val(minQty);
        return;
    }
    if (!$.isNumeric(Qty)) {
        tostpro("Please enter valid quantity", 'Error', 'error', 'mid-center', '2000');
        $('#Qty').val(minQty);
        return;
    }
    var imgProfilePhoto = '';
    var ImggProPhoto;
    var IsFluCustomize = $("#IsFluCustomize").val();
    if (IsFluCustomize == 'True') {
        var fileProfilePhoto = $("#fluCustomize").get(0);
        if (fileProfilePhoto != undefined) {
            var filesProP = fileProfilePhoto.files;
            ImggProPhoto = new FormData();
            for (var i = 0; i < filesProP.length; i++) {
                imgProfilePhoto = 'PP_' + filesProP[i].name;
                ImggProPhoto.append(filesProP[i].name, filesProP[i]);
            }
        }
    } 

    $.ajax({
        method: 'POST',
        url: '/FrontWeb.asmx/addToCart',
        data: '{ProdID: "' + Slug + '", AttriID:"' + AttriID + '",SKU:"' + SKU + '",Image1:"' + Image1 + '",ProductName:"' + ProductName + '",Qty:"' + Qty + '",Price:"' + Price + '",DiscountPrice:"' + DiscountPrice + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var sts = response.d;
        if (sts === "2") {
            tostpro("There are not enough products in stock.", 'Stock Not Available', 'info', 'mid-center', '2500');
            return;
        }
        tostpro("Product successfully added to your shopping cart.", 'Success', 'info', 'mid-center', '2500');
        $.ajax({
            url: "/UploadFile.ashx?ProdID=" + Slug + "&AttriID=" + AttriID + "",
            type: "POST",
            contentType: false,
            processData: false,
            data: ImggProPhoto,
            success: function (result) {
            },
            error: function (err) {
            }
        });
        getCart();
    }, function (error) {

    });
};

function BuyNow() {
    var url = window.location.href;
    $('#SuccessModelID').html('');
    var AttriID = $('#lblattIDquik').html();
    var SKU = $('#skuquik').html();
    var Image1 = $('#lblImg').html();
    var ProductName = $('#productNamequik').html();
    var Qty = $('#Qty').val();
    var minQty = $('#minQty').html();
    var Price = $('#rpricequik').html();
    var DiscountPrice = $('#dispricequik').html();
    var Slug = $('#spCat').html();
    if (parseInt(Qty) < parseInt(minQty) || Qty == '' || Qty == null) {
        tostpro("Please enter above " + minQty + " minimum quantity", 'Error', 'error', 'mid-center', '2000');
        $('#Qty').val(minQty);
        return;
    }
    if (!$.isNumeric(Qty)) {
        tostpro("Please enter valid quantity", 'Error', 'error', 'mid-center', '2000');
        $('#Qty').val(minQty);
        return;
    };
    var imgProfilePhoto = '';
    var IsFluCustomize = $("#IsFluCustomize").val();
    if (IsFluCustomize == 'True') {
        var fileProfilePhoto = $("#fluCustomize").get(0);
        var filesProP = fileProfilePhoto.files;
        var ImggProPhoto = new FormData();
        for (var i = 0; i < filesProP.length; i++) {
            imgProfilePhoto = 'PP_' + filesProP[i].name;
            ImggProPhoto.append(filesProP[i].name, filesProP[i]);
        };
    }
    
    $.ajax({
        method: 'POST',
        url: '/FrontWeb.asmx/addToCart',
        data: '{ProdID: "' + Slug + '", AttriID:"' + AttriID + '",SKU:"' + SKU + '",Image1:"' + Image1 + '",ProductName:"' + ProductName + '",Qty:"' + Qty + '",Price:"' + Price + '",DiscountPrice:"' + DiscountPrice + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var sts = response.d;
        if (sts === "2") {
            tostpro("There are not enough products in stock.", 'Stock Not Available', 'info', 'mid-center', '2500');
            return;
        }
        tostpro("Product successfully added to your shopping cart.", 'Success', 'info', 'mid-center', '2500');
        $.ajax({
            url: "/UploadFile.ashx?ProdID=" + Slug + "&AttriID=" + AttriID + "",
            type: "POST",
            contentType: false,
            processData: false,
            data: ImggProPhoto,
            success: function (result) {
            },
            error: function (err) {
            }
        });
        window.setTimeout(function () {
            window.location.href = "/ShoppingCart.aspx";
        }, 2500);
    }, function (error) {

    });
};

function getCart() {
    $.ajax({
        method: 'POST',
        url: '/FrontWeb.asmx/getCart',
        data: '{ }',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var sts = JSON.parse(response.d);
        var dd = sts[0].TotalCount;
        $('#TotalCount').html(sts[0].TotalCount);
        $('#TotalCountM').html(sts[0].TotalCount);
    }, function (error) {

    });
}

function getWishList() {
    $.ajax({
        method: 'POST',
        url: '/FrontWeb.asmx/getWishList',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var cart = response.d;
        $('#wishID').html(cart);
        $('#wishIDM').html(cart);
    }, function (error) {
    });
}

function validation(th) {
    var fil = "." + th;
    $(fil).addClass("error");
};

function NewsLetterFooter() {
    debugger;
    var Email = $('#txtNewsletterEmailFooter').val();
    if (!emailpattern.test(Email)) {
        tostpro("Please Enter Your Email", 'Error', 'error', 'mid-center', '2000');
        return;
    }
    $.ajax({
        method: 'POST',
        url: '../loginWS.asmx/NewsletterSubmit',
        data: '{Email: "' + Email + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        if (response.d == "Success") {
            tostpro("Thank you for your subscription", 'Success', 'success', 'mid-center', '2000');
            $('#txtNewsletterEmailFooter').val("");
        }
        else {
            $('#txtNewsletterEmailFooter').val("");
            tostpro(response.d, 'Success', 'success', 'mid-center', '2000');
        }
    }, function (error) {
    });
};
var emailpattern = new RegExp(/^[+a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/i);