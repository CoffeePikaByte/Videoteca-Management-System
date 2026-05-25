using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class PeliculasGeneros
    {

        [Required]
        int IdGenero { get; set; }

        [Required]
        Genero genero { get; set; }

        [Required]
        int IdPelicula { get; set; }

        [Required]
        Pelicula pelicula { get; set; }

    }
}
