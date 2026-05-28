using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Cliente
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int IdPersona { get; set; }

        [Required]
        public Persona persona { get; set; }

        [Required]
        [MaxLength(50)]
        public string Identificacion { get; set; }

        [Required]
        DateTime FechaRegistro { get; set; }

        [Required]
        public bool Activo { get; set; }
    }
}
