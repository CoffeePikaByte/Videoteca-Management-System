using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.DTOs
{
    public class PeliculaActualizarDTO
    {
        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; }

        [Required]
        [Range(1900, 2900)]
        public int AnioLanzamiento { get; set; }

        [Required]
        [MaxLength (50)]
        public string Idioma { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int DuracionMin { get; set; }

        [Required]
        public int IdCategoria { get; set; }

    }
}
