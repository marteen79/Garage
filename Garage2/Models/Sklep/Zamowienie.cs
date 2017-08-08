using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models.Sklep
{
    public class Zamowienie
    {
        [Key]
        public int IdZamowienia { get; set; }
        public System.DateTime DataZamowienia { get; set; }
        public string Login { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        [Display(Name = "Imię")]
        [StringLength(160)]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko")]
        [StringLength(160)]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Ulica jest wymagana")]
        [StringLength(70)]
        public string Ulica { get; set; }

        [Required(ErrorMessage = "Miasto jest wymagane")]
        [StringLength(70)]
        public string Miasto { get; set; }

        [Required(ErrorMessage = "Wojewodztwo jest wymagane")]
        [StringLength(70)]
        [Display(Name = "Województwo")]
        public string Wojewodztwo { get; set; }

        [Required(ErrorMessage = "Kod Pocztowy jest wymagany")]
        [Display(Name = "Kod Pocztowy")]
        [StringLength(10)]
        public string KodPocztowy { get; set; }

        [Required(ErrorMessage = "Państwo jest wymagane")]
        [StringLength(70)]
        [Display(Name = "Państwo")]
        public string Panstwo { get; set; }

        [Required(ErrorMessage = "Numer telefonu")]
        [StringLength(24)]
        [Display(Name = "Numer telefonu")]
        public string NumerTelefonu { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        [Display(Name = "Adres email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email nie jest prawidłowy.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public decimal Razem { get; set; }

        public virtual ICollection<PozycjaZamowienia> PozycjaZamowienia { get; set; }
    }
}