using System;
using System.Collections.Generic;

namespace NegocioWeb.BaseDeDatos;

public partial class Modulo
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Operacione> Operaciones { get; } = new List<Operacione>();
}
