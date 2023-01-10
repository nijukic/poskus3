using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aplikacija.Models
{
    public class VrstaPlacila
    {
        public int VrstaPlacilaID { get; set; }

        public string Naziv { get; set; }

        public ICollection<Racun> Racuni { get; set; }

    }
}