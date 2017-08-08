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
    public class ZakupController : Controller
    {
        private GarageContext db = new GarageContext();
        public ActionResult Dane()
        {
            KoszykB koszyk = new KoszykB(this.HttpContext);
            ViewData["wartosc"] = koszyk.GetRazem();
            ViewData["ilosc"] = koszyk.GetIlosc();

            return View();
        }
        [HttpPost]
        public ActionResult Dane(FormCollection values)
        {
            var zamowienie = new Zamowienie();
            try
            {
                TryUpdateModel(zamowienie);
                zamowienie.DataZamowienia = DateTime.Now;
                var koszykB = new KoszykB(this.HttpContext);
                int idZamowienia = koszykB.UtworzZamowienie(zamowienie);
                return RedirectToAction("Podsumowanie", new { id = idZamowienia });
            }
            catch
            {
                return View(zamowienie);
            }
        }
        public ActionResult Podsumowanie(int id)
        {
            var noweZamowienie =
                (
                    from zamowienie in db.Zamowienia
                    where zamowienie.IdZamowienia == id
                    select zamowienie
                ).First();

            if (noweZamowienie != null)
            {
                return View(noweZamowienie);
            }
            else
            {
                return View("Error");
            }
        }
    }
}
