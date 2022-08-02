using RWA_Aplikacija.AdventureWorksOBP;
using RWA_Aplikacija.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_Aplikacija.Controllers
{
    public class PotkategorijaController : Controller
    {
        AdventureWorksOBPEntities _context;
        //object relation mapper - objekte iz baze pretvara dostupne u koristenje

        //spajanje na bazu => inicijalizacija
        public PotkategorijaController()
        {
            _context = new AdventureWorksOBPEntities();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Potkategorija
        public ActionResult Index()
        {
            IList<Potkategorija> potkategorija = _context.Potkategorije.ToList();


            return View(potkategorija);
        }

        public ActionResult New()
        {
            PotkategorijaPodaciViewModel potkategorija = new PotkategorijaPodaciViewModel()
            {
                Kategorije = _context.Kategorije.ToList(),
                Potkategorija = new Potkategorija()
            };


            return View(potkategorija);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            PotkategorijaPodaciViewModel potkategorija = new PotkategorijaPodaciViewModel()
            {
                Kategorije = _context.Kategorije.ToList(),
                Potkategorija = _context.Potkategorije.SingleOrDefault(p => p.IDPotkategorija == id)
            };


            return View("New", potkategorija);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Potkategorija potkategorija)
        {

            //ako validacija nije ispravna
            if (!ModelState.IsValid)
            {
                PotkategorijaPodaciViewModel p = new PotkategorijaPodaciViewModel()
                {
                    Kategorije = _context.Kategorije.ToList(),
                    Potkategorija = potkategorija
                };
                //ispisi proizvod kaj ima i poruke
                return View("New", p);
            }
            //ako je novi ima ID = 0 i u bazi dobiva svoj pravi
            if (potkategorija.IDPotkategorija == 0)
            {
                _context.Potkategorije.Add(potkategorija);
            }
            //postoji vec u bazi
            else
            {
                var PotkategorijaUBazi = _context.Potkategorije.SingleOrDefault(p => p.IDPotkategorija == potkategorija.IDPotkategorija);
                PotkategorijaUBazi.Naziv = potkategorija.Naziv;
                PotkategorijaUBazi.KategorijaID = potkategorija.KategorijaID;
            }

            _context.SaveChanges();



            return RedirectToAction("Index", "Potkategorija");
        }
    }
}