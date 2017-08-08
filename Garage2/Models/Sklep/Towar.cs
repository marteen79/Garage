using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models.Sklep
{
    public class Towar
    {
        [Key]
        [Display(Name ="Id")]
        public int IdTowaru { get; set; }
        [Required(ErrorMessage = "Nazwa towaru jest wymagana")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Kod towaru jest wymagany")]
        public string Kod { get; set; }
        [Required(ErrorMessage = "Cena towaru jest wymagana")]
        public decimal Cena { get; set; }
        [Required(ErrorMessage = "Zdjęcie towaru jest wymagane")]
        [Display(Name = "Foto")]
        public string FotoUrl { get; set; }
        public string Opis { get; set; }
        [Display(Name ="Promocja")]
        public bool Promocja { get; set; }

        //Każdy towar ma swój jeden rodzaj 
        //to jest realizacja relacji 1 do wielu
        [Display(Name = "Rodzaj")]
        [Required(ErrorMessage = "Rodzaj towaru jest wymagany")]
        public int IdRodzaju { get; set; }
        public virtual Rodzaj Rodzaj { get; set; }
    }
}