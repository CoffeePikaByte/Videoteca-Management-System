using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.DTOs
{
    public class SucursalCrearDTO
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
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
        public string IndicacionesAdicionales { get; set; }
        [Required]
        [MaxLength(20)]
        public string Telefono { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}