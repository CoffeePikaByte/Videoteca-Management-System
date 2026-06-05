using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EdadMinima { get; set; }
        public ICollection<Pelicula> Peliculas { get; set; }
    }
}
