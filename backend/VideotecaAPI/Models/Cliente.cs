using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public int IdPersona { get; set; }

        public Persona persona { get; set; }

        public string Identificacion { get; set; }

        public DateTime FechaRegisto { get; set; }

        public bool Activo { get; set; }
    }
}
