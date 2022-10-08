app.controller('AddAddressController', function ($scope, $http) {
    $http({
        method: 'POST',
        url: '/CustomerService.asmx/GetCountryList',
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
        debugger
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
        var CompA = "JAIPUR";
        var AddA = $('#txtAddressA').val();
        var CounNameA = $("#content_drpCountry option:selected").text();
        var CounValA = $("#content_drpCountry option:selected").val();
        var StateNameA = $('#content_drpState option:selected').text();
        var StateValA = $('#content_drpState option:selected').val();
        var CityA = $("#txtCityA").val();
        var PINA = $("#txtPostalCodeA").val();
        var StateMan = $('#content_lblStateMan').text();
        var AddInfo = $('#txtAdditionalInfo').val();
        var HomePhone = $('#txtHomePhone').val();
        var MobPhone = $('#txtMobilePhone').val();
        var alias = $('#txtalias').val();
        if (StateMan === 'Yes') {
            if (FNameA === "" || AddA === "" || (CounValA === "" || CounValA === "Select")   
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