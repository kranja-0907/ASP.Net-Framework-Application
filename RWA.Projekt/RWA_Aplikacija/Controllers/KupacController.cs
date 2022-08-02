using RWA_Aplikacija.AdventureWorksOBP;
using RWA_Aplikacija.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_Aplikacija.Controllers
{
    public class KupacController : Controller
    {
        AdventureWorksOBPEntities _context;
        //object relation mapper - objekte iz baze pretvara dostupne u koristenje

        //spajanje na bazu => inicijalizacija
        public KupacController()
        {
            _context = new AdventureWorksOBPEntities();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Kupac
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            KupacSesija kupac = new KupacSesija
            {
                Racuni = _context.Racuni.Where(r => r.KupacID == id).ToList(),
                Kupac = _context.Kupci.SingleOrDefault(k => k.IDKupac == id)
            };
            string idkupac = kupac.Kupac.IDKupac.ToString();

            Session["IDKupac"] = idkupac;

            return View(kupac);
        }

        public ActionResult ReceiptDetails(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            KupacSesija k = new KupacSesija();

            Racun temp = _context.Racuni.SingleOrDefault(r => r.IDRacun == id);
            k.IDRacuna = temp.IDRacun;

            foreach (var racun in _context.Racuni.ToList())
            {
                if (racun.IDRacun == id)
                {
                    k.Stavke = _context.Stavke.Where(s => s.RacunID == id).ToList();
                    k.KreditneKartice = _context.KreditnaKartice.Where(ka => ka.IDKreditnaKartica == racun.KreditnaKarticaID).ToList();
                    k.Komercijalisti = _context.Komercijalisti.Where(ko => ko.IDKomercijalist == racun.KomercijalistID).ToList();
                }
            }
            foreach (var stavka in k.Stavke)
            {
                k.Proizvodi = _context.Proizvodi.Where(p => p.IDProizvod == stavka.ProizvodID).ToList();
            }
            foreach (var proizvod in k.Proizvodi)
            {
                k.Potkategorije = _context.Potkategorije.Where(p => p.IDPotkategorija == proizvod.PotkategorijaID).ToList();
            }
            foreach (var potkategorija in k.Potkategorije)
            {
                k.Kategorije = _context.Kategorije.Where(p => p.IDKategorija == potkategorija.KategorijaID).ToList();
            }

            return View(k);
        }

    }
}