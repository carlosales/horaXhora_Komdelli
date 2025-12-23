using System;
using System.Threading.Tasks;
using hora_Komdelli.Services;

namespace hora_Komdelli.Exemplos;

/// <summary>
/// Exemplos de uso do serviço de exportação PDF
/// </summary>
public class ExemploUsoPdf
{
    private readonly PdfExportService _pdfService;
    private readonly IProducaoService _producaoService;

    public ExemploUsoPdf()
    {
        _pdfService = new PdfExportService();
        _producaoService = new ProducaoService();
    }

    /// <summary>
    /// Exemplo 1: Exportar relatório de produção
    /// </summary>
    public async Task ExportarProducaoAsync()
    {
        // Buscar dados do banco
        var cortesExecutados = await _producaoService.ObterTodosCortesExecutadosAsync();
        var cortesPlanejados = await _producaoService.ObterTodosCortesPlanejadosAsync();
        var opsExecutados = await _producaoService.ObterTodosOpsExecutadosAsync();
        var opsPlanejados = await _producaoService.ObterTodosOpsPlanejadosAsync();

        // Gerar PDF
        var caminhoArquivo = $"C:\\Relatorios\\Producao_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
        
        _pdfService.ExportarRelatorioProducao(
            cortesExecutados,
            cortesPlanejados,
            opsExecutados,
            opsPlanejados,
            caminhoArquivo);

        Console.WriteLine($"PDF gerado: {caminhoArquivo}");
    }

    /// <summary>
    /// Exemplo 2: Exportar relatório de paradas
    /// </summary>
    public async Task ExportarParadasAsync()
    {
        // Buscar paradas do banco
        var paradas = await _producaoService.ObterTodasParadasCortesAsync();

        // Gerar PDF
        var caminhoArquivo = $"C:\\Relatorios\\Paradas_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
        
        _pdfService.ExportarRelatorioParadas(paradas, caminhoArquivo);

        Console.WriteLine($"PDF de paradas gerado: {caminhoArquivo}");
        Console.WriteLine($"Total de paradas: {paradas.Count}");
    }

    /// <summary>
    /// Exemplo 3: Exportar relatório completo
    /// </summary>
    public void ExportarRelatorioCompleto()
    {
        // Gerar PDF completo (busca dados internamente)
        var caminhoArquivo = $"C:\\Relatorios\\Completo_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
        
        _pdfService.ExportarRelatorioCompleto(caminhoArquivo);

        Console.WriteLine($"Relatório completo gerado: {caminhoArquivo}");
    }

    /// <summary>
    /// Exemplo 4: Exportar com tratamento de erros
    /// </summary>
    public async Task ExportarComTratamentoErrosAsync()
    {
        try
        {
            var paradas = await _producaoService.ObterTodasParadasCortesAsync();
            
            if (paradas.Count == 0)
            {
                Console.WriteLine("Nenhuma parada para exportar.");
                return;
            }

            var caminhoArquivo = $"C:\\Relatorios\\Paradas_{DateTime.Now:yyyyMMdd}.pdf";
            
            _pdfService.ExportarRelatorioParadas(paradas, caminhoArquivo);
            
            Console.WriteLine($"✓ PDF gerado com sucesso!");
            Console.WriteLine($"  Arquivo: {caminhoArquivo}");
            Console.WriteLine($"  Paradas: {paradas.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Erro ao gerar PDF: {ex.Message}");
        }
    }

    /// <summary>
    /// Exemplo 5: Exportar e abrir automaticamente
    /// </summary>
    public async Task ExportarEAbrirAsync()
    {
        var caminhoArquivo = $"C:\\Temp\\Relatorio_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
        
        _pdfService.ExportarRelatorioCompleto(caminhoArquivo);
        
        // Abrir o PDF no visualizador padrão
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
        {
            FileName = caminhoArquivo,
            UseShellExecute = true
        });
    }

    /// <summary>
    /// Exemplo 6: Exportar múltiplos relatórios
    /// </summary>
    public async Task ExportarMultiplosRelatoriosAsync()
    {
        var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        var pasta = $"C:\\Relatorios\\{timestamp}";
        
        // Criar pasta se não existir
        System.IO.Directory.CreateDirectory(pasta);

        // Exportar produção
        var cortesExecutados = await _producaoService.ObterTodosCortesExecutadosAsync();
        var cortesPlanejados = await _producaoService.ObterTodosCortesPlanejadosAsync();
        var opsExecutados = await _producaoService.ObterTodosOpsExecutadosAsync();
        var opsPlanejados = await _producaoService.ObterTodosOpsPlanejadosAsync();
        
        _pdfService.ExportarRelatorioProducao(
            cortesExecutados,
            cortesPlanejados,
            opsExecutados,
            opsPlanejados,
            $"{pasta}\\Producao.pdf");

        // Exportar paradas
        var paradas = await _producaoService.ObterTodasParadasCortesAsync();
        _pdfService.ExportarRelatorioParadas(paradas, $"{pasta}\\Paradas.pdf");

        // Exportar completo
        _pdfService.ExportarRelatorioCompleto($"{pasta}\\Completo.pdf");

        Console.WriteLine($"Relatórios gerados em: {pasta}");
    }
}
