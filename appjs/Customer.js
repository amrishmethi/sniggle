app = angular.module('MyEarth', ['angularUtils.directives.dirPagination']);

app.controller('MasterController', function ($scope, $http) {

    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getCart',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        // //////debugger
        var cart = response.data;
        cart = cart.d;
        //alert(response.data);
        $scope.carts = JSON.parse(cart);

        $('#TotalCount').html($scope.carts[0].TotalCount);
        $('#TotalAmount').html("$" + parseFloat($scope.carts[0].TotalAmount).toFixed(2));

    }, function (error) {

    });
    //debugger
    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getWishList',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        //debugger
        var wish = response.data;
        wish = wish.d;
        $('#wishID').html(wish);

    }, function (error) {

    });
});

app.controller('CustomerController', function ($scope, $http) {

    $http({
        method: 'POST',
        url: '../FrontFunction.asmx/GetCountryList',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        // //////debugger
        var dd = response.data;
        dd = dd.d;
        //alert(response.data);
        $scope.CountryList = JSON.parse(dd);

    }, function (error) {

    });


    $scope.StateListfn = function (th) {
        var ddd = $scope.selectedItem;
        //debugger
        $http({
            method: 'POST',
            url: '../FrontFunction.asmx/GetStateList',
            data: '{CID: "' + ddd + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var dd = response.data;
            dd = dd.d;
            //alert(response.data);
            $scope.StateList = JSON.parse(dd);
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
        //debugger
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
        debugger
        var AddId = th;
        $http({
            method: 'POST',
            url: '../CustomerService.asmx/GetAddressDetailOne',
            data: '{AddId: "' + AddId + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            debugger
            var dd = response.data;
            dd = dd.d;
            //alert(response.data);
            $scope.AddressDetail = JSON.parse(dd);
            window.location.href = "AddAddress.aspx?id=" + AddId + "";
        }, function (error) {

        });
    };


});


app.controller('RegistrationController', function ($scope, $http) {

    $http({
        method: 'POST',
        url: '../FrontFunction.asmx/GetCountryList',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        // //////debugger
        var dd = response.data;
        dd = dd.d;
        //alert(response.data);
        $scope.CountryList = JSON.parse(dd);

    }, function (error) {

    });


    $scope.StateListfn = function (th) {
        var ddd = $scope.selectedItem;
        //debugger
        $http({
            method: 'POST',
            url: '../FrontFunction.asmx/GetStateList',
            data: '{CID: "' + ddd + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var dd = response.data;
            dd = dd.d;
            //alert(response.data);
            $scope.StateList = JSON.parse(dd);
        }, function (error) {

        });
    }
});


app.controller('HomeController', function ($scope, $http) {
    var ss = $("#drpCatID option:selected").text();
    var val = $("#drpCatID option:selected").val();
    //alert(ss + val);
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
        //debugger
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
        debugger
        var Srch = $('#txtSearchProduct').val();
        var ss = $('#hddDetailUrl').val();
        alert(Srch);
        alert(ss);
        //window.location.href = "Search.aspx?" + Srch + "";
    }

});

app.controller('ProductDetailController', function ($scope, $http) {

    var path = window.location.href;
    var Slug = path;

    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getDetail',
        data: '{Slug: "' + Slug + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        //  //////debugger
        var product = response.data;
        product = product.d;

        //alert(response.data);
        $scope.products = JSON.parse(product);
        $('#DivDetail').html($scope.products[0].description);

    }, function (error) {

    });

    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getImage',
        data: '{Slug: "' + Slug + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        //debugger
        var img = response.data;
        img = img.d;

        //alert(response.data);
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
        //debugger
        var dd = response.data;
        dd = dd.d;

        //alert(response.data);
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
        //  //////debugger
        var fet = response.data;
        fet = fet.d;

        //alert(response.data);
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
        //debugger
        var attradio = response.data;
        attradio = attradio.d;
        if (attradio == "") {
            $('#lblRadio').html("No");
        }
        //alert(response.data);
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
        //  //////debugger
        var attselect = response.data;
        attselect = attselect.d;

        //alert(response.data);
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
        //  //////debugger
        var rev = response.data;
        rev = rev.d;

        //alert(response.data);
        $scope.revs = JSON.parse(rev);

    }, function (error) {

    });

    $scope.getPrice = function (th) {
        //debugger;

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
                    // alert("Your are a - " + radioValue);
                }
            }
        }

        var TypeID = cartype.slice(0, -1);
        var price = $('#rprice').html();
        var disprice = $('#disprice').html();
        // alert(TypeID);
        var path = window.location.href;
        var Slug = path;
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/getProductPrice',
            data: '{Slug: "' + Slug + '", TypeID:"' + TypeID + '",price:"' + price + '",disprice:"' + disprice + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            //debugger
            var price = response.data;
            price = price.d;

            $('#sppricenew').html("" + price.split('_')[0]);
            $('#spprice').html("" + price.split('_')[0]);
            $('#spdisprice').html("" + price.split('_')[1]);
            $('#ContentPlaceHolder1_lblattID').html(price.split('_')[2]);

        }, function (error) {

        });
    }

    $scope.addReview = function () {
        //debugger;

        //alert($("input[name='rate1']:checked").val());
        //alert($("input[name='rate2']:checked").val());
        //alert($("input[name='rate3']:checked").val());
        //alert($("input[name='rate4']:checked").val());
        //alert($("input[name='rate5']:checked").val());
        Rating = document.getElementsByName["criterion[1]"].value;
        alert(Rating);
        Name = $('#custName').val();
        Comment = $('#review').val();
        Title = $('#title').val();

        if (Title == "") {
            $('#reqTitle').show();
            return;
        }
        else
            $('#reqTitle').hide();

        if (Comment == "") {
            $('#reqReview').show();
            return;
        }
        else
            $('#reqReview').hide();
        if (Name == "") {
            $('#reqName').show();
            return;
        }
        else
            $('#reqName').hide();




        // alert(TypeID);
        var path = window.location.href;
        var Slug = path;
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/addProductReview',
            data: '{Slug: "' + Slug + '", Name:"' + Name + '",Rating:"' + Rating + '",Title:"' + Title + '",Comment:"' + Comment + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            //debugger
            var price = response.data;
            price = price.d;
            $('#custName').val('');
            $('#review').val('');
            $('#title').val('');
            $('#reqMessage').show();


        }, function (error) {

        });
    }


    $scope.addToCart = function () {
        //debugger;
        var AttriID = $('#ContentPlaceHolder1_lblattID').html();
        var SKU = $('#sku').html();
        var Image1 = $('#ContentPlaceHolder1_lblImg').html();
        var ProductName = $('#productName').html();
        var Qty = $('#quantity_wanted').val();
        var Price = $('#rprice').html();
        var DiscountPrice = $('#disprice').html();
        var path = window.location.href;
        var Slug = path;
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/addToCart',
            data: '{ProdID: "' + Slug + '", AttriID:"' + AttriID + '",SKU:"' + SKU + '",Image1:"' + Image1 + '",ProductName:"' + ProductName + '",Qty:"' + Qty + '",Price:"' + Price + '",DiscountPrice:"' + DiscountPrice + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            //debugger
            $http({
                method: 'POST',
                url: '../FrontWeb.asmx/getCart',
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                //debugger
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


    $scope.addToWishList = function () {
        //debugger;
        document.getElementById("overlay").style.display = "block";
        setInterval(myFunction, 4000);
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
            //debugger
            if (response.data.d == "0") {
                alert("Please login");
            }
            else {
                //alert("Added item in wishlist..");

                $http({
                    method: 'POST',
                    url: '/FrontWeb.asmx/getWishList',
                    data: '{}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json"
                }).then(function (response) {
                    //debugger
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

app.controller('ProductWebController', function ($scope, $http) {
    //debugger;
    var path = window.location.href;
    var Slug = path;

    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getProducts',
        data: '{Slug: "' + Slug + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        //  //////debugger
        var product = response.data;
        product = product.d;

        //alert(response.data);
        $scope.products = JSON.parse(product);
        $('#lblItemCount').html($scope.products.length);

        $('#drpShow').val("32");
        $('#drpFilter').val("0");

    }, function (error) {

    });

    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getAttributes',
        data: '{Slug: "' + Slug + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        //  //////debugger
        var filt = response.data;
        filt = filt.d;

        //alert(response.data);
        $scope.filts = JSON.parse(filt);

    }, function (error) {

    });

    $scope.addProdDetail = function (th) {
        $('#modelID').html('');
        debugger
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/getModelDetail',
            data: '{prodID: "' + th + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            debugger
            var cart = response.data;
            cart = cart.d;
            $('#modelID').html(cart);

        }, function (error) {

        });
    }

    $scope.getItems = function (th) {
        //debugger;
        var sh = $('#drpShow').val();
        var ob = $('#drpFilter').val();
        var cartype = "";
        for (var i = 0; i < $scope.filts.length; i++) {
            // alert($scope.filts[i].Attri.length);
            for (var j = 0; j < $scope.filts[i].Attri.length; j++) {

                var aa = $scope.filts[i].Attri[j].id;
                if ($('#att' + aa + '').is(":checked"))
                    cartype += aa + ",";
            }
        }

        var TypeID = cartype.slice(0, -1);

        //alert(TypeID);
        var path = window.location.href;
        var Slug = path;
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/getFilterProducts',
            data: '{Slug: "' + Slug + '", TypeID:"' + TypeID + '",OrderBy:"' + ob + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            //  //////debugger
            var product = response.data;
            product = product.d;

            //alert(response.data);
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


    $scope.getOrderBy = function () {
        //debugger;
        var sh = $('#drpShow').val();
        var ob = $('#drpFilter').val();
        // alert(ob);
        var maintype = "";
        var cartype = "";
        for (var i = 0; i < $scope.filts.length; i++) {
            // alert($scope.filts[i].Attri.length);
            for (var j = 0; j < $scope.filts[i].Attri.length; j++) {

                var aa = $scope.filts[i].Attri[j].id;
                if ($('#att' + aa + '').is(":checked"))
                    cartype += aa + ",";
            }
        }

        var TypeID = cartype.slice(0, -1);

        //alert(TypeID);
        var path = window.location.href;
        var Slug = path;
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/getFilterProducts',
            data: '{Slug: "' + Slug + '", TypeID:"' + TypeID + '",OrderBy:"' + ob + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            //  //////debugger
            var product = response.data;
            product = product.d;

            //alert(response.data);
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

    $scope.getPageShow = function () {
        debugger;
        var sh = $('#drpShow').val();

        if (sh == "0") {
            $scope.products[0].coun = $scope.products.length;
        }
        else {
            $scope.products[0].coun = sh;
        }

    }

    $scope.getFilter = function (th) {
        //debugger;
        var prodid = th;
        //alert(prodid);
        for (var i = 0; i < $scope.filts.length; i++) {
            var bb = $scope.filts[i].id_attribute_group;
            if (bb == prodid) {
                var kk = $('#txt' + th + '').val();
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
});

function addProdDetail(th) {

    debugger
    $.ajax({
        method: 'POST',
        url: '/FrontWeb.asmx/getModelDetail',
        data: '{prodID: "' + th + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        debugger
        var cart = response.d;
        $('#modelID').html(cart);

    }, function (error) {

    });
}

function addWishList(th) {

    document.getElementById("overlay").style.display = "block";
    setInterval(myFunction, 4000);

    $.ajax({
        method: 'POST',
        url: '/FrontWeb.asmx/addWishList',
        data: '{ProdID:"' + th + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        debugger
        if (response.d == "0") {
            alert("Please login");
        }
        else {
            debugger

            $.ajax({
                method: 'POST',
                url: '/FrontWeb.asmx/getWishList',
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                debugger
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

    var path = window.location.href;
    var Slug = path;
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
            debugger
            var cart = response.data;
            cart = cart.d;
            if (cart != "0") {
                window.location.href = "/ShoppingCart.aspx?step-2";
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


    $http({
        method: 'POST',
        url: '/FrontWeb.asmx/getCart',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        //debugger
        var cart = response.data;
        cart = cart.d;
        $scope.carts = JSON.parse(cart);
        $('#TotalCount').html($scope.carts[0].TotalCount);
        $('#TotalAmount').html("$" + parseFloat($scope.carts[0].TotalAmount).toFixed(2));

    }, function (error) {

    });

    $scope.getAddress = function () {
        //debugger

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

        }, function (error) {


        });
    }


    $scope.delCart = function (th) {
        //debugger
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
                //debugger
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
    debugger

    $http({
        method: 'POST',
        url: '/CustomerService.asmx/GetAddress',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        debugger
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
        debugger
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
        debugger
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


});


function getShippingAddress() {
    debugger
    var addId = $('#ContentPlaceHolder1_drpShippingAddress').val();

    $.ajax({
        method: 'POST',
        url: '/FrontWeb.asmx/getShippingAddressFilter',
        data: '{addId: "' + addId + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        debugger
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
            debugger
            var billaddress = response.d;
            $('#spBilling').html(billaddress);
        }, function (error) {

        });
    }
}

function getBillingAddress() {
    debugger
    var addId = $('#ContentPlaceHolder1_drpBillingAddress').val();

    $.ajax({
        method: 'POST',
        url: '/FrontWeb.asmx/getBillingAddressFilter',
        data: '{addId: "' + addId + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        debugger
        var billaddress = response.d;
        $('#spBilling').html(billaddress);
    }, function (error) {

    });
}

function getCommonAddress() {
    debugger
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
            debugger
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
        // //////debugger
        var dd = response.data;
        dd = dd.d;
        //alert(response.data);
        $scope.CountryList = JSON.parse(dd);

    }, function (error) {

    });

    var addid = "0";
    var path = window.location.href;
    var Slug = path;
    if (Slug.includes("addid")) {
        addid = Slug.split('&')[1].split('=')[1];

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

    $scope.addAddress = function () {
        //debugger;


        debugger
        var path = window.location.href;
        var Slug = path;
        var addid = "0";
        if (Slug.includes("addid")) {
            addid = Slug.split('&')[1].split('=')[1];
        }

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

        var AddInfo = $('#txtAdditionalInfo').val();
        var HomePhone = $('#txtHomePhone').val();
        var MobPhone = $('#txtMobilePhone').val();
        var alias = $('#txtalias').val();
        if (FNameA === "" || AddA === "" || CounValA === "" ||
            StateValA === "" || CityA === "" || PINA === "" || HomePhone === "" || MobPhone === "") {
            tostpro("Please Fill All Required Fields.", 'Error', 'error', 'top-right', '2000');
            return;
        }

        $.ajax({
            method: 'POST',
            url: '/CustomerService.asmx/CustomerAddress',
            data: '{addid: "' + addid + '",FNameA:"' + FNameA + '",LNameA:"' + LNameA + '",CompA: "' + CompA + '",AddA:"' + AddA + '",CounNameA:"' + CounNameA + '",CounValA: "' + CounValA + '",StateNameA:"' + StateNameA + '",StateValA:"' + StateValA + '",CityA:"' + CityA + '",PINA:"' + PINA + '",AddInfo:"' + AddInfo + '",HomePhone:"' + HomePhone + '",MobPhone:"' + MobPhone + '",alias:"' + alias + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            if (response.d != "Fail") {
                if (Slug.includes("back")) {
                    if (addid == "0") {
                        window.location.href = "ShoppingCart.aspx?step-3";
                    } else {
                        window.location.href = "ShoppingCart.aspx?step-3";
                    }
                }
                else {
                    alert("address updated successfully");
                }
            }
            else {
                tostpro("Authentication failed.", 'Error', 'error', 'top-right', '2000');
            }
        }, function (error) {

        });
    }






});











