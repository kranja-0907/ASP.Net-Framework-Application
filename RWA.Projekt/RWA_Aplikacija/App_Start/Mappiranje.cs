using AutoMapper;
using RWA_Aplikacija.AdventureWorksOBP;
using RWA_Aplikacija.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Aplikacija.App_Start
{
    public class Mappiranje : Profile
    {
        public Mappiranje()
        {
            Mapper.CreateMap<Kupac, KupacDto>();
            Mapper.CreateMap<KupacDto, Kupac>();
            
            Mapper.CreateMap<Proizvod, ProizvodDto>();
            Mapper.CreateMap<ProizvodDto, Proizvod>();  
        }
    }
}