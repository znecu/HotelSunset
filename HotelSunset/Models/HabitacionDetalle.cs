﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSunset.Models
{
    public class HabitacionDetalle
    {
        [Key]
        public int HabitacionDetalleId { get; set; }

        public int AgregadoId { get; set; }
        [ForeignKey("AgregadoId")]
        public Agregados? Agregados { get; set; }

        public int HabitacionId { get; set; }
        [ForeignKey("HabitacionId")]
        public Habitaciones? Habitaciones { get; set; }

        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Range(1, 999999, ErrorMessage = "Ingrese un número mayor que {1} y menor que {2}")]
        public double Precio {  get; set; }
    }
}
