var emailpattern = new RegExp(/^[+a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/i);
app = angular.module('MyEarth', ['angularUtils.directives.dirPagination']);
app.controller('MasterController', function ($scope, $http) {
    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getCart',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var cart = response.data;
        cart = cart.d;
        $scope.carts = JSON.parse(cart);
        $('#TotalCount').html($scope.carts[0].TotalCount);
        $('#TotalAmount').html("$" + parseFloat($scope.carts[0].TotalAmount).toFixed(2));
        $('#TotalCountMob').html($scope.carts[0].TotalCount);
    }, function (error) {

    });
    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getWishList',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var wish = response.data;
        wish = wish.d;
        $('#wishID').html(wish);
    }, function (error) {
    });
});

app.controller('RegistrationController', function ($scope, $http) {
    $http({
        method: 'POST',
        url: '../FrontFunction.asmx/GetCountryList',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var dd = response.data;
        dd = dd.d;
        $scope.CountryList = JSON.parse(dd);
    }, function (error) {
    });
    $scope.StateListfn = function (th) {
        var ddd = $scope.selectedItem;
        $http({
            method: 'POST',
            url: '../FrontFunction.asmx/GetStateList',
            data: '{CID: "' + ddd + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var dd = response.data;
            dd = dd.d;
            $scope.StateList = JSON.parse(dd);
        }, function (error) {
        });
    }
});

app.controller('HomeController', function ($scope, $http) {
    var ss = $("#drpCatID option:selected").text();
    var val = $("#drpCatID option:selected").val();
    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/GetSearchCat',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var dd = response.data;
        dd = dd.d;
        $scope.CatSearch = JSON.parse(dd);
    }, function () {
    });

    $scope.SearchListFilter = function (th) {
        var ddd = $scope.selectedItem;
        $http({
            method: 'POST',
            url: '/FrontFunction.asmx/GetSearchList',
            data: '{CID: "' + ddd + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var dd = response.data;
            dd = dd.d;
            $scope.CatSearchaaa = JSON.parse(dd);
        }, function (error) {

        });
    }

    $scope.srchItem = function () {
        var Srch = $('#txtSearchProduct').val();
        var ss = $('#hddDetailUrl').val();
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/getProductsSearch',
            data: '{Slug: "' + Srch + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var product = response.data;
            product = product.d;
            $scope.getProductsSearch = JSON.parse(product);
            $('#lblTotalSearchProd').html($scope.products.length);
            window.location.href = "/Search.aspx?" + Srch + "";
        }, function (error) {
        });
    }
});

app.controller('ProductDetailController', function ($scope, $http) {
    var path = window.location.href;
    var Slug = path;
    $scope.loading = true;
    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getDetail',
        data: '{Slug: "' + Slug + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var product = response.data;
        product = product.d;
        $scope.loading = false;
        $scope.products = JSON.parse(product);
    }, function (error) {
    });

    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getImage',
        data: '{Slug: "' + Slug + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var img = response.data;
        img = img.d;
        $scope.imgs = JSON.parse(img);
    }, function (error) {
    });

    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getVideo',
        data: '{Slug: "' + Slug + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var dd = response.data;
        dd = dd.d;
        $scope.videos = JSON.parse(dd);
    }, function (error) {
    });

    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/geItemFeatures',
        data: '{Slug: "' + Slug + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var fet = response.data;
        fet = fet.d;
        $scope.fets = JSON.parse(fet);
    }, function (error) {
    });

    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getItemAttributesRadio',
        data: '{Slug: "' + Slug + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var attradio = response.data;
        attradio = attradio.d;
        if (attradio == "") {
            $('#lblRadio').html("No");
        }
        $scope.attradios = JSON.parse(attradio);
    }, function (error) {
    });

    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getItemAttributesSelect',
        data: '{Slug: "' + Slug + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var attselect = response.data;
        attselect = attselect.d;
        $scope.attselects = JSON.parse(attselect);
    }, function (error) {
    });

    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getItemReviews',
        data: '{Slug: "' + Slug + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var rev = response.data;
        rev = rev.d;
        $scope.revs = JSON.parse(rev);
    }, function (error) {
    });

    $scope.getPrice = function () {
        var cartype = "";
        for (var i = 0; i < $scope.attselects.length; i++) {
            var aa = $scope.attselects[i].id_attribute_group;
            cartype += ($('#drp' + aa + '').val()) + ",";
            var selval = ($('#drp' + aa + '').val());
            $('#drp' + aa + '').val(selval);
        }
        if ($('#lblRadio').html() == "Yes") {
            var pp = $scope.attradios.length;
            for (var i = 0; i < $scope.attradios.length; i++) {
                var aa = $scope.attradios[i].id_attribute_group;
                var radioValue = $("input[name='rdo" + aa + "']:checked").val();
                if (radioValue) {
                    cartype += radioValue + ",";
                    $("#rdo" + aa + "").prop("checked", true);
                }
            }
        }
        var TypeID = cartype.slice(0, -1);
        var price = $('#rprice').html();
        var disprice = $('#disprice').html();
        var path = window.location.href;
        var Slug = path;
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/getProductPrice',
            data: '{Slug: "' + Slug + '", TypeID:"' + TypeID + '",price:"' + price + '",disprice:"' + disprice + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            debugger
            var price = response.data;
            price = price.d;
            var ffff = price.split('_');
            $('#sppricenew').html("" + price.split('_')[0]);
            $('#spprice').html("" + price.split('_')[0]);
            $('#spdisprice').html("" + price.split('_')[1]);
            $('#ContentPlaceHolder1_lblattID').html(price.split('_')[2]);
            $('#sku').html(price.split('_')[3]);
            var length = ffff.length;
            var exist = ffff[length - 1];
            if (exist === "NotExist") {
                $('#hddoutofstock').hide();
                $('#spanNotExist').show();
                $('.combinationPricehide').hide();
            }
            else {
                $('#hddoutofstock').show();
                $('#spanNotExist').hide();
                $('.combinationPricehide').show();
            }
        }, function (error) {

        });
    }

    $scope.addReview = function () {
        var Rating = $("input[name='criterion[1]']").val();
        Name = $('#custName').val();
        Comment = $('#review').val();
        Title = $('#title').val();
        if (Name == "") {
            $('#reqName').show();
            tostpro("Please Fill All Required Fields.", 'Error', 'error', 'top-right', '2000');
            return;
        }
        else
            $('#reqName').hide();
        var path = window.location.href;
        var Slug = path;
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/addProductReview',
            data: '{Slug: "' + Slug + '", Name:"' + Name + '",Rating:"' + Rating + '",Title:"' + Title + '",Comment:"' + Comment + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var price = response.data;
            price = price.d;
            $('#custName').val('');
            $('#review').val('');
            $('#title').val('');
            $('#reqMessage').show();
            tostpro("Review Send Successfully.", 'Message', 'success', 'mid-center', '2000');
            $('#myModalreview').modal('hide');
        }, function (error) {

        });
    }
    $scope.addToCart = function () {
        debugger
        var url = window.location.href;
        $('#SuccessModelID').html('');
        var AttriID = $('#ContentPlaceHolder1_lblattID').html();
        var SKU = $('#sku').html();
        var Image1 = $('#ContentPlaceHolder1_lblImg').html();
        var ProductName = $('#productName').html();
        var Qty = $('#Qty').val();
        var minQty = $('#minQty').html();
        var Price = $('#rprice').html();
        var DiscountPrice = $('#disprice').html();
        var path = window.location.href;
        var Slug = path; 
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
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/addToCart',
            data: '{ProdID: "' + Slug + '", AttriID:"' + AttriID + '",SKU:"' + SKU + '",Image1:"' + Image1 + '",ProductName:"' + ProductName + '",Qty:"' + Qty + '",Price:"' + Price + '",DiscountPrice:"' + DiscountPrice + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var sts = response.data;
            sts = sts.d;
            if (sts === "2") {
                tostpro("There are not enough products in stock.", 'Stock Not Available', 'info', 'mid-center', '2000');
            }
            $.ajax({
                method: 'POST',
                url: '../FrontWeb.asmx/BeindSuccessModal',
                data: '{prodID: "' + Slug + '", AttriID:"' + AttriID + '", url:"' + url + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                var cart = response.d;
                $('#SuccessModelID').html(cart);
                $('#myModal').modal('hide');
                $('#myModalSuccess').modal('show');

                $http({
                    method: 'POST',
                    url: '../FrontWeb.asmx/getCart',
                    data: '{}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json"
                }).then(function (response) {
                    var cart = response.data;
                    cart = cart.d;
                    $scope.carts = JSON.parse(cart);
                    $('#TotalCount').html($scope.carts[0].TotalCount);
                    $('#TotalAmount').html("$" + parseFloat($scope.carts[0].TotalAmount).toFixed(2));
                    $('#myModal').modal('hide');
                    $('#myModal222').modal('show');

                }, function (error) {

                });
                //For Success Model End  
            }, function (error) {

            });
        }, function (error) {
        });
    }
    $scope.addToWishList = function () {
        var AttriID = $('#ContentPlaceHolder1_lblattID').html();
        var path = window.location.href;
        var Slug = path;
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/addToWishList',
            data: '{ProdID: "' + Slug + '", AttriID:"' + AttriID + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            if (response.data.d == "0") {
                tostpro("You must be logged in to manage your wishlist.", 'Error', 'error', 'mid-center', '2000');
            }
            else {
                tostpro("The product was successfully added to your wishlist.", 'Success', 'success', 'mid-center', '2000');

                $http({
                    method: 'POST',
                    url: '/FrontWeb.asmx/getWishList',
                    data: '{}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json"
                }).then(function (response) {
                    var cart = response.data;
                    cart = cart.d;
                    $('#wishID').html(cart);
                }, function (error) {
                });
            }

        }, function (error) {
        });
    }
});

