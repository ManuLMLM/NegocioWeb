using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaseDeDatos.Datos;
using Microsoft.AspNetCore.Authorization;

namespace NegocioWeb.Controllers
{
    [Authorize]
    public class VentanaInicioController : Controller
    {
        private readonly NegocioWebContext _base;
        public VentanaInicioController(NegocioWebContext context)
        {
            _base = context;
        }
        [Authorize(Roles ="Administrador")]
        public IActionResult IndexAdmin()
        {
            
            return View();
        }
    }
}
