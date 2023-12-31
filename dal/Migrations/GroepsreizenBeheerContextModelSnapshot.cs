﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dal;

#nullable disable

namespace dal.Migrations
{
    [DbContext(typeof(GroepsreizenBeheerContext))]
    partial class GroepsreizenBeheerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("models.Bestemming", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Land")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Plaats")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Bestemmingen");
                });

            modelBuilder.Entity("models.Gebruiker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Aanmaakdatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Achternaam")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("LeeftijdscategorieId")
                        .HasColumnType("int");

                    b.Property<bool>("Lid")
                        .HasColumnType("bit");

                    b.Property<string>("MedischeGegevens")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Wachtwoord")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("LeeftijdscategorieId");

                    b.ToTable("Gebruikers");
                });

            modelBuilder.Entity("models.Groepsreis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Aanmaakdatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Beschrijving")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("BestemmingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Einddatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("LeeftijdscategorieId")
                        .HasColumnType("int");

                    b.Property<int>("MaxInschrijvingen")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("money");

                    b.Property<DateTime>("Startdatum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ThemaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BestemmingId");

                    b.HasIndex("LeeftijdscategorieId");

                    b.HasIndex("ThemaId");

                    b.ToTable("Groepsreizen");
                });

            modelBuilder.Entity("models.Inschrijving", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GebruikerId")
                        .HasColumnType("int");

                    b.Property<int>("GroepsreisId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GebruikerId");

                    b.HasIndex("GroepsreisId");

                    b.ToTable("Inschrijvingen");
                });

            modelBuilder.Entity("models.Leeftijdscategorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MaxLeeftijd")
                        .HasColumnType("int");

                    b.Property<int>("MinLeeftijd")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Leeftijdscategorieen");
                });

            modelBuilder.Entity("models.Thema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("KleurHex")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Themas");
                });

            modelBuilder.Entity("models.Gebruiker", b =>
                {
                    b.HasOne("models.Leeftijdscategorie", "Leeftijdscategorie")
                        .WithMany("Gebruikers")
                        .HasForeignKey("LeeftijdscategorieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Leeftijdscategorie");
                });

            modelBuilder.Entity("models.Groepsreis", b =>
                {
                    b.HasOne("models.Bestemming", "Bestemming")
                        .WithMany("Groepsreizen")
                        .HasForeignKey("BestemmingId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("models.Leeftijdscategorie", "Leeftijdscategorie")
                        .WithMany("Groepsreizen")
                        .HasForeignKey("LeeftijdscategorieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("models.Thema", "Thema")
                        .WithMany("Groepsreizen")
                        .HasForeignKey("ThemaId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Bestemming");

                    b.Navigation("Leeftijdscategorie");

                    b.Navigation("Thema");
                });

            modelBuilder.Entity("models.Inschrijving", b =>
                {
                    b.HasOne("models.Gebruiker", "Gebruiker")
                        .WithMany("Inschrijvingen")
                        .HasForeignKey("GebruikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("models.Groepsreis", "Groepsreis")
                        .WithMany("Inschrijvingen")
                        .HasForeignKey("GroepsreisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gebruiker");

                    b.Navigation("Groepsreis");
                });

            modelBuilder.Entity("models.Bestemming", b =>
                {
                    b.Navigation("Groepsreizen");
                });

            modelBuilder.Entity("models.Gebruiker", b =>
                {
                    b.Navigation("Inschrijvingen");
                });

            modelBuilder.Entity("models.Groepsreis", b =>
                {
                    b.Navigation("Inschrijvingen");
                });

            modelBuilder.Entity("models.Leeftijdscategorie", b =>
                {
                    b.Navigation("Gebruikers");

                    b.Navigation("Groepsreizen");
                });

            modelBuilder.Entity("models.Thema", b =>
                {
                    b.Navigation("Groepsreizen");
                });
#pragma warning restore 612, 618
        }
    }
}
