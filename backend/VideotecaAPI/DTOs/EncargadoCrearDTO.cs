using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.DTOs
{
    public class EncargadoCrearDTO
    {
        [Required]
        public string DocumentoIdentidad { get; set; }
        [Required]
        [MaxLength(50)]
        public string CodigoEncargado { get; set; }
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
        public DateTime FechaIngreso { get; set; }

        [Required]
        [MaxLength(20)]    
        public string Telefono { get; set; }
        [Required]
        [MaxLength(100)]
        public string Pais { get; set; }
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
        public string IndicacionesAdiccionales { get; set; }  
    }
}