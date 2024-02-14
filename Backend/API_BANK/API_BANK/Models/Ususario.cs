using System;
using System.Collections.Generic;

namespace API_BANK.Models;

public partial class Ususario
{
    public int Id { get; set; }

    public string? Usuario { get; set; }

    public string? Password { get; set; }

    public int IdEmpleado { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public DateOnly? FechaModificacion { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
