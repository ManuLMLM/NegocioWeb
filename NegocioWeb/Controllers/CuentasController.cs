using Microsoft.AspNetCore.Mvc;
using Moldes.Usuarios;
namespace NegocioWeb.Controllers
{
    public class CuentasController : Controller
    {
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Usuario usuario)
        {
            return View();
        }
    }
}
