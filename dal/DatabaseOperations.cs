using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using models;
using System.Collections.ObjectModel;

namespace dal
{
    public class DatabaseOperations
    {
        public static Gebruiker OphalenGebruikerViaEmail(string email)
        {
            using (GroepsreizenBeheerContext ctx = new GroepsreizenBeheerContext())
            {
                return ctx.Gebruikers
                    .FirstOrDefault(g => g.Email == email);
            }
        }

        public static ObservableCollection<Groepsreis> OphalenGroepreizen()
        {
            using (GroepsreizenBeheerContext ctx = new GroepsreizenBeheerContext())
            {
                List<Groepsreis> groepsreizenLijst = ctx.Groepsreizen
                    .Include(gr => gr.Thema)
                    .Include(gr => gr.Leeftijdscategorie)
                    .Include(gr => gr.Bestemming)
                    .Include(gr => gr.Inschrijvingen)
                    .ThenInclude(ins => ins.Gebruiker)
                    .ToList();

                ObservableCollection<Groepsreis> groepsreizenCollection = new ObservableCollection<Groepsreis>(groepsreizenLijst);
                return groepsreizenCollection;
            }
        }

        public static List<Leeftijdscategorie> OphalenLeeftijdscategorieen()
        {
            using (GroepsreizenBeheerContext ctx = new GroepsreizenBeheerContext())
            {
                List<Leeftijdscategorie> leeftijdscategorieLijst = ctx.Leeftijdscategorieen
                    .ToList();
                return leeftijdscategorieLijst;
            }
        }

        public static List<Bestemming> OphalenBestemmingen()
        {
            using (GroepsreizenBeheerContext ctx = new GroepsreizenBeheerContext())
            {
                List<Bestemming> bestemmingLijst = ctx.Bestemmingen
                    .ToList();
                return bestemmingLijst;
            }
        }

        public static List<Thema> OphalenThemas() {
            using (GroepsreizenBeheerContext ctx = new GroepsreizenBeheerContext())
            {
                List<Thema> themaLijst = ctx.Themas
                    .ToList();
                return themaLijst;
            }
        }
        
        public static int ToevoegenInschrijving(Inschrijving inschrijving)
        {
            try
            {
                using (GroepsreizenBeheerContext ctx = new GroepsreizenBeheerContext())
                {
                    ctx.Inschrijvingen.Add(inschrijving);
                    return ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
        
        public static ObservableCollection<Inschrijving> OphalenInschrijvingenViaGebruikerId(int id)
        {
            using (GroepsreizenBeheerContext ctx = new GroepsreizenBeheerContext())
            {
                List<Inschrijving> inschrijvingenLijst = ctx.Inschrijvingen
                    .Where(i => i.GebruikerId  == id)
                    .Include(i => i.Groepsreis)
                    .ToList();

                ObservableCollection<Inschrijving> inschrijvingenCollection = new ObservableCollection<Inschrijving>(inschrijvingenLijst);

                return inschrijvingenCollection;
            }
        }

        public static int ToevoegenGroepreis(Groepsreis groepreis)
        {
            try
            {
                using (GroepsreizenBeheerContext ctx = new GroepsreizenBeheerContext())
                {
                    ctx.Groepsreizen.Add(groepreis);
                    return ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        public static int AanpassenGroepreis(Groepsreis groepreis)
        {
            try
            {
                using (GroepsreizenBeheerContext ctx = new GroepsreizenBeheerContext())
                {
                    ctx.Entry(groepreis).State = EntityState.Modified;
                    return ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        public static int VerwijderenGroepreis(Groepsreis groepreis)
        {
            try
            {
                using (GroepsreizenBeheerContext ctx = new GroepsreizenBeheerContext())
                {
                    ctx.Entry(groepreis).State = EntityState.Deleted;
                    return ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
    }
}