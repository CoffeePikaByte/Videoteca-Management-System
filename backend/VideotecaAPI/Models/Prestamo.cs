using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Prestamo
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        string CodigoFacturacion { get; set; }

        [Required]
        int IdCliente { get; set; }

        [Required]
        Cliente cliente { get; set; }

        [Required]
        int IdEncargado { get; set; }

        [Required]
        Encargado encargado { get; set; }

        [Required]
        int IdSucursal {  get; set; }

        [Required]
        Sucursal sucursal { get; set; }

        [Required]
        DateTime FechaPrestamo { get; set; }

        DateTime? FechaLimiteDevolucion { get; set; }

        [Required]
        bool Estado {  get; set; }

    }
}
