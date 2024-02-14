using API_BANK.Models;

namespace API_BANK.DTO
{
    public class EmpleadoDTO
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
    }
}
