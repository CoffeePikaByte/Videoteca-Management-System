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

        public DbSet<Pelicula> Peliculas { get; set; }
    }
}
