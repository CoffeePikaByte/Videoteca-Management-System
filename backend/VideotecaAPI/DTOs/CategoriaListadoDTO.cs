using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.DTOs
{
    public class CategoriaListadoDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public int EdadMinima { get; set; }

    }
}