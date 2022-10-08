/// <reference path="../angjs/angular.min.js" />

app.controller('CMSController', function ($scope, $http) { 
    $scope.addContactUs = function () {
        debugger
        $scope.loading = true;
        var Name = $('#txtName').val();
        var Email = $('#txtEmail').val();
        var Subject = $('#txtSubject').val();
        var msg = $('#txtMessage').val();
        var EntryType = "Con";
        var imgName = 'tes';
        //var fileUpload = $("#fileUpload").get(0);
        //var files = fileUpload.files;
        //var Imgg = new FormData();
        //for (var i = 0; i < files.length; i++) {
        //    imgName = 'Con_' + files[i].name;
        //    Imgg.append(files[i].name, files[i]);
        //}
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
                
                $scope.loading = false;
                tostpro("Detail Submitted Successfully.", 'Success', 'success', 'mid-center', '2500');
                setTimeout(function () {
                    document.location.reload()
                }, 3000);
                $('#txtName').val('');
                $('#txtEmail').val('');
                $('#txtSubject').val('');
                $('#txtMessage').val(''); 
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