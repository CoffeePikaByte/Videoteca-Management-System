

namespace VideotecaAPI.DTOs
{
    public class PrestamoListadoDTO
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string CodigoFacturacion { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string Estado { get; set; }
    }
}