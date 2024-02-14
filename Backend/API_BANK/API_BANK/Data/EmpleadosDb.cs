
using API_BANK.Models;
using Microsoft.EntityFrameworkCore;

namespace API_BANK.Data
{
    public class EmpleadosDb:DbContext
    {
        public EmpleadosDb(DbContextOptions<EmpleadosDb> options):base(options) { 
        
        }
        public DbSet<Empleado> Empleados => Set<Empleado>();

    }
}
