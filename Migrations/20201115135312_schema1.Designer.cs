﻿// <auto-generated />
using System;
using GrozioSalonuISCF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GrozioSalonuISCF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201115135312_schema1")]
    partial class schema1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GrozioSalonuISCF.Models.Darbuotojas", b =>
                {
                    b.Property<int>("DarbuotojasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Pavarde")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("SalonasId")
                        .HasColumnType("int");

                    b.Property<string>("Vardas")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("tel_nr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("DarbuotojasId");

                    b.HasIndex("SalonasId");

                    b.ToTable("Darbuotojas");
                });

            modelBuilder.Entity("GrozioSalonuISCF.Models.Islaidos", b =>
                {
                    b.Property<string>("IslaidosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("SalonasId")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("paskirtis")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<float>("suma")
                        .HasColumnType("float");

                    b.HasKey("IslaidosId");

                    b.HasIndex("SalonasId");

                    b.ToTable("Islaidos");
                });

            modelBuilder.Entity("GrozioSalonuISCF.Models.Klientas", b =>
                {
                    b.Property<int>("KlientasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("GimimoData")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Pavarde")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Vardas")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("KlientasId");

                    b.ToTable("Klientai");
                });

            modelBuilder.Entity("GrozioSalonuISCF.Models.Miestas", b =>
                {
                    b.Property<int>("MiestasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("pavadinimas")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("MiestasId");

                    b.ToTable("Miestas");
                });

            modelBuilder.Entity("GrozioSalonuISCF.Models.Paslauga", b =>
                {
                    b.Property<int>("PaslaugaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DarbuotojasId")
                        .HasColumnType("int");

                    b.Property<int>("PaslaugosTipasId")
                        .HasColumnType("int");

                    b.Property<int>("SalonasId")
                        .HasColumnType("int");

                    b.Property<string>("aprasymas")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<float>("kaina")
                        .HasColumnType("float");

                    b.Property<string>("pavadinimas")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("priemones")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("rekomendacijos")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<float>("trukme")
                        .HasColumnType("float");

                    b.HasKey("PaslaugaId");

                    b.HasIndex("DarbuotojasId");

                    b.HasIndex("PaslaugosTipasId");

                    b.HasIndex("SalonasId");

                    b.ToTable("Paslauga");
                });

            modelBuilder.Entity("GrozioSalonuISCF.Models.PaslaugosTipas", b =>
                {
                    b.Property<int>("PaslaugosTipasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("pavadinimas")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("PaslaugosTipasId");

                    b.ToTable("PaslaugosTipas");
                });

            modelBuilder.Entity("GrozioSalonuISCF.Models.Rezervacija", b =>
                {
                    b.Property<int>("nr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("KlientasId")
                        .HasColumnType("int");

                    b.Property<int>("PaslaugaId")
                        .HasColumnType("int");

                    b.Property<bool>("busenos")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("proc_prad")
                        .HasColumnType("datetime(6)");

                    b.HasKey("nr");

                    b.HasIndex("KlientasId");

                    b.HasIndex("PaslaugaId");

                    b.ToTable("Rezervacija");
                });

            modelBuilder.Entity("GrozioSalonuISCF.Models.Salonas", b =>
                {
                    b.Property<int>("SalonasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MiestasId")
                        .HasColumnType("int");

                    b.Property<string>("adresas")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("ikurimo_data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("imones_kodas")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("pavadinimas")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("tel_nr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("SalonasId");

                    b.HasIndex("MiestasId");

                    b.ToTable("Salonas");
                });

            modelBuilder.Entity("GrozioSalonuISCF.Models.Darbuotojas", b =>
                {
                    b.HasOne("GrozioSalonuISCF.Models.Salonas", "Salonas")
                        .WithMany("Darbuotojas")
                        .HasForeignKey("SalonasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GrozioSalonuISCF.Models.Islaidos", b =>
                {
                    b.HasOne("GrozioSalonuISCF.Models.Salonas", "Salonas")
                        .WithMany("Islaidos")
                        .HasForeignKey("SalonasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GrozioSalonuISCF.Models.Paslauga", b =>
                {
                    b.HasOne("GrozioSalonuISCF.Models.Darbuotojas", "Darbuotojas")
                        .WithMany("Paslauga")
                        .HasForeignKey("DarbuotojasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrozioSalonuISCF.Models.PaslaugosTipas", "PaslaugosTipas")
                        .WithMany("Paslauga")
                        .HasForeignKey("PaslaugosTipasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrozioSalonuISCF.Models.Salonas", "Salonas")
                        .WithMany("Paslauga")
                        .HasForeignKey("SalonasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GrozioSalonuISCF.Models.Rezervacija", b =>
                {
                    b.HasOne("GrozioSalonuISCF.Models.Klientas", "Klientas")
                        .WithMany("Rezervacija")
                        .HasForeignKey("KlientasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrozioSalonuISCF.Models.Paslauga", "Paslauga")
                        .WithMany("Rezervacija")
                        .HasForeignKey("PaslaugaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GrozioSalonuISCF.Models.Salonas", b =>
                {
                    b.HasOne("GrozioSalonuISCF.Models.Miestas", "Miestas")
                        .WithMany("Salonas")
                        .HasForeignKey("MiestasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
