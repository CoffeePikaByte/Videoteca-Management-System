using System.ComponentModel.DataAnnotations;
using VideotecaAPI.Models;

namespace VideotecaAPI.DTOs
{
    public class PeliculaListadoDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public int DuracionMin {  get; set; }

        public ICollection<string> Generos { get; set; }

    }
}
