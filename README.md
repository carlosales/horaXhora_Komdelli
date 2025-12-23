# Sistema Hora x Hora - Gestão de Produção Komdelli

Sistema Windows Forms para gerenciamento de dados de produção (corte e operações) com integração Excel, banco de dados SQLite e exportação para PDF.

## 🚀 Tecnologias

- **.NET 9.0** - Framework mais recente
- **Windows Forms** - Interface gráfica
- **Entity Framework Core 9.0** - ORM para banco de dados
- **SQLite** - Banco de dados local
- **ClosedXML** - Leitura de arquivos Excel
- **QuestPDF** - Geração de relatórios PDF

## 📋 Funcionalidades

### ✅ Gestão de Produção
- Registro de corte executado vs planejado (11 horas)
- Registro de ordem de produção (OP) executado vs planejado (11 horas)
- Importação de dados planejados via Excel
- Comparação entre executado e planejado

### ✅ Gestão de Paradas
- Registro de paradas de corte
- Controle de hora início, hora final e duração
- Justificativas e processos
- Histórico completo de paradas

### ✅ Exportação de Relatórios
- **PDF de Produção** - Relatório completo de corte e OP
- **PDF de Paradas** - Listagem detalhada de paradas
- **PDF Completo** - Relatório consolidado
- Layout profissional com tabelas e cores

### ✅ Banco de Dados
- SQLite local (horaxhora.db)
- Entity Framework Core com migrations
- Operações CRUD completas
- Async/await para melhor performance

## 🏗️ Arquitetura

```
hora_Komdelli/
├── Data/
│   └── AppDbContext.cs              # Contexto EF Core
├── Models/
│   ├── CorteExecutado.cs            # Modelo de corte executado
│   ├── CortePlanejado.cs            # Modelo de corte planejado
│   ├── OpExecutado.cs               # Modelo de OP executado
│   ├── OpPlanejado.cs               # Modelo de OP planejado
│   └── ParadaCorte.cs               # Modelo de parada
├── Services/
│   ├── IProducaoService.cs          # Interface do serviço
│   ├── ProducaoService.cs           # Serviço de produção
│   ├── ExcelService.cs              # Serviço de Excel
│   └── PdfExportService.cs          # Serviço de PDF
├── Helpers/
│   └── ValidationHelper.cs          # Helper de validação
├── Migrations/                      # Migrations do EF Core
├── Exemplos/
│   └── ExemploUsoPdf.cs            # Exemplos de uso
├── Form1.cs                         # Formulário principal
├── Form2.cs                         # Formulário secundário
└── Program.cs                       # Ponto de entrada
```

## 🔧 Instalação

### Pré-requisitos
- .NET 9.0 SDK
- Visual Studio 2022 ou superior
- Windows 10/11

### Passos

1. **Clone o repositório**
```bash
git clone https://github.com/seu-usuario/hora_Komdelli.git
cd hora_Komdelli
```

2. **Restaure os pacotes**
```bash
dotnet restore
```

3. **Execute as migrations**
```bash
dotnet ef database update
```

4. **Compile o projeto**
```bash
dotnet build
```

5. **Execute a aplicação**
```bash
dotnet run
```

## 📦 Pacotes NuGet

| Pacote | Versão | Descrição |
|--------|--------|-----------|
| Microsoft.EntityFrameworkCore | 9.0.0 | ORM |
| Microsoft.EntityFrameworkCore.Sqlite | 9.0.0 | Provider SQLite |
| Microsoft.EntityFrameworkCore.Tools | 9.0.0 | Ferramentas CLI |
| ClosedXML | 0.104.2 | Manipulação Excel |
| QuestPDF | 2024.12.3 | Geração PDF |
| Serilog | 8.0.0 | Logging |

## 💻 Como Usar

### Importar Dados do Excel

1. Clique em "Abrir Plano"
2. Selecione o arquivo Excel (.xlsx ou .xls)
3. Os dados planejados serão carregados automaticamente

