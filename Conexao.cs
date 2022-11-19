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
        }

        


        
    }
            [Keyless]
    [Table("corte_executado")]
    public class Corte_executado
    {
        
        public int id;
        public String primeiro;
        public String segundo;

        public String terceiro;
        public String quarto;
        public String quinto;
        public String sexto;
        public String setimo;
        public String oitavo;
        public String nono;
        public String decimo;
        public string decimo_primeiro;


    }

    [Keyless]
    [Table("op_executado")]
    public class Op_executado
    {
        [Key]
        public int id;
        public String primeiro;
        public String segundo;

        public String terceiro;
        public String quarto;
        public String quinto;
        public String sexto;
        public String setimo;
        public String oitavo;
        public String nono;
        public String decimo;
        public string decimo_primeiro;

    }

    [Keyless]
    [Table("corte_planejado")]
    public class Corte_planejado
    {
        [Key]
        public int id;
        public String primeiro;
        public String segundo;
        public String terceiro;
        public String quarto;
        public String quinto;
        public String sexto;
        public String setimo;
        public String oitavo;
        public String nono;
        public String decimo;
        public string decimo_primeiro;

    }
    [Keyless]
    [Table("op_planejado")]
    public class Op_planejado
    {
        [Key]
        public int id;
        public String primeiro;
        public String segundo;
        public String terceiro;
        public String quarto;
        public String quinto;
        public String sexto;
        public String setimo;
        public String oitavo;
        public String nono;
        public String decimo;
        public string decimo_primeiro;

    }[Keyless]
    [Table("parada_corte")]
    public class parada_corte
    {
        [Key]
        public int id;
        public string hora_inicio;
        public String hora_final;
        public string processo;
        public string ordem;
        public string justificativa;
        public string duracao;
    }
}


