using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aplikacija.Models
{
    public class Postavka
    {


        [Key]
        public int ArtikelID { get; set; }

        [Key]
        public int NarociloID { get; set; }
        public int kolicina { get; set; }


        //[ForeignKey("ArtikelID")]
        public Artikel Artikel { get; set; }

        //[ForeignKey("NarociloID")]
        public Narocilo Narocilo { get; set; }
    }
}