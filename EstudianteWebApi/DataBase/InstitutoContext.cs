using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;

namespace DataBase
{
    public class InstitutoContext : DbContext
    {
        public InstitutoContext(DbContextOptions<InstitutoContext> options) : base (options) { }

        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<DetalleEstudiante> DetalleEstudiantes { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profesor>().ToTable("Profesor");    
            modelBuilder.Entity<Materia>().ToTable("Materia");
            modelBuilder.Entity<DetalleEstudiante>().ToTable("DetalleEstudiante");
            modelBuilder.Entity<Estudiante>().ToTable("Estudiante");
            base.OnModelCreating(modelBuilder);
        }

    


    }
}
