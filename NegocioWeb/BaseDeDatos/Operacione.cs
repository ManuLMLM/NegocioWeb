using System;
using System.Collections.Generic;

namespace NegocioWeb.BaseDeDatos;

public partial class Operacione
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? IdModulo { get; set; }

    public virtual Modulo? IdModuloNavigation { get; set; }

    public virtual ICollection<RelacionRolOperacion> RelacionRolOperacions { get; } = new List<RelacionRolOperacion>();
}
