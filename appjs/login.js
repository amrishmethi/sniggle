var emailpattern = new RegExp(/^[+a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/i);

app.controller('registerController', function ($scope, $http) {
    $http({
        method: 'POST',
        url: '../loginWS.asmx/GetCountryList',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        debugger
        var dd = response.data;
        dd = dd.d;
        $scope.CountryList = JSON.parse(dd); 
    }, function (error) {
    }); 

    $scope.StateListfn = function (th) {
        var ddd = $scope.selectedItem;
        $http({
            method: 'POST',
            url: '../loginWS.asmx/GetStateList',
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
});

app.controller('pwdRecoveryController', function ($scope, $http) {
    $scope.loading = true; 
    var path = window.location.href;
    var pp1 = path.split('?');
    var dd = pp1[1].replace("token=", "");;
    $http({
        method: 'POST',
        url: '/loginWS.asmx/UpdatePwd',
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

function CustomerLogin() {
    var Email = $('#txtCustomerEmail').val();
    var pwd = $('#txtCustomerPassword').val();
    if (Email === "" || pwd === "") {
        tostpro("Please Enter Your Email Id and Password", 'Error', 'error', 'top-right', '2000');
        return;
    }
    $.ajax({
        method: 'POST',
        url: '../loginWS.asmx/CustomerLogin',
        data: '{Email: "' + Email + '",Pwd: "' + pwd + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        if (response.d === "Success") {
            window.location.reload();
        }
        else {
            if (response.d === "ChangePwd") {
                tostpro("We have updated our website with new products, so if you are not able to login your account please reset your password first via forgot password option.", 'Message', 'info', 'top-right', '15000');
            }
            else {
                tostpro("Authentication failed.", 'Error', 'error', 'top-right', '2000');
            }
        }
    }, function (error) {
    });
};

function CustomerLogin1() {
    var Email = $('#txtCustomerEmail1').val();
    var pwd = $('#txtCustomerPassword1').val();
    if (Email === "" || pwd === "") {
        tostpro("Please Enter Your Email Id and Password", 'Error', 'error', 'mid-center', '2000');
        return;
    }
    $.ajax({
        method: 'POST',
        url: '../loginWS.asmx/CustomerLogin',
        data: '{Email: "' + Email + '",Pwd: "' + pwd + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        if (response.d === "Success") {
            var path = window.location.href;
            var Slug = path;
            if (Slug.includes("Shopping")) {
                window.location.href = "/ShoppingCart.aspx?step-1";
            }
            else {
                window.location.href = "/";
            }
        }
        else {
            if (response.d === "ChangePwd") {
                tostpro("Due to security reasons, we have updated our website, so if you are not able to login your account please reset your password first via forget password option.", 'Message', 'info', 'top-right', '15000');
            }
            else {
                tostpro("Authentication failed.", 'Message', 'error', 'mid-center', '2000');
            }
        }
    }, function (error) {
    });
};

function CustomerExists() {
    debugger
    var Email = $('#txtEmailExists').val();
    if (Email === "" || Email === null) {
        tostpro("Invalid email address.", 'Error', 'error', 'mid-center', '2000');
        return;
    };
    if (!emailpattern.test(Email)) {
        tostpro("Invalid email address.", 'Error', 'error', 'mid-center', '2000');
        return;
    }

    $.ajax({
        method: 'POST',
        url: '../loginWS.asmx/CheckCustomer',
        data: '{Email: "' + Email + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        if (response.d === "Not Exists") {
            window.location.href = "/registration";
        }
        else {
            tostpro("An account using this email address has already been registered. Please enter a valid password or request a new one.", 'Error', 'error', 'top-right', '5000');
        }
    }, function (error) {
    });
};

function CustomerRegistration() {
    debugger
    var gender = $("input[name='id_gender']:checked").val();
    var FName = $('#txtFirstName').val();
    var LName = $('#txtLastName').val();
    var Email = $('#content_txtEmail').val();
    var Pwd = $('#txtPassword').val();
    var dob = $('#txtDOB').val();
    var RecOff = $("input[name='chkReceiveOffer']:checked").val();
    var NewsL = $("input[name='chknewsletter']:checked").val();
    var TC = $("input[name='chkTC']:checked").val();
    var FNameA = $('#txtFirstNameA').val();
    var LNameA = $('#txtLastNameA').val();
    var CompA = $('#txtCompanyA').val();
    var AddA = $('#txtAddressA').val();
    //var CounNameA = $("#drpCountryA option:selected").text();
    //var CounValA = $("#drpCountryA option:selected").val();
    //var StateNameA = $("#drpStateA option:selected").text();
    //var StateValA = $("#drpStateA option:selected").val();
    var CounNameA = "India";
    var CounValA = "110";
    var StateNameA = $("#txtStateA").val();
    var StateValA ="313";
    var CityA = $("#txtCityA").val();
    var PINA = $("#txtPostalCodeA").val();
    var AddInfo = $('#txtAdditionalInfo').val();
    var HomePhone = $('#txtHomePhone').val();
    var MobPhone = $('#txtMobilePhone').val();
    var alias = $('#txtalias').val();
    var StateCount = $('#lblStateMan').val();
    if (!emailpattern.test(Email)) {
        tostpro("Invalid email address.", 'Error', 'error', 'mid-center', '2000');
        return;
    }
    if (StateCount > 0) {
        if (FName === "" || Email === "" || Pwd === "" || FNameA === "" || AddA === "" || (CounValA === "" || CounValA === "Select" || CounNameA === "") ||
            (StateValA === "" || StateValA === "Select") || PINA === "" || (HomePhone === "" && MobPhone === "")) {
            tostpro("Please Fill All Required Fields.", 'Error', 'error', 'mid-center', '2000');
            if (FName === "") {
                validation('fieldReq1');
            }
            if (Email === "") {
                validation('fieldReq2');
            }
            if (Pwd === "") {
                validation('fieldReq3');
            }
            if (dob === "") {
                validation('fieldReq4');
            }
            if (FNameA === "") {
                validation('fieldReq5');
            }
            if (AddA === "") {
                validation('fieldReq6');
            }
            if (CounValA === "" || CounValA === "Select" || CounNameA === "") {
                validation('fieldReq7');
            }
            if (StateValA === "" || StateValA === "Select" || StateValA === "undefined") {
                validation('fieldReq8');
            }
            if (CityA === "") {
                validation('fieldReq9');
            }
            if (PINA === "") {
                validation('fieldReq10');
            }
            return;
        }
    }
    else {
        StateValA = "0";
        if (FName === "" || Email === "" || Pwd === "" || FNameA === "" || AddA === "" ||
            (CounValA === "" || CounValA === "Select" || CounNameA === "") ||
            PINA === "" || (HomePhone === "" && MobPhone === "")) {
            tostpro("Please Fill All Required Fields.", 'Error', 'error', 'mid-center', '2000');
            if (FName === "") {
                validation('fieldReq1');
            }
            if (Email === "") {
                validation('fieldReq2');
            }
            if (Pwd === "") {
                validation('fieldReq3');
            }
            if (dob === "") {
                validation('fieldReq4');
            }
            if (FNameA === "") {
                validation('fieldReq5');
            }
            if (AddA === "") {
                validation('fieldReq6');
            }
            if (CounValA === "" || CounValA === "Select" || CounNameA === "") {
                validation('fieldReq7');
            }
            if (CityA === "") {
                validation('fieldReq9');
            }
            if (PINA === "") {
                validation('fieldReq10');
            }
            return;
        }
    }
    if (TC !== "1") {
        tostpro("Please check privacy policy", 'Error', 'error', 'top-right', '2000');
        return;
    }
    $.ajax({
        method: 'POST',
        url: '../loginWS.asmx/CustomerRegistration',
        data: '{gender: "' + gender + '",FName: "' + FName + '",LName: "' + LName + '",Email: "' + Email + '",Pwd: "' + Pwd + '",dob:"' + dob + '",RecOff:"' + RecOff + '",NewsL: "' + NewsL + '",TC: "' + TC + '",FNameA:"' + FNameA + '",LNameA:"' + LNameA + '",CompA: "' + CompA + '",AddA:"' + AddA + '",CounNameA:"' + CounNameA + '",CounValA: "' + CounValA + '",StateNameA:"' + StateNameA + '",StateValA:"' + StateValA + '",CityA:"' + CityA + '",PINA:"' + PINA + '",AddInfo:"' + AddInfo + '",HomePhone:"' + HomePhone + '",MobPhone:"' + MobPhone + '",alias:"' + alias + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        if (response.d === "Success") {
            window.location.href = "/";
        }
        else {
            tostpro("Authentication failed.", 'Error', 'error', 'top-right', '2000');
        }
    }, function (error) {
    });
};

function CustomerDtlUpdates() {
    var gender = $("input[name='id_gender']:checked").val();
    var FName = $('#txtFirstName').val();
    var LName = $('#txtLastName').val();
    var Email = $('#ContentPlaceHolder1_txtEmail').val();
    var dob = $('#txtDOB').val();
    var RecOff = $("input[name='chkReceiveOffer']:checked").val();
    var NewsL = $("input[name='chknewsletter']:checked").val();
    if (NewsL == 'undefined' || NewsL == undefined || NewsL == '0' || NewsL == 0) {
        NewsL = 0;
    }
    if (FName === "" || Email === "" || dob === "") {
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

function RecoverPwd() {
    $('#btnRetrievePwd').hide();
    $('#btnPleaseWait').show();
    //$('#loading').show();
    var Email = $('#txtEmailPasswordRecover').val();
    if (Email === "" || Email === null) {
        $('#loading').hide();
        tostpro("Invalid email address.", 'Error', 'error', 'top-right', '2000');
        $('#btnRetrievePwd').show();
        $('#btnPleaseWait').hide();
        return;
    };

    $.ajax({
        method: 'POST',
        url: '../loginWS.asmx/RecoverPwd',
        data: '{Email: "' + Email + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        if (response.d === "Success") {
            $('#loading').hide();
            tostpro("Your password reset link has been sent at your email address successfully!", 'Success', 'success', 'top-right', '5000');
            $('#txtEmailPasswordRecover').val('');
            setTimeout(function () {
                window.location.href = 'https://sniggle.in/login';
            }, 5000);
        }
        else {
            $('#btnRetrievePwd').show();
            $('#btnPleaseWait').hide();
            tostpro("This Email address is not registered with us!", 'Error', 'error', 'top-right', '5000');
        }
    }, function (error) {
    });
};

function ChangePwd() {
    debugger
    var NPwd = $('#txtNewPassword').val();
    var CPwd = $('#txtConfirmPassword').val();
    $.urlParam = function (name) {
        var results = new RegExp('[\?&]' + name + '=([^&#]*)')
            .exec(window.location.search);
        return (results !== null) ? results[1] || 0 : false;
    }
    var token = $.urlParam('token');
    if (NPwd !== "" || CPwd !== "") {
        if (NPwd !== CPwd) {
            tostpro("Password not matched..!", 'Error', 'error', 'top-right', '2000');
            return;
        };
    }
    else {
        tostpro("Please Enter New Password and Confirm Password..!", 'Error', 'error', 'top-right', '2000');
        return;
    }
    $.ajax({
        method: 'POST',
        url: '../loginWS.asmx/UpdatePwd',
        data: '{NPwd: "' + NPwd + '", token: "' + token + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        debugger
        if (response.d === "Success") {
            tostpro("Your password updated successfully!", 'Success', 'success', 'top-right', '2000');
            setTimeout(function () {
                window.location.href = 'https://sniggle.in/login';
            }, 2000);
        }
        else if (response.d === "Failed") {
            tostpro("Please try again!", 'Error', 'error', 'top-right', '3000');
        }
        else {
            tostpro(response.d, 'Error', 'error', 'top-right', '3000');
        }
    }, function (error) {

    });
};

function ChangeYrPwd() {
    var CurrentPwd = $('#txtCurrentPassword').val();
    var NPwd = $('#txtNewPassword').val();
    var CPwd = $('#txtConfirmPassword').val();
    if (NPwd !== "" || CPwd !== "" || CurrentPwd !== "") {
        if (NPwd !== CPwd) {
            tostpro("Password not matched..!", 'Error', 'error', 'mid-center', '2000');
            return;
        };
    }
    else {
        tostpro("Please Enter Required Fields!", 'Error', 'error', 'mid-center', '2000');
        return;
    }
    $.ajax({
        method: 'POST',
        url: '../loginWS.asmx/ChangeYourPwd',
        data: '{NPwd: "' + NPwd + '", CurrentPwd: "' + CurrentPwd + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        if (response.d === "Success") {
            tostpro("Your password updated successfully!", 'Success', 'success', 'mid-center', '2000');
            setTimeout(function () {
                window.location.href = '/my-account';
            }, 2000);
        }
        else {
            tostpro("Current password is invalid.", 'Error', 'error', 'mid-center', '2000');
        }
    }, function (error) {

    });
};