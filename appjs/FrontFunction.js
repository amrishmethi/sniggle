//var emailpattern = /^([a-z A-Z 0-9 _\.\-])+\@(([a-z A-Z 0-9\-])+\.)+([a-z A-z 0-9]{2,3})+$/;
var emailpattern = new RegExp(/^[+a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/i);

function NewsLetter() {
    var Email = $('#txtNewsletterEmail').val();
    if (!emailpattern.test(Email)) {
        tostpro("Please Enter Your Email", 'Error', 'error', 'top-right', '2000');
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
            window.location.reload();
        }
        else {
            alert(response.d);
        }
    }, function (error) {
    });
};

function NewsLetterFooter() {
    var Email = $('#txtNewsletterEmailFooter').val();
    if (!emailpattern.test(Email)) {
        tostpro("Please Enter Your Email", 'Error', 'error', 'mid-center', '2000');
        return;
    }
    $.ajax({
        method: 'POST',
        url: '../FrontFunction.asmx/NewsletterSubmit',
        data: '{Email: "' + Email + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        if (response.d == "Success") {
            tostpro("Thank you for your subscription", 'Success', 'success', 'mid-center', '2000');
            setTimeout(function () {
                window.location.reload();
            }, 5000);
        }
        else {
            alert(response.d);
        }
    }, function (error) {
    });
};

function NewsLetterChecked() {
    var dd = $('#chkNewletter').is(':checked');
    $.ajax({
        method: 'POST',
        url: '../FrontFunction.asmx/DoNotShowAgain',
        data: '{Status: "' + dd + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        if (response.d == "Success") {
            window.location.reload();
        }
        else {
            alert(response.d);
        }
    }, function (error) {
    });
};

function NewsLetterCheckedMob() {
    var dd = $('#chkNewletterMob').is(':checked');
    $.ajax({
        method: 'POST',
        url: '../FrontFunction.asmx/DoNotShowAgain',
        data: '{Status: "' + dd + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        if (response.d == "Success") {
            ;
            window.location.reload();
        }
        else {
            alert(response.d);
        }
    }, function (error) {

    });
};

function NewsLetterCheckedClose() {
    var dd = "true";
    $.ajax({
        method: 'POST',
        url: '../FrontFunction.asmx/DoNotShowAgain',
        data: '{Status: "' + dd + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        if (response.d == "Success") {
            ;
            //window.location.reload();
        }
        else {
            alert(response.d);
        }
    }, function (error) {

    });
};

function SubmitEnquiryForm() { 
    $('#aSubmitEnquiryForm').hide();
    $('#btnPleaseWait').show();
    var refNo = $('#skuquik').html();
    var CustName = $('#txtcommentCustomerName').val();
    var CustEmail = $('#txtcommentCustomerEmail').val();
    var Subject = $('#txtCommentSubject').val();
    var msg = $('#txtCommentMessage').val();
    var img = $('#ContentPlaceHolder1_lblImg').text();
    var price = $('#disprice').html();
    var ProdId = $('#ContentPlaceHolder1_lblProdId').text();
    var ProdName = $('#productName').html();
    var sss = $('#lblImg').html();
    var ssdds = $('#lblProdId').html();
    if (img == "") {
        img = $('#lblImg').html();
    }
    if (ProdId == "") {
        ProdId = $('#lblProdId').html();
    }
    if (CustName === "" || CustEmail === "" || msg === "") {
        tostpro("Please enter required fields", 'error', 'error', 'mid-center', '2000');
        if (CustName === "") {
            validation('fieldReq1');
        }
        if (CustEmail === "") {
            validation('fieldReq2');
        }
        if (msg === "") {
            validation('fieldReq3');
        }
        $('#aSubmitEnquiryForm').show();
        $('#btnPleaseWait').hide();
        return;
    }

    if (!emailpattern.test(CustEmail)) {
        tostpro("Please enter valid email address", 'Error', 'error', 'top-right', '2000'); 
        $('#aSubmitEnquiryForm').show();
        $('#btnPleaseWait').hide();
        return;
    }

    $.ajax({
        method: 'POST',
        url: '/FrontFunction.asmx/EnquiryAboutProduct',
        data: '{CustName: "' + CustName + '", CustEmail: "' + CustEmail + '",Subject: "' + Subject + '",msg: "' + msg + '",img: "' + img + '",price: "' + price + '",ProdId: "' + ProdId + '",ProdName: "' + ProdName + '",refNo: "' + refNo + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        if (response.d == "Success") {
            tostpro("Enquiry Submitted Successfully", 'Success', 'success', 'mid-center', '2000');

            $('#custEnquiryModel').modal('hide');
            $('#txtcommentCustomerName').val('');
            $('#txtcommentCustomerEmail').val('');
            $('#txtCommentSubject').val('');
            $('#txtCommentMessage').val('');
            $('#aSubmitEnquiryForm').show();
            $('#btnPleaseWait').hide();
        }
        else {
            alert(response.d);
        }
    }, function (error) {

    });
};

