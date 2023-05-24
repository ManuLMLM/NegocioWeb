using Microsoft.AspNetCore.Mvc;

namespace NegocioWeb.Controllers
{
    public class VentanaInicioController : Controller
    {
        public IActionResult IndexAdmin()
        {
            return View();
        }
    }
}
