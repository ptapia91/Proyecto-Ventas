$(document).ready(function () {
    if ('geolocation' in navigator) {
        navigator.geolocation.getCurrentPosition(
            mostrarPosicion,mostrarError);
    }
    else {
        $("#mensaje").html("Funcionalidad de localizacion no soportada por el browser.")
    }
});

function mostrarError(error) {
    switch (error.code) {
        case error.PERMISSION_DENIED:
            $("#mensaje").html("Acceso a localizacion bloqueado");
            break;
        case error.POSITION_UNAVAILABLE:
            $("#mensaje").html("Localización no disponible");
            break;
        case error.TIMEOUT:
            $("#mensaje").html("Tiempo de espera excedido");
            break;
        case error.UNKNOWN_ERROR:
            $("#mensaje").html("Error desconocido");
            break;
        default:
            $("#mensaje").html("Otro error");
            break;
    }
}

function mostrarPosicion(posicion) {
    //Obtenemos coordenadas desde el browser
    var coordenadas = new google.maps.LatLng(
        posicion.coords.latitude,
        posicion.coords.longitude);
    //Creamos el mapa
    var mapa = new google.maps.Map(
        document.getElementById('mapa'),
        {
            zoom: 13,
            center: coordenadas,
            navigationControlOptions: {
                style: google.maps.NavigationControlStyle.SMALL
            },
            mapTypeId: google.maps.MapTypeId.ROADMAP
        });
    //Creamos el marcador en el mapa
    new google.maps.Marker({
        position: coordenadas,
        map: mapa,
        title: "Esta es tu ubicación!"
    });
}