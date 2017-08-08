using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models.Admin
{
    public class Offer
    {
        [Display(Name = "Lp.")]
        public int OfferId { get; set; }
        [Display(Name = "Nazwa usługi")]
        public string ServiceName { get; set; }
        [Display(Name = "Cena usługi")]
        public decimal Price { get; set; }
    }
}