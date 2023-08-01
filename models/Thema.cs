using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class Thema
    {
        //Properties
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Naam { get; set; }

        [MaxLength(6)]
        public string KleurHex { get; set; }

        Thema()
        {
            KleurHex="E1E1E1";
        }

        //Navigatieproperties
        public ICollection<Groepsreis> Groepsreizen { get; set; }
    }
}
