﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace models
{
    [Table("Leeftijdscategorieen")]
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

        //Navigatieproperties
        public ICollection<Groepsreis> Groepsreizen { get; set; }
        public ICollection<Gebruiker> Gebruikers { get; set; }
    }
}
