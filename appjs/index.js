$(document).ready(function () {
    $('.bb:first').addClass('active');
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    document.getElementById("divNew1").style.display = "block";
    $('.tabcontent:first').addClass('active show');
});
function rptActive(evt, cityName) {
    var lastChar = cityName[cityName.length - 1];
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace("tabcontent", "");
    }
    document.getElementById("divNew" + lastChar).style.display = "block";
    document.getElementById("divNew" + lastChar).addClass = "active show";
}