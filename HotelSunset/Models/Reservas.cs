﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelSunset.Models;

public class Reservas
{
    [Key]
    public int ReservaId { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFinal { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]

    public double Total { get; set; }

    public Clientes? Clientes { get; set; }
    
    public ICollection<ReservasDetalle> ReservasDetalles { get; set; } = new List<ReservasDetalle>();
    public ICollection<HabitacionReserva> HabitacionReserva { get; set; } = new List<HabitacionReserva>();
}
