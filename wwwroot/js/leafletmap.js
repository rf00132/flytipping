var map = L.map('reportCoordinatesInput').setView([52.2371, -0.8944], 13);
L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 19,
    attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
}).addTo(map);

var marker;

function dropMarker(event) {
    var latitude = event.latlng.lat;;
    var longitude = event.latlng.lng;

    

    if (marker != undefined) {
        map.removeLayer(marker);
    }

    marker = L.marker([latitude, longitude]).addTo(map);
}

map.on("click", dropMarker);
