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
            foreach (var reserva in reservas.ReservasDetalles)
            {
                var extras = await BuscarArticulosExtras(reserva.ExtrasId);

                if (extras != null)
                {
                    if (extras.Existencia < reserva.Cantidad)
                    {
                        return false;
                    }
                    extras.Existencia -= reserva.Cantidad;
                    _contexto.ArticulosExtras.Update(extras);
                    await _contexto.SaveChangesAsync();
                }
                else
                {
                    return false;
                }
            }
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

            var detalles = await BuscarDetalle(reservas.ReservaId);

            foreach (var detalle in detalles)
            {
                var extra = await BuscarArticulosExtras(detalle.ExtrasId);
                if (extra != null)
                {
                    extra.Existencia += detalle.Cantidad;
                    await ActualizarArticulosExtras(extra);
                }
            }
            var reserva = await _contexto.Reservas
                        .Include(c => c.ReservasDetalles)
                        .FirstOrDefaultAsync(c => c.ReservaId == reservas.ReservaId);

            if (reserva == null) return false;

            _contexto.ReservasDetalle.RemoveRange(reserva.ReservasDetalles);
            _contexto.Reservas.Remove(reserva);

            var cantidad = await _contexto.SaveChangesAsync();
            return cantidad > 0;
        }

        public async Task<Reservas?> Buscar(int reservasId)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            return await _contexto.Reservas
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.ReservaId == reservasId);
        }

        public async Task<ArticulosExtras> BuscarArticulosExtras(int id)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();
            return await _contexto.ArticulosExtras
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.ExtrasId == id);
        }

        public async Task<List<ReservasDetalle>> BuscarDetalle(int id)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();
            return await _contexto.ReservasDetalle
                .Include(a => a.ArticulosExtras)
                .AsNoTracking()
                .Where(h => h.ReservaId == id)
                .ToListAsync();
        }

        public async Task<List<Reservas>> Listar(Expression<Func<Reservas, bool>> criterio)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            return await _contexto.Reservas
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
        public async Task<bool> ActualizarArticulosExtras(ArticulosExtras articulosExtras)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();
            _contexto.ArticulosExtras.Update(articulosExtras);
            return await _contexto
                .SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarDetalle(int detalleId)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();
            if (await ExisteDetalle(detalleId))
            {
                var reservaDetalle = await _contexto.ReservasDetalle.FirstOrDefaultAsync(h => h.ReservaDetalleId == detalleId);

                var extra = await _contexto.ArticulosExtras.FindAsync(reservaDetalle.ExtrasId);

                if (extra is null)
                {
                    return false;
                }
                else
                {
                    extra.Existencia += reservaDetalle.Cantidad;
                    _contexto.ArticulosExtras.Update(extra);
                }
                _contexto.ReservasDetalle.Remove(reservaDetalle);
            }

            else
            {
                var reservas = await _contexto.ReservasDetalle.FirstOrDefaultAsync(h => h.ReservaDetalleId == detalleId);

                if (reservas is null)
                {
                    return false;
                }

                _contexto.ReservasDetalle.Remove(reservas);
            }

            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> ExisteDetalle(int detalleId)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            return await _context.ReservasDetalle.AnyAsync(ed => ed.ReservaDetalleId == detalleId);
        }
    }
}
