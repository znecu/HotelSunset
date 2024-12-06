using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelSunset.Models;

public class Habitaciones
{
    [Key]
    public int HabitacionId { get; set; }

    public int TipoHabitacionId { get; set; }
    [ForeignKey("TipoHabitacionId")]
    public TipoHabitaciones? TipoHabitaciones { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [RegularExpression("^[A-Z]-\\d{3}$", ErrorMessage = "El formato de ser: una letra mayuscula, - y tres numeros. ")]
    public string? NumeroHabitacion { get; set; }

    public bool Estado { get; set; } = true;  //True = habitacion disposible / false Reservada

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [Range(1, 999999, ErrorMessage = "Ingrese un número mayor que {1} y menor que {2}. ")]

    public double PrecioBase { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [Range(1, 4, ErrorMessage = "La capacidad debe ser entre 1 y 4.")]
    public int Capacidad { get; set; }

    public double MontoTotal { get; set; }

    public ICollection<HabitacionDetalle> HabitacionDetalles { get; set; } = new List<HabitacionDetalle>();

    public ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
