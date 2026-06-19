

using System.ComponentModel.DataAnnotations;
using VideotecaAPI.Models;

namespace VideotecaAPI.DTOs
{
    public class PrestamoCrearDTO
    {
        [Required]
        [MaxLength(50)]
        public string CodigoFacturacion { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public int IdEncargado { get; set; }
        [Required]
        public int IdSucursal { get; set; }
        [Required]
        public DateTime FechaPrestamo { get; set; }

        public DateTime? FechaLimiteDevolucion { get; set; }
        [Required]
        public string Estado { get; set; }

        public List<PrestamoDetallesCrearDTO> Detalles { get; set; }
    }
}