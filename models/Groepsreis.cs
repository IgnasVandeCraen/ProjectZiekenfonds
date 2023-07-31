using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class Groepsreis
    {
        //Properties
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime Einddatum { get; set; }
        public decimal Prijs { get; set; }
        public DateTime Aanmaakdatum { get; set; }

        //FK naar Leeftijdscategorie
        public int LeeftijdscategorieId { get; set; }
        public Leeftijdscategorie Leeftijdscategorie { get; set; }

        //FK naar Bestemming
        public int BestemmingId { get; set; }
        public Bestemming Bestemming { get; set; }

        //FK naar Thema
        public int ThemaId { get; set; }
        public Thema Thema { get; set; }

        //Veel-op-veel relatie naar Inschrijving
        public ICollection<Inschrijving> Inschrijvingen { get; set; }

        public Groepsreis()
        {
            Aanmaakdatum = DateTime.Now;
        }
    }
}