function SubmitEnquiryFormFromDtailPage() {
    $('#aSubmitEnquiryForm').hide();
    $('#btnPleaseWait').show();
    var refNo = $('#skuquik').html();
    var CustName = $('#txtcommentCustomerNameDtailPage').val();
    var CustEmail = $('#txtcommentCustomerEmailDtailPage').val();
    var Subject = $('#txtCommentSubjectDtailPage').val();
    var msg = $('#txtCommentMessageDtailPage').val();
    var img = $('#ContentPlaceHolder1_lblImgDtailPage').text();
    var price = $('#dispricequik').html();
    var ProdId = $('#ContentPlaceHolder1_lblProdIdDtailPage').text();
    var ProdName = $('#ContentPlaceHolder1_lblCusrProdNameCustEnq').text();
    if (img == "") {
        img = $('#lblImg').html();
    }
    if (ProdId == "") {
        ProdId = $('#lblProdId').html();
    }
    if (CustName === "" || CustEmail === "" || msg === "") {
        tostpro("Please enter required fields", 'error', 'error', 'mid-center', '2000');
        if (CustName === "") {
            validation('fieldReq1');
        }
        if (CustEmail === "") {
            validation('fieldReq2');
        }
        if (msg === "") {
            validation('fieldReq3');
        }
        $('#aSubmitEnquiryForm').show();
        $('#btnPleaseWait').hide();
        return;
    }
    if (!emailpattern.test(CustEmail)) {
        tostpro("Please enter valid email address", 'Error', 'error', 'top-right', '2000'); 
        $('#aSubmitEnquiryForm').show();
        $('#btnPleaseWait').hide();
        return;
    }
    $.ajax({
        method: 'POST',
        url: '/FrontFunction.asmx/EnquiryAboutProduct',
        data: '{CustName: "' + CustName + '", CustEmail: "' + CustEmail + '",Subject: "' + Subject + '",msg: "' + msg + '",img: "' + img + '",price: "' + price + '",ProdId: "' + ProdId + '",ProdName: "' + ProdName + '",refNo: "' + refNo + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        if (response.d == "Success") {

            tostpro("Enquiry Submitted Successfully", 'Success', 'info', 'mid-center', '2000');
            $('#myModal1').modal('hide');
            $('#custEnquiryModelOnDetail').modal('hide');
            $('#txtcommentCustomerNameDtailPage').val('');
            $('#txtcommentCustomerEmailDtailPage').val('');
            $('#txtCommentSubjectDtailPage').val('');
            $('#txtCommentMessageDtailPage').val('');
            $('#aSubmitEnquiryForm').show();
            $('#btnPleaseWait').hide();
        }
        else {
            //alert(response.d);
        }
    }, function (error) {
    });
};

function SubmitReferFriend() {
    var CustName = $('#txtFriendName').val();
    var CustEmail = $('#txtFriendEmail').val();
    var img = $('#ContentPlaceHolder1_lblImgDtailPage').text();
    var ProdId = $('#ContentPlaceHolder1_lblProdIdDtailPage').text();
    var ProdName = $('#ContentPlaceHolder1_lblCusrProdNameCustEnq').text();
    if (img == "") {
        img = $('#lblImg').html();
    }
    if (ProdId == "") {
        ProdId = $('#lblProdId').html();
    }
    if (CustName === "" || CustEmail === "") {
        tostpro("Please enter required fields", 'error', 'error', 'mid-center', '2000');
        if (CustName === "") {
            validation('fieldReq4');
        }
        if (CustEmail === "") {
            validation('fieldReq5');
        }
        return;
    }
    $.ajax({
        method: 'POST',
        url: '/FrontFunction.asmx/SubmitReferFriend',
        data: '{CustName: "' + CustName + '", CustEmail: "' + CustEmail + '",img: "' + img + '",ProdId: "' + ProdId + '",ProdName: "' + ProdName + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        if (response.d == "Success") {
            tostpro("Submitted Successfully", 'Success', 'info', 'mid-center', '2000');
            $('#shareprodonemail').modal('hide');
            $('#txtFriendName').val('');
            $('#txtFriendEmail').val('');
        }
        else {
            alert(response.d);
        }
    }, function (error) {
    });
};

