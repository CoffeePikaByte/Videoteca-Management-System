using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Prestamo
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string CodigoFacturacion { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public Cliente cliente { get; set; }

        [Required]
        public int IdEncargado { get; set; }

        [Required]
        public Encargado encargado { get; set; }

        [Required]
        public int IdSucursal {  get; set; }

        [Required]
        public Sucursal sucursal { get; set; }

        [Required]
        public DateTime FechaPrestamo { get; set; }

        public DateTime? FechaLimiteDevolucion { get; set; }

        [Required]
        public bool Estado {  get; set; }

    }
}
