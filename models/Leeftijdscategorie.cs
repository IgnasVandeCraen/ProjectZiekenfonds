using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    [Table("Leeftijdscategorien")]
    public class Leeftijdscategorie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Naam { get; set; }

        [Required]
        [Range(0, 100)]
        public int MinLeeftijd { get; set; }

        [Required]
        [Range(0, 100)]
        public int MaxLeeftijd { get; set; }
    }
}
