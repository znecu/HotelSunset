using HotelSunset.Data;
using HotelSunset.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelSunset.Service;

public class HabitacionesService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Guardar(Habitaciones habitacion)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        if (!await Existe(habitacion.HabitacionId))
        {
            return await Insertar(habitacion);
        }
        else
        {
            return await Modificar(habitacion);
        }
    }
    private async Task<bool> Existe(int habitacionId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Habitaciones
            .AnyAsync(c => c.HabitacionId == habitacionId);
    }
    private async Task<bool> Insertar(Habitaciones habitacion)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Habitaciones.Add(habitacion);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Habitaciones habitacion)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Update(habitacion);
        return await _contexto.SaveChangesAsync() > 0;

    }

    public async Task<bool> Eliminar(Habitaciones habitacion)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Habitaciones
            .AsNoTracking()
            .Where(c => c.HabitacionId == habitacion.HabitacionId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<Habitaciones?> Buscar(int habitacionId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Habitaciones
            .Include(h => h.HabitacionDetalles)
            .Include(t => t.TipoHabitaciones)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.HabitacionId == habitacionId);
    }

    public async Task<List<HabitacionDetalle>> BuscarDetalle(int id)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.HabitacionDetalle
            .Include(a => a.Agregados)
            .AsNoTracking()
            .Where(h => h.HabitacionId == id)
            .ToListAsync();
    }

    //public async Task<List<Habitaciones>> BuscarHabitacionDisponibles(DateTime fechaInicio, DateTime fechaFinal)
    //{
    //    await using var _contexto = await DbFactory.CreateDbContextAsync();

    //    return await _contexto.Habitaciones
    //        .Include(h => h.TipoHabitaciones)
    //        .Where(h => !h.Reservas.Any(r =>
    //            (fechaInicio >= r.FechaInicio && fechaInicio < r.FechaFinal) ||
    //            (fechaFinal > r.FechaInicio && fechaFinal <= r.FechaFinal) ||
    //            (r.FechaInicio >= fechaInicio && r.FechaFinal <= fechaFinal)))
    //        .ToListAsync();
    //}

    public async Task<List<Habitaciones>> ListarConDetalles()
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Habitaciones
            .Include(h => h.TipoHabitaciones) // Incluye la relación con TipoHabitacion (si existe)
            /*.Include(h => h.Reservas)*/ // Incluye reservas (si quieres relacionarlas)
            .ToListAsync();
    }


    public async Task<List<Habitaciones>> Listar(Expression<Func<Habitaciones, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Habitaciones
            .Include(h => h.TipoHabitaciones)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
