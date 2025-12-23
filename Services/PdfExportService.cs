using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using hora_Komdelli.Models;

namespace hora_Komdelli.Services;

public class PdfExportService
{
    public PdfExportService()
    {
        // Configurar licença do QuestPDF (Community License)
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public void ExportarRelatorioProducao(
        List<CorteExecutado> cortesExecutados,
        List<CortePlanejado> cortesPlanejados,
        List<OpExecutado> opsExecutados,
        List<OpPlanejado> opsPlanejados,
        string caminhoArquivo)
    {
        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4.Landscape());
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(10));

                page.Header()
                    .Height(80)
                    .Background(Colors.Blue.Darken3)
                    .Padding(10)
                    .Column(column =>
                    {
                        column.Item().Text("Relatório de Produção - Hora x Hora")
                            .FontSize(20)
                            .Bold()
                            .FontColor(Colors.White);
                        
                        column.Item().Text($"Data: {DateTime.Now:dd/MM/yyyy HH:mm}")
                            .FontSize(12)
                            .FontColor(Colors.White);
                    });

                page.Content()
                    .PaddingVertical(10)
                    .Column(column =>
                    {
                        // Seção Corte
                        column.Item().Element(c => CriarSecaoCorte(c, cortesExecutados, cortesPlanejados));
                        
                        column.Item().PaddingTop(20);
                        
                        // Seção OP
                        column.Item().Element(c => CriarSecaoOp(c, opsExecutados, opsPlanejados));
                    });

