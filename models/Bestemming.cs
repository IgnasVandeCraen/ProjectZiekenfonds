﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class Bestemming
    {
        //Properties
        public int Id { get; set; }
        public string Adres { get; set; }
        public string Plaats { get; set; }
        public string Postcode { get; set; }
        public string Land { get; set; }
    }
}
