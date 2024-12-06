using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSunset.Models;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }

    public int ReservasId { get; set; }
    [ForeignKey("ReservasId")]
    public Reservas? Reservas { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [RegularExpression(@"^[\p{L}\s]+$", ErrorMessage = "Solo se permiten letras, espacios y acentos.")]
    public string? Nombres { get; set; }


    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [RegularExpression(@"^(809|829|849|853|862)-[0-9]{7}$", ErrorMessage = "El número de teléfono debe ser válido y tener el formato correcto (ej. 809-1234567).")]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "El correo electrónico no tiene un formato válido.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "La cédula debe tener 11 dígitos.")]
    public string? Cedula { get; set; }

}
