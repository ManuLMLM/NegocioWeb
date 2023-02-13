using System;
using System.Collections.Generic;

namespace NegocioWeb.BaseDeDatos;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Contraseña { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdRol { get; set; }

    public virtual Role? IdRolNavigation { get; set; }
}