                page.Footer()
                    .Height(30)
                    .Background(Colors.Grey.Lighten3)
                    .Padding(10)
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Página ");
                        x.CurrentPageNumber();
                        x.Span(" de ");
                        x.TotalPages();
                    });
            });
        })
        .GeneratePdf(caminhoArquivo);
    }

    public void ExportarRelatorioParadas(List<ParadaCorte> paradas, string caminhoArquivo)
    {
        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(10));

                page.Header()
                    .Height(80)
                    .Background(Colors.Red.Darken2)
                    .Padding(10)
                    .Column(column =>
                    {
                        column.Item().Text("Relatório de Paradas de Corte")
                            .FontSize(20)
                            .Bold()
                            .FontColor(Colors.White);
                        
                        column.Item().Text($"Data: {DateTime.Now:dd/MM/yyyy HH:mm}")
                            .FontSize(12)
                            .FontColor(Colors.White);
                        
                        column.Item().Text($"Total de Paradas: {paradas.Count}")
                            .FontSize(12)
                            .FontColor(Colors.White);
                    });

                page.Content()
                    .PaddingVertical(10)
                    .Column(column =>
                    {
                        if (!paradas.Any())
                        {
                            column.Item()
                                .PaddingTop(50)
                                .AlignCenter()
                                .Text("Nenhuma parada registrada")
                                .FontSize(14)
                                .Italic()
                                .FontColor(Colors.Grey.Medium);
                            return;
                        }

                        // Tabela de paradas
                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(80);  // Hora Início
                                columns.ConstantColumn(80);  // Hora Final
                                columns.ConstantColumn(80);  // Duração
                                columns.RelativeColumn(2);   // Processo
                                columns.RelativeColumn(1);   // Ordem
                                columns.RelativeColumn(3);   // Justificativa
                            });

                            // Cabeçalho
                            table.Header(header =>
                            {
                                header.Cell().Element(CellStyle).Text("Hora Início").Bold();
                                header.Cell().Element(CellStyle).Text("Hora Final").Bold();
                                header.Cell().Element(CellStyle).Text("Duração").Bold();
                                header.Cell().Element(CellStyle).Text("Processo").Bold();
                                header.Cell().Element(CellStyle).Text("Ordem").Bold();
                                header.Cell().Element(CellStyle).Text("Justificativa").Bold();

                                static IContainer CellStyle(IContainer container)
                                {
                                    return container
                                        .Background(Colors.Grey.Lighten2)
                                        .Padding(5)
                                        .BorderBottom(1)
                                        .BorderColor(Colors.Grey.Medium);
                                }
                            });

                            // Dados
                            foreach (var parada in paradas.OrderByDescending(p => p.DataCriacao))
                            {
                                table.Cell().Element(CellStyle).Text(parada.HoraInicio);
                                table.Cell().Element(CellStyle).Text(parada.HoraFinal);
                                table.Cell().Element(CellStyle).Text(parada.Duracao ?? "-");
                                table.Cell().Element(CellStyle).Text(parada.Processo);
                                table.Cell().Element(CellStyle).Text(parada.Ordem ?? "-");
                                table.Cell().Element(CellStyle).Text(parada.Justificativa);

                                static IContainer CellStyle(IContainer container)
                                {
                                    return container
                                        .Padding(5)
                                        .BorderBottom(1)
                                        .BorderColor(Colors.Grey.Lighten2);
                                }
                            }
                        });
                    });

                page.Footer()
                    .Height(30)
                    .Background(Colors.Grey.Lighten3)
                    .Padding(10)
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Página ");
                        x.CurrentPageNumber();
                        x.Span(" de ");
                        x.TotalPages();
                    });
            });
        })
        .GeneratePdf(caminhoArquivo);
    }

    private void CriarSecaoCorte(IContainer container, List<CorteExecutado> executados, List<CortePlanejado> planejados)
    {
        container.Column(column =>
        {
            column.Item()
                .Background(Colors.Blue.Lighten3)
                .Padding(8)
                .Text("CORTE")
                .FontSize(14)
                .Bold();

            column.Item().PaddingTop(5).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(100);
                    for (int i = 0; i < 11; i++)
                        columns.RelativeColumn();
                });

                // Cabeçalho
                table.Header(header =>
                {
                    header.Cell().Element(HeaderStyle).Text("Tipo");
                    for (int i = 1; i <= 11; i++)
                        header.Cell().Element(HeaderStyle).Text($"H{i}");

                    static IContainer HeaderStyle(IContainer c) =>
                        c.Background(Colors.Grey.Lighten2).Padding(5).BorderBottom(1).BorderColor(Colors.Grey.Medium);
                });

                // Dados Executados
                var ultimoExecutado = executados.OrderByDescending(c => c.DataCriacao).FirstOrDefault();
                if (ultimoExecutado != null)
                {
                    table.Cell().Element(CellStyle).Text("Executado").Bold().FontColor(Colors.Green.Darken2);
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora1 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora2 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora3 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora4 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora5 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora6 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora7 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora8 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora9 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora10 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora11 ?? "-");
                }

                // Dados Planejados
                var ultimoPlanejado = planejados.OrderByDescending(c => c.DataCriacao).FirstOrDefault();
                if (ultimoPlanejado != null)
                {
                    table.Cell().Element(CellStyle).Text("Planejado").Bold().FontColor(Colors.Blue.Darken2);
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora1 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora2 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora3 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora4 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora5 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora6 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora7 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora8 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora9 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora10 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora11 ?? "-");
                }

                static IContainer CellStyle(IContainer c) =>
                    c.Padding(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
            });
        });
    }

    private void CriarSecaoOp(IContainer container, List<OpExecutado> executados, List<OpPlanejado> planejados)
    {
        container.Column(column =>
        {
            column.Item()
                .Background(Colors.Green.Lighten3)
                .Padding(8)
                .Text("ORDEM DE PRODUÇÃO (OP)")
                .FontSize(14)
                .Bold();

            column.Item().PaddingTop(5).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(100);
                    for (int i = 0; i < 11; i++)
                        columns.RelativeColumn();
                });

                // Cabeçalho
                table.Header(header =>
                {
                    header.Cell().Element(HeaderStyle).Text("Tipo");
                    for (int i = 1; i <= 11; i++)
                        header.Cell().Element(HeaderStyle).Text($"H{i}");

                    static IContainer HeaderStyle(IContainer c) =>
                        c.Background(Colors.Grey.Lighten2).Padding(5).BorderBottom(1).BorderColor(Colors.Grey.Medium);
                });

                // Dados Executados
                var ultimoExecutado = executados.OrderByDescending(o => o.DataCriacao).FirstOrDefault();
                if (ultimoExecutado != null)
                {
                    table.Cell().Element(CellStyle).Text("Executado").Bold().FontColor(Colors.Green.Darken2);
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora1 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora2 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora3 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora4 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora5 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora6 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora7 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora8 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora9 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora10 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoExecutado.Hora11 ?? "-");
                }

                // Dados Planejados
                var ultimoPlanejado = planejados.OrderByDescending(o => o.DataCriacao).FirstOrDefault();
                if (ultimoPlanejado != null)
                {
                    table.Cell().Element(CellStyle).Text("Planejado").Bold().FontColor(Colors.Blue.Darken2);
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora1 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora2 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora3 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora4 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora5 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora6 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora7 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora8 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora9 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora10 ?? "-");
                    table.Cell().Element(CellStyle).Text(ultimoPlanejado.Hora11 ?? "-");
                }

                static IContainer CellStyle(IContainer c) =>
                    c.Padding(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
            });
        });
    }

    public void ExportarRelatorioCompleto(string caminhoArquivo)
    {
        var service = new ProducaoService();
        
        var cortesExecutados = service.ObterTodosCortesExecutadosAsync().Result;
        var cortesPlanejados = service.ObterTodosCortesPlanejadosAsync().Result;
        var opsExecutados = service.ObterTodosOpsExecutadosAsync().Result;
        var opsPlanejados = service.ObterTodosOpsPlanejadosAsync().Result;
        var paradas = service.ObterTodasParadasCortesAsync().Result;

        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4.Landscape());
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(10));

                page.Header()
                    .Height(100)
                    .Background(Colors.Blue.Darken4)
                    .Padding(10)
                    .Column(column =>
                    {
                        column.Item().Text("Relatório Completo de Produção")
                            .FontSize(22)
                            .Bold()
                            .FontColor(Colors.White);
                        
                        column.Item().Text($"Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
                            .FontSize(12)
                            .FontColor(Colors.White);
                        
                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Text($"Cortes: {cortesExecutados.Count}").FontColor(Colors.White);
                            row.RelativeItem().Text($"OPs: {opsExecutados.Count}").FontColor(Colors.White);
                            row.RelativeItem().Text($"Paradas: {paradas.Count}").FontColor(Colors.White);
                        });
                    });

                page.Content()
                    .PaddingVertical(10)
                    .Column(column =>
                    {
                        column.Item().Element(c => CriarSecaoCorte(c, cortesExecutados, cortesPlanejados));
                        column.Item().PaddingTop(15);
                        column.Item().Element(c => CriarSecaoOp(c, opsExecutados, opsPlanejados));
                        
                        if (paradas.Any())
                        {
                            column.Item().PageBreak();
                            column.Item()
                                .Background(Colors.Red.Lighten3)
                                .Padding(8)
                                .Text("PARADAS DE CORTE")
                                .FontSize(14)
                                .Bold();
                            
                            column.Item().PaddingTop(10).Text($"Total: {paradas.Count} paradas registradas");
                        }
                    });

                page.Footer()
                    .Height(30)
                    .Background(Colors.Grey.Lighten3)
                    .Padding(10)
                    .Row(row =>
                    {
                        row.RelativeItem().AlignLeft().Text("Sistema Hora x Hora - Komdelli");
                        row.RelativeItem().AlignCenter().Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                            x.Span(" de ");
                            x.TotalPages();
                        });
                        row.RelativeItem().AlignRight().Text(DateTime.Now.ToString("dd/MM/yyyy"));
                    });
            });
        })
        .GeneratePdf(caminhoArquivo);
    }
}
