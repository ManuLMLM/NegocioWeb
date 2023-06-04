using System;
using System.Collections.Generic;

namespace BaseDeDatos.Datos;

public partial class Operacione
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdModulo { get; set; }

    public virtual Modulo IdModuloNavigation { get; set; } = null!;

    public virtual ICollection<RelacionRolOperacion> RelacionRolOperacions { get; } = new List<RelacionRolOperacion>();
}
