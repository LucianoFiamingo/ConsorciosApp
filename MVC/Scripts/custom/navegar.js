function volver() {
    history.back();
}

function colorear() {
    var fila = $('.colorear');
    fila.removeClass('table-success');
}

$(document).ready(function () {

    if ($(".colorear").offset() != null && $(".colorear").offset().top != 'undefined') {
        $('html, body').animate({
            scrollTop: $(".colorear").offset().top - 300
        }, 1000);

        setTimeout(colorear, 2000); 
    }

});