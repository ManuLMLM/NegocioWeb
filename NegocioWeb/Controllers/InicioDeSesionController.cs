using Microsoft.AspNetCore.Mvc;
using NegocioWeb.BaseDeDatos;

namespace NegocioWeb.Controllers
{
    public class InicioDeSesionController : Controller
    {
        private readonly NegocioContext _context;
        public InicioDeSesionController(NegocioContext contexto)
        {
            _context = contexto;
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
