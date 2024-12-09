using HotelSunset.Data;
using HotelSunset.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelSunset.Service;

public class ArticulosExtrasService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Guardar(ArticulosExtras extras)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        if (!await Existe(extras.ExtrasId))
        {
            return await Insertar(extras);
        }
        else
        {
            return await Modificar(extras);
        }
    }
    private async Task<bool> Existe(int extrasId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.ArticulosExtras
            .AnyAsync(e => e.ExtrasId == extrasId);
    }
    public async Task<bool> ExisteArticuloExtra(int extraId, string descripcion)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.ArticulosExtras
            .AnyAsync(t => t.ExtrasId != extraId &&
                t.Descripcion.ToLower().Equals(descripcion.ToLower()));
    }
    private async Task<bool> Insertar(ArticulosExtras extras)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.ArticulosExtras.Add(extras);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(ArticulosExtras extras)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Update(extras);
        return await _contexto.SaveChangesAsync() > 0;

    }

    public async Task<bool> Eliminar(ArticulosExtras extras)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.ArticulosExtras
            .AsNoTracking()
            .Where(e => e.ExtrasId == extras.ExtrasId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<ArticulosExtras?> Buscar(int extrasId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.ArticulosExtras
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.ExtrasId == extrasId);
    }
    public async Task<List<ArticulosExtras>> Listar(Expression<Func<ArticulosExtras, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.ArticulosExtras
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
