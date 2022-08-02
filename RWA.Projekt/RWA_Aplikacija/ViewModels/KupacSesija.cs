using RWA_Aplikacija.AdventureWorksOBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Aplikacija.ViewModels
{
    public class KupacSesija
    {
        public IEnumerable<Racun> Racuni { get; set; }
        public Kupac Kupac { get; set; }

        
        //ReceiptInfo
        public int IDRacuna { get; set; }
        public IEnumerable<Stavka> Stavke { get; set; }
        public IEnumerable<Proizvod> Proizvodi { get; set; }
        public IEnumerable<Potkategorija> Potkategorije { get; set; }
        public IEnumerable<Kategorija> Kategorije { get; set; }
        public IEnumerable<KreditnaKartica> KreditneKartice { get; set; }
        public IEnumerable<Komercijalist> Komercijalisti { get; set; }
    }
}