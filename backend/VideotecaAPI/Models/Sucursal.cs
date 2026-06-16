using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Sucursal
    {
        public int Id { get; set; }


        public string Nombre { get; set; }

        public int IdDireccion { get; set; }

        public Direccion Direccion { get; set; }

        public int IdTelefono { get; set; }

        public Telefono Telefono{ get; set; }

        public bool Estado { get; set; }
    }
}
