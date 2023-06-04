using System;
using System.Collections.Generic;

namespace BaseDeDatos.Datos;

public partial class Modulo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Operacione> Operaciones { get; } = new List<Operacione>();
}
