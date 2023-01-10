using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aplikacija.Models
{
    public class TipPrevzema
    {
        public int TipPrevzemaID { get; set; }

        public string Naziv { get; set; }

        public ICollection<Narocilo> Narocila { get; set; }

    }
}