using System.ComponentModel.DataAnnotations;

namespace HotelSunset.Models;
public class ArticulosExtras
{
    [Key]
    public int ExtrasId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo solo permite letras. ")]
    public string? Descripcion { get; set; }
    public double Precio { get; set; }

    [Range(1,500, ErrorMessage = "El articulo esta agotado.")]
    public int Cantidad { get; set; }

}

