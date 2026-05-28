using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Genero
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(500)]
        public string Descripcion { get; set; }

        public ICollection<PeliculasGeneros> PeliculasGeneros { get; set; }
    }
}
