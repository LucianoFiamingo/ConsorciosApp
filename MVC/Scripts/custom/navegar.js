function volver() {
    history.back();
}

function colorear() {
    var fila = $('.colorear');
    fila.removeClass('table-success');
}

$(document).ready(function () {

    $('html, body').animate({
        scrollTop: $(".colorear").offset().top
    }, 2000);

    setTimeout(colorear, 2000);
});