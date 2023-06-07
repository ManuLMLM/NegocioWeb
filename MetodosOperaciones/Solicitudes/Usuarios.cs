using BaseDeDatos.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosOperaciones.Solicitudes
{
    public class Usuarios
    {
        
        public Moldes.Usuarios.Usuario ValidarUsuario(string correo,string contra)
        {
            
            using (NegocioWebContext _context = new NegocioWebContext())
            {
               var user = (from d in _context.Usuarios
                            where d.Correo == correo & d.Contraseña == contra
                            select new Moldes.Usuarios.Usuario
                            {
                                Id = d.Id,
                                Nombre = d.Nombre,
                                Correo = d.Correo,
                                Contraseña = d.Contraseña,
                                Fecha = d.Fecha,
                                Rol = d.IdRolNavigation.Nombre
                            }).ToList();
                return user.FirstOrDefault();
            }
            
        }
    }
}
