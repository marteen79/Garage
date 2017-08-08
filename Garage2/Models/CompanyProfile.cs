using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class CompanyProfile
    {
        [Display(Name ="Historia firmy")]
        public int CompanyProfileId { get; set; }
        public string ProfileContent { get; set; }
    }
}