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
    [Migration("20200913032749_dbinit1")]
    partial class dbinit1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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

            modelBuilder.Entity("memoire.Models.Approvisionement", b =>
                {
                    b.HasOne("memoire.Models.Revendeur", "Revendeur")
                        .WithMany("Approvisionement")
                        .HasForeignKey("Revendeurid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}