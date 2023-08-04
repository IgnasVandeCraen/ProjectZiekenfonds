using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using models;

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

        public static List<Groepsreis> OphalenGroepreizen()
        {
            using (GroepsreizenBeheerContext ctx = new GroepsreizenBeheerContext())
            {
                return ctx.Groepsreizen.Include(gr => gr.Thema).Include(gr => gr.Leeftijdscategorie).Include(gr => gr.Bestemming).ToList();
            }
        }
    }
}