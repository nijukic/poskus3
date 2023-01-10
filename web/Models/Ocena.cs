using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aplikacija.Models
{
    public enum Vrednost
    {
        A, B, C, D, F
    }

    public class Ocena
    {
        public int OcenaID { get; set; }
        
        public int OsebaID { get; set; }

        public int ArtikelID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Opis { get; set; }


        [Required]
        public Vrednost Vrednost { get; set; }

        public bool potrjenNakup { get; set; }


//[ForeignKey("ArtikelID")]
        public Artikel Artikel { get; set; }


        //[ForeignKey("OsebaID")]
        public Oseba Oseba { get; set; }

        //public ApplicationUser ApplicationUser { get; set; }
    }
}