app.controller('websumControllerrr', function ($scope, $http) {
    debugger
    $scope.loading = true;
    $http({
        method: 'POST',
        url: '/FrontFunction.asmx/getAttributeWS',
        data: '{AttID: "6"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        $scope.loading = false;
        debugger
        var filt = response.data;
        filt = filt.d;
        $scope.gemstoneList = JSON.parse(filt);
    }, function (error) {
    });
    $http({
        method: 'POST',
        url: '/FrontFunction.asmx/getCategoryWS',
        data: '{AttID: "0"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        $scope.loading = false;
        debugger
        var filt = response.data;
        filt = filt.d;
        $scope.categoryList = JSON.parse(filt);
    }, function (error) {
    });

    $scope.getAttWS = function (th) {
        $scope.loading = true;
        $http({
            method: 'POST',
            url: '/FrontFunction.asmx/getAttributeWS',
            data: '{AttID: "' + th + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            $scope.loading = false;
            debugger
            var filt = response.data;
            filt = filt.d;
            $scope.filtsWS = JSON.parse(filt);
        }, function (error) {
        });
    };
});

app.controller('wsproductlist', function ($scope, $http) {
    $scope.RfineLoading = true;
    $scope.loading = true;
    var path = window.location.href;
    var pp1 = path.split('/');
    var pp = pp1[4].split('-');
    var AttID = pp[0];
    $http({
        method: 'POST',
        url: '/NFunction.asmx/getWSProdList',
        data: '{AttID : "' + AttID + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var prod = response.data;
        prod = prod.d;
        var dddd = JSON.parse(prod);
        var tab1 = dddd.Table;
        $scope.products = tab1;
        $('#lblItemCount').html($scope.products.length);
        $scope.products[0].coun = 40;
        $('#drpShow').val("40");
        $('#drpFilter').val("0");
        //$('#prodnameb').html($scope.products[0].AttName);
        $scope.loading = false;
        //$scope.RfineLoading = false;
    }, function (error) {
    });

    $http({
        method: 'POST',
        url: '/NFunction.asmx/getAttributes',
        data: '{AttID: "' + AttID + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var filt = response.data;
        filt = filt.d;
        $scope.filts = JSON.parse(filt);

        $scope.RfineLoading = false;
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
    };

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
    };
    //Code for product Search For Othr
    $scope.getItems = function (th) {
        var path = window.location.href;
        var pp1 = path.split('/');
        var pp = pp1[4].split('-');
        var AttID = pp[0];
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
            url: '/NFunction.asmx/getFilterProducts',
            data: '{AttID:"' + AttID + '",TypeID:"' + TypeID + '",OrderBy:"' + ob + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var product = response.data;
            product = product.d;
            $scope.loading = false;

            $scope.products = JSON.parse(product);
            $('#lblItemCount').html($scope.products.length);

        }, function (error) {
            $scope.loading = false;
        });
    };

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
    };
    $scope.reloadpage = function () {
        $scope.loading = true;
        document.location.reload();
    }
});

app.controller('TestimonialController', function ($scope, $http) {

    $http({
        method: 'POST',
        url: '/NFunction.asmx/getTestimonial',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        debugger
        var dd = response.data;
        dd = dd.d;
        var dddd = JSON.parse(dd);
        $scope.testimonial = dddd;
    }, function (error) {

    });

    $scope.submitTestimonial = function () {
        var name = $('#txtName').val();
        var AdditionalInfo = $('#txtAdditionalInfo').val();
        var Email = $('#txtEmail').val();
        var URL = $('#txtURL').val();
        var Content = $('#txtContent').val();
        if (name == '' || Content == '') {
            tostpro("Please Fill All Required Fields.", 'Error', 'error', 'top-right', '2000');
            return;
        }
        $http({
            method: 'POST',
            url: '/NFunction.asmx/submitTestimonial',
            data: '{name: "' + name + '", AdditionalInfo:"' + AdditionalInfo + '",Email:"' + Email + '",URL:"' + URL + '",Content:"' + Content + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            var dd = response.data.d;
            if (dd == 'Success') {
                var dvPassport = document.getElementById("dvPassport");
                dvPassport.style.display = "none";
                btnPassport.value = "Yes";
                tostpro("Submitted successfully.", 'Success', 'success', 'top-right', '2000');
                $('#txtName').val(''); $('#txtAdditionalInfo').val(''); $('#txtEmail').val('');
                $('#txtURL').val(''); $('#txtContent').val('');
            }

        }, function (error) {

        });
    }
}).filter('ashtml', function ($sce) { return $sce.trustAsHtml; });



app.controller('BlogControllerList', function ($scope, $http) {
    $scope.loading = true;
    $http({
        method: 'POST',
        url: '/FrontFunction.asmx/getBlogList',
        data: '{ }',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var Blog = response.data;
        Blog = Blog.d;
        var dddd = JSON.parse(Blog);
        $scope.BlogList = dddd;
        $scope.loading = false;
    }, function (error) {
    });

});

app.controller('pwdRecoveryController', function ($scope, $http) {
    $scope.loading = true;
    debugger
    var path = window.location.href;
    var pp1 = path.split('?');
    var dd = pp1[1].replace("token=", "");;
    $http({
        method: 'POST',
        url: '/NFunction.asmx/UpdatePwd',
        data: '{token: "' + dd + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var rst = response.data.d;
        if (rst == 'Expired') { 
            tostpro("Password reset link has expired or already use. Please generate a new reset password link.", 'Error', 'error', 'mid-center', '7000');
            window.setTimeout(function () {
                window.location.href = 'https://sniggle.in/';
            }, 7000); 
        }
        $scope.loading = false;
    }, function (error) {
    });
});