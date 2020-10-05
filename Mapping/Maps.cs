using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Sina_CSC_Project.Data;
using Sina_CSC_Project.Models;

namespace Sina_CSC_Project.Mapping
{
    public class Maps:Profile
    {
        public Maps()
        {
            CreateMap<Country, CountryCreateViewModel>().ReverseMap();
            CreateMap<Country, CountryDetailViewModel>().ReverseMap();
            CreateMap<State, StateCreateViewModel>().ReverseMap();
            CreateMap<State, StateDetailViewModel>().ReverseMap();
            CreateMap<City, CityCreateViewModel>().ReverseMap();
            CreateMap<City, CityDetailViewModel>().ReverseMap();
        }
    }
}
