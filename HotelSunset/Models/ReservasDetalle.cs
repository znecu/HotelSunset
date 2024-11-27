﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSunset.Models;

public class ReservasDetalle
{
    [Key]
    public int ReservaDetalleId { get; set; }

    [ForeignKey("ExtrasId")]
    public int ExtrasId { get; set; }

    [ForeignKey("ReservaId")]
    public int ReservaId { get; set; }

    public ArticulosExtras? ArticulosExtras { get; set; }
    public Reservas? Reservas { get; set; }

    [Range(1, 10, ErrorMessage = "La capacidad debe ser entre 1 y 10.")]
    public int Cantidad { get; set; }
  
}
