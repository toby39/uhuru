﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using memoire.Models;

namespace memoire.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201025153211_dbinit8")]
    partial class dbinit8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("memoire.Models.Agence", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("adresse")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("designation")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("agence");
                });

            modelBuilder.Entity("memoire.Models.Approvisionement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Revendeurid")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("numero")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("quantite")
                        .HasColumnType("int");

                    b.Property<string>("unite")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.HasIndex("Revendeurid");

                    b.ToTable("approvisionement");
                });

            modelBuilder.Entity("memoire.Models.Client", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("noms")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("sexe")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("solde")
                        .HasColumnType("double");

                    b.Property<string>("telephone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("client");
                });

            modelBuilder.Entity("memoire.Models.Revendeur", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("noms")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("sexe")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("solde")
                        .HasColumnType("double");

                    b.Property<string>("telephone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("revendeur");
                });

            modelBuilder.Entity("memoire.Models.Stat", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("stat");
                });

            modelBuilder.Entity("memoire.Models.Superuser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("noms")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("superuser");
                });

            modelBuilder.Entity("memoire.Models.Tarif", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("desciption")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("designation")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("tranfert")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("uptime")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("tarif");
                });

            modelBuilder.Entity("memoire.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("noms")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("memoire.Models.Vente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Clientid")
                        .HasColumnType("int");

                    b.Property<int>("Revendeurid")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("numero")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("paquet")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.HasIndex("Clientid");

                    b.HasIndex("Revendeurid");

                    b.ToTable("vente");
                });

            modelBuilder.Entity("memoire.Models.Approvisionement", b =>
                {
                    b.HasOne("memoire.Models.Revendeur", "Revendeur")
                        .WithMany("Approvisionement")
                        .HasForeignKey("Revendeurid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("memoire.Models.Vente", b =>
                {
                    b.HasOne("memoire.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("Clientid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("memoire.Models.Revendeur", "Revendeur")
                        .WithMany()
                        .HasForeignKey("Revendeurid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
