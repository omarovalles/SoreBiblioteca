using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoreBiblioteca.Domain.Entities;

public partial class Cliente
{
    [Key]
    public int Idcliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string? Telefono { get; set; }

    public string Correo { get; set; } = null!;

    public string Estado { get; set; } = null!;
}
