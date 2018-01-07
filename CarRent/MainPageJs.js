
var map

function initMap() {
    var locations = [
        ['Ashdod', 31.780357, 34.650026],
        ['tel aviv', 32.064030, 34.786602],
        ['Beer-Sheva', 31.242886, 34.798546],
        ['Haifa', 32.79348881, 34.95783895],
        ['Jerusalem', 31.78869238, 35.20363793]

    ];

    function func() {

        map = new google.maps.Map(document.getElementById('map'), {
            zoom: 8,
            center: new google.maps.LatLng(32.064030, 34.786602),
            mapTypeId: google.maps.MapTypeId.ROADMAP
        });

        var infowindow = new google.maps.InfoWindow();

        var marker, i;

        for (i = 0; i < locations.length; i++) {
            marker = new google.maps.Marker({
                position: new google.maps.LatLng(locations[i][1], locations[i][2]),
                map: map
            });

            google.maps.event.addListener(marker, 'click', (function (marker, i) {
                return function () {
                    infowindow.setContent(locations[i][0]);
                    infowindow.open(map, marker);
                }
            })(marker, i));
        }
      
    }

    setTimeout(func, 1000);
  
}

function GoToPosition(newLat, newLng) {
    map.setCenter({

        lat: newLat,
        lng: newLng
    });
    map.setZoom(13);
}



