

namespace VideotecaAPI.DTOs
{
    public class EncargadoDetallesDTO
    {
        public int Id { get; set; }
        public string DocumentoIdentidad { get; set; }

        public string CodigoEncargado { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string IndicacionesAdiccionales { get; set; }
    }
}