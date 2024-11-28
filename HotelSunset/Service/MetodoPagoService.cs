using HotelSunset.Data;
using HotelSunset.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelSunset.Service;

public class MetodoPagoService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Guardar(MetodoPago metodoPago)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        if (!await Existe(metodoPago.MetodoPagoId))
        {
            return await Insertar(metodoPago);
        }
        else
        {
            return await Modificar(metodoPago);
        }
    }
    private async Task<bool> Existe(int metodoPagoId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.MetodoPago
            .AnyAsync(m => m.MetodoPagoId == metodoPagoId);
    }
    private async Task<bool> Insertar(MetodoPago metodoPago)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.MetodoPago.Add(metodoPago);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(MetodoPago metodoPago)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Update(metodoPago);
        return await _contexto.SaveChangesAsync() > 0;

    }

    public async Task<bool> Eliminar(MetodoPago metodoPago)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.MetodoPago
            .AsNoTracking()
            .Where(m => m.MetodoPagoId == metodoPago.MetodoPagoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<MetodoPago?> Buscar(int metodoPagoId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.MetodoPago
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.MetodoPagoId == metodoPagoId);
    }
    public async Task<List<MetodoPago>> Listar(Expression<Func<MetodoPago, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.MetodoPago
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
