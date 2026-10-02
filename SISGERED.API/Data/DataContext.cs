using Microsoft.EntityFrameworkCore;
using SISGERED.shared.Entities;

namespace SISGERED.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Administrador> Administradores { get; set; }

        public DbSet<Residente> Residentes { get; set; }

        public DbSet<ConjuntoResidencial> ConjuntoResidenciales { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Administrador>().HasIndex(a => a.Cedula).IsUnique();
        }
        public DbSet<ConjuntoResidencial> ConjuntosResidenciales { get; set; }
    }
}
