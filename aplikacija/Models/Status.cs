using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace aplikacija.Models
{
    public class Status
    {
        public int StatusID { get; set; }

        public String Naziv{ get; set; }

        public ICollection<Narocilo> Narocila { get; set; }
    
    }
}