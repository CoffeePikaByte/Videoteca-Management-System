using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Categoria
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [Range(0, 18)]
        public int EdadMinima { get; set; }
    }
}
