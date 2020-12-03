function buscarConsorcioPorNombre(nombre, id, idCon) {
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
    if (idCon == null) {
        xhttp.open("GET", "/Consorcio/Existe/?nombre=" + nombre + "&id=" + id, true);
        xhttp.send();
    } else {
        xhttp.open("GET", "/Consorcio/Existe/?nombre=" + nombre + "&id=" + id + "&idCon=" + idCon, true);
        xhttp.send();
    }
}

function buscarUnidadPorNombre(nombre, idUsuCre, idCon, idUni) {
    var xhttp;
    if (nombre == "") {
        document.getElementById("existeNombreUni").innerHTML = "";
        return;
    }
    xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("existeNombreUni").innerHTML = this.responseText;
        }
    };
    if (idCon == null) {
        xhttp.open("GET", "/Unidad/Existe/?nombre=" + nombre + "&idUsuCre=" + idUsuCre + "&idCon=" + idCon, true);
        xhttp.send();
    } else {
        xhttp.open("GET", "/Unidad/Existe/?nombre=" + nombre + "&idUsuCre=" + idUsuCre + "&idCon=" + idCon + "&idUni=" + idUni, true);
        xhttp.send();
    }
}