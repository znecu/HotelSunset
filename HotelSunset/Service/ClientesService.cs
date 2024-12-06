using HotelSunset.Data;
using HotelSunset.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelSunset.Service
{
    public class ClientesService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<bool> Guardar(Clientes cliente)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            if (!await Existe(cliente.ClienteId))
            {
                return await Insertar(cliente);
            }
            else
            {
                return await Modificar(cliente);
            }
        }
        private async Task<bool> Existe(int clienteId)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            return await _contexto.Clientes
                .AnyAsync(c => c.ClienteId == clienteId);
        }

        public async Task<bool> ExisteCliente(int clientesId, string nombres, string telefono, string email, string cedula)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();
            return await _contexto.Clientes
                .AnyAsync(c => c.ClienteId != clientesId &&
                (c.Nombres.ToLower().Equals(nombres.ToLower()) || c.Telefono.Equals(telefono) || c.Email.Equals(email) || c.Cedula.Equals(cedula)));
        }

        private async Task<bool> Insertar(Clientes cliente)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            _contexto.Clientes.Add(cliente);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Clientes cliente)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            _contexto.Update(cliente);
            return await _contexto.SaveChangesAsync() > 0;

        }

        public async Task<bool> Eliminar(Clientes cliente)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            return await _contexto.Clientes
                .AsNoTracking()
                .Where(c => c.ClienteId == cliente.ClienteId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Clientes?> Buscar(int clienteId)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            return await _contexto.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClienteId == clienteId);
        }

        public async Task<bool> ExisteCliente(int clienteId, string nombre, string email, string cedula)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            return await _contexto.Clientes
                .AnyAsync(c => c.ClienteId != clienteId
                && (c.Nombres.ToLower().Equals(nombre.ToLower())
                || c.Email.ToLower().Equals(email.ToLower())
                || c.Cedula.ToLower().Equals(cedula.ToLower())));
        }

        public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            return await _contexto.Clientes
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
