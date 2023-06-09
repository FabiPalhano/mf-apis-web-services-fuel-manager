﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using vacina_tracker_v3.Models;

#nullable disable

namespace vacina_tracker_v3.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230423015616_M01")]
    partial class M01
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("vacina_tracker_v3.Models.LinkDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Href")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MembroId")
                        .HasColumnType("int");

                    b.Property<string>("Metodo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VacinaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MembroId");

                    b.HasIndex("VacinaId");

                    b.ToTable("LinkDto");
                });

            modelBuilder.Entity("vacina_tracker_v3.Models.Membro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("NomeMembroFamilia")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("VacinaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VacinaId");

                    b.ToTable("Membros");
                });

            modelBuilder.Entity("vacina_tracker_v3.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuário");
                });

            modelBuilder.Entity("vacina_tracker_v3.Models.Vacina", b =>
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

                    b.Property<int>("NomeVacina")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vacinas");
                });

            modelBuilder.Entity("vacina_tracker_v3.Models.VacinaMembro", b =>
                {
                    b.Property<int>("VacinaId")
                        .HasColumnType("int");

                    b.Property<int>("MembroId")
                        .HasColumnType("int");

                    b.HasKey("VacinaId", "MembroId");

                    b.HasIndex("MembroId");

                    b.ToTable("Vacinas Membros");
                });

            modelBuilder.Entity("vacina_tracker_v3.Models.LinkDto", b =>
                {
                    b.HasOne("vacina_tracker_v3.Models.Membro", null)
                        .WithMany("Links")
                        .HasForeignKey("MembroId");

                    b.HasOne("vacina_tracker_v3.Models.Vacina", null)
                        .WithMany("Links")
                        .HasForeignKey("VacinaId");
                });

            modelBuilder.Entity("vacina_tracker_v3.Models.Membro", b =>
                {
                    b.HasOne("vacina_tracker_v3.Models.Vacina", "Vacina")
                        .WithMany()
                        .HasForeignKey("VacinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vacina");
                });

            modelBuilder.Entity("vacina_tracker_v3.Models.VacinaMembro", b =>
                {
                    b.HasOne("vacina_tracker_v3.Models.Membro", "Membro")
                        .WithMany("Vacinas")
                        .HasForeignKey("MembroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vacina_tracker_v3.Models.Vacina", "Vacina")
                        .WithMany("Membros")
                        .HasForeignKey("VacinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Membro");

                    b.Navigation("Vacina");
                });

            modelBuilder.Entity("vacina_tracker_v3.Models.Membro", b =>
                {
                    b.Navigation("Links");

                    b.Navigation("Vacinas");
                });

            modelBuilder.Entity("vacina_tracker_v3.Models.Vacina", b =>
                {
                    b.Navigation("Links");

                    b.Navigation("Membros");
                });
#pragma warning restore 612, 618
        }
    }
}
