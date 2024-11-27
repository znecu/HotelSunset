using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelSunset.Models
{
    public class Habitaciones
    {
        [Key]
        public int HabitacionId { get; set; }

        [ForeignKey("TipoHabitacionId")]
        public int TipoHabitacionId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras.")]
        public string? NumeroHabitacion { get; set; }

        public bool Estado { get; set; } = true;  //True = habitacion disposible / false Reservada

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Range(1, double.MaxValue, ErrorMessage = "El precio es demasido alto para el sistema")]

        public double PrecioBase { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Range(1, 4, ErrorMessage = "La capacidad debe ser entre 1 y 4.")]
        public int Capacidad { get; set; }

        public TipoHabitaciones? TipoHabitaciones { get; set; }

        public ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
        public ICollection<HabitacionDetalle> habitacionDetalles { get; set; } = new List<HabitacionDetalle>();
    }
}
