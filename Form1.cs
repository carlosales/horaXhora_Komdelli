using System;
using System.Windows.Forms;
using hora_Komdelli.Models;
using hora_Komdelli.Services;

namespace hora_Komdelli
{
    public partial class Form1 : Form
    {
        private readonly IProducaoService _producaoService;
        private readonly ExcelService _excelService;
        private readonly PdfExportService _pdfExportService;

        public Form1()
        {
            InitializeComponent();
            _producaoService = new ProducaoService();
            _excelService = new ExcelService();
            _pdfExportService = new PdfExportService();
            //corte planejado
            textBox22.Enabled = false;
            textBox21.Enabled = false;
            textBox20.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox17.Enabled = false;
            textBox16.Enabled = false;
            textBox15.Enabled = false;
            textBox14.Enabled = false;
            textBox13.Enabled = false;
            textBox12.Enabled = false;
            //o.p planejado
            textBox44.Enabled = false;
            textBox43.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox40.Enabled = false;
            textBox39.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox35.Enabled = false;
            textBox34.Enabled = false;
        }

        private void Abrir_plano_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Arquivos Excel (*.xlsx;*.xls)|*.xlsx;*.xls";
                openFileDialog1.CheckFileExists = true;
                
                if (openFileDialog1.ShowDialog() != DialogResult.OK)
                    return;

                var caminhoArquivo = openFileDialog1.FileName;
                var (cortePlanejado, opPlanejado) = _excelService.LerDadosPlano(caminhoArquivo);

                // Preencher campos de corte planejado
                textBox22.Text = cortePlanejado[0];
                textBox21.Text = cortePlanejado[1];
                textBox20.Text = cortePlanejado[2];
                textBox19.Text = cortePlanejado[3];
                textBox18.Text = cortePlanejado[4];
                textBox17.Text = cortePlanejado[5];
                textBox16.Text = cortePlanejado[6];
                textBox15.Text = cortePlanejado[7];
                textBox14.Text = cortePlanejado[8];
                textBox13.Text = cortePlanejado[9];
                textBox12.Text = cortePlanejado[10];

                // Preencher campos de OP planejado
                textBox44.Text = opPlanejado[0];
                textBox43.Text = opPlanejado[1];
                textBox42.Text = opPlanejado[2];
                textBox41.Text = opPlanejado[3];
                textBox40.Text = opPlanejado[4];
                textBox39.Text = opPlanejado[5];
                textBox38.Text = opPlanejado[6];
                textBox37.Text = opPlanejado[7];
                textBox36.Text = opPlanejado[8];
                textBox35.Text = opPlanejado[9];
                textBox34.Text = opPlanejado[10];

