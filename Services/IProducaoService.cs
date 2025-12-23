using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using hora_Komdelli.Models;

namespace hora_Komdelli.Services;

public interface IProducaoService
{
    // Corte Executado
    Task<bool> SalvarCorteExecutadoAsync(CorteExecutado corte, CancellationToken cancellationToken = default);
    Task<List<CorteExecutado>> ObterTodosCortesExecutadosAsync(CancellationToken cancellationToken = default);
    Task<CorteExecutado?> ObterCorteExecutadoPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<bool> AtualizarCorteExecutadoAsync(CorteExecutado corte, CancellationToken cancellationToken = default);
    Task<bool> ExcluirCorteExecutadoAsync(int id, CancellationToken cancellationToken = default);
    
    // Corte Planejado
    Task<bool> SalvarCortePlanejadoAsync(CortePlanejado corte, CancellationToken cancellationToken = default);
    Task<List<CortePlanejado>> ObterTodosCortesPlanejadosAsync(CancellationToken cancellationToken = default);
    
    // OP Executado
    Task<bool> SalvarOpExecutadoAsync(OpExecutado op, CancellationToken cancellationToken = default);
    Task<List<OpExecutado>> ObterTodosOpsExecutadosAsync(CancellationToken cancellationToken = default);
    
    // OP Planejado
    Task<bool> SalvarOpPlanejadoAsync(OpPlanejado op, CancellationToken cancellationToken = default);
    Task<List<OpPlanejado>> ObterTodosOpsPlanejadosAsync(CancellationToken cancellationToken = default);
    
    // Parada Corte
    Task<bool> SalvarParadaCorteAsync(ParadaCorte parada, CancellationToken cancellationToken = default);
    Task<List<ParadaCorte>> ObterTodasParadasCortesAsync(CancellationToken cancellationToken = default);
    Task<bool> ExcluirParadaCorteAsync(int id, CancellationToken cancellationToken = default);
    Task<bool> AtualizarParadaCorteAsync(ParadaCorte parada, CancellationToken cancellationToken = default);
}
