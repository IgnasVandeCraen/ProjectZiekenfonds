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

        [Required]
        public int GroepsreisId { get; set; }

        [Required]
        public int GebruikerId { get; set; }

        //Navigatieproperties
        public Groepsreis Groepsreis { get; set; }
        public Gebruiker Gebruiker { get; set; }
    }
}