function addQtyPlus() {
    var IsStockAllow = $('#IsStockAllow').html();
    IsStockAllow = $('#IsStockAllow').val().trim();
    var stockQty = $('#stockQty').val().trim();
    var Qty = $('#Qty').val();
    if (IsStockAllow === 'Deny') {
        Qty = parseInt(Qty) + 1;
        if (parseInt(Qty) > parseInt(stockQty)) {
            tostpro("" + Qty + " quantity not available in stock.", 'Error', 'error', 'mid-center', '2000');
            Qty = parseInt(Qty) - 1;
            $('#Qty').val(Qty);
            return;
        }
        else {
            Qty = parseInt(Qty);
        }
    }
    else {
        Qty = parseInt(Qty) + 1;
    }
    $('#Qty').val(Qty);
}

function removeQty() {
    var Qty = $('#Qty').val();
    Qty = Qty - 1;
    var minQty = $('#minQty').html();
    if (parseInt(Qty) < parseInt(minQty)) {
        tostpro("Please enter above " + minQty + " minimum quantity", 'Error', 'error', 'mid-center', '2000');
        $('#Qty').val(minQty);
        return;
    }
    Qty = parseInt(Qty);
    $('#Qty').val(Qty);
}

function cartQtyChange() {
    var minQty = $('#minQty').html();
    var IsStockAllow = $('#IsStockAllow').html();
    IsStockAllow = $('#IsStockAllow').val().trim();
    var stockQty = $('#stockQty').val().trim();
    var Qty = $('#Qty').val();
    if (IsStockAllow === 'Deny') {
        Qty = parseInt(Qty);
        if (parseInt(Qty) > parseInt(stockQty)) {
            tostpro("" + Qty + " quantity not available in stock.", 'Error', 'error', 'mid-center', '2000');
            $('#Qty').val(minQty);
            return;
        }
    }
}

function getPrice(th) {
    var cartype = "";
    var selectData = $('#selectDataquik').html();
    var selectArray = selectData.split(',');
    for (var i = 0; i < selectArray.length; i++) {
        var aa = selectArray[i];
        cartype += ($('#drpquik' + aa + '').val()) + ",";
        var selval = ($('#drpquik' + aa + '').val());
        $('#drpquik' + aa + '').val(selval);
    }

    if ($('#lblRadio').html() == "Yes") {
        var rdoData = $('#rdoDataquik').html();
        var rdoArray = rdoData.split(',');
        for (var i = 0; i < rdoArray.length; i++) {
            var aa = rdoArray[i];
            var radioValue = $("input[id='rdoquik" + aa + "']:checked").val();  //add on 10/11/2020
            if (radioValue) {
                cartype += radioValue + ",";
            }
        }
    }
    var TypeID = cartype.slice(0, -1);
    var price = $('#rpricequik').html();
    var disprice = $('#dispricequik').html();
    var Slug = $('#spCat').html();
    $.ajax({
        method: 'POST',
        url: '/FrontWeb.asmx/getProductPrice',
        data: '{Slug: "' + Slug + '", TypeID:"' + TypeID + '",price:"' + price + '",disprice:"' + disprice + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var price = response.d;
        $('#sppricenewquik').html("" + price.split('_')[0]);
        $('#sppricequik').html("" + price.split('_')[0]);
        $('#spdispricequik').html("" + price.split('_')[1]);
        $('#lblattIDquik').html(price.split('_')[2]);
        $('#skuquik').html(price.split('_')[3]);
        $('#minQty').html(price.split('_')[4]);
        $('#Qty').val(price.split('_')[4]);
        $('#stockQty').val(price.split('_')[5]);
        if (price.split('_')[6] == 'OutofStock') {
            $('.EnqNotifyDiv').css('background', '#b22222')
            $('.EnqNotifyDiv').html("Notify me when restock");
            $('.outofstockdiv').show();
            $('.notoutofstockdiv').hide();
        }
        else {
            $('.EnqNotifyDiv').css('background', '#6cd1bb').html("Enquire About This Product");
            $('.outofstockdiv').hide();
            $('.notoutofstockdiv').show();
        }
        if (price.split('_')[3] == 'NotExist') {
            $('.EnqNotifyDiv').css('background', '#6cd1bb').html("Enquire About This Product");
            $('.outofstockdiv').show();
            $('.notoutofstockdiv').hide();
            $('.prshowornot').hide();
            $('.notExistMsg').css('background', '#6cd1bb').css('padding', '2px').css('color', 'white').show().html("This combination does not exist for this product. Please select another combination.");
        }
        else {
            $('.prshowornot').show();
            $('.notExistMsg').hide().html("");
        }
        var imgg = price.split('_')[7];
        var imgname = imgg.split('#');
        var imggid = imgname[0];
        $('#' + imggid).click();
        $(".popMySlides").css("display", "none");
        $('#' + imggid).css("display", "block");
        quickViewImgPopup(imggid);
    }, function (error) {
    });
};

function quickViewImgPopup(th) {
    let thumbnails = document.getElementsByClassName('thumbnail2');
    let activeImages = document.getElementsByClassName('active');
    //$('.modClass').removeClass('active');
    var id = '#m' + th;
    var jj = 0;
    $(".modClass ").each(function () {
        jj = jj + 1;
        var currentid = '#' + $(this).attr('id');
        if (id == currentid) {
            return false;
        }
    });
    var jj1 = jj * 10;
    var swidth = $(id).width() * jj;
    if (jj > 11) {
        document.getElementById('slider').scrollLeft = swidth + 90;
    }
    else {
        document.getElementById('slider').scrollLeft = swidth - 80;
    }

    //$(id).addClass("active");
    $('#featured').attr('src', $(id).prop('src'));
};


function slideLeftmod() {
    let buttonLeft = document.getElementById('slideLeft');
    document.getElementById('slider').scrollLeft -= 103
}

function slideRightmod() {
    let buttonRight = document.getElementById('slideRight');
    document.getElementById('slider').scrollLeft += 103
}

function addToCart() {
    var url = window.location.href;
    $('#SuccessModelID').html('');
    var AttriID = $('#lblattIDquik').html();
    var SKU = $('#skuquik').html();
    var Image1 = $('#lblImg').html();
    var ProductName = $('#productName').html();
    var Qty = $('#Qty').val();
    var minQty = $('#minQty').html();
    var Price = $('#rprice').html();
    var DiscountPrice = $('#disprice').html();
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

        $.ajax({
            method: 'POST',
            url: '../FrontWeb.asmx/BeindSuccessModal',
            data: '{prodID: "' + Slug + '", AttriID:"' + AttriID + '", url:"' + url + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var cart = response.d;
            $('#SuccessModelID').html(cart);
            $('#myModal').modal('hide');
            $('#myModalSuccess').modal('show');

            $.ajax({
                method: 'POST',
                url: '../FrontWeb.asmx/getCart',
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                var cart = response.d;
            }, function (error) {

            });
        }, function (error) {

        });

    }, function (error) {

    });
}

