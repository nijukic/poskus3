using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel; 

namespace aplikacija.Models
{
    public class Oseba
    {
        public int OsebaID { get; set; }

        //[Display(Name = "Last Name")]
        [Required]
        [StringLength(50, MinimumLength = 1)]
        //[Column("FirstName")]
        public string Ime { get; set; }

        [StringLength(50)]
        public string Priimek { get; set; }
        public string Telefon { get; set; }

        [Column(TypeName = "money")]
        [DefaultValue(0)]
        public decimal znesekKosarice { get; set; }

        public ApplicationUser Owner { get; set; }

        [Display(Name = "Full Name")]
        public string PolnoIme
        {
            get
            {
                return Ime + ", " + Priimek;
            }
        }

        //oseba ima lahko več ocen

        public ICollection<ArtikelVKosarici> ArtikliVKosarici { get; set; }
        public ICollection<Ocena> Ocene { get; set; }

        public ICollection<Narocilo> Narocila { get; set; }

        public ICollection<Naslov> Naslovi { get; set; }
    }
}