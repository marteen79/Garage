using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models.Admin
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public decimal Cena { get; set; }
        public string Jakosc { get; set; }
    }
}