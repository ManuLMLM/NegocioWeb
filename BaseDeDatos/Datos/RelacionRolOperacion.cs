using System;
using System.Collections.Generic;

namespace BaseDeDatos.Datos;

public partial class RelacionRolOperacion
{
    public int Id { get; set; }

    public int IdRol { get; set; }

    public int IdOperacion { get; set; }

    public virtual Operacione IdOperacionNavigation { get; set; } = null!;

    public virtual Role IdRolNavigation { get; set; } = null!;
}
