using Microsoft.EntityFrameworkCore;
using SISGERED.API.entidades;
using SISGERED.shared.Entities; // Ajusta los usings si es necesario
using System.Linq;

namespace SISGERED.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // 1. Definición de DbSets (Entidades)
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Residente> Residentes { get; set; }
        public DbSet<ConjuntoResidencial> ConjuntosResidenciales { get; set; }
        public DbSet<personal> Personal { get; set; }
        public DbSet<Empresaaeaxterna> EmpresasExternas { get; set; }
        public DbSet<Intervecion> Intervenciones { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }
        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<Revision> Revisiones { get; set; }
        public object Intervesiones { get; internal set; }
        public object Intervensiones { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
            modelBuilder.Entity<personal>().ToTable("Personal");
            modelBuilder.Entity<Intervecion>().ToTable("Intervenciones");
            modelBuilder.Entity<Empresaaeaxterna>().ToTable("EmpresasExternas");

            
            modelBuilder.Entity<Administrador>().HasIndex(a => a.Cedula).IsUnique();

            

            // RN01: Relación 1:1 entre ConjuntoResidencial y Administrador
            modelBuilder.Entity<ConjuntoResidencial>()
                .HasOne(c => c.Administrador)
                .WithOne() // Se deja vacío porque Administrador no tiene la propiedad de vuelta
                .HasForeignKey<ConjuntoResidencial>(c => c.AdministradorId);



            // RN16: Una intervención no puede tener Empresa Externa y Personal a la vez
            modelBuilder.Entity<Intervecion>()
    .HasCheckConstraint("CK_Intervencion_ResponsableExclusivo",
    "([ID_personal] IS NOT NULL AND [ID_Empresaexterna] IS NULL) OR ([ID_personal] IS NULL AND [ID_Empresaexterna] IS NOT NULL)");

            //prevencion de cascada de eliminacion para todas las relaciones

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}