using System;
using System.Collections.Generic;

namespace SoreBiblioteca.Domain.Entities;

public partial class Empleado
{
    public int Idempleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Puesto { get; set; } = null!;
}