function SubmitReferFriendQuickView() {
    var CustName = $('#txtFriendNameQuickView').val();
    var CustEmail = $('#txtFriendEmailQuickView').val();
    var img = $('#ContentPlaceHolder1_lblImg').text();
    var ProdId = $('#ContentPlaceHolder1_lblProdId').text();
    var ProdName = $('#productName').html();
    if (img == "") {
        img = $('#lblImg').html();
    }
    if (ProdId == "") {
        ProdId = $('#lblProdId').html();
    }
    if (CustName === "" || CustEmail === "") {
        tostpro("Please enter required fields", 'error', 'error', 'mid-center', '2000');
        if (CustName === "") {
            validation('fieldReq4');
        }
        if (CustEmail === "") {
            validation('fieldReq5');
        }
        return;
    }
    $.ajax({
        method: 'POST',
        url: '/FrontFunction.asmx/SubmitReferFriend',
        data: '{CustName: "' + CustName + '", CustEmail: "' + CustEmail + '",img: "' + img + '",ProdId: "' + ProdId + '",ProdName: "' + ProdName + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        if (response.d == "Success") {
            tostpro("Submitted Successfully", 'Success', 'info', 'mid-center', '2000');
            $('#shareprodonemail').modal('hide');
            $('#txtFriendNameQuickView').val('');
            $('#txtFriendEmailQuickView').val('');
        }
        else {
            alert(response.d);
        }
    }, function (error) {
    });
};

function SubmitReferFriendBlog() { 
    $('#aReferFriend').hide();
    $('#btnPleaseWait').show();
    var ProdId = "";
    var CustName = $('#txtFriendNameBlog').val();
    var CustEmail = $('#txtFriendEmailBlog').val();
    var img = $('#ContentPlaceHolder1_lblBlogImg').html(); 
    var ProdName = $('#ContentPlaceHolder1_lblBolgName').html();
    var Url = $('#ContentPlaceHolder1_lblBolgDtlUrl').html();
    if (CustName === "" || CustEmail === "") {
        tostpro("Please enter required fields", 'error', 'error', 'mid-center', '2000');
        if (CustName === "") {
            validation('fieldReq4');
        }
        if (CustEmail === "") {
            validation('fieldReq5');
        }
        $('#aReferFriend').show();
        $('#btnPleaseWait').hide();
        return;
    }

    if (!emailpattern.test(CustEmail)) {
        tostpro("Please enter valid email address", 'Error', 'error', 'top-right', '2000');
        $('#aReferFriend').show();
        $('#btnPleaseWait').hide();
        return;
    }
    $.ajax({
        method: 'POST',
        url: '/NFunction.asmx/SubmitBlogReferFriend',
        data: '{CustName: "' + CustName + '", CustEmail: "' + CustEmail + '",img: "' + img + '",ProdId: "' + ProdId + '",ProdName: "' + ProdName + '",Url: "' + Url + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        if (response.d == "Success") {
            tostpro("Submitted Successfully", 'Success', 'info', 'mid-center', '2000');
            $('#shareBLOGonemail').modal('hide');
            $('#txtFriendNameBolg').val('');
            $('#txtFriendEmailBolg').val('');
            $('#aReferFriend').show();
            $('#btnPleaseWait').hide();
        }
        else {
            alert(response.d);
        }
    }, function (error) {
    });
};

function addReviewnew() {
    var Rating = $("input[name='criterion[1]']").val();
    var Name = $('#custName').val();
    var Comment = $('#review').val();
    var Title = $('#title').val();
    if (Name == "") {
        $('#reqName').show();
        tostpro("Please Fill All Required Fields.", 'Error', 'error', 'top-right', '2000');
        return;
    }
    else {

        $('#reqName').hide();
        var path = window.location.href;
        var Slug = path;

        $.ajax({
            method: 'POST',
            url: '../FrontWeb.asmx/addProductReview',
            data: '{Slug: "' + Slug + '", Name:"' + Name + '",Rating:"' + Rating + '",Title:"' + Title + '",Comment:"' + Comment + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            if (response.d === "Success") {
                var price = response.data;
                price = price.d;
                $('#custName').val('');
                $('#review').val('');
                $('#title').val('');
                $('#reqMessage').show();
                tostpro("Review Send Successfully.", 'Message', 'success', 'mid-center', '2000');
                $('#myModalreview').modal('hide');
            }
            else {
                tostpro("Failed.", 'Error', 'error', 'top-right', '2000');
            }
        }, function (error) {
        });
    }
};

