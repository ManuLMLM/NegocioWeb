using System;
using System.Collections.Generic;

namespace NegocioWeb.BaseDeDatos;

public partial class RelacionRolOperacion
{
    public int Id { get; set; }

    public int? IdRol { get; set; }

    public int? IdOperacion { get; set; }

    public virtual Operacione? IdOperacionNavigation { get; set; }

    public virtual Role? IdRolNavigation { get; set; }
}
