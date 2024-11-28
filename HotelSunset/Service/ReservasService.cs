using HotelSunset.Data;
using HotelSunset.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelSunset.Service
{
    public class ReservasService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<bool> Guardar(Reservas reservas)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            if (!await Existe(reservas.ReservaId))
            {
                return await Insertar(reservas);
            }
            else
            {
                return await Modificar(reservas);
            }
        }
        private async Task<bool> Existe(int reservasId)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            return await _contexto.Reservas
                .AnyAsync(r => r.ReservaId == reservasId);
        }
        private async Task<bool> Insertar(Reservas reservas)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            _contexto.Reservas.Add(reservas);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Reservas reservas)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            _contexto.Update(reservas);
            return await _contexto.SaveChangesAsync() > 0;

        }

        public async Task<bool> Eliminar(Reservas reservas)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            return await _contexto.Reservas
                .AsNoTracking()
                .Where(r => r.ReservaId == reservas.ReservaId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Reservas?> Buscar(int reservasId)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            return await _contexto.Reservas
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.ReservaId == reservasId);
        }
        public async Task<List<Reservas>> Listar(Expression<Func<Reservas, bool>> criterio)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            return await _contexto.Reservas
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
