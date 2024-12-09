using HotelSunset.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelSunset.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Agregados> Agregados { get; set; }
        public DbSet<ArticulosExtras> ArticulosExtras { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<HabitacionDetalle> HabitacionDetalle { get; set; }
        public DbSet<Habitaciones> Habitaciones { get; set; }
        public DbSet<Tarjetas> Tarjetas { get; set; }
        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<ReservasDetalle> ReservasDetalle { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<TipoHabitaciones> TipoHabitaciones { get; set; }
        public DbSet<MetodoPago> MetodoPago { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MetodoPago>().HasData(
                new List<MetodoPago>()
                {
                    new()
                    {
                        MetodoPagoId = 1,
                        Descripcion = "Débito"
                    },

                    new()
                    {
                        MetodoPagoId = 2,
                        Descripcion = "Crédito"
                    }
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
