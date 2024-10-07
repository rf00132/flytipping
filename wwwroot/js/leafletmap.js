let map = L.map('map').setView([52.2371, -0.8944], 13);
L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 19,
    attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
}).addTo(map);

let marker;
const reportCoordinatesInput = document.getElementById("reportCoordinatesInput");


function dropMarker(event) {
    var latitude = event.latlng.lat;;
    var longitude = event.latlng.lng;

    if (marker != undefined) {
        map.removeLayer(marker);
    }

    marker = L.marker([latitude, longitude]).addTo(map);
    reportCoordinatesInput.value = "[" + latitude + "," + longitude + "]";
}

map.on("click", dropMarker);
