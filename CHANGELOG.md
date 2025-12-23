# Changelog

Todas as mudanças notáveis neste projeto serão documentadas neste arquivo.

O formato é baseado em [Keep a Changelog](https://keepachangelog.com/pt-BR/1.0.0/),
e este projeto adere ao [Semantic Versioning](https://semver.org/lang/pt-BR/).

## [2.0.0] - 2024-12-23

### 🎉 Adicionado
- **Exportação para PDF** usando QuestPDF 2024.12.3
  - Relatório de Produção (Corte + OP)
  - Relatório de Paradas
  - Relatório Completo
- **Atualização para .NET 9.0**
  - Nullable Reference Types
  - Primary Constructors
  - Collection Expressions
  - File-Scoped Namespaces
  - CancellationToken em métodos async
- **Nova Arquitetura em Camadas**
  - Camada de Serviços (Services/)
  - Camada de Modelos (Models/)
  - Camada de Dados (Data/)
  - Camada de Helpers (Helpers/)
- **Novos Serviços**
  - PdfExportService - Exportação de PDFs
  - ProducaoService - Lógica de negócio
  - ExcelService - Leitura de Excel
  - ValidationHelper - Validações
- **Documentação Completa**
  - README.md atualizado
  - MELHORIAS_IMPLEMENTADAS.md
  - ATUALIZACAO_NET9.md
  - EXPORTACAO_PDF.md
  - .editorconfig
  - CHANGELOG.md
  - .gitignore

### 🔄 Modificado
- **Modelos de Dados**
  - Nomenclatura PascalCase (Id, Hora1, Hora2, etc.)
  - Propriedades nullable com `?`
  - Propriedades required com `required`
  - Adicionado campo DataCriacao
  - Removido conflito [Keyless] + [Key]
- **DbContext**
  - Renomeado de Conexao para AppDbContext
  - Primary Constructor implementado
  - Índices adicionados em DataCriacao
  - Propriedades como init-only
- **Form1.cs**
  - Injeção de dependências
  - Métodos async/await corretos
  - Validação de dados
  - Tratamento de erros melhorado
  - Métodos de exportação PDF
- **Pacotes NuGet**
  - Entity Framework Core 5.0.17 → 9.0.0
  - ClosedXML 0.97.0 → 0.104.2
  - Adicionado QuestPDF 2024.12.3
  - Adicionado Serilog 8.0.0
  - Adicionado Microsoft.Extensions.* 9.0.0

### 🗑️ Removido
- Pacotes obsoletos:
  - EntityFramework 6.4.4
  - FastReport.Compat
  - FastReport.OpenSource
  - FastReport.OpenSource.Data.SQLite
  - Microsoft.EntityFrameworkCore.Relational (incluído no EF Core 9)
- Código comentado e morto
- Usings desnecessários
- Métodos quebrados (Find sem parâmetros)

### 🐛 Corrigido
- Uso incorreto de AddAsync sem await
- Métodos Find() sem parâmetros
- Exclusão sempre do primeiro registro
- Nomenclatura inconsistente
- Falta de validação de dados
- Tratamento de erros genérico
- DbContext não descartado corretamente
- Conflito de anotações [Keyless] + [Key]

### 🔒 Segurança
- Nullable Reference Types habilitado
- Validações com Data Annotations
- Required properties para campos obrigatórios
- Tratamento adequado de exceções

### ⚡ Performance
- Async/await em todas operações de I/O
- CancellationToken support
- Await using para IAsyncDisposable
- Entity Framework Core 9.0 otimizações
- Índices no banco de dados

## [1.0.0] - 2022-11-21

### Adicionado
- Versão inicial do sistema
- Formulários Windows Forms
- Integração com SQLite
- Entity Framework Core 5.0
- Leitura de arquivos Excel
- Registro de corte e OP
- Registro de paradas

---

## Tipos de Mudanças

- `Adicionado` para novas funcionalidades
- `Modificado` para mudanças em funcionalidades existentes
- `Descontinuado` para funcionalidades que serão removidas
- `Removido` para funcionalidades removidas
- `Corrigido` para correções de bugs
- `Segurança` para vulnerabilidades corrigidas
