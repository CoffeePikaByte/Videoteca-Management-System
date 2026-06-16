using Microsoft.EntityFrameworkCore;
using VideotecaAPI.Models;


namespace VideotecaAPI.Data
{
    public class VideotecaContext : DbContext
    {


        public VideotecaContext(DbContextOptions<VideotecaContext> options) 
            : base(options)     
        {      
        }


        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DetallesPrestamo> DetallesPrestamo { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Encargado> Encargados { get; set; }

        public DbSet<Pelicula> Peliculas { get; set; }

        public DbSet<Genero> Generos { get; set; }

        public DbSet<PeliculasGeneros> PeliculasGeneros { get;set; }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<SucursalesPeliculas> SucursalesPeliculas { get;set; }
        public DbSet<Telefono> Telefonos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeliculasGeneros>()
                .HasKey(pg => new
                {
                    pg.IdGenero,
                    pg.IdPelicula
                });


            modelBuilder.Entity<PeliculasGeneros>()
            .HasOne(pg => pg.Pelicula)
            .WithMany(p => p.PeliculaGeneros)
            .HasForeignKey(pg => pg.IdPelicula);

            modelBuilder.Entity<PeliculasGeneros>()
                .HasOne(pg => pg.Genero)
                .WithMany(g => g.PeliculasGeneros)
                .HasForeignKey(pg => pg.IdGenero);


            modelBuilder.Entity<DetallesPrestamo>()
                .HasKey(dp => new
                {
                    dp.IdPrestamo,
                    dp.IdPelicula
                });

            modelBuilder.Entity<SucursalesPeliculas>()
                .HasKey(sp => new
                {
                    sp.IdSucursal,
                    sp.IdPelicula

                });

            modelBuilder.Entity<Pelicula>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Peliculas)
                .HasForeignKey(p => p.IdCategoria);



            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.persona)
                .WithOne()
                .HasForeignKey<Cliente>(c => c.IdPersona);

            modelBuilder.Entity<Persona>()
                .HasOne(p => p.Direcciones)
                .WithOne()
                .HasForeignKey<Persona>(p => p.IdDirecciones);    

            modelBuilder.Entity<Persona>()
                .HasOne(p => p.Telefono)
                .WithOne()
                .HasForeignKey<Persona>(p => p.IdTelefono);

            

            base.OnModelCreating(modelBuilder);
        }
    }
}
