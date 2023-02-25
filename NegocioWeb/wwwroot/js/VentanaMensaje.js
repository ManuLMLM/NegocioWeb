
function loginjava() {

    
    let user, pass
    user = document.getElementById("Usuario").value;
    pass = document.getElementById("Contrasena").value;

    if (user == "" && pass == "") {
        alert("Por favor introduzca el usuario y contraseña")
    } else if (user != "" && pass=="") {
        alert("Por favor introduzca la contraseña")
    } else if (user =="" && pass!="") {
        alert("Por favor introduzca el usuario")
    }
    
}