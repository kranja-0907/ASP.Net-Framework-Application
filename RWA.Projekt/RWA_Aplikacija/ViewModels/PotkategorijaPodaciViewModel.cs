using RWA_Aplikacija.AdventureWorksOBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Aplikacija.ViewModels
{
    public class PotkategorijaPodaciViewModel
    {
        public IEnumerable<Kategorija> Kategorije { get; set; }
        public Kategorija Kategorija { get; set; }
        public Potkategorija Potkategorija { get; set; }
    }
}