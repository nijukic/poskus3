using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aplikacija.Models
{
    public class Naslov
    {

        public int NaslovID { get; set; }

        public int OsebaID { get; set; }

        [Required]
        public int HisnaSt { get; set; }

        [Required]
        public string Ulica { get; set; }
        
        [Required]
        public int Posta { get; set; }

        [Required]
        public string Mesto { get; set; }

        //[ForeignKey("OsebaID")]
        public Oseba Oseba { get; set; }

        //public ApplicationUser ApplicationUser { get; set; }
    }
}