using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Cliente
    {
        [Required]
        int Id { get; set; }

        [Required]
        int IdPersona { get; set; }

        [Required]
        Persona persona { get; set; }

        [Required]
        [MaxLength(50)]
        string Identificacion { get; set; }

        [Required]
        DateTime FechaRegistro { get; set; }

        [Required]
        bool Activo { get; set; }
    }
}
