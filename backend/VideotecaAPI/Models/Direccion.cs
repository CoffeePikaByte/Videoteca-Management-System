using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Direccion
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Pais {  get; set; }

        [Required]
        [MaxLength(100)]
        public string Provincia { get; set; }

        [Required]
        [MaxLength(100)]
        public string Canton {  get; set; }

        [MaxLength(100)]
        public string? Distrito { get; set; }

        [MaxLength(500)]
        public string? IndicacionesAdiccionales { get; set; }

    }
}
