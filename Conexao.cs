using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace hora_Komdelli
{
    class Conexao : DbContext
    {
        public DbSet<Corte_executado> corte_Executados { get; set; }
        public DbSet<Corte_planejado> corte_Planejados { get; set; }
        public DbSet<Op_executado> op_Executados { get; set; }
        public DbSet<Op_planejado> op_Planejados { get; set; }
        public DbSet<parada_corte> parada_Cortes{ get; set; }

        ///public string DbPath { get; }

        public Conexao()
        {
            //var folder = Environment.SpecialFolder.LocalApplicationData;
            //var folder = "C:\Database";
            //var path = Environment.GetFolderPath(folder);
            //DbPath = System.IO.Path.Join(path, "horaxhora.db");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=horaxhora.db;");
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Corte_executado>().HasKey(x => x.id);
            //base.OnModelCreating(builder);

            builder.Entity<Corte_planejado>().HasKey(y => y.id);

            builder.Entity<Op_executado>().HasKey(y => y.id);

            builder.Entity<Op_planejado>().HasKey(y => y.id);

            builder.Entity<parada_corte>().HasKey(y => y.id);
        }



    }
            [Keyless]
    [Table("corte_executado")]
    public class Corte_executado
    {
        [Key]
        public int id { get; set; }
        public String primeiro { get; set; }
        public String segundo { get; set; }

        public String terceiro { get; set; }
        public String quarto { get; set; }
        public String quinto { get; set; }
        public String sexto { get; set; }
        public String setimo { get; set; }
        public String oitavo { get; set; }
        public String nono { get; set; }
        public String decimo { get; set; }
        public string decimo_primeiro { get; set; }


    }

    [Keyless]
    [Table("op_executado")]
    public class Op_executado
    {
        [Key]
        public int id { get; set; }
        public String primeiro { get; set; }
        public String segundo { get; set; }

        public String terceiro { get; set; }
        public String quarto { get; set; }
        public String quinto { get; set; }
        public String sexto { get; set; }
        public String setimo { get; set; }
        public String oitavo { get; set; }
        public String nono { get; set; }
        public String decimo { get; set; }
        public string decimo_primeiro { get; set; }

    }

    [Keyless]
    [Table("corte_planejado")]
    public class Corte_planejado
    {
        [Key]
        public int id { get; set; }
        public String primeiro { get; set; }
        public String segundo { get; set; }

        public String terceiro { get; set; }
        public String quarto { get; set; }
        public String quinto { get; set; }
        public String sexto { get; set; }
        public String setimo { get; set; }
        public String oitavo { get; set; }
        public String nono { get; set; }
        public String decimo { get; set; }
        public string decimo_primeiro { get; set; }

    }
    [Keyless]
    [Table("op_planejado")]
    public class Op_planejado
    {
        [Key]
        public int id { get; set; }
        public String primeiro { get; set; }
        public String segundo { get; set; }

        public String terceiro { get; set; }
        public String quarto { get; set; }
        public String quinto { get; set; }
        public String sexto { get; set; }
        public String setimo { get; set; }
        public String oitavo { get; set; }
        public String nono { get; set; }
        public String decimo { get; set; }
        public string decimo_primeiro { get; set; }

    }

    [Keyless]
    [Table("parada_corte")]
    public class parada_corte
    {
        [Key]
        public int id { get; set; }
        public string hora_inicio { get; set; }
        public String hora_final { get; set; }
        public string processo { get; set; }
        public string ordem { get; set; }
        public string justificativa { get; set; }
        public string duracao { get; set; }
    }
}


