using Garage2.DAL;
using Garage2.Models.Sklep;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Garage2.Controllers
{
    public class SklepController : Controller
    {
        private GarageContext db = new GarageContext();
        //Ta funkcja dostarcza danych do głównego widoku sklepu
        //który będzie wyświetlał towary promocyjne
        public ActionResult Promocje()
        {
            var towaryPromocyjne =
                (
                    from towar in db.Towary
                    where towar.Promocja == true
                    orderby towar.Cena
                    select towar
                ).ToList();
            return View(towaryPromocyjne);
        }
        // GET: Sklep
        //Funkcja ta dostarczy dane do widoku wyświetlającego wszystkie towary danego rodzaju 
        //przy pierwszym uruchomieniu automatycznie pojawią się towary pierwszego rodzaju natomiast
        // kolejne przeładowanie będzie wyświetlało towary tego rodzaju, które ktoś kliknie
        //jako paramter ta funkcja dostaje IdRodzaju, którego towary ma wyświetlić
        public ActionResult Index(int? id)
        {
            if (id == null)
                id = db.Rodzaje.First().IdRodzaju;//Jeżeli wchodzimy do sklepu to domyslnie wyświetlą się towary pierwszego rodzaju
            var rodzaj = db.Rodzaje.Find(id);
            //var rodzaj = db.Rodzaje.Single(r=>r.IdRodzaju==id);
            return View(rodzaj);
        }
        [ChildActionOnly]//Oznacza to, że ta funkcja będzie dostarczała danych do widoku partialnego, który będzie częścią innego widoku
        public ActionResult RodzajeMenu()
        {
            //Ta funkcja dostarcza danych do widoku RodzajeMenu, który wyświetla wszystkie rodzaje towarów
            var rodzaje = db.Rodzaje.ToList();
            return PartialView(rodzaje);
        }
        public ActionResult Szczegoly(int id)// w zmiennej id siedzi nr. towaru którego szczegóły mamy wyświetlic
        {
            //Z bazy danych pobieramy towar o danym id
            var wybranyTowar = db.Towary.Find(id);
            return View(wybranyTowar);
        }
        // ******************************* dodane metody **************************************

        public ActionResult AdminIndex()
        {
            return View(db.Towary.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Towar towar = db.Towary.Find(id);
            if (towar == null)
            {
                return HttpNotFound();
            }
            return View(towar);
        }

        // GET: Hours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTowaru,Nazwa,Kod,Cena,FotoUrl,Opis,Promocja,IdRodzaju")] Towar towar)
        {
            if (ModelState.IsValid)
            {
                db.Towary.Add(towar);
                db.SaveChanges();
                return RedirectToAction("AdminIndex");
            }

            return View(towar);
        }

        // GET: Hours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Towar towar = db.Towary.Find(id);
            if (towar == null)
            {
                return HttpNotFound();
            }
            return View(towar);
        }

        // POST: Hours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTowaru,Nazwa,Kod,Cena,FotoUrl,Opis,Promocja,IdRodzaju")] Towar towar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(towar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AdminIndex");
            }
            return View(towar);
        }

        // GET: Hours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Towar towar = db.Towary.Find(id);
            if (towar == null)
            {
                return HttpNotFound();
            }
            return View(towar);
        }

        // POST: Hours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Towar towar = db.Towary.Find(id);
            db.Towary.Remove(towar);
            db.SaveChanges();
            return RedirectToAction("AdminIndex");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}