app.controller('ProductWebController', function ($scope, $http) {
    var path = window.location.href;
    var Slug = path;
    $scope.loading = true;
    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getProducts',
        data: '{Slug: "' + Slug + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var product = response.data;
        product = product.d;
        $scope.products = JSON.parse(product);
        $('#lblItemCount').html($scope.products.length);
        $scope.products[0].coun = 40;
        $('#drpShow').val("40");
        $('#drpFilter').val("0"); 
        var neloc = window.location.href.split('?')[1];
        if (neloc !== undefined) {
            neloc = neloc.split('=')[1]
            if (neloc < 10) {
                if (neloc == '' || neloc === undefined || neloc == '0') {
                    $scope.currentPage = 1;
                }
                else {
                    $scope.currentPage = neloc;
                }
            }
            else {
                $scope.currentPage = 1;
            }
        }
        else {
            neloc = window.location.href.split('#')[1];
            if (neloc == '' || neloc === undefined || neloc == '0') {
                $scope.currentPage = 1;
            }
            else {
                neloc = neloc.split('-')[1]
                if (neloc == '' || neloc === undefined || neloc == '0') {
                    $scope.currentPage = 1;
                }
                else {
                    $scope.currentPage = neloc;
                }
            }
        }

        $scope.loading = false;
    }, function (error) {

    }).finally(function () {
        $scope.loading = false;
    });

    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getAttributes',
        data: '{Slug: "' + Slug + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var filt = response.data;
        filt = filt.d;
        $scope.filts = JSON.parse(filt);
    }, function (error) {
    });

    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getSubCategories',
        data: '{Slug: "' + Slug + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var filt = response.data;
        filt = filt.d;
        $scope.filtsSub = JSON.parse(filt);
    }, function (error) {
    });

    $scope.addProdDetail = function (th) {
        $('#modelID').html('');
        $scope.loading = true;
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/getModelDetail',
            data: '{prodID: "' + th + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var cart = response.data;
            cart = cart.d;
            $('#modelID').html(cart);
            $http({
                method: 'POST',
                url: '/FrontWeb.asmx/custProdEnquiryModel',
                data: '{prodID: "' + th + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                var EnqProdModel = response.data;
                EnqProdModel = EnqProdModel.d;
                var ddd = EnqProdModel.split('^')[1];
                $('#bindProdEnquiryModel').html(EnqProdModel.split('^')[0]);
                $('#bindProdReferAFriend').html(ddd);
                $scope.loading = false;
            }, function (error) {
            });

        }, function (error) {
        });
    }

    $scope.getItems = function (th) {
        $scope.loading = true;
        var subType = "";
        for (var i = 0; i < $scope.filtsSub.length; i++) {
            var aa = $scope.filtsSub[i].id_category;
            if ($('#sub' + aa + '').is(":checked"))
                subType += aa + ",";
        }
        subType = subType.slice(0, -1);

        var sh = $('#drpShow').val();
        var ob = $('#drpFilter').val();
        var cartype = "";
        for (var i = 0; i < $scope.filts.length; i++) {
            for (var j = 0; j < $scope.filts[i].Attri.length; j++) {
                var aa = $scope.filts[i].Attri[j].id;
                if ($('#att' + aa + '').is(":checked"))
                    cartype += aa + ",";
            }
        }
        var TypeID = cartype.slice(0, -1);
        var path = window.location.href;
        var Slug = path;
        var cartypeProduct = "";
        for (var i = 0; i < $scope.filts.length; i++) {
            for (var j = 0; j < $scope.filts[i].Attri.length; j++) {
                var kk = $scope.filts[i].Attri[j].id;
                var ll = $scope.filts[i].id_attribute_group;
                if ($('#att' + kk + '').is(":checked")) {
                    cartypeProduct += kk + "-" + ll + ",";
                }
            }
        }
        var TypeID = cartypeProduct.slice(0, -1);
        $scope.loading = true;
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/getFilterProducts',
            data: '{Slug: "' + Slug + '", TypeID:"' + TypeID + '",OrderBy:"' + ob + '", subType:"' + subType + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var product = response.data;
            product = product.d;
            $scope.loading = false;
            $scope.products = JSON.parse(product);
            $('#lblItemCount').html($scope.products.length);
            if (sh == "0") {
                $scope.products[0].coun = $scope.products.length;
            }
            else {
                $scope.products[0].coun = sh;
            }
        }, function (error) {
            $scope.loading = false;
        });
    }

    $scope.getOrderBy = function () {
        $scope.loading = true;
        var sh = $('#drpShow').val();
        var ob = $('#drpFilter').val();
        var maintype = "";
        var cartype = "";
        for (var i = 0; i < $scope.filts.length; i++) {
            for (var j = 0; j < $scope.filts[i].Attri.length; j++) {
                var aa = $scope.filts[i].Attri[j].id;
                if ($('#att' + aa + '').is(":checked"))
                    cartype += aa + ",";
            }
        }
        var TypeID = cartype.slice(0, -1);
        var path = window.location.href;
        var Slug = path;
        $scope.loading = true;
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/getFilterProducts',
            data: '{Slug: "' + Slug + '", TypeID:"' + TypeID + '",OrderBy:"' + ob + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var product = response.data;
            product = product.d;
            $scope.products = JSON.parse(product);
            $('#lblItemCount').html($scope.products.length);
            if (sh == "0") {
                $scope.products[0].coun = $scope.products.length;
            }
            else {
                $scope.products[0].coun = sh;
            }
            $scope.loading = false;
        }, function (error) {
        });
    }
    $scope.loading = true;
    $scope.getPageShow = function () {
        var sh = $('#drpShow').val();
        if (sh == "0") {
            $scope.products[0].coun = $scope.products.length;
        }
        else {
            $scope.products[0].coun = sh;
        }
    }
    $scope.getFilter = function (th) {
        var prodid = th;
        for (var i = 0; i < $scope.filts.length; i++) {
            var bb = $scope.filts[i].id_attribute_group;
            if (bb == prodid) {
                var kk = $('#txt' + th + '').val().toLowerCase();
                var pp = uppercase(kk);
                for (var j = 0; j < $scope.filts[i].Attri.length; j++) {
                    var aa = $scope.filts[i].Attri[j].Name;
                    var liid = $scope.filts[i].Attri[j].id;
                    if (aa.includes(kk) || aa.includes(pp)) {
                        $('#li' + liid + '').show();
                    }
                    else {
                        $('#li' + liid + '').hide();
                    }
                }
            }
        }
    }

    $scope.reloadpage = function () {
        $scope.loading = true;
        document.location.reload();
    }
});

app.controller('ProductSearchController', function ($scope, $http) {
    $scope.loading = true;
    var path = window.location.href;
    var Srch = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getProductsSearch',
        data: '{Slug: "' + Srch + '", OBY: "Default"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        debugger
        var product = response.data;
        product = product.d;
        $scope.loading = false;
        $scope.productsSearch = JSON.parse(product);
        var kw = Srch.toString().split(',');
        var kword = kw[1].split('=');
        $scope.keyword = kword[1].replace(/[+]/gi, ' ');
        $('#lblItemCount').html($scope.productsSearch.length);
        $scope.productsSearch[0].coun = 40;
        $('#drpShow').val("40");
        $('#drpFilter').val("0");
    }, function (error) {

    }).finally(function () {
        $scope.loading = false;
    });

    $scope.getSearchProdOrderBy = function () {
        $scope.loading = true;
        var ob = $('#drpFilter').val();
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/getProductsSearch',
            data: '{Slug: "' + Srch + '",OBY: "' + ob + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var product = response.data;
            product = product.d;
            $scope.loading = false;
            $scope.productsSearch = JSON.parse(product);
            $('#lblItemCount').html($scope.productsSearch.length);
            $('#drpShow').val("40");
            $('#drpFilter').val(ob);
        }, function (error) {

        }).finally(function () {
            $scope.loading = false;
        });
    };

    $scope.getPageShow = function () {
        var sh = $('#drpShow').val();
        if (sh == "0") {
            $scope.productsSearch[0].coun = $scope.productsSearch.length;
        }
        else {
            $scope.productsSearch[0].coun = sh;
        }
    };

    $scope.addProdDetail = function (th) {
        $('#modelID').html('');
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/getModelDetail',
            data: '{prodID: "' + th + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var cart = response.data;
            cart = cart.d;
            $('#modelID').html(cart);
            $http({
                method: 'POST',
                url: '/FrontWeb.asmx/custProdEnquiryModel',
                data: '{prodID: "' + th + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                var EnqProdModel = response.data;
                EnqProdModel = EnqProdModel.d;
                $('#bindProdEnquiryModel').html(EnqProdModel);
            }, function (error) {
            });
        }, function (error) {
        });
    }

    $scope.getItems = function (th) {
        $scope.loading = true;
        var sh = $('#drpShow').val();
        var ob = $('#drpFilter').val();
        var cartype = "";
        for (var i = 0; i < $scope.filts.length; i++) {
            for (var j = 0; j < $scope.filts[i].Attri.length; j++) {
                var aa = $scope.filts[i].Attri[j].id;
                if ($('#att' + aa + '').is(":checked"))
                    cartype += aa + ",";
            }
        }
        var TypeID = cartype.slice(0, -1);
        var path = window.location.href;
        var Slug = path;
        var cartypeProduct = "";
        for (var i = 0; i < $scope.filts.length; i++) {
            for (var j = 0; j < $scope.filts[i].Attri.length; j++) {
                var kk = $scope.filts[i].Attri[j].id;
                var ll = $scope.filts[i].id_attribute_group;
                if ($('#att' + kk + '').is(":checked")) {
                    cartypeProduct += kk + "-" + ll + ",";
                }
            }
        }
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/getFilterProducts',
            data: '{Slug: "' + Srch + '", TypeID:"' + TypeID + '",OrderBy:"' + ob + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var product = response.data;
            product = product.d;
            $scope.loading = false;
            $scope.products = JSON.parse(product);
            $('#lblItemCount').html($scope.products.length);
            if (sh == "0") {
                $scope.products[0].coun = $scope.products.length;
            }
            else {
                $scope.products[0].coun = sh;
            }
        }, function (error) {

        });
    }
});

function addProdDetail(th) {
    $('#modelID').html('');
    $.ajax({
        method: 'POST',
        url: '/FrontWeb.asmx/getModelDetail',
        data: '{prodID: "' + th + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var cart = response.d;
        $('#modelID').html(cart);

        $.ajax({
            method: 'POST',
            url: '/FrontWeb.asmx/custProdEnquiryModel',
            data: '{prodID: "' + th + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var EnqProdModel = response.d;
            //$('#bindProdEnquiryModel').html(EnqProdModel); 
            var ddd = EnqProdModel.split('^')[1];
            $('#bindProdEnquiryModel').html(EnqProdModel.split('^')[0]);
            $('#bindProdReferAFriend').html(ddd);
        }, function (error) {

        });

    }, function (error) {

    });
}

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
            $.ajax({
                method: 'POST',
                url: '/FrontWeb.asmx/getWishList',
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                var cart = response.d;
                $('#wishID').html(cart);
            }, function (error) {
            });
        }
    }, function (error) {

    });
}
function uppercase(str) {
    var array1 = str.split(' ');
    var newarray1 = [];
    for (var x = 0; x < array1.length; x++) {
        newarray1.push(array1[x].charAt(0).toUpperCase() + array1[x].slice(1));
    }
    return newarray1.join(' ');
}

