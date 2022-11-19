﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hora_Komdelli;

namespace hora_Komdelli.Migrations
{
    [DbContext(typeof(Conexao))]
    partial class ConexaoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("hora_Komdelli.Corte_executado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("decimo")
                        .HasColumnType("TEXT");

                    b.Property<string>("decimo_primeiro")
                        .HasColumnType("TEXT");

                    b.Property<string>("nono")
                        .HasColumnType("TEXT");

                    b.Property<string>("oitavo")
                        .HasColumnType("TEXT");

                    b.Property<string>("primeiro")
                        .HasColumnType("TEXT");

                    b.Property<string>("quarto")
                        .HasColumnType("TEXT");

                    b.Property<string>("quinto")
                        .HasColumnType("TEXT");

                    b.Property<string>("segundo")
                        .HasColumnType("TEXT");

                    b.Property<string>("setimo")
                        .HasColumnType("TEXT");

                    b.Property<string>("sexto")
                        .HasColumnType("TEXT");

                    b.Property<string>("terceiro")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("corte_executado");
                });

            modelBuilder.Entity("hora_Komdelli.Corte_planejado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("decimo")
                        .HasColumnType("TEXT");

                    b.Property<string>("decimo_primeiro")
                        .HasColumnType("TEXT");

                    b.Property<string>("nono")
                        .HasColumnType("TEXT");

                    b.Property<string>("oitavo")
                        .HasColumnType("TEXT");

                    b.Property<string>("primeiro")
                        .HasColumnType("TEXT");

                    b.Property<string>("quarto")
                        .HasColumnType("TEXT");

                    b.Property<string>("quinto")
                        .HasColumnType("TEXT");

                    b.Property<string>("segundo")
                        .HasColumnType("TEXT");

                    b.Property<string>("setimo")
                        .HasColumnType("TEXT");

                    b.Property<string>("sexto")
                        .HasColumnType("TEXT");

                    b.Property<string>("terceiro")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("corte_planejado");
                });

            modelBuilder.Entity("hora_Komdelli.Op_executado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("decimo")
                        .HasColumnType("TEXT");

                    b.Property<string>("decimo_primeiro")
                        .HasColumnType("TEXT");

                    b.Property<string>("nono")
                        .HasColumnType("TEXT");

                    b.Property<string>("oitavo")
                        .HasColumnType("TEXT");

                    b.Property<string>("primeiro")
                        .HasColumnType("TEXT");

                    b.Property<string>("quarto")
                        .HasColumnType("TEXT");

                    b.Property<string>("quinto")
                        .HasColumnType("TEXT");

                    b.Property<string>("segundo")
                        .HasColumnType("TEXT");

                    b.Property<string>("setimo")
                        .HasColumnType("TEXT");

                    b.Property<string>("sexto")
                        .HasColumnType("TEXT");

                    b.Property<string>("terceiro")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("op_executado");
                });

            modelBuilder.Entity("hora_Komdelli.Op_planejado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("decimo")
                        .HasColumnType("TEXT");

                    b.Property<string>("decimo_primeiro")
                        .HasColumnType("TEXT");

                    b.Property<string>("nono")
                        .HasColumnType("TEXT");

                    b.Property<string>("oitavo")
                        .HasColumnType("TEXT");

                    b.Property<string>("primeiro")
                        .HasColumnType("TEXT");

                    b.Property<string>("quarto")
                        .HasColumnType("TEXT");

                    b.Property<string>("quinto")
                        .HasColumnType("TEXT");

                    b.Property<string>("segundo")
                        .HasColumnType("TEXT");

                    b.Property<string>("setimo")
                        .HasColumnType("TEXT");

                    b.Property<string>("sexto")
                        .HasColumnType("TEXT");

                    b.Property<string>("terceiro")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("op_planejado");
                });

            modelBuilder.Entity("hora_Komdelli.parada_corte", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("duracao")
                        .HasColumnType("TEXT");

                    b.Property<string>("hora_final")
                        .HasColumnType("TEXT");

                    b.Property<string>("hora_inicio")
                        .HasColumnType("TEXT");

                    b.Property<string>("justificativa")
                        .HasColumnType("TEXT");

                    b.Property<string>("ordem")
                        .HasColumnType("TEXT");

                    b.Property<string>("processo")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("parada_corte");
                });
#pragma warning restore 612, 618
        }
    }
}
