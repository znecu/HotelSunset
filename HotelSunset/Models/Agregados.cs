using System.ComponentModel.DataAnnotations;

namespace HotelSunset.Models
{
    public class Agregados
    {
        [Key]
        public int AgregadoId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Solo se permiten letras y numeros.")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio. ")]
        [Range(1, double.MaxValue, ErrorMessage = "El precio es demasido alto para el sistema")]
        public double Precio { get; set; }

        [Range(1, 500, ErrorMessage = "La capacidad debe ser entre 1 y 500.")]
        public int Existencia { get; set; }
    }
}