app.controller('shoppingCartController', function ($scope, $http) {
    $scope.loading = true;
    var path = window.location.href;
    var Slug = path;

    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/chkLogin',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        $scope.loading = false;
        var userid = response.data;
        userid = userid.d;
        if (userid == "0") {
            $('#ancAddress').removeAttr("href");
        }
    }, function (error) {
    });

    if (Slug.includes("step-1")) {
        $('#tabShopping').removeClass("tab-pane show active");
        $('#tabShopping').addClass("tab-pane show");
        $('#tabSignIn').removeClass("tab-pane fade");
        $('#tabSignIn').addClass("tab-pane show active");
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/chkLogin',
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            $scope.loading = false;
            var cart = response.data;
            cart = cart.d;
            if (cart != "0") {
                window.location.href = "/ShoppingCart.aspx?step-2";
            }
            else {

            }
        }, function (error) {
        });
    }
    else if (Slug.includes("step-2")) {
        $('#ancSignIn').removeClass("nav-link");
        $('#ancSignIn').addClass("nav-link active");
        $('#tabShopping').removeClass("tab-pane show active");
        $('#tabShopping').addClass("tab-pane show");
        $('#tabAddress').removeClass("tab-pane fade");
        $('#tabAddress').addClass("tab-pane show active");
    }
    else if (Slug.includes("step-3")) {
        $('#ancSignIn').removeClass("nav-link");
        $('#ancSignIn').addClass("nav-link active");

        $('#ancAddress').removeClass("nav-link");
        $('#ancAddress').addClass("nav-link active");

        $('#tabShopping').removeClass("tab-pane show active");
        $('#tabShopping').addClass("tab-pane show");

        $('#tabPayment').removeClass("tab-pane fade");
        $('#tabPayment').addClass("tab-pane show active");
    }
    else if (Slug.includes("payment")) {
        $('#ancSignIn').removeClass("nav-link");
        $('#ancSignIn').addClass("nav-link active");

        $('#ancAddress').removeClass("nav-link");
        $('#ancAddress').addClass("nav-link active");

        $('#tabShopping').removeClass("tab-pane show active");
        $('#tabShopping').addClass("tab-pane show");

        $('#tabPayment').removeClass("tab-pane show active");
        $('#tabPayment').addClass("tab-pane show");

        $('#tabBankWire').removeClass("tab-pane fade");
        $('#tabBankWire').addClass("tab-pane show active");
    }
    else {
        $scope.loading = false;
    }
    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getCart',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var cart = response.data;
        cart = cart.d;
        $scope.carts = JSON.parse(cart);
        $('#TotalCount').html($scope.carts[0].TotalCount);
        $('#TotalAmount').html("$" + parseFloat($scope.carts[0].TotalAmount).toFixed(2));
        $scope.loading = false;
    }, function (error) {
    });

    $scope.getAddress = function () {
        var shippingAddId = $('#ContentPlaceHolder1_drpShippingAddress').val();
        var billingAddId = $('#ContentPlaceHolder1_drpBillingAddress').val();
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/addAddressCart',
            data: '{shippingAddId: "' + shippingAddId + '",billingAddId: "' + billingAddId + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            window.location.href = "/ShoppingCart.aspx?step-3";
            $scope.loading = false;
        }, function (error) {
        });
    }

    $scope.delCart = function (th) {
        $scope.loading = true;
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/removeCart',
            data: '{AttriID: "' + th + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            $http({
                method: 'POST',
                url: '../FrontWeb.asmx/getCart',
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                $scope.loading = false;
                var cart = response.data;
                cart = cart.d;
                $scope.carts = JSON.parse(cart);
                $('#TotalCount').html($scope.carts[0].TotalCount);
                $('#TotalAmount').html("$" + parseFloat($scope.carts[0].TotalAmount).toFixed(2));

            }, function (error) {
                $scope.loading = false;
            });
        }, function (error) {
            $scope.loading = false;
        });
    }

    $scope.addQty = function (th, th1, th2) {
        debugger
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/getStockQtyAttribute',
            data: '{ProdId: "' + th1 + '", AttId:"' + th + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var cart = response.data;
            cart = cart.d;
            cart = $.parseJSON(cart);
            var IsStockAllow = cart[0].IsStockAllow.trim();
            var stockQty = cart[0].StockQty.trim();
            var Qty = th2;
            if (IsStockAllow === 'Deny') {
                Qty = parseInt(Qty) + 1;
                if (parseInt(Qty) > parseInt(stockQty)) {
                    tostpro("" + Qty + " quantity not available in stock.", 'Error', 'error', 'mid-center', '2000');
                    Qty = parseInt(Qty) - 1;
                    return;
                }
            }
            $http({
                method: 'POST',
                url: '/FrontWeb.asmx/addQtyToCart',
                data: '{AttriID: "' + th + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                $http({
                    method: 'POST',
                    url: '../FrontWeb.asmx/getCart',
                    data: '{}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json"
                }).then(function (response) {
                    var cart = response.data;
                    cart = cart.d;
                    $scope.carts = JSON.parse(cart);
                    $('#TotalCount').html($scope.carts[0].TotalCount);
                    $('#TotalAmount').html("$" + parseFloat($scope.carts[0].TotalAmount).toFixed(2));
                }, function (error) {
                });
            }, function (error) {
            });
        }, function (error) {
        });
    }
    $scope.cartQtyChangenew = function (th, th1, th2, minqty) {
        if (th2 !== "" && th2 !== null && th2 !== "undefined" && th2 !== "0") {
            if ((parseInt(th2)) < parseInt(minqty)) {
                tostpro("Please enter above " + minqty + " minimum quantity", 'Error', 'error', 'mid-center', '2000');
                setTimeout(function () {
                    document.location.reload()
                }, 2500);
                return;
            }
            $http({
                method: 'POST',
                url: '/FrontWeb.asmx/getStockQty',
                data: '{ProdId: "' + th1 + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                var cart = response.data;
                cart = cart.d;
                cart = $.parseJSON(cart);
                var IsStockAllow = cart[0].IsStockAllow.trim();
                var stockQty = cart[0].StockQty.trim();
                var Qty = th2;
                if (IsStockAllow === 'Deny') {
                    Qty = parseInt(Qty);
                    if (parseInt(Qty) > parseInt(stockQty)) {
                        tostpro("" + Qty + " quantity not available in stock.", 'Error', 'error', 'mid-center', '2000');

                        Qty = parseInt(stockQty);
                        setTimeout(function () {
                            document.location.reload()
                        }, 2500);
                        return;
                    }
                    else {
                        $http({
                            method: 'POST',
                            url: '/FrontWeb.asmx/addQtyToCartonChange',
                            data: '{AttriID: "' + th + '", qty: "' + th2 + '"}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json"
                        }).then(function (response) {
                            $http({
                                method: 'POST',
                                url: '../FrontWeb.asmx/getCart',
                                data: '{}',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json"
                            }).then(function (response) {
                                var cart = response.data;
                                cart = cart.d;
                                $scope.carts = JSON.parse(cart);
                                $('#TotalCount').html($scope.carts[0].TotalCount);
                                $('#TotalAmount').html("$" + parseFloat($scope.carts[0].TotalAmount).toFixed(2));
                            }, function (error) {
                            });
                        }, function (error) {
                        });
                    }
                }
                else {
                    $http({
                        method: 'POST',
                        url: '/FrontWeb.asmx/addQtyToCartonChange',
                        data: '{AttriID: "' + th + '", qty: "' + th2 + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json"
                    }).then(function (response) {
                        $http({
                            method: 'POST',
                            url: '../FrontWeb.asmx/getCart',
                            data: '{}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json"
                        }).then(function (response) {
                            var cart = response.data;
                            cart = cart.d;
                            $scope.carts = JSON.parse(cart);
                            $('#TotalCount').html($scope.carts[0].TotalCount);
                            $('#TotalAmount').html("$" + parseFloat($scope.carts[0].TotalAmount).toFixed(2));
                        }, function (error) {
                        });
                    }, function (error) {
                    });
                }
            }, function (error) {
            });
        }
    }

    $scope.removeQty = function (th, th1, th2) {
        if ((parseInt(th2) - 1) < parseInt(th1)) {
            tostpro("Please enter above " + th1 + " minimum quantity", 'Error', 'error', 'mid-center', '2000');
            return;
        }
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/removeQtyToCart',
            data: '{AttriID: "' + th + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            $http({
                method: 'POST',
                url: '/FrontWeb.asmx/getCart',
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                var cart = response.data;
                cart = cart.d;
                $scope.carts = JSON.parse(cart);
                $('#TotalCount').html($scope.carts[0].TotalCount);
                $('#TotalAmount').html("$" + parseFloat($scope.carts[0].TotalAmount).toFixed(2));
            }, function (error) {
            });
        }, function (error) {
        });
    }

    $http({
        method: 'POST',
        url: '/CustomerService.asmx/GetAddress',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var address = response.data;
        address = address.d;
        $scope.addresss = JSON.parse(address);
        var addid = $scope.addresss[0].id_address;
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/getShippingAddress',
            data: '{addId: "' + addid + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var shipaddress = response.data;
            shipaddress = shipaddress.d;
            $scope.ShipAddressDetail = JSON.parse(shipaddress);
        }, function (error) {
        });

        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/getBillingAddress',
            data: '{addId: "' + addid + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var billaddress = response.data;
            billaddress = billaddress.d;
            $scope.BillAddressDetail = JSON.parse(billaddress);
        }, function (error) {
        });
    }, function (error) {
    });

    $scope.getShippingAddress = function (th) {
        addid = $('#ContentPlaceHolder1_drpShippingAddress').val();
        $http({
            method: 'POST',
            url: '/CustomerService.asmx/GetAddress',
            data: '{addId: "' + addid + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var shipaddress = response.data;
            shipaddress = shipaddress.d;
            $scope.ShipAddressDetail = JSON.parse(shipaddress);
        }, function (error) {
        });
    }

    $scope.getBillingAddress = function (th) {
        addid = $('#drpBillingAddress').val();
        $http({
            method: 'POST',
            url: '/CustomerService.asmx/GetAddress',
            data: '{addId: "' + addid + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var billaddress = response.data;
            billaddress = billaddress.d;
            $scope.BillAddressDetail = JSON.parse(billaddress);
        }, function (error) {
        });
    }

    $scope.getVoucher = function (th) {
        var code = $('#' + th).val();
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/GetVoucher',
            data: '{code: "' + code + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var messase = response.data;
            messase = messase.d;
            $http({
                method: 'POST',
                url: '/FrontWeb.asmx/getCart',
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                var cart = response.data;
                cart = cart.d;
                $scope.carts = JSON.parse(cart);
                $('#TotalCount').html($scope.carts[0].TotalCount);
                $('#TotalAmount').html("$" + parseFloat($scope.carts[0].TotalAmount).toFixed(2));
            }, function (error) {
            });
            tostpro(messase, 'Message', 'error', 'mid-center', '4000');
        }, function (error) {
        });
    }

    $scope.removeVoucher = function () {
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/removeVoucherDtl',
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var messase = response.data;
            messase = messase.d;
            $http({
                method: 'POST',
                url: '/FrontWeb.asmx/getCart',
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                var cart = response.data;
                cart = cart.d;
                $scope.carts = JSON.parse(cart);
                $('#TotalCount').html($scope.carts[0].TotalCount);
                $('#TotalAmount').html("$" + parseFloat($scope.carts[0].TotalAmount).toFixed(2));
            }, function (error) {
            });
            alert(messase);
        }, function (error) {
        });
    }

    $scope.paymentPayPal = function () {
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/paymentPayPal',
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var paypalurl = response.data;
            paypalurl = paypalurl.d;
            window.location.href = paypalurl;
        }, function (error) {
        });
    }

    $scope.addQtyPlusCart = function (th) {
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/getStockQty',
            data: '{ProdId: "' + th + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var cart = response.data;
            cart = cart.d;
            cart = $.parseJSON(cart);
            var IsStockAllow = cart[0].IsStockAllow.trim();
            var stockQty = cart[0].StockQty.trim();
            var Qty = $('#Qty').val();
        }, function (error) {
        });
    };
});


