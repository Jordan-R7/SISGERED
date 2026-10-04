using Microsoft.EntityFrameworkCore;
using SISGERED.shared.Entities; // Ajusta los usings si es necesario

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
        public DbSet<EmpresaExterna> EmpresasExternas { get; set; }
        public DbSet<Intervencion> Intervenciones { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }
        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<Revision> Revisiones { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
            modelBuilder.Entity<personal>().ToTable("Personal");
            modelBuilder.Entity<Intervencion>().ToTable("Intervensiones");
            modelBuilder.Entity<EmpresaExterna>().ToTable("EmpresasExternas");

            
            modelBuilder.Entity<Administrador>().HasIndex(a => a.Cedula).IsUnique();

            

            // RN01: Relación 1:1 entre ConjuntoResidencial y Administrador
            modelBuilder.Entity<ConjuntoResidencial>()
                .HasOne(c => c.Administrador)
                .WithOne() // Se deja vacío porque Administrador no tiene la propiedad de vuelta
                .HasForeignKey<ConjuntoResidencial>(c => c.AdministradorId);



            // RN16: Una intervención no puede tener Empresa Externa y Personal a la vez
            modelBuilder.Entity<Intervencion>()
            .HasCheckConstraint("CK_Intervencion_ResponsableExclusivo",
            "([ID_personal] IS NOT NULL AND [ID_Empresaexterna] IS NULL) OR ([ID_personal] IS NULL AND [ID_Empresaexterna] IS NOT NULL)");

            modelBuilder.Entity<Intervencion>()
                .HasOne<personal>()
                .WithMany()
                .HasForeignKey(i => i.ID_personal)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Intervencion>()
                .HasOne<EmpresaExterna>()
                .WithMany()
                .HasForeignKey(i => i.ID_Empresaexterna)
                .OnDelete(DeleteBehavior.Restrict);

            //prevencion de cascada de eliminacion para todas las relaciones

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Configuración de la relación entre Intervension y Administrador

            modelBuilder.Entity<Intervencion>()
            .HasOne(i => i.Administrador)
            .WithMany()
            .HasForeignKey(i => i.ID_Administrador)
            .OnDelete(DeleteBehavior.Restrict);

            // Configuración de la relación entre Intervension y Reporte
            modelBuilder.Entity<Intervencion>()
            .HasOne(i => i.Reporte)
            .WithOne(r => r.Intervension)
            .HasForeignKey<Intervencion>(i => i.ID_Reporte)
            .OnDelete(DeleteBehavior.Restrict);


        }
    }
}