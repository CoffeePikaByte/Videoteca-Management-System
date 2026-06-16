using System.ComponentModel.DataAnnotations;
using VideotecaAPI.Models;

namespace VideotecaAPI.DTOs
{
    public class ClienteListadoDTO
    {
        public int Id { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string CodigoCliente { get; set; }   
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        
        public bool Activo { get; set; }

    }
}