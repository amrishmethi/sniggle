/// <reference path="../angjs/angular.min.js" />

app.controller('ProductsController', function ($scope, $http) {
    $scope.RfineLoading = true;
    var path = window.location.href;
    var Slug = path;
    $scope.loading = true;
    $http({
        method: 'POST',
        url: '/products.asmx/getProducts',
        data: '{Slug: "' + Slug + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var product = response.data;
        product = product.d;
        $scope.products = JSON.parse(product);
        $('#lblItemCount').html($scope.products.length);
        $scope.products[0].coun = 42;
        $('#drpShow').val("42");
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
        url: '/products.asmx/getAttributes',
        data: '{Slug: "' + Slug + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        $scope.RfineLoading = false;
        var filt = response.data;
        filt = filt.d;
        $scope.filts = JSON.parse(filt);
    }, function (error) {
        $scope.RfineLoading = false;
    });

    $http({
        method: 'POST',
        url: '/products.asmx/getSubCategories',
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
            url: '/products.asmx/getModelDetail',
            data: '{prodID: "' + th + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var cart = response.data;
            cart = cart.d;
            $('#modelID').html(cart);
            $http({
                method: 'POST',
                url: '/products.asmx/custProdEnquiryModel',
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
        var minDis = 0;
        var maxDis = 0;
        if ($("#txtDicount10").prop("checked")) {
            minDis = 10;
            maxDis = 20;
        }
        if ($("#txtDicount20").prop("checked")) {
            minDis = 21;
            maxDis = 30;
        }
        if ($("#txtDicount30").prop("checked")) {
            minDis = 31;
            maxDis = 40;
        }
        if ($("#txtDicount40").prop("checked")) {
            minDis = 41;
            maxDis = 50;
        }
        if ($("#txtDicount50").prop("checked")) {
            minDis = 51;
            maxDis = 100;
        }
        if ($("#txtDicount60").prop("checked")) {
            minDis = 60;
            maxDis = 100;
        }
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
            url: '/products.asmx/getFilterProducts',
            data: '{Slug: "' + Slug + '", TypeID:"' + TypeID + '",OrderBy:"' + ob + '", subType:"' + subType + '", minDis:"' + minDis + '", maxDis:"' + maxDis + '"}',
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
            url: '/products.asmx/getFilterProducts',
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
                var pp = kk.toString().toUpperCase();
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
        var Rating = $('#lblRating').text();
        var Name = $('#custName').val();
        var Email = $('#custEmail').val();
        var Comment = $('#custReview').val();
        Title = '';
        if (Name == "") {
            $('#reqName').show();
            tostpro("Please Fill All Required Fields.", 'Error', 'error', 'top-right', '2000');
            return;
        }
        else
            $('#reqName').hide();
        if (Email == "") {
            $('#reqEmail').show();
            tostpro("Please Fill All Required Fields.", 'Error', 'error', 'top-right', '2000');
            return;
        }
        else
            $('#reqEmail').hide();
        if (Comment == "") {
            $('#reqReview').show();
            tostpro("Please Fill All Required Fields.", 'Error', 'error', 'top-right', '2000');
            return;
        }
        else
            $('#reqReview').hide();
        var path = window.location.href;
        var Slug = path;
        $http({
            method: 'POST',
            url: '/products.asmx/addProductReview',
            data: '{Slug: "' + Slug + '", Name:"' + Name + '",Rating:"' + Rating + '",Title:"' + Email + '",Comment:"' + Comment + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var price = response.data;
            price = price.d;
            if (price == 'Login') {
                tostpro("You must be logged in to write your review.", 'Message', 'error', 'mid-center', '2000');
            };
            if (price == 'Success') {
                $('#custName').val('');
                $('#custEmail').val('');
                $('#custReview').val('');
                tostpro("Review Send Successfully.", 'Message', 'success', 'mid-center', '2000');
            };
        }, function (error) {

        });
    }
    $scope.addToCart = function () {
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

    $scope.ratingValue = function (th) {
        $('#lblRating').text(th);
        $("#ratingFill1 ,#ratingFill2 ,#ratingFill3 ,#ratingFill4,#ratingFill5").addClass("fill");
        switch (th) {
            case 5:
                break;
            case 4:
                $("#ratingFill5").removeClass("fill");
                break;
            case 3:
                $("#ratingFill4,#ratingFill5").removeClass("fill");
                break;
            case 2:
                $("#ratingFill3, #ratingFill4,#ratingFill5").removeClass("fill");
                break;
            default:
                $("#ratingFill2, #ratingFill3, #ratingFill4,#ratingFill5").removeClass("fill");
        };
    };
});

function getPrice(th) { 
    var cartype = "";
    var selectData = $('#selectDataquik').html();
    var selectArray = selectData.split(',');
    for (var i = 0; i < selectArray.length; i++) {
        var aa = selectArray[i];
        if (aa == 13 || aa == 18) {
            var sz = th.split('-');
            if (sz.length > 0) {
                $('#drpquik' + aa + '').val(sz[1]);
                $('.eachSize').removeClass('activeSize');
            }
            cartype += ($('#drpquik' + aa + '').val()) + ",";
            var sizeVal = ($('#drpquik' + aa + '').val());
            $('#size_' + sizeVal).addClass('activeSize');
            $('#drpquik' + aa + '').val(selval);
        }
        else {
            cartype += ($('#drpquik' + aa + '').val()) + ",";
            var selval = ($('#drpquik' + aa + '').val());
            $('#drpquik' + aa + '').val(selval);
        }
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
        debugger
        $('#sppricenewquik').html("" + price.split('_')[1]);
        $('#sppricequik').html("" + price.split('_')[0]);
        $('#prodwithoutdiscountprice').html("" + price.split('_')[0]);
        $('#spdispricequik').html("" + price.split('_')[1]);
        $('#lblattIDquik').html(price.split('_')[2]);
        $('#skuquik').html(price.split('_')[3]);
        $('#minQty').html(price.split('_')[4]);
        $('#Qty').val(price.split('_')[4]);
        $('#stockQty').val(price.split('_')[5]);
        //if (price.split('_')[5] == "" || price.split('_')[5] == "0") {
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
        //quickViewImgPopup(imggid);
    }, function (error) {
    });
};