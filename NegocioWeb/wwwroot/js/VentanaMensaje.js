var url = "https://localhost:7084/InicioDeSesion/Login";
function loginjava() {

    var user, pass
    user = document.getElementById("Usuario").value;
    pass = document.getElementById("Contrasena").value;

    if (user == "" && pass == "") {
        alert("Por favor introduzca el usuario y contraseña")
    } else if (user != "" && pass == "") {
        alert("Por favor introduzca la contraseña")
    } else if (user == "" && pass != "") {
        alert("Por favor introduzca el usuario")
    } else {
        //var accion = document.getElementById("datosusuario");
        //accion.id = '@Url.Content("~/VentanaInicio/IndexAdmin")';
        //accion.method = "post";
        
        var objeto = `{"Lista":[{"Usuario":"` + user + `","Contra":"` + pass + `"}]}`;
        //fetch(url, {
        //    method: "POST",
        //    headers: {
        //        "Content-Type": "application/json",
        //    },
        //    body: JSON.stringify(objeto),
        //});
    }
}