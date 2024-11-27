using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSunset.Models
{
    public class HabitacionDetalle
    {
        [Key]
        public int HabitacionDetalleId { get; set; }

        [ForeignKey("AgregadoId")]
        public int AgregadoId { get; set; }

        [ForeignKey("HabitacionId")]
        public int HabitacionId { get; set; }
        public Agregados? Agregados { get; set; }
        public Habitaciones? Habitaciones { get; set; }
        public int Cantidad { get; set; }

        [Range(1, 4, ErrorMessage = "El monto debe ser mayor a 0.")]
        public double Precio {  get; set; }
    }
}
