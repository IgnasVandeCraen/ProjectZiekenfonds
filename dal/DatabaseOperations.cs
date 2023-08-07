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
                    .ToList();

                ObservableCollection<Groepsreis> groepsreizenCollection = new ObservableCollection<Groepsreis>(groepsreizenLijst);
                return groepsreizenCollection;
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
    }
}