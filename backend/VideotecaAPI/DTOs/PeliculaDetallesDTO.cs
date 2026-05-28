using System.ComponentModel.DataAnnotations;
using VideotecaAPI.Models;

namespace VideotecaAPI.DTOs
{
    public class PeliculaDetallesDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public int AnioLanzamiento { get; set; }

        public string Idioma { get; set; }

        public int DuracionMin { get; set; }

        public string Categoria { get; set; }

        public int EdadMinima { get; set; }

        public ICollection<string> Generos { get; set; } = new List<string>();
    }
}
