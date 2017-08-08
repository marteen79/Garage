using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models.Sklep
{
    public class ElementKoszyka
    {
        [Key]
        public int IdElementuKoszyka { get; set; }
        public string IdSesjiKoszyka { get; set; }

        public int IdTowaru { get; set; }
        public virtual Towar Towar { get; set; }

        public decimal Ilosc { get; set; }
        public DateTime DataUtworzenia { get; set; }
    }
}
