using System;
using ClosedXML.Excel;

namespace hora_Komdelli.Services;

public class ExcelService
{
    public (string[] cortePlanejado, string[] opPlanejado) LerDadosPlano(string caminhoArquivo)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(caminhoArquivo);
        
        try
        {
            using var excell = new XLWorkbook(caminhoArquivo);
            var sheet = excell.Worksheet(6);

            var cortePlanejado = new string[11];
            var opPlanejado = new string[11];

            int[] linhas = [19, 20, 21, 22, 23, 24, 26, 27, 28, 29, 30];

            for (int i = 0; i < linhas.Length; i++)
            {
                cortePlanejado[i] = sheet.Cell($"J{linhas[i]}").Value.ToString() ?? string.Empty;
                opPlanejado[i] = sheet.Cell($"I{linhas[i]}").Value.ToString() ?? string.Empty;
            }

            return (cortePlanejado, opPlanejado);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Erro ao ler arquivo Excel: {ex.Message}", ex);
        }
    }
}
