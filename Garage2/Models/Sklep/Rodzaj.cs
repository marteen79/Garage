using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models.Sklep
{
    public class Rodzaj
    {
        [Key]
        public int IdRodzaju { get; set; }
        [Required(ErrorMessage = "Nazwa kategorii jest wymagana")]
        [MaxLength(20, ErrorMessage = "Nazwa kategorii może zawierać max 20 znaków")]
        public string Nazwa { get; set; }
        public string Opis { get; set; }

        //Mamy wiele towarów danego rodzaju
        //dlatego Rodzaj zawiera w sobie wirtualną kolekcję towarów danego rodzaju
        //to jest realizacja relacji 1 do wielu
        public virtual ICollection<Towar> Towar { get; set; }
    }
}