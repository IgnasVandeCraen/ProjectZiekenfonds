using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class Inschrijving
    {
        //Properties
        public int Id { get; set; }

        //FK naar Groepsreis
        public int GroepsreisId { get; set; }
        public Groepsreis Groepsreis { get; set; }

        //FK naar Gebruiker
        public int GebruikerId { get; set; }
        public Gebruiker Gebruiker { get; set; }
    }
}
