using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models.Admin
{
    public class Hour
    {
        public int HourId { get; set; }
        [Display(Name = "Dzień tygodnia")]
        public string Day { get; set; }
        [Display(Name = "Godziny otwarcia")]
        public string Hours { get; set; }
    }
}