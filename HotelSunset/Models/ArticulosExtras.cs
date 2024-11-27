using System.ComponentModel.DataAnnotations;

namespace HotelSunset.Models;
public class ArticulosExtras
{
    [Key]
    public int ExtrasId { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Solo se permiten letras y numeros.")]
    public string? Descripcion { get; set; }
    public double Precio { get; set; }
    public int Cantidad { get; set; }

    [Range(1,500, ErrorMessage = "El articulo esta agotado.")]
    public int Existencia { get; set; }

}

