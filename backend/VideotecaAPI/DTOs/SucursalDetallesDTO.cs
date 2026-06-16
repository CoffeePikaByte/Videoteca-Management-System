
namespace VideotecaAPI.DTOs
{
    public class SucursalDetallesDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string IndicacionesAdicionales { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
    }
}