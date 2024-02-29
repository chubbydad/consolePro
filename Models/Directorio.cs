using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Directorio
{
    public int IdDirectorio { get; set; }

    public string? Nombre { get; set; }

    public int? IdPadre { get; set; }
}
