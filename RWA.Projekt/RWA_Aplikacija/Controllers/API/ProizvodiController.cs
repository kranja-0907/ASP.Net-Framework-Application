using AutoMapper;
using RWA_Aplikacija.AdventureWorksOBP;
using RWA_Aplikacija.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RWA_Aplikacija.Controllers.API
{
    public class ProizvodiController : ApiController
    {
        private AdventureWorksOBPEntities _context;

        public ProizvodiController()
        {
            _context = new AdventureWorksOBPEntities();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET:/api/Potkategorije
        [HttpGet] //REQUESTI
        public IEnumerable<ProizvodDto> GetProizvodi()
        {
            return _context.Proizvodi.ToList().Select(Mapper.Map<Proizvod, ProizvodDto>);
        }

        // GET:/api/Potkategorije/1
        [HttpGet]
        public IHttpActionResult GetProizvod(int id)
        {
            var proizvod = _context.Proizvodi.SingleOrDefault(k => k.IDProizvod == id);

            if (proizvod == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Proizvod, ProizvodDto>(proizvod));
        }

        //POST:/api/Potkategorije
        [HttpPost] //ZA KREIRANJE JE POST
        public IHttpActionResult NewProizvod(ProizvodDto proizvodDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var proizvod = Mapper.Map<ProizvodDto, Proizvod>(proizvodDto);
            _context.Proizvodi.Add(proizvod);
            _context.SaveChanges();

            proizvodDto.IDProizvod = proizvod.IDProizvod;

            return Created(new Uri(Request.RequestUri + "/" + proizvod.IDProizvod), proizvodDto);
        }

        //POST:/api/Potkategorije/1
        [HttpPut]
        public void UpdateProizvod(int id, ProizvodDto proizvodDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var ProizvodUBazi = _context.Proizvodi.SingleOrDefault(k => k.IDProizvod == id);

            if (ProizvodUBazi == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<ProizvodDto, Proizvod>(proizvodDto, ProizvodUBazi);

            _context.SaveChanges();
        }

        //DELETE:/api/Potkategorije/1
        [HttpDelete]
        public void DeleteProizvod(int id)
        {

            var ProizvodUBazi = _context.Proizvodi.SingleOrDefault(k => k.IDProizvod == id);

            if (ProizvodUBazi == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var listaStavki = _context.Stavke.Where(s => s.ProizvodID == id).ToList();
            foreach (var racun in listaStavki)
            {
                _context.Stavke.RemoveRange(_context.Stavke.Where(s => s.ProizvodID == id));
            }
            _context.SaveChanges();
            _context.Proizvodi.Remove(ProizvodUBazi);
            _context.SaveChanges();
        }
    }
}
