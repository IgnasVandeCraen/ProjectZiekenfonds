using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    [Table("Inschrijvingen")]
    public class Inschrijving
    {
        //Properties
        public int Id { get; set; }

        //FK naar Groepsreis
        [Required]
        public int GroepsreisId { get; set; }
        public Groepsreis Groepsreis { get; set; }

        //FK naar Gebruiker
        [Required]
        public int GebruikerId { get; set; }
        public Gebruiker Gebruiker { get; set; }
    }
}
