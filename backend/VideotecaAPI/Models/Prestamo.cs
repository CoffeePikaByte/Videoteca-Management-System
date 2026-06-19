using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Prestamo
    {
        public int Id { get; set; }

        public string CodigoFacturacion { get; set; }

        [Required]
        public int IdCliente { get; set; }

        public Cliente cliente { get; set; }

        public int IdEncargado { get; set; }

        public Encargado encargado { get; set; }

        public int IdSucursal {  get; set; }

        public Sucursal sucursal { get; set; }

        public DateTime FechaPrestamo { get; set; }

        public DateTime? FechaLimiteDevolucion { get; set; }

        public string Estado {  get; set; }

    }
}
