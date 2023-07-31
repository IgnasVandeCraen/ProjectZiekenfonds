using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class Leeftijdscategorie
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int MinLeeftijd { get; set; }
        public int MaxLeeftijd { get; set; }
    }
}
