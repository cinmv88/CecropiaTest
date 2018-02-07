using Microsoft.EntityFrameworkCore;

namespace PruebaCECROPIACinthya.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Patient> PatientTB { get; set; }
    }
}
