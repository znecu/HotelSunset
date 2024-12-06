using System.ComponentModel.DataAnnotations;

namespace HotelSunset.Models
{
    public class Agregados
    {
        [Key]
        public int AgregadoId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression(@"^[\p{L}\s]+$", ErrorMessage = "Solo se permiten letras, espacios y acentos.")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio. ")]
        [Range(1, 500000, ErrorMessage = "El precio debe ser entre 1 y 500,000")]
        public double Precio { get; set; }

        [Range(1, 500, ErrorMessage = "La exitencia debe ser entre 1 y 500.")]
        public int Existencia { get; set; }
    }
}
