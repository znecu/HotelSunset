using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelSunset.Models;

public class Reservas
{
    [Key]
    public int ReservaId { get; set; }

    [ForeignKey("ClienteId")]
    public int ClienteId { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFinal { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public bool? EstadoReserva { get; set; } = true;

    public double Total { get; set; }

    public Clientes? Clientes { get; set; }
    public ICollection<Habitaciones>? habitaciones { get; set; } = new List<Habitaciones>();
    public ICollection<ReservasDetalle> ReservasDetalles { get; set; } = new List<ReservasDetalle>();
}
