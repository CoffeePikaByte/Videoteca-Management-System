using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class DetallesPrestamo
    {
        [Required]
        public int IdPelicula { get; set; }

        public Pelicula Pelicula { get; set; }

        [Required]
        public int IdPrestamo { get; set; }

        public Prestamo Prestamo { get; set; }

        [Required]
        [Range (0, int.MaxValue)]
        public int Cantidad { get; set; }
    }
}
