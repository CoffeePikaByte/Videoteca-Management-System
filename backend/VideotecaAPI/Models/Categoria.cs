using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Categoria
    {
        [Required]
        int Id { get; set; }

        [Required]
        [MaxLength(100)]
        string Nombre { get; set; }

        [Required]
        [Range(0, 18)]
        int EdadMinima { get; set; }
    }
}
