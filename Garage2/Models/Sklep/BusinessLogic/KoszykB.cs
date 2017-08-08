using Garage2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models.Sklep.BusinessLogic
{
    public class KoszykB
    {
        private GarageContext db = new GarageContext();
        private string IdSesjiKoszyka;
        public KoszykB(HttpContextBase context)
        {
            this.IdSesjiKoszyka = GetIdSesjiKoszyka(context);
        }
        private string GetIdSesjiKoszyka(HttpContextBase context)
        {
            //Jeżeli w Sesji IdSesjiKoszyka jest null-em
            if (context.Session[IdSesjiKoszyka] == null)
            {
                //Jeżeli context.User.Identity.Name nie jest puste i nie posiada białych zanków
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[IdSesjiKoszyka] = context.User.Identity.Name;
                }
                else
                {
                    // W przeciwnym wypadku wygeneruj przy pomocy random Guid IdSesjiKoszyka
                    Guid tempIdSesjiKoszyka = Guid.NewGuid();
                    // Wyślij wygenerowane IdSesjiKoszyka jako cookie
                    context.Session[IdSesjiKoszyka] = tempIdSesjiKoszyka.ToString();
                }
            }
            return context.Session[IdSesjiKoszyka].ToString();
        }
        public List<ElementKoszyka> GetElementyKoszyka()
        {
            List<ElementKoszyka> listaElementowKoszyka =
                (
                    from element in db.ElementyKoszyka
                    where element.IdSesjiKoszyka == this.IdSesjiKoszyka
                    select element
                 ).ToList();

            return listaElementowKoszyka;
        }
        public decimal GetRazem()
        {
            decimal? razem =
                (
                from element in db.ElementyKoszyka
                where element.IdSesjiKoszyka == this.IdSesjiKoszyka
                select (decimal?)element.Ilosc * element.Towar.Cena
                ).Sum();
            return razem ?? decimal.Zero;
        }
        public void DodajDoKoszyka(Towar towar)
        {
            // Najpierw sprawdzamy czy dany towar już istnieje w koszyku danego klienta
            var elementKoszyka =
                (
                    from element in db.ElementyKoszyka
                    where element.IdSesjiKoszyka == this.IdSesjiKoszyka && element.IdTowaru == towar.IdTowaru
                    select element
                ).FirstOrDefault();
            //jeżeli brak tego towaru w koszyku
            if (elementKoszyka == null)
            {
                // Wtedy tworzymy nowy element w koszyku
                elementKoszyka = new ElementKoszyka()
                {
                    IdSesjiKoszyka = this.IdSesjiKoszyka,
                    IdTowaru = towar.IdTowaru,
                    Ilosc = 1,
                    DataUtworzenia = DateTime.Now
                };
                //i dodajemy do kolekcji lokalne
                db.ElementyKoszyka.Add(elementKoszyka);
            }
            else
            {
                // Jeżeli dany towar istnieje już w koszyku to liczbe sztuk zwiekszamy o 1
                elementKoszyka.Ilosc++;
            }
            // Zapisujemy zmiany do bazy
            db.SaveChanges();
        }
        public decimal GetIlosc()
        {
            //obliczamy ilosc towarow 
            decimal? ilosc =
                (
                    from element in db.ElementyKoszyka
                    where element.IdSesjiKoszyka == IdSesjiKoszyka
                    select (decimal?)element.Ilosc
                ).Sum();
            // zwracamy ilosc lub zero gdy brak
            return ilosc ?? 0;
        }
        public void UsunZKoszyka(int id) //w zmiennej id jest id kasowanego towaru z koszyka
        {
            // odnajdujemy ten towar w koszyku (po id i idSesji)
            //tak:
            //var elementKoszyka=
            //    db.ElementyKoszyka.Single(element=>element.IdSesjiKoszyka==IdSesjiKoszyka && element.IdTowaru==id);
            //lub tak:
            var elementKoszyka =
                (
                    from element in db.ElementyKoszyka
                    where element.IdSesjiKoszyka == IdSesjiKoszyka && element.IdTowaru == id
                    select element
                ).FirstOrDefault();
            if (elementKoszyka != null)
            {
                //kasowanie z lokalnej kolekcji
                db.ElementyKoszyka.Remove(elementKoszyka);
                //zapisywanie zmian
                db.SaveChanges();
            }
        }
        public void UsunWszystkieZKoszyka() //w zmiennej id jest id kasowanego towaru z koszyka
        {
            // odnajdujemy wszystkie elementy koszyka dla danej sesji
            var elementyKoszyka =
                (
                    from element in db.ElementyKoszyka
                    where element.IdSesjiKoszyka == IdSesjiKoszyka
                    select element
                );
            if (elementyKoszyka != null)
            {
                foreach (var element in elementyKoszyka)
                {
                    //kasowanie z lokalnej kolekcji
                    db.ElementyKoszyka.Remove(element);
                    //zapisywanie zmian
                }
                db.SaveChanges();
            }
        }
        public int UtworzZamowienie(Zamowienie zamowienie)
        {
            decimal wartoscZamowienia = 0;
            var elementyKoszyka = GetElementyKoszyka();
            db.Zamowienia.Add(zamowienie);
            //db.SaveChanges();
            foreach (var element in elementyKoszyka)
            {
                var pozycjaZamowienia = new PozycjaZamowienia
                {
                    IdTowaru = element.IdTowaru,
                    IdZamowienia = zamowienie.IdZamowienia,
                    Cena = element.Towar.Cena,
                    Ilosc = element.Ilosc
                };
                wartoscZamowienia += (element.Ilosc * element.Towar.Cena);
                db.PozycjeZamowienia.Add(pozycjaZamowienia);
            }

            zamowienie.Razem = wartoscZamowienia;
            db.SaveChanges();
            UsunWszystkieZKoszyka();
            return zamowienie.IdZamowienia;
        }
    }
}
