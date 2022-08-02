using RWA_Aplikacija.AdventureWorksOBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Aplikacija.Models.ViewModel
{
    //za view kad mi treba neki konkretni podaci
    public class ProductAndSubCategory
    {
        public IList<Proizvod> proizvod { get; set; }

        public Potkategorija potkategorija { get; set; }
    }
}