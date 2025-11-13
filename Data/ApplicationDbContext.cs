using Microsoft.EntityFrameworkCore;
using SistemaTitulos.Models;

namespace SistemaTitulos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<SistemaTitulos.Models.Tutor> Tutor { get; set; } = default!;
        public DbSet<SistemaTitulos.Models.MiembroTribunal> MiembroTribunal { get; set; } = default!;
    }
}