### Registrar Produção

1. Preencha os campos de corte executado (11 horas)
2. Preencha os campos de OP executado (11 horas)
3. Clique em "Salvar"

### Registrar Parada

1. Vá para a aba "PRODUTIVIDADE"
2. Preencha hora início, hora final, processo, ordem e justificativa
3. Clique em "Salvar"

### Exportar Relatórios PDF

```csharp
// Exportar produção
private async void ExportarPdfProducao_Click(object sender, EventArgs e)

// Exportar paradas
private async void ExportarPdfParadas_Click(object sender, EventArgs e)

// Exportar completo
private void ExportarPdfCompleto_Click(object sender, EventArgs e)
```

## 🎨 Recursos Modernos do .NET 9.0

- ✅ **Nullable Reference Types** - Segurança contra null
- ✅ **Primary Constructors** - Sintaxe simplificada
- ✅ **Collection Expressions** - `[1, 2, 3]`
- ✅ **File-Scoped Namespaces** - Menos indentação
- ✅ **CancellationToken** - Suporte a cancelamento
- ✅ **Await Using** - Descarte assíncrono
- ✅ **Required Properties** - Propriedades obrigatórias

## 📊 Banco de Dados

### Tabelas

- **corte_executado** - Dados de corte executado
- **corte_planejado** - Dados de corte planejado
- **op_executado** - Dados de OP executado
- **op_planejado** - Dados de OP planejado
- **parada_corte** - Registro de paradas

### Campos Comuns

- `Id` - Chave primária
- `Hora1` a `Hora11` - Dados das 11 horas
- `DataCriacao` - Timestamp de criação

## 📄 Documentação Adicional

- [MELHORIAS_IMPLEMENTADAS.md](MELHORIAS_IMPLEMENTADAS.md) - Refatoração completa
- [ATUALIZACAO_NET9.md](ATUALIZACAO_NET9.md) - Migração para .NET 9.0
- [EXPORTACAO_PDF.md](EXPORTACAO_PDF.md) - Documentação de PDF
- [.editorconfig](.editorconfig) - Configurações de código

## 🔍 Exemplos de Código

### Salvar Dados

```csharp
var corteExecutado = new CorteExecutado
{
    Hora1 = "100",
    Hora2 = "150",
    // ... outras horas
};

var sucesso = await _producaoService.SalvarCorteExecutadoAsync(corteExecutado);
```

### Buscar Dados

```csharp
var cortes = await _producaoService.ObterTodosCortesExecutadosAsync();
var paradas = await _producaoService.ObterTodasParadasCortesAsync();
```

### Exportar PDF

```csharp
var pdfService = new PdfExportService();
pdfService.ExportarRelatorioCompleto("relatorio.pdf");
```

## 🐛 Solução de Problemas

### Erro ao abrir banco de dados
```bash
dotnet ef database update
```

### Erro de pacotes
```bash
dotnet restore
dotnet clean
dotnet build
```

### Erro de migrations
```bash
dotnet ef migrations add NomeDaMigration
dotnet ef database update
```

## 🤝 Contribuindo

1. Fork o projeto
2. Crie uma branch (`git checkout -b feature/NovaFuncionalidade`)
3. Commit suas mudanças (`git commit -m 'Adiciona nova funcionalidade'`)
4. Push para a branch (`git push origin feature/NovaFuncionalidade`)
5. Abra um Pull Request

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 👥 Autores

- **Komdelli** - Desenvolvimento inicial

## 🙏 Agradecimentos

- Entity Framework Core Team
- QuestPDF Team
- ClosedXML Team
- Comunidade .NET

## 📞 Suporte

Para suporte, abra uma issue no GitHub ou entre em contato através do email.

---

**Versão:** 2.0.0  
**Última Atualização:** 23/12/2024  
**Status:** ✅ Produção
