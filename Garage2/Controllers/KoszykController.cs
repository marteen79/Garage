using Garage2.DAL;
using Garage2.Models.Sklep;
using Garage2.Models.Sklep.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage2.Controllers
{
    public class KoszykController : Controller
    {
        private GarageContext db = new GarageContext();
        public ActionResult Index()
        {
            KoszykB koszyk = new KoszykB(this.HttpContext);
            var daneDoKoszyka = new DaneDoKoszyka
            {
                ElementyKoszyka = koszyk.GetElementyKoszyka(),
                Razem = koszyk.GetRazem()
            };
            return View(daneDoKoszyka);
        }
        public ActionResult DodajDoKoszyka(int id)
        {
            var nowyElementKoszyka =
                (
                    from towar in db.Towary
                    where towar.IdTowaru == id
                    select towar
                ).First();
            KoszykB koszyk = new KoszykB(this.HttpContext);
            koszyk.DodajDoKoszyka(nowyElementKoszyka);
            return RedirectToAction("Index");
        }
        [ChildActionOnly]
        public ActionResult LiczbaTowarowWKoszyku()
        {
            KoszykB koszyk = new KoszykB(this.HttpContext);
            ViewData["LiczbaTowarowWKoszyku"] = koszyk.GetIlosc();
            ViewData["WartscTowarowWKoszyku"] = koszyk.GetRazem();
            return PartialView();
        }
        public ActionResult UsunZKoszyka(int id)
        {
            KoszykB koszyk = new KoszykB(this.HttpContext);
            koszyk.UsunZKoszyka(id);
            return RedirectToAction("Index");
        }
        public ActionResult UsunWszystkieZKoszyka()
        {
            KoszykB koszyk = new KoszykB(this.HttpContext);
            koszyk.UsunWszystkieZKoszyka();
            return RedirectToAction("Index");
        }
    }
}