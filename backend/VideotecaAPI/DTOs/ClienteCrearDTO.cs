using System.ComponentModel.DataAnnotations;
using VideotecaAPI.Models;

namespace VideotecaAPI.DTOs
{
    public class ClienteCrearDTO
    {
        [Required]
        [MaxLength(50)]
        public string DocumentoIdentidad { get; set; }

        [Required]
        [MaxLength(50)]
        public string CodigoCliente { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string PrimerApellido { get; set; }
        [Required]
        [MaxLength(50)] 
        public string SegundoApellido { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [MaxLength(100)]
        public string pais { get; set; }
        [Required]
        [MaxLength(100)]
        public string Provincia { get; set; }
        [Required]
        [MaxLength(100)]
        public string Canton { get; set; }
        [Required]
        [MaxLength(100)]
        public string Distrito { get; set; }
        [MaxLength(500)]
        public string? IndicacionesAdiccionales { get; set; }
        [Required]
        [MaxLength(20)]
        public string Telefono { get; set; }
    }
}