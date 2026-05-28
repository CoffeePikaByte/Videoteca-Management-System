using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Persona
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string DocumentoIdentidad { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string PrimerApellido { get; set; }

        [Required]
        [MaxLength(50)]
        public string SegundoApellico { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public int IdDireccion { get; set; }

        [Required]
        public Direccion Direccion { get; set; }

        [Required]
        public int IdTelefono { get; set; }

        [Required]
        public Telefono Telefono { get; set; }

    }
}
