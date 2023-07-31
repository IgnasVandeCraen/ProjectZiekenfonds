namespace models
{
    public class Gebruiker
    {
        //Properties
        public int Id { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public bool Admin { get; set; }
        public bool Lid { get; set; }
        public string? MedischeGegevens { get; set; }
        public DateTime Aanmaakdatum { get; set; }

        //FK naar Leeftijdscategorie
        public int LeeftijdscategorieId { get; set; }
        public Leeftijdscategorie Leeftijdscategorie { get; set; }

        //Veel-op-veel relatie naar Inschrijving
        public ICollection<Inschrijving> Inschrijvingen { get; set; }


        public Gebruiker()
        {
            Aanmaakdatum = DateTime.Now;
        }
    }
}