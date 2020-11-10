function volver() {
        history.back();
}

function colorear() {
    var fila = $('.colorear');
    fila.removeClass('table-success');
}

$(document).ready(function () {
    setTimeout(colorear, 1000);
});