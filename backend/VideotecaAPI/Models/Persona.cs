using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Persona
    {
        [Required]
        int Id { get; set; }

        [Required]
        [MaxLength(50)]
        string DocumentoIdentidad { get; set; }

        [Required]
        [MaxLength(50)]
        string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        string PrimerApellido { get; set; }

        [Required]
        [MaxLength(50)]
        string SegundoApellico { get; set; }

        [Required]
        DateTime FechaNacimiento { get; set; }

        [Required]
        int IdDireccion { get; set; }

        [Required]
        Direccion Direccion { get; set; }

        [Required]
        int IdTelefono { get; set; }

        [Required]
        Telefono Telefono { get; set; }

    }
}
