using System;
using System.Collections.Generic;

namespace DTOs.Usuarios;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Estado { get; set; }
}
