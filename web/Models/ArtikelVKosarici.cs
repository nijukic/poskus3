using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aplikacija.Models
{
    public class ArtikelVKosarici
    {

        [Key]
        public int ArtikelID { get; set; }

        [Key]
        public int OsebaID { get; set; }
        public int kolicina { get; set; }


        //[ForeignKey("ArtikelID")]
        public Artikel Artikel { get; set; }

        //[ForeignKey("NarociloID")]
        public Oseba Oseba { get; set; }
    }
}