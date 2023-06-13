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
function crearcuenta() {
    var nombre, correo, contra, contra2;
    nombre = document.getElementById("Nombre").value;
    correo = document.getElementById("Correo").value;
    contra = document.getElementById("Contra").value;
    contra2 = document.getElementById("Contra2").value; alert(nombre + correo + contra + contra2)
    if (nombre == "" || correo == "" || contra == "" || contra2 == "") {
        alert("Por favor, rellene los campos para la reación de su Cuenta");
    } else if (contra != contra2) {
        contra.fontcolor("red");
        alert("La contraseña no coincide")
    } else {
        var formulario = document.getElementById("formulario");
        formulario.id = '@Url.Content("~/Cuentas/Crear")';
        formulario.method = "post";
    }
}