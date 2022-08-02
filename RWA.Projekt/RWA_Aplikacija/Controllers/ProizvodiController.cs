using RWA_Aplikacija.AdventureWorksOBP;
using RWA_Aplikacija.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_Aplikacija.Controllers
{
    public class ProizvodiController : Controller
    {
        AdventureWorksOBPEntities _context;
        //object relation mapper - objekte iz baze pretvara dostupne u koristenje

        //spajanje na bazu => inicijalizacija
        public ProizvodiController()
        {
            _context = new AdventureWorksOBPEntities();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Proizvodi
        public ActionResult Index()
        {
            //za pojedinacan po IDU
            //Proizvod proizvod = _context.Proizvodi.SingleOrDefault(p => p.IDProizvod == 10);
            //za raspon po necem
            //IList<Proizvod> proizvodi1 = _context.Proizvodi.Where(p => p.Naziv == "Bikes").ToList();
            //sto god u listu na kraju tolist
            IList<Proizvod> proizvod = _context.Proizvodi.ToList();

            return View(proizvod);
        }

        public ActionResult New()
        {
            ProizvodPodaciViewModel proizvod = new ProizvodPodaciViewModel()
            {
                Potkategorije = _context.Potkategorije.ToList(),
                Proizvod = new Proizvod()
            };


            return View(proizvod);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            ProizvodPodaciViewModel proizvod = new ProizvodPodaciViewModel()
            {
                Potkategorije = _context.Potkategorije.ToList(),
                Proizvod = _context.Proizvodi.SingleOrDefault(m => m.IDProizvod == id)
            };


            return View("New",proizvod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Proizvod proizvod)
        {
             
            //ako validacija nije ispravna
            if (!ModelState.IsValid)
            {
                ProizvodPodaciViewModel p = new ProizvodPodaciViewModel()
                {
                    Potkategorije = _context.Potkategorije.ToList(),
                    Proizvod = proizvod
                };
                //ispisi proizvod kaj ima i poruke
                return View("New", p);
            }
            //ako je novi ima ID = 0 i u bazi dobiva svoj pravi
            if (proizvod.IDProizvod == 0)
            {
                _context.Proizvodi.Add(proizvod);                
            }
            //postoji vec u bazi
            else
            {
                var ProizvodUBazi = _context.Proizvodi.SingleOrDefault(p => p.IDProizvod == proizvod.IDProizvod);
                ProizvodUBazi.Naziv = proizvod.Naziv;
                ProizvodUBazi.Boja = proizvod.Boja;
                ProizvodUBazi.BrojProizvoda = proizvod.BrojProizvoda;
                ProizvodUBazi.CijenaBezPDV = proizvod.CijenaBezPDV;
                ProizvodUBazi.MinimalnaKolicinaNaSkladistu = proizvod.MinimalnaKolicinaNaSkladistu;
                ProizvodUBazi.PotkategorijaID = proizvod.PotkategorijaID;
            }

            _context.SaveChanges();

            

            return RedirectToAction("Index","Proizvodi");
        }



    }
}