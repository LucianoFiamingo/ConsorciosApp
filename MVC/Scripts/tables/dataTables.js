
$(document).ready(function () {

    iniciarTabla();
});

function iniciarTabla() {
    $('#example').DataTable({
        "scrollX": true,
        "autoWidth": false,
        "responsive ": true,
        "language": {
            "url": "/Content/Tables/Json/Spanish.json"
        }
    });

}

