using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Genero
    {
        [Required]
        int Id { get; set; }

        [Required]
        [MaxLength(100)]
        string Nombre { get; set; }

        [Required]
        [MaxLength(500)]
        string Descripcion { get; set; }
    }
}
