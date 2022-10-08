$(document).ready(function () {
    getLocation();
});
    function getLocation() {
        debugger
            if (navigator.geolocation) {
        //document.getElementById('ctl00_ContentPlaceHolder1_divdata').innerHTML = "wel";
        navigator.geolocation.getCurrentPosition(showPosition);

            } else {
        document.getElementById('divdata').innerHTML = ("");
}
}


        function showPosition(position) {
        //alert(position);
    document.getElementById('hddLat').value = position.coords.latitude;
    document.getElementById('hddLong').value = position.coords.longitude;
   // alert(document.getElementById('hddLat').value);
  //  alert(document.getElementById('hddLong').value);
    //document.getElementById('hdddata').value = position.coords.latitude +
     //   "," + position.coords.longitude;

    var latvalue = position.coords.latitude;
    var longvalue = position.coords.longitude;

    getcityname(latvalue, longvalue);

}
    
        function getcityname(latvalue, longvalue) {
            var geocoder;
        geocoder = new google.maps.Geocoder();
        var latlng = new google.maps.LatLng(latvalue, longvalue);

         //alert(latlng);
        geocoder.geocode(
                {'latLng': latlng },
                function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        if (results[0]) {
                            var add = results[0].formatted_address;
        var value = add.split(",");

        count = value.length;
        var places = "";
                            for (var i = 0; i < count; i++) {
            places = places + value[i];
    }
//alert(places);

    document.getElementById('hddPlace').value = places;
  //  alert(places);
    document.getElementById('lblGeo').innerHTML = "Place Name : " + places;
    country = value[count - 1];
    state = value[count - 2];
    city = value[count - 3];
    // alert("city name is: " + add);
}
                        else {
            //alert("address not found");
        }
        }
                    else {
            //alert("Geocoder failed due to: " + status);
        }
        }
    );
}
   