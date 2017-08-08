using Garage2.Models.Admin;
using Garage2.Models.Sklep;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage2.DAL
{
    public class GarageContext:DbContext
    {
        public GarageContext():base("GarageConnectionString")
        { }

        public System.Data.Entity.DbSet<Garage2.Models.Admin.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<Garage2.Models.Admin.Hour> Hours { get; set; }

        public System.Data.Entity.DbSet<Garage2.Models.Admin.Offer> Offers { get; set; }

        public System.Data.Entity.DbSet<Garage2.Models.Admin.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Garage2.Models.CompanyProfile> CompanyProfiles { get; set; }
        public System.Data.Entity.DbSet<Garage2.Models.Sklep.Rodzaj> Rodzaje { get; set; }
        public System.Data.Entity.DbSet<Garage2.Models.Sklep.Towar> Towary { get; set; }
        public System.Data.Entity.DbSet<Garage2.Models.Sklep.ElementKoszyka> ElementyKoszyka { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<PozycjaZamowienia> PozycjeZamowienia { get; set; }
    }

}
