$(document).ready(function () {

    var pincodepattern = /^\d{6}$/;
    var mobilenopattern = /^\d{10}$/;
    //var emailpattern = /^([a-z A-Z 0-9 _\.\-])+\@(([a-z A-Z 0-9\-])+\.)+([a-z A-z 0-9]{2,3})+$/;
    var emailpattern = new RegExp(/^[+a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/i);
    //For Required
    $(".fieldReq1").on("blur", function () {
        var a = $('.fieldReq1').val().trim();
        if (a === '') {
            $(".fieldReq1").addClass("error");
            return false;
        }
        else {
            $(".fieldReq1").removeClass("error");
            return true;
        }
    });

    $(".fieldReq2").on("blur", function () {
        var a = $('.fieldReq2').val().trim();
        if (a === '') {
            $(".fieldReq2").addClass("error");
            return false;
        }
        else {
            $(".fieldReq2").removeClass("error");
            return true;
        }
    });


    $(".fieldReq3").on("blur", function () {
        var a = $('.fieldReq3').val().trim();
        if (a === '') {
            $(".fieldReq3").addClass("error");
            return false;
        }
        else {
            $(".fieldReq3").removeClass("error");
            return true;
        }
    });

    $(".fieldReq4").on("blur", function () {
        var a = $('.fieldReq4').val().trim();
        if (a === '') {
            $(".fieldReq4").addClass("error");
            return false;
        }
        else {
            $(".fieldReq4").removeClass("error");
            return true;
        }
    });

    $(".fieldReq5").on("blur", function () {
        var a = $('.fieldReq5').val().trim();
        if (a === '') {
            $(".fieldReq5").addClass("error");
            return false;
        }
        else {
            $(".fieldReq5").removeClass("error");
            return true;
        }
    });

    $(".fieldReq6").on("blur", function () {
        var a = $('.fieldReq6').val().trim();
        if (a === '') {
            $(".fieldReq6").addClass("error");
            return false;
        }
        else {
            $(".fieldReq6").removeClass("error");
            return true;
        }
    });

    $(".fieldReq7").on("blur", function () {
        var a = $('.fieldReq7').val().trim();
        if (a === '') {
            $(".fieldReq7").addClass("error");
            return false;
        }
        else {
            $(".fieldReq7").removeClass("error");
            return true;
        }
    });

    $(".fieldReq8").on("blur", function () {
        var a = $('.fieldReq8').val().trim();
        if (a === '') {
            $(".fieldReq8").addClass("error");
            return false;
        }
        else {
            $(".fieldReq8").removeClass("error");
            return true;
        }
    });

    $(".fieldReq9").on("blur", function () {
        var a = $('.fieldReq9').val().trim();
        if (a === '') {
            $(".fieldReq9").addClass("error");
            return false;
        }
        else {
            $(".fieldReq9").removeClass("error");
            return true;
        }
    });

    $(".fieldReq10").on("blur", function () {
        var a = $('.fieldReq10').val().trim();
        if (a === '') {
            $(".fieldReq10").addClass("error");
            return false;
        }
        else {
            $(".fieldReq10").removeClass("error");
            return true;
        }
    });

    $(".fieldReq11").on("blur", function () {
        var a = $('.fieldReq11').val().trim();
        if (a === '') {
            $(".fieldReq11").addClass("error");
            return false;
        }
        else {
            $(".fieldReq11").removeClass("error");
            return true;
        }
    });

    $(".fieldReqDrop1").on("blur", function () {
        var a = $(".fieldReqDrop1 option:selected").val();
        if (a === '') {
            $(".fieldReqDrop1").addClass("error");
            return false;
        }
        else {
            $(".fieldReqDrop1").removeClass("error");
            return true;
        }
    });


    //For Mobile No 
    $(".MobileV").on("blur", function () {
        var mobNum = $(".MobileV").val();
        if (mobNum != '') {
            if (!mobilenopattern.test(mobNum)) {
                tostpro("Please enter Valid Mobile Number.", 'Message', 'error', 'mid-center', '2000');
                //$('.btnSubmita').hide();
                return false;
            }
            else {
                //$('.btnSubmita').show();
            }
        }
        else {
            tostpro("Please enter Mobile Number.", 'Message', 'error', 'mid-center', '2000');
        }
    });
    //For Email Id 
    $(".EmailIdV").on("blur", function () { 
        var emailV = $(".EmailIdV").val();
        if (emailV != '') {
            if (!emailpattern.test(emailV)) {
                $(".EmailIdV").addClass("error");
                tostpro("Please enter valid email address.", 'Message', 'error', 'mid-center', '2000');
                //$('.btnSubmita').hide();
                return false;
            }
            else {
                $(".EmailIdV").removeClass("error");
                //$('.btnSubmita').show();
            }
        }
        else {
            tostpro("Please enter email.", 'Message', 'error', 'mid-center', '2000');
        }
    });
    //For Email Id 
    $(".EmailIdV1").on("blur", function () {
        var emailV = $(".EmailIdV1").val();
        if (emailV != '') {
            if (!emailpattern.test(emailV)) {
                $(".EmailIdV1").addClass("error");
                tostpro("Please enter valid email address.", 'Message', 'error', 'mid-center', '2000');
                //$('.btnSubmita').hide();
                return false;
            }
            else {
                $(".EmailIdV1").removeClass("error");
                //$('.btnSubmita').show();
            }
        }
        else {
            tostpro("Please enter email.", 'Message', 'error', 'mid-center', '2000');
        }
    });

    //For Email Id 
    $(".EmailIdVM").on("blur", function () {
        var emailV = $(".EmailIdVM").val();
        if (emailV != '') {
            if (!emailpattern.test(emailV)) {
                $(".EmailIdVM").addClass("error");
                tostpro("Please enter valid email address.", 'Message', 'error', 'mid-center', '2000');
                //$('.btnSubmita').hide();
                return false;
            }
            else {
                $(".EmailIdVM").removeClass("error");
                //$('.btnSubmita').show();
            }
        }
        else {
            tostpro("Please enter email.", 'Message', 'error', 'mid-center', '2000');
        }
    });
    //For Email Id 
    $(".EmailIdVM1").on("blur", function () {
        var emailV = $(".EmailIdVM1").val();
        if (emailV != '') {
            if (!emailpattern.test(emailV)) {
                $(".EmailIdVM1").addClass("error");
                tostpro("Please enter valid email address.", 'Message', 'error', 'mid-center', '2000');
                //$('.btnSubmita').hide();
                return false;
            }
            else {
                $(".EmailIdVM1").removeClass("error");
                //$('.btnSubmita').show();
            }
        }
        else {
            tostpro("Please enter email.", 'Message', 'error', 'mid-center', '2000');
        }
    });
    //For Email Id 
    $(".EmailIdVM2").on("blur", function () {
        var emailV = $(".EmailIdVM1").val();
        if (emailV != '') {
            if (!emailpattern.test(emailV)) {
                $(".EmailIdVM1").addClass("error");
                tostpro("Please enter valid email address.", 'Message', 'error', 'mid-center', '2000');
                //$('.btnSubmita').hide();
                return false;
            }
            else {
                $(".EmailIdVM1").removeClass("error");
                //$('.btnSubmita').show();
            }
        }
        else {
            tostpro("Please enter email.", 'Message', 'error', 'mid-center', '2000');
        }
    });
    //For Email Id 
    $(".EmailIdVPOP").on("blur", function () {
        var emailV = $(".EmailIdVPOP").val();
        if (emailV != '') {
            if (!emailpattern.test(emailV)) {
                $(".EmailIdVPOP").addClass("error");
                tostpro("Please enter valid email address.", 'Message', 'error', 'mid-center', '2000');
                //$('.btnSubmita').hide();
                return false;
            }
            else {
                $(".EmailIdVPOP").removeClass("error");
                //$('.btnSubmita').show();
            }
        }
        else {
            tostpro("Please enter email.", 'Message', 'error', 'mid-center', '2000');
        }
    });


    //For Character Length Validation
    $(".charLength").on("blur", function () {
        var a = $(".charLength").val().length;
        if (a >= 5) {
            return true;
        }
        else {
            tostpro('Please enter minimum five characters for password.', 'Error', 'error', 'top-right', '2000');
            $(".charLength").addClass("not_valid");
            return false;
        }
    });

    tostpro = function (text, heading, icon, position, hideAfter) {
        $.toast({
            text: text,
            heading: heading,
            icon: icon,
            position: position,
            hideAfter: hideAfter
        });
    };

    (function ($) {
        $.fn.inputFilter = function (inputFilter) {
            return this.on("input keydown keyup mousedown mouseup select contextmenu drop", function () {
                if (inputFilter(this.value)) {
                    this.oldValue = this.value;
                    this.oldSelectionStart = this.selectionStart;
                    this.oldSelectionEnd = this.selectionEnd;
                } else if (this.hasOwnProperty("oldValue")) {
                    this.value = this.oldValue;
                    this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
                } else {
                    this.value = "";
                }
            });
        };
    }(jQuery));

    //Only Integer value allowed
    $(".integerV").inputFilter(function (value) {
        return /^-?\d*$/.test(value);
    });

    //at most two decimal places
    $(".integerWithTwoDecimalV").inputFilter(function (value) {
        return /^-?\d*[.,]?\d{0,2}$/.test(value);
    });

    //Validation for Float Value
    $(".floatV").inputFilter(function (value) {
        return /^-?\d*[.,]?\d*$/.test(value);
    });

    //Validation for A-Z value
    $(".AtoZV").inputFilter(function (value) {
        return /^[a-z]*$/i.test(value);
    });

    //Validation for Hexadecimal value
    $(".hexadecimalV").inputFilter(function (value) {
        return /^[0-9a-f]*$/i.test(value);
    });

    //Validation for between integer values Limit
    $(".intlimitV").inputFilter(function (value) {
        return /^\d*$/.test(value) && (value === "" || parseInt(value) <= 500);
    });

    //Validation for file
    Filevalidation = () => {
        const fi = document.getElementById('file');
        // Check if any file is selected.
        if (fi.files.length > 0) {
            for (const i = 0; i <= fi.files.length - 1; i++) {

                const fsize = fi.files.item(i).size;
                const file = Math.round((fsize / 1024));
                // The size of the file.
                if (file >= 4096) {
                    alert(
                        "File too Big, please select a file less than 4mb");
                } else if (file < 2048) {
                    alert(
                        "File too small, please select a file greater than 2mb");
                } else {
                    document.getElementById('size').innerHTML = '<b>'
                        + file + '</b> KB';
                }
            }
        }
    }
});
