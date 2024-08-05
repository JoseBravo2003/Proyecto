using Microsoft.EntityFrameworkCore;
using Proyecto.Models;

namespace Proyecto.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        // DbSet para Usuario
        public DbSet<Usuario> Usuarios { get; set; }

        // DbSet para Comida
        public DbSet<Comida> Comidas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la entidad Usuario
            modelBuilder.Entity<Usuario>(tb =>
            {
                tb.HasKey(col => col.IdUsuario);
                tb.Property(col => col.IdUsuario)
                  .UseIdentityColumn()
                  .ValueGeneratedOnAdd();

                tb.Property(col => col.NombreCompleto).HasMaxLength(50);
                tb.Property(col => col.Correo).HasMaxLength(50);
                tb.Property(col => col.clave).HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>().ToTable("Usuario");

            // Configuración de la entidad Comida
            modelBuilder.Entity<Comida>(tb =>
            {
                tb.HasKey(col => col.IdComida);
                tb.Property(col => col.IdComida)
                  .UseIdentityColumn()
                  .ValueGeneratedOnAdd();

                tb.Property(col => col.Nombre).HasMaxLength(100);
                tb.Property(col => col.Descripcion).HasMaxLength(500);
                tb.Property(col => col.Precio).HasColumnType("decimal(18,2)");
                tb.Property(col => col.Categoria).HasMaxLength(50);
            });

            modelBuilder.Entity<Comida>().ToTable("Comida");
        }
    }
}
