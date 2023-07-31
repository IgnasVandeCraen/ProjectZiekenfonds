using System.ComponentModel.DataAnnotations;

namespace models
{
    public class Gebruiker
    {
        //Properties
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Wachtwoord { get; set; }

        [Required]
        [MaxLength(50)]
        public string Voornaam { get; set; }

        [Required]
        [MaxLength(50)]
        public string Achternaam { get; set; }

        [Required]
        public bool Admin { get; set; }

        [Required]
        public bool Lid { get; set; }

        [MaxLength(200)]
        public string? MedischeGegevens { get; set; }

        [Required]
        public DateTime Aanmaakdatum { get; set; }

        //FK naar Leeftijdscategorie
        [Required]
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