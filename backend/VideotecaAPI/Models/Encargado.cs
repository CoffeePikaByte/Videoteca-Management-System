using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Encargado
    {
        [Required]
        int Id { get; set; }

        [Required]
        int IdPersona { get; set; }

        [Required]
        Persona Persona { get; set; }

        [Required]
        [MaxLength(50)]
        string CodigoIdentificacion { get; set; }

        [Required]
        DateTime FechaIngreso { get; set; }
    }
}
