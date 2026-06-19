

using VideotecaAPI.Models;

namespace VideotecaAPI.DTOs
{
    public class PrestamoDetallesDTO
    {
        public int Id { get; set; }
        public string CodigoFacturacion { get; set; }
        public string NombreCliente { get; set; }
        public string NombreEncargado { get; set; }
        public string NombreSucursal { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaLimiteDevolucion { get; set; }
        public string Estado { get; set; }

        public List<PeliculasPrestamoDTO> Peliculas { get; set; }
    }
}