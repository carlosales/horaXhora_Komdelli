using Microsoft.EntityFrameworkCore;
using hora_Komdelli.Data;
using hora_Komdelli.Models;

namespace hora_Komdelli.Services;

public class ProducaoService : IProducaoService
{
    // Corte Executado
    public async Task<bool> SalvarCorteExecutadoAsync(CorteExecutado corte, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var context = new AppDbContext();
            await context.CortesExecutados.AddAsync(corte, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<List<CorteExecutado>> ObterTodosCortesExecutadosAsync(CancellationToken cancellationToken = default)
    {
        await using var context = new AppDbContext();
        return await context.CortesExecutados.ToListAsync(cancellationToken);
    }

    public async Task<CorteExecutado?> ObterCorteExecutadoPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await using var context = new AppDbContext();
        return await context.CortesExecutados.FindAsync([id], cancellationToken);
    }

    public async Task<bool> AtualizarCorteExecutadoAsync(CorteExecutado corte, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var context = new AppDbContext();
            context.CortesExecutados.Update(corte);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> ExcluirCorteExecutadoAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var context = new AppDbContext();
            var corte = await context.CortesExecutados.FindAsync([id], cancellationToken);
            if (corte == null) return false;
            
            context.CortesExecutados.Remove(corte);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    // Corte Planejado
    public async Task<bool> SalvarCortePlanejadoAsync(CortePlanejado corte, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var context = new AppDbContext();
            await context.CortesPlanejados.AddAsync(corte, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<List<CortePlanejado>> ObterTodosCortesPlanejadosAsync(CancellationToken cancellationToken = default)
    {
        await using var context = new AppDbContext();
        return await context.CortesPlanejados.ToListAsync(cancellationToken);
    }

    // OP Executado
    public async Task<bool> SalvarOpExecutadoAsync(OpExecutado op, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var context = new AppDbContext();
            await context.OpsExecutados.AddAsync(op, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<List<OpExecutado>> ObterTodosOpsExecutadosAsync(CancellationToken cancellationToken = default)
    {
        await using var context = new AppDbContext();
        return await context.OpsExecutados.ToListAsync(cancellationToken);
    }

    // OP Planejado
    public async Task<bool> SalvarOpPlanejadoAsync(OpPlanejado op, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var context = new AppDbContext();
            await context.OpsPlanejados.AddAsync(op, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<List<OpPlanejado>> ObterTodosOpsPlanejadosAsync(CancellationToken cancellationToken = default)
    {
        await using var context = new AppDbContext();
        return await context.OpsPlanejados.ToListAsync(cancellationToken);
    }

    // Parada Corte
    public async Task<bool> SalvarParadaCorteAsync(ParadaCorte parada, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var context = new AppDbContext();
            await context.ParadasCortes.AddAsync(parada, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<List<ParadaCorte>> ObterTodasParadasCortesAsync(CancellationToken cancellationToken = default)
    {
        await using var context = new AppDbContext();
        return await context.ParadasCortes
            .OrderByDescending(p => p.DataCriacao)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> ExcluirParadaCorteAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var context = new AppDbContext();
            var parada = await context.ParadasCortes.FindAsync([id], cancellationToken);
            if (parada == null) return false;
            
            context.ParadasCortes.Remove(parada);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> AtualizarParadaCorteAsync(ParadaCorte parada, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var context = new AppDbContext();
            context.ParadasCortes.Update(parada);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
