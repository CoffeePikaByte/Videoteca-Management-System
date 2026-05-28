using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Sucursal
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        public int IdDireccion { get; set; }

        [Required]
        public Direccion Direccion { get; set; }

        [Required]
        public int IdTelefono { get; set; }

        [Required]
        public Telefono Telefono{ get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
