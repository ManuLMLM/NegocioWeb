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
        public async Task<IActionResult> IndexAdmin()
        {
            var consulta = _base.Usuarios.Include(d => d.IdRolNavigation);
            return View(await consulta.ToListAsync());
        }
    }
}
