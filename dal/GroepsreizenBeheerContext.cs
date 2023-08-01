using Microsoft.EntityFrameworkCore;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal
{
    public class GroepsreizenBeheerContext : DbContext
    {
        public DbSet<Bestemming> Bestemmingen { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Groepsreis> Groepsreizen { get; set; }
        public DbSet<Inschrijving> Inschrijvingen { get; set; }
        public DbSet<Leeftijdscategorie> Leeftijdscategorien { get; set; }
        public DbSet<Thema> Themas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=GroepsreizenBeheerDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Een leeftijdscategorie mag niet verwijdert worden, wnr er nog reizen of gebruikers zijn die ernaar verwijzen.
            modelBuilder.Entity<Groepsreis>()
                .HasOne(gr => gr.Leeftijdscategorie)
                .WithMany(lc => lc.Groepsreizen)
                .HasForeignKey(gr => gr.LeeftijdscategorieId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Gebruiker>()
                .HasOne(g => g.Leeftijdscategorie)
                .WithMany(lc => lc.Gebruikers)
                .HasForeignKey(g => g.LeeftijdscategorieId)
                .OnDelete(DeleteBehavior.Restrict);

            //Als een thema verwijdert is, worden de verwijzingen ernaar null
            modelBuilder.Entity<Groepsreis>()
                .HasOne(gr => gr.Thema)
                .WithMany(t => t.Groepsreizen)
                .HasForeignKey(gr => gr.ThemaId)
                .OnDelete(DeleteBehavior.SetNull);

            //Als een bestemming verwijdert is, worden de verwijzingen ernaar null
            modelBuilder.Entity<Groepsreis>()
                .HasOne(gr => gr.Bestemming)
                .WithMany(b => b.Groepsreizen)
                .HasForeignKey(gr => gr.BestemmingId)
                .OnDelete(DeleteBehavior.SetNull);

            //Als een gebruiker verwijdert is, worden zijn inschrijvingen ook verwijdert
            modelBuilder.Entity<Inschrijving>()
                .HasOne(i => i.Groepsreis)
                .WithMany(gr => gr.Inschrijvingen)
                .HasForeignKey(i => i.GroepsreisId)
                .OnDelete(DeleteBehavior.Cascade);

            //Als een groepsreis verwijdert is, worden zijn inschrijvingen ook verwijdert
            modelBuilder.Entity<Inschrijving>()
                .HasOne(i => i.Gebruiker)
                .WithMany(g => g.Inschrijvingen)
                .HasForeignKey(i => i.GebruikerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
