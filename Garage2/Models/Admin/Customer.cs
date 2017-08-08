using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models.Admin
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Discount { get; set; }
    }
}