using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class DetallesPrestamo
    {
        [Required]
        int IdPersona { get; set; }

        [Required]
        int IdPrestamo { get; set; }

        [Required]
        [Range (0, int.MaxValue)]
        int Cantidad { get; set; }
    }
}
