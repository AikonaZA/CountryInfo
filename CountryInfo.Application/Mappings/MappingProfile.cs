using AutoMapper;
using CountryInfo.Core.Entities;
using CountryInfo.Shared.DTOs;

namespace CountryInfo.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name.common))
                .ForMember(dest => dest.Currencies, opt => opt.MapFrom(src => src.currencies.Values.Select(c => $"{c.name} ({c.symbol})").ToList()))
                .ForMember(dest => dest.Capitals, opt => opt.MapFrom(src => src.capital))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.region))
                .ForMember(dest => dest.Subregion, opt => opt.MapFrom(src => src.subregion))
                .ForMember(dest => dest.Languages, opt => opt.MapFrom(src => src.languages.Values.ToList()))
                .ForMember(dest => dest.Borders, opt => opt.MapFrom(src => src.borders))
                .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.population));
        }
    }
}