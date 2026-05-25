using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class SucursalesPeliculas
    {
        [Required]
        int IdSucursal {  get; set; }

        [Required]
        Sucursal sucursal { get; set; }

        [Required]
        int IdPelicula { get; set; }

        [Required]
        Pelicula pelicula { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        int Cantidad { get; set; }
    }
}
