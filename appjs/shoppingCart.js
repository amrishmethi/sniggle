app.controller('shoppingCartController', function ($scope, $http) {
    $scope.loading = true;
    var path = window.location.href; 
    var Slug = path; 
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
        if ($scope.carts.length > 0) {
            $('#TotalCount').html($scope.carts[0].TotalCount);
            $('#TotalAmount').html("₹" + parseFloat($scope.carts[0].TotalAmount).toFixed(2));
        }
        $scope.loading = false;
    }, function (error) {
    });
    if (Slug.includes("step-2")) {
        $("#aAddress").attr("href", "#Address")
        $('.nav-link').removeClass("active");
        $('.tab-pane').removeClass("active");
        $('.Address').addClass("active");
        $('#Address').addClass("active");
    }

    $scope.pCheckout = function (th) {
        $("#aAddress").attr("href", "#Address")
        $('.nav-link').removeClass("active");
        $('.tab-pane').removeClass("active");
        $('.' + th).addClass("active");
        $('#' + th).addClass("active");
    }

    $scope.getAddress = function () { 
        var shippingAddId = $('#content_drpShippingAddress').val();
        var billingAddId = $('#content_drpBillingAddress').val();
        $http({
            method: 'POST',
            url: '/FrontWeb.asmx/addAddressCart',
            data: '{shippingAddId: "' + shippingAddId + '",billingAddId: "' + billingAddId + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            $('.nav-link').removeClass("active");
            $('.tab-pane').removeClass("active");
            $('.Payment').addClass("active");
            $('#Payment').addClass("active");
            $("#aPayment").attr("href", "#Payment")
            //window.location.href = "/ShoppingCart.aspx?step-3";
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
                $('#TotalAmount').html("₹" + parseFloat($scope.carts[0].TotalAmount).toFixed(2));

            }, function (error) {
                $scope.loading = false;
            });
        }, function (error) {
            $scope.loading = false;
        });
    }

    $scope.addQty = function (th, th1, th2) {
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
                    $('#TotalAmount').html("₹" + parseFloat($scope.carts[0].TotalAmount).toFixed(2));
                }, function (error) {
                });
            }, function (error) {
            });
        }, function (error) {
        });
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
                $('#TotalAmount').html("₹" + parseFloat($scope.carts[0].TotalAmount).toFixed(2));
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
                $('#TotalAmount').html("₹" + parseFloat($scope.carts[0].TotalAmount).toFixed(2));
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
                $('#TotalAmount').html("₹" + parseFloat($scope.carts[0].TotalAmount).toFixed(2));
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

    $scope.getShippingAddress = function (th) {
        addid = $('#content_drpShippingAddress').val();
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
});

function getShippingAddress() {
    var addId = $('#content_drpShippingAddress').val();
    $.ajax({
        method: 'POST',
        url: '/FrontWeb.asmx/getShippingAddressFilter',
        data: '{addId: "' + addId + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var shipaddress = response.d;
        $('#spShipping').html(shipaddress);
        $('.dUpdate').hide();
        getBillingAddress();
    }, function (error) {
    }); 
}

function getBillingAddress() {
    var addId = $('#content_drpShippingAddress').val();
    $.ajax({
        method: 'POST',
        url: '/FrontWeb.asmx/getBillingAddressFilter',
        data: '{addId: "' + addId + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var billaddress = response.d;
        $('#spBilling').html(billaddress);
        $('.dUpdate').hide();
    }, function (error) {
    });
}