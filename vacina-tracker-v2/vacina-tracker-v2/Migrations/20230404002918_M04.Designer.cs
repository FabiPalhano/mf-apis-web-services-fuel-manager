﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using vacina_tracker_v2.Models;

#nullable disable

namespace vacina_tracker_v2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230404002918_M04")]
    partial class M04
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("vacina_tracker_v2.Models.LinkDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Href")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Metodo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResponsavelId")
                        .HasColumnType("int");

                    b.Property<int?>("VacinaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResponsavelId");

                    b.HasIndex("VacinaId");

                    b.ToTable("LinkDto");
                });

            modelBuilder.Entity("vacina_tracker_v2.Models.Responsavel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Perfil Usuário Responsável");
                });

            modelBuilder.Entity("vacina_tracker_v2.Models.Vacina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataAplicacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataProxAplicacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Dose")
                        .HasColumnType("int");

                    b.Property<string>("NomeVacina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vacinas Adicionadas");
                });

            modelBuilder.Entity("vacina_tracker_v2.Models.VacinasUsuarios", b =>
                {
                    b.Property<int>("VacinaId")
                        .HasColumnType("int");

                    b.Property<int>("ResponsavelId")
                        .HasColumnType("int");

                    b.HasKey("VacinaId", "ResponsavelId");

                    b.HasIndex("ResponsavelId");

                    b.ToTable("Vacinas Usuários");
                });

            modelBuilder.Entity("vacina_tracker_v2.Models.LinkDto", b =>
                {
                    b.HasOne("vacina_tracker_v2.Models.Responsavel", null)
                        .WithMany("Links")
                        .HasForeignKey("ResponsavelId");

                    b.HasOne("vacina_tracker_v2.Models.Vacina", null)
                        .WithMany("Links")
                        .HasForeignKey("VacinaId");
                });

            modelBuilder.Entity("vacina_tracker_v2.Models.VacinasUsuarios", b =>
                {
                    b.HasOne("vacina_tracker_v2.Models.Responsavel", "Responsavel")
                        .WithMany("Vacina")
                        .HasForeignKey("ResponsavelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vacina_tracker_v2.Models.Vacina", "Vacina")
                        .WithMany("Responsavel")
                        .HasForeignKey("VacinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Responsavel");

                    b.Navigation("Vacina");
                });

            modelBuilder.Entity("vacina_tracker_v2.Models.Responsavel", b =>
                {
                    b.Navigation("Links");

                    b.Navigation("Vacina");
                });

            modelBuilder.Entity("vacina_tracker_v2.Models.Vacina", b =>
                {
                    b.Navigation("Links");

                    b.Navigation("Responsavel");
                });
#pragma warning restore 612, 618
        }
    }
}
