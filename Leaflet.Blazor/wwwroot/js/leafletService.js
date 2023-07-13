import * as L from "./leaflet-src.esm.js"

const maps = new Map(); // Diccionario JS

export const createMap = (mapId, point, zoomLevel) => {
    var map = L.map(mapId).setView([point.latitude, point.longitude], zoomLevel);
    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: zoomLevel,
        attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    }).addTo(map);

    map.addedMarkers = []; // Atributo nuevo personalizado
    maps.set(mapId, map);

    /*
    Otra forma de guardar el objeto map:

    var element = document.getElementById(mapId);
    element.Map = map;

    */
    console.info(`map ${mapId} created.`);
}

export const deleteMap = (mapId) => {
    var map = maps.get(mapId);
    map.remove();
    maps.delete(mapId);
    console.info(`map ${mapId} removed.`);
}

export const setView = (mapId, point) => {
    var map = maps.get(mapId);
    map.setView([point.latitude, point.longitude]);
}

/***** Add Marker *************/

export const setMarkerHelper = (mapId, markerHelper, dragendHandler) => {
    var map = maps.get(mapId);
    map.markerHelper = {
        dotNetObjectReference: markerHelper,
        dragendHandler: dragendHandler
    }
}

export const addMarker = (mapId, point, title, popupDescription, iconUrl) => {
    var options = buildMarkerOptions(title, iconUrl);
    return addMarkerWithOptions(mapId, point, popupDescription, options);
}

export const addDraggableMarker = (mapId, point, title, popupDescription, iconUrl) => {
    var options = buildMarkerOptions(title, iconUrl, true);
    let markerId = addMarkerWithOptions(mapId, point, popupDescription, options);

    var map = maps.get(mapId);
    var marker = map.addedMarkers[markerId];

    marker.on('dragend', (e) => {
        let point = marker.getLatLng();
        console.log(point);
        let dragendMarkerEventArgs = {
            markerId: markerId,
            position: {
                latitude: point.lat,
                longitude: point.lng
            }
        }

        let dotNetObjectReference = map.markerHelper.dotNetObjectReference;
        let dragendHandler = map.markerHelper.dragendHandler;

        dotNetObjectReference.invokeMethodAsync(dragendHandler, dragendMarkerEventArgs);
    });

    return markerId;
}

export const buildMarkerOptions = (title, iconUrl, draggable) => {
    var options = {
        title: title
    };
    if (iconUrl) {
        options.icon = L.icon(
            { iconUrl: iconUrl, iconSize: [32, 32], iconAnchor: [16, 16] });
    }
    if (draggable) {
        options.draggable = true;
    }
    return options;
}

export const addMarkerWithOptions = (mapId, point, popupDescription, options) => {
    var map = maps.get(mapId);

    var marker = L.marker([point.latitude, point.longitude], options)
        .bindPopup(popupDescription)
        .addTo(map);

    let markerId = map.addedMarkers.push(marker) - 1;  

    return markerId; // Devuelve el índice del elemento insertado

}
/* End Add Marker *******/

export const removeMarkers = (mapId) => {
    var map = maps.get(mapId);
    map.addedMarkers.forEach(marker => marker.removeFrom(map));
    map.addedMarkers = [];
}

export const drawCircle = (mapId, center, lineColor,
    fillColor, fillOpacity, radius) => {
    var map = maps.get(mapId);

    var circle = L.circle([center.latitude, center.longitude], {
        color: lineColor,
        fillColor: fillColor,
        fillOpacity: fillOpacity,
        radius: radius
    }).addTo(map);


    // Opcionalmente, guardar el circulo.
}

export const moveMarker = (mapId, markerId, newPosition) => {
    var map = maps.get(mapId);
    var marker = map.addedMarkers[markerId];
    marker.setLatLng([newPosition.latitude, newPosition.longitude]);
}

export const setPopupMarkerContent = (mapId, markerId, content) => {
    getMarker(mapId, markerId)
        .setPopupContent(content)
        .openPopup();
}

const getMarker = (mapId, markerId) => 
     maps.get(mapId)
        .addedMarkers[markerId];
