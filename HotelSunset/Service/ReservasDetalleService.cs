using HotelSunset.Data;
using HotelSunset.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelSunset.Service;

public class ReservasDetalleService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<List<ReservasDetalle>> Listar(Expression<Func<ReservasDetalle, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.ReservasDetalle
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
