using System;
using System.Collections.Generic;

namespace SoreBiblioteca.Domain.Entities;

public partial class Libro
{
    public int Idlibro { get; set; }

    public string Autor { get; set; } = null!;

    public string Titulo { get; set; } = null!;

    public int? Idproveedor { get; set; }

    public int? Stock { get; set; }

    public virtual Proveedore? IdproveedorNavigation { get; set; }
}