                MessageBox.Show("Dados carregados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var corteExecutado = new CorteExecutado
                {
                    Hora1 = textBox1.Text,
                    Hora2 = textBox2.Text,
                    Hora3 = textBox3.Text,
                    Hora4 = textBox4.Text,
                    Hora5 = textBox5.Text,
                    Hora6 = textBox6.Text,
                    Hora7 = textBox7.Text,
                    Hora8 = textBox8.Text,
                    Hora9 = textBox9.Text,
                    Hora10 = textBox10.Text,
                    Hora11 = textBox11.Text
                };

                var cortePlanejado = new CortePlanejado
                {
                    Hora1 = textBox22.Text,
                    Hora2 = textBox21.Text,
                    Hora3 = textBox20.Text,
                    Hora4 = textBox19.Text,
                    Hora5 = textBox18.Text,
                    Hora6 = textBox17.Text,
                    Hora7 = textBox16.Text,
                    Hora8 = textBox15.Text,
                    Hora9 = textBox14.Text,
                    Hora10 = textBox13.Text,
                    Hora11 = textBox12.Text
                };

                var opExecutado = new OpExecutado
                {
                    Hora1 = textBox33.Text,
                    Hora2 = textBox32.Text,
                    Hora3 = textBox31.Text,
                    Hora4 = textBox30.Text,
                    Hora5 = textBox29.Text,
                    Hora6 = textBox28.Text,
                    Hora7 = textBox27.Text,
                    Hora8 = textBox26.Text,
                    Hora9 = textBox25.Text,
                    Hora10 = textBox24.Text,
                    Hora11 = textBox23.Text
                };

                var opPlanejado = new OpPlanejado
                {
                    Hora1 = textBox44.Text,
                    Hora2 = textBox43.Text,
                    Hora3 = textBox42.Text,
                    Hora4 = textBox41.Text,
                    Hora5 = textBox40.Text,
                    Hora6 = textBox39.Text,
                    Hora7 = textBox38.Text,
                    Hora8 = textBox37.Text,
                    Hora9 = textBox36.Text,
                    Hora10 = textBox35.Text,
                    Hora11 = textBox34.Text
                };

                var sucesso1 = await _producaoService.SalvarCorteExecutadoAsync(corteExecutado);
                var sucesso2 = await _producaoService.SalvarCortePlanejadoAsync(cortePlanejado);
                var sucesso3 = await _producaoService.SalvarOpExecutadoAsync(opExecutado);
                var sucesso4 = await _producaoService.SalvarOpPlanejadoAsync(opPlanejado);

                if (sucesso1 && sucesso2 && sucesso3 && sucesso4)
                {
                    MessageBox.Show("Dados salvos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao salvar alguns dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            // Limpar corte executado
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
            textBox5.Clear(); textBox6.Clear(); textBox7.Clear(); textBox8.Clear();
            textBox9.Clear(); textBox10.Clear(); textBox11.Clear();
            
            // Limpar OP executado
            textBox23.Clear(); textBox24.Clear(); textBox25.Clear(); textBox26.Clear();
            textBox27.Clear(); textBox28.Clear(); textBox29.Clear(); textBox30.Clear();
            textBox31.Clear(); textBox32.Clear(); textBox33.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidade de alteração será implementada com seleção de registros.", 
                "Em desenvolvimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidade de exclusão será implementada com seleção de registros.", 
                "Em desenvolvimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox45.Text) || 
                    string.IsNullOrWhiteSpace(textBox46.Text) ||
                    string.IsNullOrWhiteSpace(textBox47.Text) ||
                    string.IsNullOrWhiteSpace(comboBox1.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", 
                        "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var parada = new ParadaCorte
                {
                    HoraInicio = textBox45.Text,
                    HoraFinal = textBox46.Text,
                    Processo = textBox47.Text,
                    Ordem = textBox48.Text,
                    Justificativa = comboBox1.Text,
                    Duracao = textBox50.Text
                };

                var sucesso = await _producaoService.SalvarParadaCorteAsync(parada);

                if (sucesso)
                {
                    MessageBox.Show("Parada salva com sucesso!", "Sucesso", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCamposParada();
                }
                else
                {
                    MessageBox.Show("Erro ao salvar parada.", "Erro", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCamposParada()
        {
            textBox45.Clear();
            textBox46.Clear();
            textBox47.Clear();
            textBox48.Clear();
            textBox50.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void Excluir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidade de exclusão será implementada com seleção de registros.", 
                "Em desenvolvimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Alterar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidade de alteração será implementada com seleção de registros.", 
                "Em desenvolvimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void ExportarPdfProducao_Click(object sender, EventArgs e)
        {
            try
            {
                var saveDialog = new SaveFileDialog
                {
                    Filter = "Arquivos PDF (*.pdf)|*.pdf",
                    DefaultExt = "pdf",
                    FileName = $"Relatorio_Producao_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                };

                if (saveDialog.ShowDialog() != DialogResult.OK)
                    return;

                var cortesExecutados = await _producaoService.ObterTodosCortesExecutadosAsync();
                var cortesPlanejados = await _producaoService.ObterTodosCortesPlanejadosAsync();
                var opsExecutados = await _producaoService.ObterTodosOpsExecutadosAsync();
                var opsPlanejados = await _producaoService.ObterTodosOpsPlanejadosAsync();

                _pdfExportService.ExportarRelatorioProducao(
                    cortesExecutados,
                    cortesPlanejados,
                    opsExecutados,
                    opsPlanejados,
                    saveDialog.FileName);

                MessageBox.Show("Relatório PDF gerado com sucesso!", "Sucesso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                var result = MessageBox.Show("Deseja abrir o arquivo PDF?", "Abrir PDF", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = saveDialog.FileName,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar PDF: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ExportarPdfParadas_Click(object sender, EventArgs e)
        {
            try
            {
                var saveDialog = new SaveFileDialog
                {
                    Filter = "Arquivos PDF (*.pdf)|*.pdf",
                    DefaultExt = "pdf",
                    FileName = $"Relatorio_Paradas_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                };

                if (saveDialog.ShowDialog() != DialogResult.OK)
                    return;

                var paradas = await _producaoService.ObterTodasParadasCortesAsync();

                _pdfExportService.ExportarRelatorioParadas(paradas, saveDialog.FileName);

                MessageBox.Show("Relatório de paradas PDF gerado com sucesso!", "Sucesso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                var result = MessageBox.Show("Deseja abrir o arquivo PDF?", "Abrir PDF", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = saveDialog.FileName,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar PDF: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarPdfCompleto_Click(object sender, EventArgs e)
        {
            try
            {
                var saveDialog = new SaveFileDialog
                {
                    Filter = "Arquivos PDF (*.pdf)|*.pdf",
                    DefaultExt = "pdf",
                    FileName = $"Relatorio_Completo_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                };

                if (saveDialog.ShowDialog() != DialogResult.OK)
                    return;

                _pdfExportService.ExportarRelatorioCompleto(saveDialog.FileName);

                MessageBox.Show("Relatório completo PDF gerado com sucesso!", "Sucesso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                var result = MessageBox.Show("Deseja abrir o arquivo PDF?", "Abrir PDF", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = saveDialog.FileName,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar PDF: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}