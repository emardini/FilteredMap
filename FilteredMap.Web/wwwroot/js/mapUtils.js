﻿class MapLoader {
    constructor(placeList) {
        this.placeList = placeList;
    }

    load() {

        var places = this.placeList;

        $(document).ready(function () {
            (function () {
                var options = {
                    zoom: 5,
                    mapTypeId: google.maps.MapTypeId.TERRAIN,
                    mapTypeControl: false
                };

                var map = new google.maps.Map(document.getElementById('map-canvas'), options);
                var bounds = new google.maps.LatLngBounds();
                var placeListUl = document.getElementById('place-list');

                for (var i = 0; i < places.length; i++) {
                    var marker = new google.maps.Marker({
                        position: new google.maps.LatLng(places[i].location.latitude, places[i].location.longitude),
                        map: map,
                        title: places[i].name
                    });

                    bounds.extend(marker.position);

                    var li = document.createElement('li');
                    li.innerHTML = li.innerHTML + places[i].name;
                    placeListUl.appendChild(li);

                    var infowindow = new google.maps.InfoWindow({
                        content: places[i].name
                    });

                    (function (infowindow, marker, li) {
                        google.maps.event.addListener(marker, 'click', function () { infowindow.open(map, marker); });
                        $(li)
                            .hover(function () {
                                $(this).css("font-weight", "bold");
                                infowindow.open(map, marker);
                            }, function () {
                                $(this).css("font-weight", "normal");
                                infowindow.close();
                            }
                            );
                    })(infowindow, marker, li);
                }

                map.fitBounds(bounds);

            })();
        });
    }
}

export { MapLoader };