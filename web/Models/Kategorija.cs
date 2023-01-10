using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aplikacija.Models
{
    public class Kategorija
    {
        public int KategorijaID { get; set; }

        [Required]
        [StringLength(50, MinimumLength=1)]
        public string Naziv { get; set; }

        public ICollection<Artikel> Artikli { get; set; }
    }
}