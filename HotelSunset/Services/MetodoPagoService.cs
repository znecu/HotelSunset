﻿using HotelSunset.Data;
using HotelSunset.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelSunset.Service;

public class MetodoPagoService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<List<MetodoPago>> Listar(Expression<Func<MetodoPago, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.MetodoPago
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<MetodoPago?> Buscar(int id)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.MetodoPago
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.MetodoPagoId == id);
    }
}
