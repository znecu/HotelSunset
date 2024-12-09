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
    private async Task<bool> Insertar(Habitaciones habitaciones)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        foreach (var habitacion in habitaciones.HabitacionDetalles)
        {
            var agregados = await BuscarAgregados(habitacion.AgregadoId);

            if (agregados != null)
            {
                if (agregados.Existencia < habitacion.Cantidad)
                {
                    return false;
                }
                agregados.Existencia -= habitacion.Cantidad;
                _contexto.Agregados.Update(agregados);
                await _contexto.SaveChangesAsync();
            }
            else
            {
                return false;
            }
        }
        _contexto.Habitaciones.Add(habitaciones);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Habitaciones habitacion)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Update(habitacion);
        return await _contexto.SaveChangesAsync() > 0;

    }

    public async Task<bool> Eliminar(Habitaciones habitaciones)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        var detalles = await BuscarDetalle(habitaciones.HabitacionId);

        foreach (var detalle in detalles)
        {
            var agregado = await BuscarAgregados(detalle.AgregadoId);
            if (agregado != null)
            {
                agregado.Existencia += detalle.Cantidad;
                await ActualizarAgregados(agregado);
            }
        }
        var habitacion = await _contexto.Habitaciones
                    .Include(c => c.HabitacionDetalles)
                    .FirstOrDefaultAsync(c => c.HabitacionId == habitaciones.HabitacionId);

        if (habitacion == null) return false;

        _contexto.HabitacionDetalle.RemoveRange(habitacion.HabitacionDetalles);
        _contexto.Habitaciones.Remove(habitacion);

        var cantidad = await _contexto.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<Habitaciones?> Buscar(int habitacionId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Habitaciones
            .Include(h => h.HabitacionDetalles)
            .Include(t => t.TipoHabitaciones)
            .Include(r => r.Reservas)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.HabitacionId == habitacionId);
    }
    public async Task<Agregados> BuscarAgregados(int id)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Agregados
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.AgregadoId == id);
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

    public async Task<List<Habitaciones>> ListarConDetalles()
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Habitaciones
            .Include(h => h.TipoHabitaciones)
            .Include(r => r.Reservas)
            .Include(d => d.HabitacionDetalles)
            .ToListAsync();
    }

    public async Task<List<Habitaciones>> Listar(Expression<Func<Habitaciones, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Habitaciones
            .Include(h => h.TipoHabitaciones)
            .Include(h => h.Reservas)
            .Include(d => d.HabitacionDetalles)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> ActualizarAgregados(Agregados agregado)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        _contexto.Agregados.Update(agregado);
        return await _contexto
            .SaveChangesAsync() > 0;
    }

    public async Task<bool> EliminarDetalle(int detalleId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        if (await ExisteDetalle(detalleId))
        {
            var habitacionDetalle = await _contexto.HabitacionDetalle.FirstOrDefaultAsync(h => h.HabitacionDetalleId == detalleId);

            var agregado = await _contexto.Agregados.FindAsync(habitacionDetalle.AgregadoId);

            if (agregado is null)
            {
                return false;
            }
            else
            {
                agregado.Existencia += habitacionDetalle.Cantidad;
                _contexto.Agregados.Update(agregado);
            }
            _contexto.HabitacionDetalle.Remove(habitacionDetalle);
        }

        else
        {
            var habitaciones = await _contexto.HabitacionDetalle.FirstOrDefaultAsync(h => h.HabitacionDetalleId == detalleId);

            if (habitaciones is null)
            {
                return false;
            }

            _contexto.HabitacionDetalle.Remove(habitaciones);
        }

        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> ExisteDetalle(int detalleId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.HabitacionDetalle.AnyAsync(ed => ed.HabitacionDetalleId == detalleId);
    }
}