function getShippingAddress() {
    var addId = $('#ContentPlaceHolder1_drpShippingAddress').val();
    $.ajax({
        method: 'POST',
        url: '/FrontWeb.asmx/getShippingAddressFilter',
        data: '{addId: "' + addId + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var shipaddress = response.d;
        $('#spShipping').html(shipaddress);
    }, function (error) {
    });

    if ($('#chk').is(":checked")) {
        $('#ContentPlaceHolder1_drpBillingAddress').hide();
        $('#ancBilling').hide();
        var addId = $('#ContentPlaceHolder1_drpShippingAddress').val();
        $('#ContentPlaceHolder1_drpBillingAddress').val($('#ContentPlaceHolder1_drpShippingAddress').val());
        $.ajax({
            method: 'POST',
            url: '/FrontWeb.asmx/getBillingAddressFilter',
            data: '{addId: "' + addId + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var billaddress = response.d;
            $('#spBilling').html(billaddress);
        }, function (error) {
        });
    }
}

function getBillingAddress() {
    var addId = $('#ContentPlaceHolder1_drpBillingAddress').val();
    $.ajax({
        method: 'POST',
        url: '/FrontWeb.asmx/getBillingAddressFilter',
        data: '{addId: "' + addId + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var billaddress = response.d;
        $('#spBilling').html(billaddress);
    }, function (error) {
    });
}

function getCommonAddress() {
    if ($('#chk').is(":checked")) {
        $('#ContentPlaceHolder1_drpBillingAddress').hide();
        $('#ancBilling').hide();
        var addId = $('#ContentPlaceHolder1_drpShippingAddress').val();
        $('#ContentPlaceHolder1_drpBillingAddress').val($('#ContentPlaceHolder1_drpShippingAddress').val());
        $.ajax({
            method: 'POST',
            url: '/FrontWeb.asmx/getBillingAddressFilter',
            data: '{addId: "' + addId + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var billaddress = response.d;
            $('#spBilling').html(billaddress);
        }, function (error) {
        });
    }
    else {
        if ($('#ContentPlaceHolder1_lblAddressQty').html == "1") {
            $('#ContentPlaceHolder1_drpBillingAddress').hide();
            $('#ancBilling').show();
        }
        else {
            $('#ContentPlaceHolder1_drpBillingAddress').show();
            $('#ancBilling').hide();
        }
    }
}


app.controller('AddAddressController', function ($scope, $http) {
    $http({
        method: 'POST',
        url: '/FrontFunction.asmx/GetCountryList',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var dd = response.data;
        dd = dd.d;
        $scope.CountryList = JSON.parse(dd);
    }, function (error) {

    });
    var addid = "0";
    var path = window.location.href;
    var Slug = path;
    if (Slug.includes("addid")) {
        addid = Slug.split('?')[1].split('=')[1];
        if (addid !== "0") {
            $http({
                method: 'POST',
                url: '/CustomerService.asmx/GetAddress',
                data: '{addId: "' + addid + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                var address = response.data;
                address = address.d;
                $scope.AddressDetail = JSON.parse(address);
            }, function (error) {
            });
        }
    }
    if (Slug.includes("id")) {
        addid = Slug.split('?')[1].split('=')[1];
        if (addid !== "0") {
            $http({
                method: 'POST',
                url: '/CustomerService.asmx/GetAddressDetail',
                data: '{addId: "' + addid + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                var address = response.data;
                address = address.d;
                $scope.AddressDetail = JSON.parse(address);
            }, function (error) {
            });
        }
    }
    $scope.addAddress = function () {
        var cartRedirect = 0;
        var path = window.location.href;
        var Slug = path;
        var addid = "0";
        if (Slug.includes("addid")) {
            addid = Slug.split('?')[1].split('=')[1];
            cartRedirect = 1;
        }
        if (Slug.includes("id")) {
            addid = Slug.split('?')[1].split('=')[1];
            cartRedirect = 0;
        }
        var AliasExist = true;
        var FNameA = $('#txtFirstNameA').val();
        var LNameA = $('#txtLastNameA').val();
        var CompA = $('#txtCompanyA').val();
        var AddA = $('#txtAddressA').val();
        var CounNameA = $("#ContentPlaceHolder1_drpCountry option:selected").text();
        var CounValA = $("#ContentPlaceHolder1_drpCountry option:selected").val();
        var StateNameA = $('#ContentPlaceHolder1_drpState option:selected').text();
        var StateValA = $('#ContentPlaceHolder1_drpState option:selected').val();
        var CityA = $("#txtCityA").val();
        var PINA = $("#txtPostalCodeA").val();
        var StateMan = $('#ContentPlaceHolder1_lblStateMan').text();
        var AddInfo = $('#txtAdditionalInfo').val();
        var HomePhone = $('#txtHomePhone').val();
        var MobPhone = $('#txtMobilePhone').val();
        var alias = $('#txtalias').val();
        if (StateMan === 'Yes') {
            if (FNameA === "" || AddA === "" || (CounValA === "" || CounValA === "Select") || (StateValA === "" || StateValA === "Select")
                || CityA === "" || PINA === "" || (HomePhone === "" && MobPhone === "")) {
                tostpro("Please Fill All Required Fields.", 'Error', 'error', 'mid-center', '2000');
                if (FNameA === "") {
                    validation('fieldReq1');
                }
                if (AddA === "") {
                    validation('fieldReq2');
                }
                if (CounValA === "" || CounValA === "Select") {
                    validation('fieldReq3');
                }
                if (StateValA === "" || StateValA === "Select" || StateValA === "undefined") {
                    validation('fieldReq4');
                }
                if (CityA === "") {
                    validation('fieldReq5');
                }
                if (PINA === "") {
                    validation('fieldReq6');
                }
                if (alias === "") {
                    validation('fieldReq7');
                }
                return;
            }
        }
        else {
            StateValA = "0";
            if (FNameA === "" || AddA === "" || CounValA === "" ||
                StateValA === "" || CityA === "" || PINA === "" || (HomePhone === "" && MobPhone === "")) {
                tostpro("Please Fill All Required Fields.", 'Error', 'error', 'top-right', '2000');
                if (FNameA === "") {
                    validation('fieldReq1');
                }
                if (AddA === "") {
                    validation('fieldReq2');
                }
                if (CounValA === "" || CounValA === "Select") {
                    validation('fieldReq3');
                }
                if (StateValA === "" || StateValA === "Select" || StateValA === "undefined") {
                    validation('fieldReq4');
                }
                if (CityA === "") {
                    validation('fieldReq5');
                }
                if (PINA === "") {
                    validation('fieldReq6');
                }
                if (alias === "") {
                    validation('fieldReq7');
                }
                return;
            }
        }
        if (alias !== "") {
            $http({
                method: 'POST',
                url: '/CustomerService.asmx/GetAddressAlias',
                data: '{addid: "' + addid + '",alias: "' + alias + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                var address = response.data;
                address = address.d;
                if (address === "Exist") {
                    tostpro("This address alias is already exists please change the alias name.", 'Error', 'error', 'top-right', '4000');
                    AliasExist = true;
                    return true;
                }
                else {
                    $.ajax({
                        method: 'POST',
                        url: '/CustomerService.asmx/CustomerAddress',
                        data: '{addid: "' + addid + '",FNameA:"' + FNameA + '",LNameA:"' + LNameA + '",CompA: "' + CompA + '",AddA:"' + AddA + '",CounNameA:"' + CounNameA + '",CounValA: "' + CounValA + '",StateNameA:"' + StateNameA + '",StateValA:"' + StateValA + '",CityA:"' + CityA + '",PINA:"' + PINA + '",AddInfo:"' + AddInfo + '",HomePhone:"' + HomePhone + '",MobPhone:"' + MobPhone + '",alias:"' + alias + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json"
                    }).then(function (response) {
                        if (response.d != "Fail") {
                            if (Slug.includes("addid")) {
                                if (addid === "0") {
                                    alert("address updated successfully");
                                    window.location.href = "ShoppingCart.aspx?step-2";
                                } else {
                                    alert("address updated successfully");
                                    window.location.href = "ShoppingCart.aspx?step-2";
                                }
                            }
                            else {
                                window.location.href = "addresses.aspx";
                                alert("address updated successfully");
                            }
                        }
                        else {
                            tostpro("Authentication failed.", 'Error', 'error', 'top-right', '2000');
                        }
                    }, function (error) {
                    });
                }
            }, function (error) {
            });
        }
        else {
            if (alias === "") {
                validation('fieldReq7');
                tostpro("Please Fill Assign an address alias for future reference.", 'Error', 'error', 'top-right', '2000');
            }
        }
    }
});


