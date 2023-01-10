using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aplikacija.Models
{
    public class Narocilo
    {
        public int NarociloID { get; set; }

        public int OsebaID { get; set; }

        public int StatusID { get; set; }

        public int NaslovID { get; set; }

        public int TipPrevzemaID { get; set; }

        public DateTime Datum { get; set; }
        
        [Column(TypeName = "money")]
        public decimal skupniZnesek { get; set; }

        public ICollection<Postavka> Postavke { get; set; }

//[ForeignKey("RacunID")]
        public Racun Racun { get; set; }

//[ForeignKey("TipPrevzemaID")]
        public TipPrevzema TipPrevzema { get; set; }

//[ForeignKey("NaslovID")]
        public Naslov Naslov { get; set; }

//[ForeignKey("StatusID")]
        public Status Status { get; set; }

        //[ForeignKey("OsebaID")]
        public Oseba Oseba { get; set; }

        //public ApplicationUser ApplicationUser { get; set; }
    }
}