using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class SucursalesPeliculas
    {
        [Required]
        public int IdSucursal {  get; set; }

        [Required]
        public Sucursal sucursal { get; set; }

        [Required]
        public int IdPelicula { get; set; }

        [Required]
        public Pelicula pelicula { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }
    }
}
