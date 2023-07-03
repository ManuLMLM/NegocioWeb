using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaseDeDatos.Datos;
using Moldes.Usuarios;
namespace NegocioApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Api1Controller : ControllerBase
    {
        NegocioWebContext _context = new NegocioWebContext();
        [HttpGet]
        [Route("Usuarios")]
        public async Task<List<LoginValidacion>> listausuarios()
        {
            
            Task<List<LoginValidacion>> lista = (from l in _context.Usuarios 
                                                 select new LoginValidacion
                                                 {
                                                  Usuario = l.Correo,
                                                  Contra = l.Contraseña
                                                  }).ToListAsync();
            return await lista;
        }
        [HttpGet]
        [Route("Usuarios-1")]
        public async Task<List<Moldes.Usuarios.Usuario>> get()
        {

            Task<List<Moldes.Usuarios.Usuario>> ListUser = (from d in _context.Usuarios
                            select new Moldes.Usuarios.Usuario
                            {
                                Id = d.Id,
                                Nombre = d.Nombre,
                                Correo = d.Correo,
                                Contraseña = d.Contraseña,
                                Fecha = d.Fecha,
                                Rol = d.IdRolNavigation.Nombre
                            }).ToListAsync();
            
            return await ListUser;

        }
        [HttpGet]
        [Route("CorreosExistentes")]
        public async Task<List<string>> ListaCorreos()
        {
            var correos = (from d in _context.Usuarios select d.Correo).ToListAsync();
            return await correos;
        }
    }
}
