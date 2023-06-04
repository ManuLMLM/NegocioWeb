
using Microsoft.AspNetCore.Mvc;
using Moldes.Usuarios;
using System.Text.Json;
using BaseDeDatos.Datos;
using Newtonsoft.Json;

namespace NegocioWeb.Controllers
{
    public class InicioDeSesionController : Controller
    {
        private readonly NegocioWebContext _context;
        public async Task<string> SolicitarGet(string url)
        {
            HttpClient pedido = new HttpClient();
            var respuesta = await pedido.GetAsync(url);
            var contenido = await respuesta.Content.ReadAsStringAsync();
            return contenido;
        }
        public InicioDeSesionController(NegocioWebContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
    public async Task<IActionResult> Login(string Username, string Contra)
    {
            var url = "https://localhost:7002/api/Api1/Usuarios";
            string respuesta = await SolicitarGet(url);

            var lista = JsonConvert.DeserializeObject<List<LoginValidacion>>(respuesta);
            var User = (from d in _context.Usuarios
                        where d.Correo == Username
                          && d.Contraseña == Contra
                        select d.IdRol).FirstOrDefault();
            var Validar = (from d in _context.Usuarios
                        where d.Correo == Username
                          && d.Contraseña == Contra
                        select new LoginValidacion
                        {
                            Usuario=d.Correo,
                            Contra=d.Contraseña
                        }).ToList();
            if (Validar[0].Usuario == Username && Validar[0].Contra == Contra) {
                if (User ==1)
                {
                    return RedirectToAction("IndexAdmin", "VentanaInicio");
                }
                else if (User == 3)
                {
                    return RedirectToAction("IndexAdmin", "VentanaInicio");
                }
                else { return View(); }

            }
            else { return View(); }

        }
}
}
