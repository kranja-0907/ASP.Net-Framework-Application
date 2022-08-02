using RWA_Aplikacija.AdventureWorksOBP;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWA_Aplikacija.Dto
{
    public class KupacDto
    {
        //bez custom validacija ovdje!!!
        public int IDKupac { get; set; }
        [Required(ErrorMessage = "Ime kupca je obavezno!")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime kupca je obavezno!")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Email kupca je obavezno!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Unesite ispravnu E-mail adresu!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefon kupca je obavezno!")]
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Grad je obavezan")] //erro poruka ako ga nema
        [Display(Name = "Grad")] //naziv stupca
        public Nullable<int> GradID { get; set; }

    }
}