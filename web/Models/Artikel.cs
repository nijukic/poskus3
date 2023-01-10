using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aplikacija.Models
{
    public class Artikel
    {
        public int ArtikelID { get; set; }

        public int KategorijaID { get; set; }

        public int ProizvajalecID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Naziv { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Cena { get; set; }
        public string Opis { get; set; }

        public int Zaloga { get; set; }

        public ICollection<Ocena> Ocene { get; set; }

        public ICollection<Postavka> Postavke { get; set; }

        //[ForeignKey("KategorijaID")]
        public Kategorija Kategorija { get; set; }

        //[ForeignKey("ProizvajalecID")]
        public Proizvajalec Proizvajalec { get; set; }
    }
}