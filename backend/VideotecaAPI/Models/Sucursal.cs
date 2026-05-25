using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Sucursal
    {
        [Required]
        int Id { get; set; }

        [Required]
        [MaxLength(100)]
        string Nombre { get; set; }

        [Required]
        int IdDireccion { get; set; }

        [Required]
        Direccion direccion { get; set; }

        [Required]
        int IdTelefono { get; set; }

        [Required]
        Telefono telefono{ get; set; }

        [Required]
        bool Estado { get; set; }
    }
}
