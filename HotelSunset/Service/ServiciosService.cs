using HotelSunset.Data;
using HotelSunset.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelSunset.Service;

public class ServiciosService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Guardar(Servicios servicio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        if (!await Existe(servicio.ServicioId))
        {
            return await Insertar(servicio);
        }
        else
        {
            return await Modificar(servicio);
        }
    }
    private async Task<bool> Existe(int servicioId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Servicios
            .AnyAsync(s => s.ServicioId == servicioId);
    }
    private async Task<bool> Insertar(Servicios servicio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Servicios.Add(servicio);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Servicios servicio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Update(servicio);
        return await _contexto.SaveChangesAsync() > 0;

    }

    public async Task<bool> Eliminar(Servicios servicio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Servicios
            .AsNoTracking()
            .Where(s => s.ServicioId == servicio.ServicioId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<Servicios?> Buscar(int servicioId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Servicios
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.ServicioId == servicioId);
    }
    public async Task<List<Servicios>> Listar(Expression<Func<Servicios, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Servicios
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
