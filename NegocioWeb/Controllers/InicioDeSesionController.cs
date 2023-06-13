
using Microsoft.AspNetCore.Mvc;
using Moldes.Usuarios;
using System.Text.Json;
using BaseDeDatos.Datos;
using MetodosOperaciones.Solicitudes;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace NegocioWeb.Controllers
{
    public class InicioDeSesionController : Controller
    {
        private readonly NegocioWebContext _context;
        
        public InicioDeSesionController(NegocioWebContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Moldes.Usuarios.Usuario usuario)
        {
            
                Usuarios metodo = new Usuarios();
                var user = metodo.ValidarUsuario(usuario.Correo, usuario.Contraseña);
                if (user != null)
                {
                    var token = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Nombre),
                    new Claim("Correo", user.Correo)
                };

                    token.Add(new Claim(ClaimTypes.Role, user.Rol));

                    var tokenidentidad = new ClaimsIdentity(token, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(tokenidentidad));

                    return RedirectToAction("IndexAdmin", "VentanaInicio");
                }
                else
                {
                    return View();
                }
            
        }
        
        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "InicioDeSesion");
        }
        //    [HttpPost]
        //public async Task<IActionResult> Login(string Username, string Contra)
        //{
        //        var url = "https://localhost:7002/api/Api1/Usuarios";
        //        string respuesta = await Solicitudes.SolicitarGet(url);

        //        var lista = JsonConvert.DeserializeObject<List<LoginValidacion>>(respuesta);
        //        var User = (from d in _context.Usuarios
        //                    where d.Correo == Username
        //                      && d.Contraseña == Contra
        //                    select d.IdRol).FirstOrDefault();
        //        var Validar = (from d in _context.Usuarios
        //                    where d.Correo == Username
        //                      && d.Contraseña == Contra
        //                    select new LoginValidacion
        //                    {
        //                        Usuario=d.Correo,
        //                        Contra=d.Contraseña
        //                    }).ToList();
        //        if (Validar[0].Usuario == Username && Validar[0].Contra == Contra) {
        //            if (User ==1)
        //            {
        //                return RedirectToAction("IndexAdmin", "VentanaInicio");
        //            }
        //            else if (User == 3)
        //            {
        //                return RedirectToAction("IndexAdmin", "VentanaInicio");
        //            }
        //            else { return View(); }

        //        }
        //        else { return View(); }

        //    }
    }
}
