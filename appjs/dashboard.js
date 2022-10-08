app.controller('CustomerController', function ($scope, $http) {
    $http({
        method: 'POST',
        url: '../CustomerService.asmx/GetCountryList',
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
            url: '../CustomerService.asmx/GetStateList',
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
    };
});

function CustomerDtlUpdates() {
    debugger
    var gender = $("input[name='id_gender']:checked").val();
    var FName = $('#txtFirstName').val();
    var LName = $('#txtLastName').val();
    var Email = $('#content_txtEmail').val();
    var dob = $('#txtDOB').val();
    var RecOff = $("input[name='chkReceiveOffer']:checked").val();
    var NewsL = $("input[name='chknewsletter']:checked").val();
    if (NewsL == 'undefined' || NewsL == undefined || NewsL == '0' || NewsL == 0) {
        NewsL = 0;
    }
    if (FName === "" || Email === "") {
        tostpro("Please Fill All Required Fields.", 'Error', 'error', 'top-right', '2000');
        return;
    }
    $.ajax({
        method: 'POST',
        url: '../CustomerService.asmx/CustomerDtlUpdate',
        data: '{gender: "' + gender + '",FName: "' + FName + '",LName: "' + LName + '",Email: "' + Email + '",dob:"' + dob + '",RecOff:"' + RecOff + '",NewsL: "' + NewsL + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        if (response.d === "Success") {
            tostpro("Updated Successfully.", 'Success', 'success', 'top-right', '2000');
        }
        else {
            tostpro("Authentication failed.", 'Error', 'error', 'top-right', '2000');
        }
    }, function (error) {
    });
};