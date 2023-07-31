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
    }
}
