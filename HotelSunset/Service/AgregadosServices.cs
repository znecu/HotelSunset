using HotelSunset.Data;
using HotelSunset.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelSunset.Service;

public class AgregadosServices(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Guardar(Agregados agregados)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        if (!await Existe(agregados.AgregadoId))
        {
            return await Insertar(agregados);
        }
        else
        {
            return await Modificar(agregados);
        }
    }
    private async Task<bool> Existe(int agregadosId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Agregados
            .AnyAsync(c => c.AgregadoId == agregadosId);
    }
    private async Task<bool> Insertar(Agregados agregados)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Agregados.Add(agregados);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Agregados agregados)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Update(agregados);
        return await _contexto.SaveChangesAsync() > 0;

    }

    public async Task<bool> Eliminar(Agregados agregados)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Agregados
            .AsNoTracking()
            .Where(a => a.AgregadoId == agregados.AgregadoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<bool> ExisteAgregados(int agregadosId, string Descripcion)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Agregados
            .AnyAsync(c => c.AgregadoId != agregadosId
            && (c.Descripcion.ToLower().Equals(Descripcion.ToLower())));
    }

    public async Task<Agregados?> Buscar(int agregadosId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Agregados
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.AgregadoId == agregadosId);
    }
    public async Task<List<Agregados>> Listar(Expression<Func<Agregados, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Agregados
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
