

using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.DTOs
{
    public class PrestamoDetallesCrearDTO
    {
        [Required]
        public int IdPelicula {get;set;}
        
        [Required]
        public int Cantidad {get;set;}


    }


}