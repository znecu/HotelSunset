using HotelSunset.Data;
using HotelSunset.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelSunset.Service;

public class HabitacionesDetalleService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<List<HabitacionDetalle>> Listar(Expression<Func<HabitacionDetalle, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.HabitacionDetalle
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<List<HabitacionDetalle>> ListarDetalle(int id)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        var detalle = await _contexto.HabitacionDetalle
            .Where(d => d.HabitacionDetalleId == id)
            .ToListAsync();

        return detalle;
    }
}
