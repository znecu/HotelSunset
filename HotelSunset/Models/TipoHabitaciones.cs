using System.ComponentModel.DataAnnotations;

namespace HotelSunset.Models;

public class TipoHabitaciones
{
    [Key]
    public int TipoHabitacionId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo solo permite letras. ")]
    public string? Categoria { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [RegularExpression(@"^[\p{L}\s]+$", ErrorMessage = "Solo se permiten letras, espacios y acentos.")]
    public string? Descripcion { get; set; }
}
