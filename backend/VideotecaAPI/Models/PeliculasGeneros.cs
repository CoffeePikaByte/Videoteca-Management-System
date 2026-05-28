using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class PeliculasGeneros
    {

        [Required]
        public int IdGenero { get; set; }

        [Required]
        public Genero Genero { get; set; }

        [Required]
        public int IdPelicula { get; set; }

        [Required]
        public Pelicula Pelicula { get; set; }

    }
}
