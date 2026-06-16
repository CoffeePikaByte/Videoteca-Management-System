using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Encargado
    {
        public int Id { get; set; }

        public int IdPersona { get; set; }

        public Persona Persona { get; set; }

    
        public string CodigoIdentificacion { get; set; }

        public DateTime FechaIngreso { get; set; }
    }
}
