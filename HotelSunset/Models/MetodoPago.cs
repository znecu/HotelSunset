﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelSunset.Models;

public class MetodoPago
{
    [Key]
    public int MetodoPagoId { get; set; }

    [ForeignKey("ClienteId")]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string? NombresApellido { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [RegularExpression(@"^\d{16}$", ErrorMessage = "El número de tarjeta debe contener 16 dígitos.")]
    public string? NumeroTarjeta { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{4}$", ErrorMessage = "La fecha debe tener el formato MM/AAAA.")]
    public string? FechaExpiracion { get; set; }

    [RegularExpression(@"^\d{3}$", ErrorMessage = "El código de seguridad debe contener 3 dígitos.")]
    public string? CodigoSeguridad { get; set; }
    public Clientes? Clientes { get; set; }
}