function SubmitCreativeCutsForms() {
    var CustName = $('#txtCreativeCutsName').val();
    var CustEmail = $('#txtCreativeCutsEmail').val();
    var dsd = $('#txtCreativeCutsDescription').val();
    var description = $('#txtCreativeCutsDescription').val();
    var img = $('#CreativeCutsfileToUpload').text();
    var ProdName = $('#hProductName').text();
    var prodImg = $('#hddProdImgCC').val();
    var imgName = '';
    var fileUpload = $("#CreativeCutsfileToUpload").get(0);
    var files = fileUpload.files;
    var Imgg = new FormData();
    for (var i = 0; i < files.length; i++) {
        imgName = files[i].name;
        Imgg.append(files[i].name, files[i]);
    }

    if (CustName === "" || CustEmail === "") {
        tostpro("Please enter required fields", 'error', 'error', 'mid-center', '2000');
        if (CustName === "") {
            validation('fieldReq1');
        }
        if (CustEmail === "") {
            validation('fieldReq2');
        }
        return;
    }
    if (!emailpattern.test(CustEmail)) {
        tostpro("Please enter valid email address", 'Error', 'error', 'top-right', '2000');
        $scope.loading = false;
        return;
    }
    $.ajax({
        method: 'POST',
        url: '/FrontFunction.asmx/SubmitCreatinveCuts',
        data: '{CustName: "' + CustName + '", CustEmail: "' + CustEmail + '",img: "' + imgName + '",description: "' + description + '",ProdName: "' + ProdName + '",prodImg: "' + prodImg + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
        var result = response.d.split('_');
        if (result[0] === "Success") {
            var EntryType = 'Creattive';
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
            $('#txtCreativeCutsName').val('');
            $('#txtCreativeCutsEmail').val('');
            $('#txtCreativeCutsDescription').val('');
            $('#txtMessage').val('');
            $("#fileUpload").val('');
        }
        else {
            tostpro("Please Fill Required Fields.", 'Error', 'error', 'mid-center', '2500');
        }
    }, function (error) {
    });
};


window.fbAsyncInit = function () {
    FB.init({
        appId: '325767557950729',
        xfbml: true,
        version: 'v3.2'
    });
    //Not In Face Book
    FB.getLoginStatus(function (response) {
        if (response.status === 'connected') { }
    });
    FB.AppEvents.logPageView();
};

(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement(s); js.id = id;
    // In Face Book
    js.src = "https://connect.facebook.net/en_US/sdk.js";
    //js.src = "//connect.facebook.net/en_US/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
}
    (document, 'script', 'facebook-jssdk'));


//Login FB from root start
function loginfb() {

    FB.login(function (response) {
        if (response.status === 'connected') {
            info();
        }
    }, { scope: 'email, public_profile' });
};

function info() {
    FB.api('/me?fields=id,name,email, gender, first_name,last_name,picture', function (response) {
        var name = response.first_name + " " + response.last_name;
        $.ajax({
            type: "POST",
            url: '/FrontWeb.asmx/AppLogin',
            data: '{email: "' + response.email + '",name: "' + name + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessf, failure: function (response) {
                //window.location.href = "/my-account";
            }
        });
    });
}
function OnSuccessf(response) {
    if (response.d != "Yes") {
        window.location.href = "/my-account";
    }
    else
        window.location.href = "/my-account";
}

//Login FB from root end

//Login FB from shooing cart start
function loginfb1() {

    FB.login(function (response) {
        if (response.status === 'connected') {
            info1();
        }
    }, { scope: 'email, public_profile' });
};

function info1() {
    FB.api('/me?fields=id,name,email, gender, first_name,last_name,picture', function (response) {
        var name = response.first_name + " " + response.last_name;
        $.ajax({
            type: "POST",
            url: '/FrontWeb.asmx/AppLogin',
            data: '{email: "' + response.email + '",name: "' + name + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessf1, failure: function (response) {
                //window.location.href = "/my-account";
            }
        });
    });
}
function OnSuccessf1(response) {
    if (response.d != "Yes") {
        window.location.href = "/ShoppingCart.aspx?step-2";
    }
    else
        window.location.href = "/ShoppingCart.aspx?step-2";
}
//Login FB from shooing cart end
$(".txtCustMsg").change(function () {
    var msg = $('.txtCustMsg').val();
    $.ajax({
        method: 'POST',
        url: '../FrontFunction.asmx/CustMsgOnPayment',
        data: '{msg: "' + msg + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {
    }, function (error) {
    });
});
$(document).ready(function () {
    tostpro = function (text, heading, icon, position, hideAfter) {
        $.toast({
            text: text,
            heading: heading,
            icon: icon,
            position: position,
            hideAfter: hideAfter
        });
    };
});

function quickViewImgPopupCreativeCut() {
    let thumbnails = document.getElementsByClassName('thumbnail2');
    let activeImages = document.getElementsByClassName('active');
    //$('.modClass').removeClass('active');  
    $('#featured').hide();
    $('.mySlides').show();
};
