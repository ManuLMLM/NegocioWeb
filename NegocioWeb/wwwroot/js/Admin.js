var url = "https://localhost:7084/api/ApiDatos/Usuarios-1";
let tabla1 = document.getElementById("tabla1"); 
fetch(url).then(function (resultado) {
    if (resultado.ok) {
        return resultado.json();
    }
}).then(function (dato) {
    dato.forEach(function (elemento) {
        let td = document.createElement("td");
        let td1 = document.createElement("td");
        let td2 = document.createElement("td");
        let tr = document.createElement("tr");
        td.appendChild(document.createTextNode(elemento.nombre));
        td1.appendChild(document.createTextNode(elemento.correo));
        td2.appendChild(document.createTextNode(elemento.rol));
        tabla1.appendChild(td);
        tabla1.appendChild(td1);
        tabla1.appendChild(td2);
        tabla1.appendChild(tr);
    })
})