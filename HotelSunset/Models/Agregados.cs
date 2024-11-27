using System.ComponentModel.DataAnnotations;

namespace HotelSunset.Models
{
    public class Agregados
    {
        [Key]
        public int AgregadoId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Solo se permiten letras y numeros.")]
        public string? Descripcion { get; set; }

        public double Precio { get; set; }

        public int Existencia { get; set; }
    }
}
