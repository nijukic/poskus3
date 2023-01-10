using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aplikacija.Models
{
    public class Proizvajalec
    {
        public int ProizvajalecID { get; set; }

        [Required]
        [StringLength(50, MinimumLength=1)]
        public string Naziv { get; set; }

        [Required]
        [StringLength(500, MinimumLength=1)]
        public string Opis { get; set; }

        public ICollection<Artikel> Artikli { get; set; }
    
    }
}