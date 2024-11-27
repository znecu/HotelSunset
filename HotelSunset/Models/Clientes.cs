﻿using System.ComponentModel.DataAnnotations;

namespace HotelSunset.Models;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Solo se permiten lestras en este campo.")]
    public string? Nombres { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [RegularExpression(@"^(809|829|849|853|862)-[0-9]{7}$", ErrorMessage = "El número de teléfono debe ser válido y tener el formato correcto (ej. 809-1234567).")]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "La cédula debe tener 11 dígitos.")]
    public string? Cedula { get; set; }
    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    public ICollection<MetodoPago> MetodoPagos { get; set; } = new List<MetodoPago>();
    public ICollection<Reservas>? Reservas { get; set; } = new List<Reservas>();
}
