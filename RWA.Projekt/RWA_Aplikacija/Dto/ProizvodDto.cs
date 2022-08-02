using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWA_Aplikacija.Dto
{
    public class ProizvodDto
    { 

        public int IDProizvod { get; set; }
        [Required(ErrorMessage = "Naziv je obavezan")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "BrojProizvoda je obavezan")]
        //[Range(typeof(int), "0", "2147483647")]
        public string BrojProizvoda { get; set; }
        [Required(ErrorMessage = "Boja je obavezan")]
        public string Boja { get; set; }
        [Required(ErrorMessage = "MinimalnaKolicinaNaSkladistu je obavezan")]
        //[Range(typeof(int), "0", "2147483647")]
        public short MinimalnaKolicinaNaSkladistu { get; set; }
        [Required(ErrorMessage = "CijenaBezPDV je obavezan")]
        //[Range(typeof(int), "0", "2147483647")]
        public decimal CijenaBezPDV { get; set; }
        [Required(ErrorMessage = "Potkategorija je obavezna")]
        [Display(Name = "Potkategorija")]
        public Nullable<int> PotkategorijaID { get; set; }
    }
}