using System;
using System.Collections.Generic;

namespace SoreBiblioteca.Domain.Entities;

public partial class Proveedore
{
    public int Idproveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
