using HotelSunset.Data;
using HotelSunset.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelSunset.Service;

public class TipoHabitacionService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Guardar(TipoHabitaciones tipoHabitacion)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        if (!await Existe(tipoHabitacion.TipoHabitacionId))
        {
            return await Insertar(tipoHabitacion);
        }
        else
        {
            return await Modificar(tipoHabitacion);
        }
    }
    private async Task<bool> Existe(int tipoHabitacionId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.TipoHabitaciones
            .AnyAsync(t => t.TipoHabitacionId == tipoHabitacionId);
    }
    public async Task<bool> ExisteTipoHabitacion(int tipoHabitacionId, string descripcion, string categoria)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.TipoHabitaciones
            .AnyAsync(t => t.TipoHabitacionId != tipoHabitacionId &&
            (t.Descripcion.Equals(descripcion) || t.Categoria.ToLower().Equals(categoria.ToLower())));

    }
    private async Task<bool> Insertar(TipoHabitaciones tipoHabitacion)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.TipoHabitaciones.Add(tipoHabitacion);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(TipoHabitaciones tipoHabitacion)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Update(tipoHabitacion);
        return await _contexto.SaveChangesAsync() > 0;

    }

    public async Task<bool> Eliminar(TipoHabitaciones tipoHabitacion)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.TipoHabitaciones
            .AsNoTracking()
            .Where(t => t.TipoHabitacionId == tipoHabitacion.TipoHabitacionId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<TipoHabitaciones?> Buscar(int tipoHabitacionId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.TipoHabitaciones
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TipoHabitacionId == tipoHabitacionId);
    }
    public async Task<List<TipoHabitaciones>> Listar(Expression<Func<TipoHabitaciones, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.TipoHabitaciones
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
