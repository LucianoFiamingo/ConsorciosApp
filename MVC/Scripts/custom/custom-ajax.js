﻿function buscarConsorcioPorNombre(nombre, id) {
    var xhttp;
    if (nombre == "") {
        document.getElementById("existeNombreCons").innerHTML = "";
        return;
    }
    xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("existeNombreCons").innerHTML = this.responseText;
        }
    };
    xhttp.open("GET", "Existe/?nombre=" + nombre + "&?id=" + id, true);
    xhttp.send();
}