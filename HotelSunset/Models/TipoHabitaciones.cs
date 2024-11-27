using System.ComponentModel.DataAnnotations;

namespace HotelSunset.Models;

public class TipoHabitaciones
{
    [Key]
    public int TipoHabitacionId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string? categoria { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string? Descripcion { get; set; }
}
