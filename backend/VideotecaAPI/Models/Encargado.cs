using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Encargado
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int IdPersona { get; set; }

        [Required]
        public Persona Persona { get; set; }

        [Required]
        [MaxLength(50)]
        public string CodigoIdentificacion { get; set; }

        [Required]
        public DateTime FechaIngreso { get; set; }
    }
}
