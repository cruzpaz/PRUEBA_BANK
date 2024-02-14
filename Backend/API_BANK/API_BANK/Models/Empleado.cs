using System;
using System.Collections.Generic;

namespace API_BANK.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public int? Area { get; set; }

    public DateOnly? FechaContratacion { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public DateOnly? FechaModificacion { get; set; }

    public virtual Departamento? AreaNavigation { get; set; }

    public virtual ICollection<Ususario> Ususarios { get; set; } = new List<Ususario>();
}
