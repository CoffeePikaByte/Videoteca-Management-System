using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Direccion
    {
        [Required]
        int Id { get; set; }

        [Required]
        [MaxLength(100)]
        string Pais {  get; set; }

        [Required]
        [MaxLength(100)]
        string Provincia { get; set; }

        [Required]
        [MaxLength(100)]
        string Canton {  get; set; }

        [MaxLength(100)]
        string? Distrito { get; set; }

        [MaxLength(500)]
        string? IndicacionesEspecificas { get; set; }
    }
}
