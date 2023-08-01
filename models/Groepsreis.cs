using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    [Table("Groepsreizen")]
    public class Groepsreis
    {
        //Properties
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Naam { get; set; }

        [Required]
        [MaxLength(200)]
        public string Beschrijving { get; set; }

        [Required]
        public DateTime Startdatum { get; set; }

        [Required]
        public DateTime Einddatum { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Prijs { get; set; }

        public DateTime Aanmaakdatum { get; set; }

        [Required]
        public int LeeftijdscategorieId { get; set; }

        public int? BestemmingId { get; set; }

        public int? ThemaId { get; set; }

        //Navigatieproperties
        public ICollection<Inschrijving> Inschrijvingen { get; set; }
        public Leeftijdscategorie Leeftijdscategorie { get; set; }
        public Bestemming? Bestemming { get; set; }
        public Thema? Thema { get; set; }

        public Groepsreis()
        {
            Aanmaakdatum = DateTime.Now;
        }
    }
}