app.controller('BlogController', function ($scope, $http) {
    var path = window.location.href;
    var pp = path.split('/');
    var BlogId = pp[4];
    $http({
        method: 'POST',
        url: '/FrontFunction.asmx/getBlogDetail',
        data: '{BlogId : "' + BlogId + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var Blog = response.data;
        Blog = Blog.d;
        var dddd = JSON.parse(Blog);
        var tab1 = dddd.Table;
        var tab2 = dddd.Table1;
        $scope.BlogList = tab2;
        $scope.BlogDetail = tab1;
        $('#divContent').html($scope.BlogDetail[0].content);
    }, function (error) {
    });

    $http({
        method: 'POST',
        url: '/FrontFunction.asmx/GetBlogCommentFront',
        data: '{BlogId : "' + BlogId + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var BComment = response.data;
        BComment = BComment.d;
        $scope.BCommentList = JSON.parse(BComment);
    }, function (error) {
    });

    $scope.submitBlogPost = function () {
        var BlogPostID = $('#ContentPlaceHolder1_hddBlogID').val();
        var Name = $('#txtYourName').val();
        var Email = $('#txtYourEmail').val();
        var Comment = $('#txtComment').val();
        if (Name === "" || Comment === "") {
            $scope.loading = false;
            tostpro("Please Fill Required Fields.", 'Error', 'error', 'mid-center', '2500');
            if (Name === "") {
                validation('fieldReq1');
            }

            if (Comment === "") {
                validation('fieldReq3');
            }
            return;
        };
        $http({
            method: 'POST',
            url: '/CustomerService.asmx/submitBlogPost',
            data: '{Name: "' + Name + '",Email:"' + Email + '",Comment:"' + Comment + '",BlogPostID:"' + BlogPostID + '"}',
            headers: { 'Accept': 'json', 'Content-Type': "application/json; charset=utf-8" }
        }).then(function (response) {
            var result = response.data.d.split('_');
            if (result[0] === "Success") {
                tostpro("Detail Submitted Successfully.", 'Message', 'success', 'top-right', '2500');
                setTimeout(function () {
                    document.location.reload()
                }, 3000);
            }
        }, function (error) {

        });
    };
});

app.controller('CMSController', function ($scope, $http) {
    alert("Shankar");
    $scope.addContactUs = function () {
        $scope.loading = true;
        var Name = $('#txtName').val();
        var Email = $('#txtEmail').val();
        var Subject = $('#txtSubject').val();
        var msg = $('#txtMessage').val();
        var EntryType = "Con";
        var imgName = '';
        var fileUpload = $("#fileUpload").get(0);
        var files = fileUpload.files;
        var Imgg = new FormData();
        for (var i = 0; i < files.length; i++) {
            imgName = 'Con_' + files[i].name;
            Imgg.append(files[i].name, files[i]);
        }
        if (Name === "" || Email === "" || msg === "") {
            $scope.loading = false;
            tostpro("Please Fill Required Fields.", 'Error', 'error', 'mid-center', '2500');
            if (Name === "") {
                validation('fieldReq1');
            }
            if (Email === "") {
                validation('fieldReq2');
            }
            if (msg === "") {
                validation('fieldReq3');
            }
            return;
        }
        if (!emailpattern.test(Email)) {
            tostpro("Please enter valid email address", 'Error', 'error', 'top-right', '2000');
            $scope.loading = false;
            return;
        }
        $.ajax({
            method: 'POST',
            url: '/CustomerService.asmx/SubmitContactUs',
            data: '{Name: "' + Name + '",Email:"' + Email + '",Subject:"' + Subject + '",Message: "' + msg + '",imgName: "' + imgName + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var result = response.d.split('_');
            if (result[0] === "Success") {
                $.ajax({
                    url: "/UploadFiles.ashx?EntryType= " + EntryType + "&eid=" + result[1],
                    type: "POST",
                    contentType: false,
                    processData: false,
                    data: Imgg,
                    success: function (result) {
                        $scope.loading = false;
                    },
                    error: function (err) {
                    }
                });
                $scope.loading = false;
                tostpro("Detail Submitted Successfully.", 'Success', 'success', 'mid-center', '2500');
                setTimeout(function () {
                    document.location.reload()
                }, 3000);
                $('#txtName').val('');
                $('#txtEmail').val('');
                $('#txtSubject').val('');
                $('#txtMessage').val('');
                $("#fileUpload").val('');
            }
            else {
                tostpro("Please Fill Required Fields.", 'Error', 'error', 'mid-center', '2500');
            }
        }, function (error) {
            $scope.loading = false;
        });
    }
    $scope.submitButtonNN = true;
    $scope.addCustomOrderForm = function () {
        $scope.progressButton = true;
        $scope.submitButtonNN = false;
        $scope.loading = true;
        var Name = $('#txtFullName').val();
        var Email = $('#txtEmail').val();
        var ContactNo = $('#txtContactNo').val();
        var StoneName = $('#txtStoneName').val();
        var Description = $('#txtDescription').val();
        var EntryType = $('#txtEntryType').val();
        var filename = '';
        var fileUpload = $("#fileUpload").get(0);
        var files = fileUpload.files;
        var Imgg = new FormData();
        for (var i = 0; i < files.length; i++) {
            filename = EntryType + '_' + files[i].name;
            Imgg.append(files[i].name, files[i]);
        }
        if (Name === "" || Email === "" || Description === "") {
            $scope.loading = false;
            tostpro("Please Fill Required Fields.", 'Error', 'error', 'mid-center', '2500');
            if (Name === "") {
                validation('fieldReq1');
            }
            if (Email === "") {
                validation('fieldReq2');
            }
            if (Description === "") {
                validation('fieldReq4');
            }
            $scope.progressButton = false;
            $scope.submitButtonNN = true;
            $scope.loading = false;
            return;
        }
        if (!emailpattern.test(Email)) {
            tostpro("Please enter valid email address", 'Error', 'error', 'top-right', '2000');
            $scope.progressButton = false;
            $scope.submitButtonNN = true;
            $scope.loading = false;
            return;
        }
        $.ajax({
            method: 'POST',
            url: '/CustomerService.asmx/SubmitCustomOrderForm',
            data: '{Name: "' + Name + '",Email:"' + Email + '",ContactNo:"' + ContactNo + '",StoneName: "' + StoneName + '",Description:"' + Description + '",filename: "' + filename + '",EntryType:"' + EntryType + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var result = response.d.split('_');
            if (result[0] === "Success") {
                $scope.loading = false;
                $.ajax({
                    url: "/UploadFiles.ashx?EntryType= " + EntryType + "&eid=" + result[1],
                    type: "POST",
                    contentType: false,
                    processData: false,
                    data: Imgg,
                    success: function (result) {
                    },
                    error: function (err) {
                    }
                });
                tostpro("Detail Submitted Successfully.", 'Success', 'success', 'mid-center', '2500');
                setTimeout(function () {
                    document.location.reload()
                }, 3000);

                $scope.progressButton = false;
                $scope.submitButtonNN = true;
                $('#txtFullName').val('');
                $('#txtEmail').val('');
                $('#txtContactNo').val('');
                $('#txtStoneName').val('');
                $('#txtDescription').val('');
                $('#fileUpload').val('');
                $(".fieldReq1").removeClass("error");
            }
            else {
                tostpro("Please Fill Required Fields.", 'Error', 'error', 'mid-center', '2500');
                $scope.progressButton = false;
                $scope.submitButtonNN = true;
            }
        }, function (error) {
            $scope.loading = false;
        });
    }

    $scope.fngetFiles = function (file) {
        var TotSize = 0;
        for (var i = 0; i < file.length; i++) {
            var Size = file[i].size;
            TotSize = TotSize + Size;
        }
        var MaxSize = 1 * 1024 * 1024
        if (MaxSize < TotSize) {
            alert("File size should not be greater than 1Mb.");
            $('#btnSubmit').hide();
            $('#fileUpload').val("");
            return false;
        }
        else {
            $('#btnSubmit').show();
        }
        var name = file[0].name;
        if (name.includes('&')) {
            alert("Please remove & character from filename.");
            $('#btnSubmit').hide();
            return;
        }
        else {
            $('#btnSubmit').show();
        }
        if (name.includes('#')) {
            alert("Please remove # character from filename.");
            $('#btnSubmit').hide();
            return;
        }
        else {
            $('#btnSubmit').show();
        }
        var type = file[0].type;
        switch (type) {
            case 'application/vnd.openxmlformats-officedocument.wordprocessingml.document':
            case 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet':
            case 'application/pdf':
            case 'image/jpeg':
            case 'image/gif':
                return true;
                break;
            default:
                $('#fileUpload').val("");
                return false;
        }
    }
});

