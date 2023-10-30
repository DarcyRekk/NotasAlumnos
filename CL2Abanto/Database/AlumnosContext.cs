using Microsoft.EntityFrameworkCore;
namespace CL2Abanto.Database
{
    public class AlumnosContext : DbContext
    {
        public DbSet<AlumnosEntity>Alumnos { get; set; }
        public DbSet<NotasEntity>Notas { get; set; }
        public AlumnosContext(DbContextOptions<AlumnosContext> option) : base (option)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotasEntity>()
                .HasOne(n => n.Alumnos)
                .WithMany(e => e.Notas)
                .HasForeignKey(n => n.IdAlumno);
        }
    }
}