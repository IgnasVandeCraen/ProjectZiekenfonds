﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace models
{
    [Table ("Bestemmingen")]
    public class Bestemming
    {
        //Properties
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Adres { get; set; }

        [Required]
        [MaxLength(50)]
        public string Plaats { get; set; }

        [Required]
        [MaxLength(10)]
        public string Postcode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Land { get; set; }

        //Navigatieproperties
        public ICollection<Groepsreis> Groepsreizen { get; set; }
    }
}
