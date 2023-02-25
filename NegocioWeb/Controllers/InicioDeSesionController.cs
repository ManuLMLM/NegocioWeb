using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NegocioWeb.BaseDeDatos;
using Newtonsoft.Json.Converters;
using System.Security.Policy;
using System.Text.Encodings.Web;

namespace NegocioWeb.Controllers
{
    public class InicioDeSesionController : Controller
    {
        private readonly NegocioContext _context;
        public InicioDeSesionController(NegocioContext context)
        {
            _context= context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Username, string Contra)
        {
                    var User = (from d in _context.Usuarios where d.Correo == Username 
                                  && d.Contraseña == Contra select d).FirstOrDefault();

                    if (User == null) {
                return View();

            }
            else if (User.IdRol==1)
            {
                return RedirectToAction("Privacy", "Home");
            }
                    else { return RedirectToAction("Index", "Home"); }
        }
    }
}
