using RWA_Aplikacija.AdventureWorksOBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_Aplikacija.Controllers
{
    public class KategorijaController : Controller
    {
        AdventureWorksOBPEntities _context;
        //object relation mapper - objekte iz baze pretvara dostupne u koristenje

        //spajanje na bazu => inicijalizacija
        public KategorijaController()
        {
            _context = new AdventureWorksOBPEntities();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Kategorija
        public ActionResult Index()
        {
            IList<Kategorija> kategorija = _context.Kategorije.ToList();


            return View(kategorija);
        }

        public ActionResult New()
        {
            Kategorija kategorija = new Kategorija();


            return View(kategorija);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            Kategorija kategorija = _context.Kategorije.SingleOrDefault(k => k.IDKategorija == id);


            return View("New", kategorija);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Kategorija kategorija)
        {

            //ako validacija nije ispravna
            if (!ModelState.IsValid)
            {
                Kategorija k = new Kategorija()
                {
                    Naziv = kategorija.Naziv
                };
                //ispisi proizvod kaj ima i poruke
                return View("New", k);
            }
            //ako je novi ima ID = 0 i u bazi dobiva svoj pravi
            if (kategorija.IDKategorija == 0)
            {
                _context.Kategorije.Add(kategorija);
            }
            //postoji vec u bazi
            else
            {
                var KategorijaUBazi = _context.Kategorije.SingleOrDefault(p => p.IDKategorija == kategorija.IDKategorija);
                KategorijaUBazi.Naziv = kategorija.Naziv;
                
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Kategorija");
        }
    }
}