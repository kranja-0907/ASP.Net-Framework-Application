using AutoMapper;
using RWA_Aplikacija.AdventureWorksOBP;
using RWA_Aplikacija.App_Start;
using RWA_Aplikacija.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RWA_Aplikacija.Controllers.API
{
    public class KupciController : ApiController
    {
        private AdventureWorksOBPEntities _context;

        public KupciController()
        {
            _context = new AdventureWorksOBPEntities();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET:/api/Kupci
        //Mapper.Map bez () jer ju ne zelimo zvat mi zelimo samo referencirat
        public IEnumerable<KupacDto> GetKupci()
        {
            return _context.Kupci.ToList().Select(Mapper.Map<Kupac,KupacDto> );
        }

        // GET:/api/Kupci/1
       
        public IHttpActionResult GetKupac(int id)
        {
            var kupac = _context.Kupci.SingleOrDefault(k => k.IDKupac == id);

            if (kupac == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Kupac, KupacDto>(kupac));
        }

        //POST:/api/Kupci
        [HttpPost] //ZA KREIRANJE JE POST
        public IHttpActionResult NewKupac(KupacDto kupacDto)
        {
            if (!ModelState.IsValid)
            {
                // zbog IHttpactionResult
                return BadRequest();
            }

            var kupac = Mapper.Map<KupacDto, Kupac>(kupacDto);
            _context.Kupci.Add(kupac);
            _context.SaveChanges();
            
            //novi kupac dobiva ID pa ga dajemo Dto-u da ga dobije klijent nazad
            kupacDto.IDKupac = kupac.IDKupac;

            //vracamo unified resource indentifier /api/Kupci/10  kupacDto je kreirani objekt a ovo prije je url api/kupac/ + njegov id
            return Created(new Uri(Request.RequestUri + "/" + kupac.IDKupac), kupacDto);
        }

        //POST:/api/Kupci/1
        [HttpPut]
        public void UpdateKupac(int id, KupacDto kupacDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var KupacUBazi = _context.Kupci.SingleOrDefault(k => k.IDKupac == id);

            if (KupacUBazi == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<KupacDto, Kupac>(kupacDto,KupacUBazi);

            _context.SaveChanges();
        }

        //DELETE:/api/Kupci/1
        [HttpDelete]
        public void DeleteKupac(int id)
        {

            var KupacUBazi = _context.Kupci.SingleOrDefault(k => k.IDKupac == id);

            if (KupacUBazi == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var Racuni = _context.Racuni.Where(k=> k.KupacID == id).ToList();

            foreach (var racun in Racuni)
            {
                _context.Stavke.RemoveRange(_context.Stavke.Where(s => s.RacunID == racun.IDRacun));
            }
            _context.SaveChanges();
            _context.Racuni.RemoveRange(_context.Racuni.Where(r => r.KupacID == id));
            _context.SaveChanges();
            _context.Kupci.Remove(KupacUBazi);
            _context.SaveChanges();
        }





    }
}
