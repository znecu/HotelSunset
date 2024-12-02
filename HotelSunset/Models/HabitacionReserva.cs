using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelSunset.Models;

public class HabitacionReserva
{
    [Key]
    public int HabitacionReservaId { get; set; }

    public int ReservaId { get; set; }
    [ForeignKey("ReservaId")]
    public Reservas? Reservas { get; set; }

    public int HabitacionId { get; set; }
    [ForeignKey("HabitacionId")]
    public Habitaciones? Habitaciones { get; set; }
}
