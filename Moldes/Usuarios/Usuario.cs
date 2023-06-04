using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moldes.Usuarios
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Contraseña { get; set; } = null!;

        public DateTime Fecha { get; set; }

        public string Rol { get; set; } = null!;
        public IList<Usuario> Lista { get; set; }
    }
}
