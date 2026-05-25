using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Pelicula
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int AnioLanzamiento { get; set; }

        [Required]
        [MaxLength(50)]
        public string Idioma { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int DuracionMin { get; set; }

        [Required]
        public int IdCategoria { get; set; }

        [Required]
        public Categoria categoria { get; set; }
    }
}
