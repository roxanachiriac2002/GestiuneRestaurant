﻿// <auto-generated />
using System;
using GestiuneRestaurant.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestiuneRestaurant.Migrations
{
    [DbContext(typeof(RestaurantContext))]
    partial class RestaurantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestiuneRestaurant.Models.ArticolComandat", b =>
                {
                    b.Property<int>("ArticolComandatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticolComandatId"));

                    b.Property<int>("Cantitate")
                        .HasColumnType("int");

                    b.Property<int>("ComandaId")
                        .HasColumnType("int");

                    b.Property<int>("ProdusMeniuId")
                        .HasColumnType("int");

                    b.HasKey("ArticolComandatId");

                    b.HasIndex("ComandaId");

                    b.HasIndex("ProdusMeniuId");

                    b.ToTable("ArticoleComandate");
                });

            modelBuilder.Entity("GestiuneRestaurant.Models.Comanda", b =>
                {
                    b.Property<int>("ComandaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComandaId"));

                    b.Property<int>("MasaId")
                        .HasColumnType("int");

                    b.HasKey("ComandaId");

                    b.HasIndex("MasaId")
                        .IsUnique();

                    b.ToTable("Comenzi");
                });

            modelBuilder.Entity("GestiuneRestaurant.Models.Masa", b =>
                {
                    b.Property<int>("MasaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasaId"));

                    b.Property<int>("Capacitate")
                        .HasColumnType("int");

                    b.Property<int>("Numar")
                        .HasColumnType("int");

                    b.HasKey("MasaId");

                    b.ToTable("Mese");

                    b.HasData(
                        new
                        {
                            MasaId = 1,
                            Capacitate = 6,
                            Numar = 1
                        },
                        new
                        {
                            MasaId = 2,
                            Capacitate = 6,
                            Numar = 2
                        },
                        new
                        {
                            MasaId = 3,
                            Capacitate = 6,
                            Numar = 3
                        },
                        new
                        {
                            MasaId = 4,
                            Capacitate = 6,
                            Numar = 4
                        },
                        new
                        {
                            MasaId = 5,
                            Capacitate = 6,
                            Numar = 5
                        },
                        new
                        {
                            MasaId = 6,
                            Capacitate = 6,
                            Numar = 6
                        });
                });

            modelBuilder.Entity("GestiuneRestaurant.Models.ProdusMeniu", b =>
                {
                    b.Property<int>("ProdusMeniuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdusMeniuId"));

                    b.Property<string>("Descriere")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(6, 2)");

                    b.HasKey("ProdusMeniuId");

                    b.ToTable("ProduseMeniu");
                });

            modelBuilder.Entity("GestiuneRestaurant.Models.Rezervare", b =>
                {
                    b.Property<int>("RezervareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RezervareId"));

                    b.Property<DateTime>("DataRezervare")
                        .HasColumnType("datetime2");

                    b.Property<int>("MasaId")
                        .HasColumnType("int");

                    b.Property<int>("NumarPersoane")
                        .HasColumnType("int");

                    b.Property<string>("NumeClient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RezervareId");

                    b.HasIndex("MasaId");

                    b.ToTable("Rezervari");
                });

            modelBuilder.Entity("GestiuneRestaurant.Models.ArticolComandat", b =>
                {
                    b.HasOne("GestiuneRestaurant.Models.Comanda", "Comanda")
                        .WithMany("ArticoleComandate")
                        .HasForeignKey("ComandaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestiuneRestaurant.Models.ProdusMeniu", "ProdusMeniu")
                        .WithMany("ArticoleComandate")
                        .HasForeignKey("ProdusMeniuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comanda");

                    b.Navigation("ProdusMeniu");
                });

            modelBuilder.Entity("GestiuneRestaurant.Models.Comanda", b =>
                {
                    b.HasOne("GestiuneRestaurant.Models.Masa", "Masa")
                        .WithOne("Comanda")
                        .HasForeignKey("GestiuneRestaurant.Models.Comanda", "MasaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Masa");
                });

            modelBuilder.Entity("GestiuneRestaurant.Models.Rezervare", b =>
                {
                    b.HasOne("GestiuneRestaurant.Models.Masa", "Masa")
                        .WithMany("Rezervari")
                        .HasForeignKey("MasaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Masa");
                });

            modelBuilder.Entity("GestiuneRestaurant.Models.Comanda", b =>
                {
                    b.Navigation("ArticoleComandate");
                });

            modelBuilder.Entity("GestiuneRestaurant.Models.Masa", b =>
                {
                    b.Navigation("Comanda")
                        .IsRequired();

                    b.Navigation("Rezervari");
                });

            modelBuilder.Entity("GestiuneRestaurant.Models.ProdusMeniu", b =>
                {
                    b.Navigation("ArticoleComandate");
                });
#pragma warning restore 612, 618
        }
    }
}