using System.ComponentModel.DataAnnotations;
using VideotecaAPI.Models;

namespace VideotecaAPI.DTOs
{
    public class CategoriaDetallesDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EdadMinima { get; set; }
        public ICollection<PeliculaDetallesDTO> Peliculas { get; set; } = new List<PeliculaDetallesDTO>();
    }
}