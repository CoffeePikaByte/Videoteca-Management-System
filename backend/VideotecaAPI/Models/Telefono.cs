using System.ComponentModel.DataAnnotations;

namespace VideotecaAPI.Models
{
    public class Telefono
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Numero { get; set; }

    }
}