app.controller('CustomerController', function ($scope, $http) {
    $http({
        method: 'POST',
        url: '../FrontFunction.asmx/GetCountryList',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var dd = response.data;
        dd = dd.d;
        $scope.CountryList = JSON.parse(dd);
    }, function (error) {
    });


    $scope.StateListfn = function (th) {
        var ddd = $scope.selectedItem;
        $http({
            method: 'POST',
            url: '../FrontFunction.asmx/GetStateList',
            data: '{CID: "' + ddd + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var dd = response.data;
            dd = dd.d;
            $scope.StateList = JSON.parse(dd);
            $scope.Statecount = $scope.StateList.length;
        }, function (error) {
        });
    }

    $http({
        method: 'POST',
        url: '../CustomerService.asmx/GetCustomerOrder',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var dd = response.data;
        dd = dd.d;
        $scope.CustOrderList = JSON.parse(dd);
    }, function (error) {

    });

    var odtl = window.location.href.slice(window.location.href.indexOf('?') + 1).split('=');
    var oname = odtl[0];
    var oid = odtl[1];
    if (oid !== '' && oid !== undefined && oid !== null) {
        $http({
            method: 'POST',
            url: '../CustomerService.asmx/GetOrderDetailStatus',
            data: '{oid: "' + oid + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var dd = response.data;
            dd = dd.d;
            $scope.orderstatus = JSON.parse(dd);
        }, function (error) {
        });

        $http({
            method: 'POST',
            url: '../CustomerService.asmx/GetOrderDetailTbl0',
            data: '{oid: "' + oid + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var dd = response.data;
            dd = dd.d;
            $scope.OrderDetailTbl0 = JSON.parse(dd);
        }, function (error) {
        });

        $http({
            method: 'POST',
            url: '../CustomerService.asmx/GetOrderDetailTbl1',
            data: '{oid: "' + oid + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var dd = response.data;
            dd = dd.d;
            $scope.OrderDetailTbl1 = JSON.parse(dd);
        }, function (error) {
        });

        $http({
            method: 'POST',
            url: '../CustomerService.asmx/GetOrderDetailDelAdd',
            data: '{oid: "' + oid + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var dd = response.data;
            dd = dd.d;
            $scope.OrderDetailDelAdd = JSON.parse(dd);
        }, function (error) {
        });

        $http({
            method: 'POST',
            url: '../CustomerService.asmx/GetOrderDetailInvAdd',
            data: '{oid: "' + oid + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var dd = response.data;
            dd = dd.d;
            $scope.OrderDetailInvAdd = JSON.parse(dd);
        }, function (error) {
        });

        $http({
            method: 'POST',
            url: '../CustomerService.asmx/GetOrderDetailTracking',
            data: '{oid: "' + oid + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var dd = response.data;
            dd = dd.d;
            $scope.ordertrack = JSON.parse(dd);
        }, function (error) {
        });
    }

    $http({
        method: 'POST',
        url: '../CustomerService.asmx/GetCustomerAddress',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var dd = response.data;
        dd = dd.d;
        $scope.CustAddressList = JSON.parse(dd);
    }, function (error) {

    });

    $scope.DeleteAddress = function (addid) {
        if (confirm("Do you really delete this address ?")) {
            $http({
                method: 'POST',
                url: '/CustomerService.asmx/deleteAddress',
                data: '{addid: "' + addid + '"}',
                contentType: "application/json; charset=utf-8"
            }).then(function (response) {
                var dd = response.data;
                dd = dd.d;
                $scope.CustAddressList = JSON.parse(dd);
                tostpro("Address Deleted Successfully.", 'Success', 'success', 'top-right', '2000');
            }, function (error) {
                var ss = error;
            });
        }
    }

    $http({
        method: 'POST',
        url: '../CustomerService.asmx/GetWishList',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var dd = response.data;
        dd = dd.d;
        $scope.WishList = JSON.parse(dd);
    }, function (error) {
    });

    $scope.RemoveItemWL = function (th) {
        $http({
            method: 'POST',
            url: '/CustomerService.asmx/RemoveFromWL',
            data: '{ProdId: "' + th + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var dd = response.data;
            dd = dd.d;
            $scope.WishList = JSON.parse(dd);
            tostpro("Product Removed Successfully.", 'Success', 'success', 'top-right', '2000');
        }, function (error) {
        });
    }

    $scope.Orderdelete = function (th) {
        if (confirm("Do you really want to cancel this order ?")) {
            $http({
                method: 'POST',
                url: '/CustomerService.asmx/OrderCancel',
                data: '{OrderId: "' + th + '"}',
                contentType: "application/json; charset=utf-8"
            }).then(function (response) {
                var dd = response.data.d;
                if (dd === "Success") {
                    $http({
                        method: 'POST',
                        url: '/CustomerService.asmx/GetCustomerOrder',
                        data: '{}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json"
                    }).then(function (response) {
                        var dd = response.data;
                        dd = dd.d;
                        $scope.CustOrderList = JSON.parse(dd);
                        tostpro("Order Cancelled Successfully.", 'Success', 'success', 'top-right', '2000');
                    }, function (error) {

                    });
                }
            }, function (error) {
                var ss = error;
            });
        }
    }

    $scope.OrderCancel = function (th) {
    }
    $http({
        method: 'POST',
        url: '../CustomerService.asmx/GetPersonalInfo',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var dd = response.data;
        dd = dd.d;
        $scope.CustPersonalInfo = JSON.parse(dd);
    }, function (error) {
    });
    $scope.GetAddDetailOne = function (th) {

        var AddId = th;
        $http({
            method: 'POST',
            url: '../CustomerService.asmx/GetAddressDetailOne',
            data: '{AddId: "' + AddId + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var dd = response.data;
            dd = dd.d;
            $scope.AddressDetail = JSON.parse(dd);
            window.location.href = "AddAddress.aspx?id=" + AddId + "";
        }, function (error) {
        });
    }

    $scope.reorderProduct = function (th, th1, th2) {
        $http({
            method: 'POST',
            url: '/NFunction.asmx/reorderProduct',
            data: '{ProdId: "' + th + '", AttriID: "' + th1 + '", OrderDetailId: "' + th2 + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            tostpro("Product successfully added to your shopping cart.", 'Message', 'success', 'mid-center', '2000');
            window.setTimeout(function () {
                window.location.href = '/ShoppingCart.aspx';
            }, 3000);

        }, function (error) {
        });
    };

    $scope.reorderNotifyMe = function (pRef, pName, pPrice, pImg, pDtlUrl, pProdId, cName, Email) {
        $('#txtreorderNotifyEmail').val(Email);
        $('#hddpRef').val(pRef); $('#hddpName').val(pName); $('#hddpPrice').val(pPrice);
        $('#hddpImg').val(pImg); $('#hddpDtlUrl').val(pDtlUrl); $('#hddpProdId').val(pProdId);
        $('#hddcName').val(cName);
    }
    $scope.submitButtonNN = true;
    $scope.SubmitReorderNotifyMe = function () {
        $scope.progressButton = true;
        $scope.submitButtonNN = false;
        var pRef = $('#hddpRef').val(); var pName = $('#hddpName').val();
        var pPrice = $('#hddpPrice').val(); var pImg = $('#hddpImg').val();
        var pDtlUrl = $('#hddpDtlUrl').val(); var pProdId = $('#hddpProdId').val();
        var cName = $('#hddcName').val(); var Email = $('#txtreorderNotifyEmail').val();
        if (!emailpattern.test(Email)) {
            tostpro("Please enter valid email address", 'Error', 'error', 'top-right', '2000');
            $scope.progressButton = false;
            $scope.submitButtonNN = true;
            return;
        }
        $http({
            method: 'POST',
            url: '/NFunction.asmx/notifyReorder',
            data: '{pRef: "' + pRef + '", pName: "' + pName + '", pPrice: "' + pPrice + '", pImg: "' + pImg + '", pDtlUrl: "' + pDtlUrl + '", pProdId: "' + pProdId + '", cName: "' + cName + '", Email: "' + Email + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            $scope.progressButton = false;
            $scope.submitButtonNN = true;
            tostpro("Send Successfully.", 'Message', 'success', 'mid-center', '2000');
            $('#reorderNotifyMe').modal('hide');
        }, function (error) {
        });
    };

    $scope.IsVisible = false;
    $scope.ShowHide = function () {
        $scope.IsVisible = $scope.IsVisible ? false : true;
    }
});


