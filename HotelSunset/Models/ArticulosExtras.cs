using System.ComponentModel.DataAnnotations;

namespace HotelSunset.Models;
public class ArticulosExtras
{
    [Key]
    public int ExtrasId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [RegularExpression(@"^[\p{L}\s]+$", ErrorMessage = "Solo se permiten letras, espacios y acentos.")]
    public string? Descripcion { get; set; }
    public double Precio { get; set; }

    [Range(1,500, ErrorMessage = "El articulo está agotado.")]
    public int Existencia { get; set; }

}

