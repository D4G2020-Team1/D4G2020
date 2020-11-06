﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DesignDbContext))]
    [Migration("20201104174605_AjoutTableHistoriques")]
    partial class AjoutTableHistoriques
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BO.Commune", b =>
                {
                    b.Property<string>("CodeInsee")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("CodePostal")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NomCommune")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CodeInsee");

                    b.ToTable("Communes");
                });

            modelBuilder.Entity("BO.Historique", b =>
                {
                    b.Property<int>("HistoriqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodeInsee")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CodeIris")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateAjout")
                        .HasColumnType("datetime(6)");

                    b.HasKey("HistoriqueId");

                    b.ToTable("Historiques");
                });

            modelBuilder.Entity("BO.Score", b =>
                {
                    b.Property<int>("ScoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodeCommune")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4");

                    b.Property<string>("CodeDepartement")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CodeEpci")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CodeIris")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("CodeRegion")
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

                    b.Property<string>("NomIris")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

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

                    b.HasKey("ScoreId");

                    b.HasIndex("CodeCommune");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("BO.Score", b =>
                {
                    b.HasOne("BO.Commune", "Commune")
                        .WithMany("Scores")
                        .HasForeignKey("CodeCommune")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
