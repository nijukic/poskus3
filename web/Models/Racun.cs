using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace aplikacija.Models
{
    public class Racun
    {
        public int RacunID { get; set; }

        public int NarociloID { get; set; }

        public int VrstaPlacilaID { get; set; }

        public DateTime Datum { get; set; }

        //[ForeignKey("VrstaPlacilaID")]
        public VrstaPlacila VrstaPlacila { get; set; }
    
    }
}