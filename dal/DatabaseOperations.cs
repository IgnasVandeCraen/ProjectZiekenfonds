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
    }
}