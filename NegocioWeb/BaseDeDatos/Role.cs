using System;
using System.Collections.Generic;

namespace NegocioWeb.BaseDeDatos;

public partial class Role
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<RelacionRolOperacion> RelacionRolOperacions { get; } = new List<RelacionRolOperacion>();

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
