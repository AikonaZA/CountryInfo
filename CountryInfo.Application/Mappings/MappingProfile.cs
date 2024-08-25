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
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Common))
                .ForMember(dest => dest.Currencies, opt => opt.MapFrom(src => src.Currencies.Values.Select(c => $"{c.Name} ({c.Symbol})").ToList()))
                .ForMember(dest => dest.Capitals, opt => opt.MapFrom(src => src.Capital))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region))
                .ForMember(dest => dest.Subregion, opt => opt.MapFrom(src => src.Subregion))
                .ForMember(dest => dest.Languages, opt => opt.MapFrom(src => src.Languages.Values.ToList()))
                .ForMember(dest => dest.Borders, opt => opt.MapFrom(src => src.Borders))
                .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.Population));
        }
    }
}