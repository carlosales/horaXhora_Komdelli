using Microsoft.EntityFrameworkCore;
using hora_Komdelli.Models;

namespace hora_Komdelli.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<CorteExecutado> CortesExecutados => Set<CorteExecutado>();
    public DbSet<CortePlanejado> CortesPlanejados => Set<CortePlanejado>();
    public DbSet<OpExecutado> OpsExecutados => Set<OpExecutado>();
    public DbSet<OpPlanejado> OpsPlanejados => Set<OpPlanejado>();
    public DbSet<ParadaCorte> ParadasCortes => Set<ParadaCorte>();

    public AppDbContext() : this(new DbContextOptionsBuilder<AppDbContext>()
        .UseSqlite(@"DataSource=horaxhora.db;")
        .Options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<CorteExecutado>().HasKey(x => x.Id);
        builder.Entity<CortePlanejado>().HasKey(x => x.Id);
        builder.Entity<OpExecutado>().HasKey(x => x.Id);
        builder.Entity<OpPlanejado>().HasKey(x => x.Id);
        builder.Entity<ParadaCorte>().HasKey(x => x.Id);
        
        // Índices para melhor performance
        builder.Entity<CorteExecutado>().HasIndex(x => x.DataCriacao);
        builder.Entity<CortePlanejado>().HasIndex(x => x.DataCriacao);
        builder.Entity<OpExecutado>().HasIndex(x => x.DataCriacao);
        builder.Entity<OpPlanejado>().HasIndex(x => x.DataCriacao);
        builder.Entity<ParadaCorte>().HasIndex(x => x.DataCriacao);
    }
}
