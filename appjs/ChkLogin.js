
var path = window.location.href;

if (path.includes("?")) {
    //debugger;
    $.ajax({
        method: 'POST',
        url: 'checklogin.asmx/chkLogin',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response) {

    }, function (error) {

    });
}
else {
    debugger;
    var username = getCookie("FTUser");
    if (username != "") {
        window.location.href = "DashBoard.aspx";
    }
}

function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}