app.controller('NewArrivalsController', function ($scope, $http) {
    $scope.loading = true;
    $scope.RfineLoading = true;
    var path = window.location.href;
    var Slug = path;
    //$http({
    //    method: 'POST',
    //    url: '/FrontFunction.asmx/getAttributes',
    //    data: '{Slug: "' + Slug + '"}',
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json"
    //}).then(function (response) { 
    //    var filt = response.data;
    //    filt = filt.d;
    //    $scope.filts = JSON.parse(filt);
    //    $scope.RfineLoading = false;
    //}, function (error) {
    //});

    $http({
        method: 'POST',
        url: '/FrontFunction.asmx/getNewArrivalsProdForPage',
        data: '{OBY: "0"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var product = response.data;
        product = product.d;
        $scope.loading = false;
        $scope.newArrivalsProduct = JSON.parse(product);
        $('#lblItemCount').html($scope.newArrivalsProduct.length);
        $scope.ShowItemonPage = 40;
        $('#drpShow').val("40");
        $('#drpFilter').val("0");
    }, function (error) {

    }).finally(function () {
        $scope.loading = false;
    });

    //Code for product Search For Othr
    $scope.getItems = function (th) {
        $scope.loading = true;
        var sh = $('#drpShow').val();
        var ob = $('#drpFilter').val();
        var cartype = "";
        for (var i = 0; i < $scope.filts.length; i++) {
            for (var j = 0; j < $scope.filts[i].Attri.length; j++) {
                var aa = $scope.filts[i].Attri[j].id;
                if ($('#att' + aa + '').is(":checked"))
                    cartype += aa + ",";
            }
        }
        var TypeID = cartype.slice(0, -1);
        var path = window.location.href;
        var Slug = path;
        var cartypeProduct = "";
        for (var i = 0; i < $scope.filts.length; i++) {
            for (var j = 0; j < $scope.filts[i].Attri.length; j++) {
                var kk = $scope.filts[i].Attri[j].id;
                var ll = $scope.filts[i].id_attribute_group;
                if ($('#att' + kk + '').is(":checked")) {
                    cartypeProduct += kk + "-" + ll + ",";
                }
            }
        }
        var TypeID = cartypeProduct.slice(0, -1);
        $scope.loading = true;
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/getFilterProductsForOther',
            data: '{TypeID:"' + TypeID + '",OrderBy:"' + ob + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var product = response.data;
            product = product.d;
            $scope.loading = false;

            $scope.newArrivalsProduct = JSON.parse(product);
            $('#lblItemCount').html($scope.newArrivalsProduct.length);

        }, function (error) {
            $scope.loading = false;
        });
    };

    $scope.getNewArrivalsOrderBy = function () {
        $scope.loading = true;
        var ob = $('#drpFilter').val();
        $http({
            method: 'POST',
            url: '/FrontFunction.asmx/getNewArrivalsProdForPage',
            data: '{OBY: "' + ob + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var product = response.data;
            product = product.d;
            $scope.loading = false;
            $scope.newArrivalsProduct = JSON.parse(product);
            $('#lblItemCount').html($scope.newArrivalsProduct.length);
            $('#drpShow').val("40");
            $('#drpFilter').val(ob);
        }, function (error) {

        }).finally(function () {
            $scope.loading = false;
        });
    };

    $scope.getPageShow = function () {
        var sh = $('#drpShow').val();
        if (sh == "0") {
            $scope.newArrivalsProduct[0].coun = $scope.newArrivalsProduct.length;
        }
        else {
            $scope.newArrivalsProduct[0].coun = sh;
        }
    };

    $scope.addProdDetail = function (th) {
        $('#modelID').html('');
        $scope.loading = true;
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/getModelDetail',
            data: '{prodID: "' + th + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var cart = response.data;
            cart = cart.d;
            $('#modelID').html(cart);
            $http({
                method: 'POST',
                url: '/FrontWeb.asmx/custProdEnquiryModel',
                data: '{prodID: "' + th + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                var EnqProdModel = response.data;
                EnqProdModel = EnqProdModel.d;
                $('#bindProdEnquiryModel').html(EnqProdModel);
                $scope.loading = false;
            }, function (error) {
            });

        }, function (error) {
        });
    };

});

app.controller('BestSellsController', function ($scope, $http) {
    $scope.loading = true;
    //Best Selling Products
    $http({
        method: 'POST',
        url: '/FrontFunction.asmx/getBestSellingProdForPage',
        data: '{OBY: "0"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var product = response.data;
        product = product.d;
        $scope.loading = false;
        $scope.bestSellingProduct = JSON.parse(product);
        $('#lblItemCount').html($scope.bestSellingProduct.length);
        $scope.ShowItemonPage = 40;
        $('#drpShow').val(40);
        $('#drpFilter').val("0");
    }, function (error) {

    }).finally(function () {
        $scope.loading = false;
    });

    $scope.getNewArrivalsOrderBy = function () {
        $scope.loading = true;
        var ob = $('#drpFilter').val();
        $http({
            method: 'POST',
            url: '/FrontFunction.asmx/getBestSellingProdForPage',
            data: '{OBY: "' + ob + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var product = response.data;
            product = product.d;
            $scope.loading = false;
            $scope.bestSellingProduct = JSON.parse(product);
            $('#lblItemCount').html($scope.bestSellingProduct.length);
            $scope.ShowItemonPage = 40;
            //$('#drpShow').val('40');
            $('#drpFilter').val(ob);
        }, function (error) {

        }).finally(function () {
            $scope.loading = false;
        });
    };

    $scope.getPageShow = function () {
        var sh = $('#drpShow').val();
        if (sh == "0") {
            $scope.ShowItemonPage = $scope.bestSellingProduct.length;
        }
        else {
            $scope.ShowItemonPage = sh;
        }
    };

    $scope.addProdDetail = function (th) {
        $('#modelID').html('');
        $scope.loading = true;
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/getModelDetail',
            data: '{prodID: "' + th + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var cart = response.data;
            cart = cart.d;
            $('#modelID').html(cart);
            $http({
                method: 'POST',
                url: '/FrontWeb.asmx/custProdEnquiryModel',
                data: '{prodID: "' + th + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                var EnqProdModel = response.data;
                EnqProdModel = EnqProdModel.d;
                $('#bindProdEnquiryModel').html(EnqProdModel);
                $scope.loading = false;
            }, function (error) {
            });

        }, function (error) {
        });
    }

});


app.controller('CreativeCustController', function ($scope, $http) {
    $scope.loading = true;
    $http({
        method: 'POST',
        url: '/FrontFunction.asmx/getCreativeCutsProd',
        data: '{OBY: "0"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var product = response.data;
        product = product.d;
        $scope.loading = false;
        $scope.CreativeCustProduct = JSON.parse(product);
        $('#CatDescription').html($scope.CreativeCustProduct[0].catDes);
        $('#lblItemCount').html($scope.CreativeCustProduct.length);
        $('#drpShow').val("40");
        $('#drpFilter').val("0");
    }, function (error) {

    }).finally(function () {
        $scope.loading = false;
    });

    $scope.getCreativeCutsOrderBy = function () {
        $scope.loading = true;
        var ob = $('#drpFilter').val();
        $http({
            method: 'POST',
            url: '/FrontFunction.asmx/getCreativeCutsProd',
            data: '{OBY: "' + ob + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var product = response.data;
            product = product.d;
            $scope.loading = false;
            $scope.CreativeCustProduct = JSON.parse(product);
            $('#lblItemCount').html($scope.CreativeCustProduct.length);
            $('#drpShow').val("40");
            $('#drpFilter').val(ob);
        }, function (error) {

        }).finally(function () {
            $scope.loading = false;
        });
    };

    $scope.getPageShow = function () {
        var sh = $('#drpShow').val();
        if (sh == "0") {
            $scope.CreativeCustProduct[0].coun = $scope.CreativeCustProduct.length;
        }
        else {
            $scope.CreativeCustProduct[0].coun = sh;
        }
    };

    $scope.creativecutsDetail = function (th) {
        $('#modelIDcreativecuts').html('');
        $scope.loading = true;
        $http({
            method: 'POST',
            url: '/FrontFunction.asmx/getCreativeCustModelDetail',
            data: '{prodID: "' + th + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var dtl = response.data;
            dtl = dtl.d;
            $('#modelIDcreativecuts').html(dtl);
            $scope.loading = false;
        }, function (error) {
        });
    }
});

app.directive('ngFiles', ['$parse', function ($parse) {
    function fn_link(scope, element, attrs) {
        var onChange = $parse(attrs.ngFiles);
        element.on('change', function (event) {
            onChange(scope, { $files: event.target.files });
        });
    };
    return {
        link: fn_link
    }
}]);

function validation(th) {
    var fil = "." + th;
    $(fil).addClass("error");
};

// Google Login
function onSignIn(googleUser) {
    var profile = googleUser.getBasicProfile();
    $.ajax({
        method: 'POST',
        url: '/FrontWeb.asmx/AppLogin',
        data: '{email: "' + profile.getEmail() + '",name: "' + profile.getName() + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        window.location.href = "/my-account";
    }, function (error) {
    });
}

// google signout
function onLoad() {
    gapi.load('auth2', function () {
        gapi.auth2.init();
    });
}
function signOut() {
    var auth2 = gapi.auth2.getAuthInstance();
    auth2.signOut().then(function () {
        window.location.href = "/logout.aspx";
    });
};
