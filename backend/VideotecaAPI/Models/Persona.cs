using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Persona
    {
        public int Id { get; set; }

        public string DocumentoIdentidad { get; set; }

        public string Nombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int IdDirecciones { get; set; }

        public Direccion Direcciones { get; set; }

        public int IdTelefono { get; set; }

        public Telefono Telefono { get; set; }

    }
}
