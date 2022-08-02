using RWA_Aplikacija.AdventureWorksOBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Aplikacija.ViewModels
{
    public class ProizvodPodaciViewModel
    {
        public IEnumerable<Potkategorija> Potkategorije { get; set; }
        public IEnumerable<Proizvod> Proizvodi { get; set; }
        public Proizvod Proizvod { get; set; }
        public Potkategorija Potkategorija { get; set; }
    }
}