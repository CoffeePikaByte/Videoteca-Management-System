using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.DTOs
{
    public class CategoriaCrearDTO
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [Range(0, 18)]
        public int EdadMinima { get; set; }
    }
}