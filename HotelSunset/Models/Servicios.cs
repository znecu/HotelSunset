using System.ComponentModel.DataAnnotations;

namespace HotelSunset.Models;

public class Servicios
{
    [Key]
    public int ServicioId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras .")]
    public string? NombreServicio { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Solo se permiten letras y números.")]
    public string? Descripcion { get; set; }
}
