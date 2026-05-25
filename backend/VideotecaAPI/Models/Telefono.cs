using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Telefono
    {
        [Required]
        int Id { get; set; }

        [Required]
        [MaxLength(20)]
        string Numero { get; set; }

    }
}
