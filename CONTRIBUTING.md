# Contribuindo para o Sistema Hora x Hora

Obrigado por considerar contribuir para o projeto! 🎉

## 📋 Código de Conduta

Este projeto adere a um código de conduta. Ao participar, você concorda em manter um ambiente respeitoso e colaborativo.

## 🚀 Como Contribuir

### Reportando Bugs

Se você encontrou um bug, por favor:

1. Verifique se o bug já não foi reportado nas [Issues](https://github.com/seu-usuario/hora_Komdelli/issues)
2. Se não encontrar, crie uma nova issue com:
   - Título claro e descritivo
   - Descrição detalhada do problema
   - Passos para reproduzir
   - Comportamento esperado vs atual
   - Screenshots (se aplicável)
   - Versão do .NET e sistema operacional

### Sugerindo Melhorias

Para sugerir melhorias:

1. Abra uma issue com o prefixo `[FEATURE]`
2. Descreva a funcionalidade desejada
3. Explique por que seria útil
4. Forneça exemplos de uso

### Pull Requests

1. **Fork o projeto**
```bash
git clone https://github.com/seu-usuario/hora_Komdelli.git
cd hora_Komdelli
```

2. **Crie uma branch**
```bash
git checkout -b feature/minha-nova-funcionalidade
```

3. **Faça suas alterações**
   - Siga o estilo de código do projeto (.editorconfig)
   - Adicione testes se aplicável
   - Atualize a documentação

4. **Commit suas mudanças**
```bash
git commit -m "feat: Adiciona nova funcionalidade X"
```

Siga o padrão [Conventional Commits](https://www.conventionalcommits.org/):
- `feat:` Nova funcionalidade
- `fix:` Correção de bug
- `docs:` Documentação
- `style:` Formatação
- `refactor:` Refatoração
- `test:` Testes
- `chore:` Manutenção

5. **Push para o GitHub**
```bash
git push origin feature/minha-nova-funcionalidade
```

6. **Abra um Pull Request**
   - Descreva suas mudanças
   - Referencie issues relacionadas
   - Aguarde review

## 🎨 Padrões de Código

### C# Style Guide

- Use **PascalCase** para classes, métodos e propriedades públicas
- Use **camelCase** para variáveis locais e parâmetros
- Use **_camelCase** para campos privados
- Prefira `var` quando o tipo é óbvio
- Use nullable reference types (`string?`)
- Prefira `async/await` para operações I/O
- Use `using` para IDisposable
- Adicione XML comments em APIs públicas

### Exemplo

```csharp
namespace hora_Komdelli.Services;

/// <summary>
/// Serviço para gerenciar operações de produção
/// </summary>
public class ProducaoService : IProducaoService
{
    private readonly AppDbContext _context;

    public ProducaoService(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Salva um corte executado no banco de dados
    /// </summary>
    public async Task<bool> SalvarCorteExecutadoAsync(
        CorteExecutado corte, 
        CancellationToken cancellationToken = default)
    {
        await using var context = new AppDbContext();
        await context.CortesExecutados.AddAsync(corte, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
```

## 🧪 Testes

- Adicione testes unitários para novas funcionalidades
- Mantenha cobertura de testes acima de 80%
- Use nomes descritivos para testes

```csharp
[Fact]
public async Task SalvarCorteExecutado_DeveRetornarTrue_QuandoDadosValidos()
{
    // Arrange
    var corte = new CorteExecutado { Hora1 = "100" };
    
    // Act
    var resultado = await _service.SalvarCorteExecutadoAsync(corte);
    
    // Assert
    Assert.True(resultado);
}
```

## 📝 Documentação

- Atualize o README.md se necessário
- Adicione XML comments em APIs públicas
- Crie exemplos de uso
- Atualize o CHANGELOG.md

## 🔍 Checklist do Pull Request

Antes de submeter, verifique:

- [ ] Código compila sem erros
- [ ] Testes passam
- [ ] Documentação atualizada
- [ ] CHANGELOG.md atualizado
- [ ] Commits seguem Conventional Commits
- [ ] Código segue .editorconfig
- [ ] Sem warnings do compilador
- [ ] Nullable reference types tratados

## 🏗️ Estrutura do Projeto

```
hora_Komdelli/
├── Data/           # Contexto e configurações de banco
├── Models/         # Entidades do domínio
├── Services/       # Lógica de negócio
├── Helpers/        # Utilitários
├── Migrations/     # Migrations do EF Core
├── Exemplos/       # Exemplos de uso
└── Tests/          # Testes unitários (a criar)
```

## 💡 Dicas

- Mantenha PRs pequenos e focados
- Um PR = Uma funcionalidade
- Responda aos comentários de review
- Seja paciente e respeitoso
- Peça ajuda se precisar

## 📞 Contato

- Abra uma issue para discussões
- Use Discussions para perguntas gerais

## 🙏 Agradecimentos

Obrigado por contribuir! Sua ajuda é muito apreciada. 🎉

---

**Lembre-se:** Código bom é código que outros conseguem entender e manter!
