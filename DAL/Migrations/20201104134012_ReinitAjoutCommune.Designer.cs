﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DesignDbContext))]
    [Migration("20201104134012_ReinitAjoutCommune")]
    partial class ReinitAjoutCommune
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BO.Commune", b =>
                {
                    b.Property<int>("CommuneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CodeIris")
                        .HasColumnType("int");

                    b.Property<string>("GeoShape")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("GrandQuart")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LibelleDepartement")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LibelleEpci")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LibelleRegion")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nom")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NomIris")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("NumeroDepartement")
                        .HasColumnType("int");

                    b.Property<int>("NumeroEpci")
                        .HasColumnType("int");

                    b.Property<int>("NumeroRegion")
                        .HasColumnType("int");

                    b.Property<double>("Population")
                        .HasColumnType("double");

                    b.Property<double>("ScoreAccesInfoDep")
                        .HasColumnType("double");

                    b.Property<double>("ScoreAccesInfoEpci")
                        .HasColumnType("double");

                    b.Property<double>("ScoreAccesInfoReg")
                        .HasColumnType("double");

                    b.Property<double>("ScoreAccesInterDep")
                        .HasColumnType("double");

                    b.Property<double>("ScoreAccesInterEpci")
                        .HasColumnType("double");

                    b.Property<double>("ScoreAccesInterReg")
                        .HasColumnType("double");

                    b.Property<double>("ScoreCompAdminDep")
                        .HasColumnType("double");

                    b.Property<double>("ScoreCompAdminEpci")
                        .HasColumnType("double");

                    b.Property<double>("ScoreCompAdminReg")
                        .HasColumnType("double");

                    b.Property<double>("ScoreCompNumDep")
                        .HasColumnType("double");

                    b.Property<double>("ScoreCompNumEpci")
                        .HasColumnType("double");

                    b.Property<double>("ScoreCompNumReg")
                        .HasColumnType("double");

                    b.Property<double>("ScoreGlobalAccesDep")
                        .HasColumnType("double");

                    b.Property<double>("ScoreGlobalAccesEpci")
                        .HasColumnType("double");

                    b.Property<double>("ScoreGlobalAccesReg")
                        .HasColumnType("double");

                    b.Property<double>("ScoreGlobalCompDep")
                        .HasColumnType("double");

                    b.Property<double>("ScoreGlobalCompEpci")
                        .HasColumnType("double");

                    b.Property<double>("ScoreGlobalCompReg")
                        .HasColumnType("double");

                    b.Property<double>("ScoreGlobalDep")
                        .HasColumnType("double");

                    b.Property<double>("ScoreGlobalEpci")
                        .HasColumnType("double");

                    b.Property<double>("ScoreGlobalReg")
                        .HasColumnType("double");

                    b.HasKey("CommuneId");

                    b.ToTable("Communes");
                });
#pragma warning restore 612, 618
        }
    }
}
