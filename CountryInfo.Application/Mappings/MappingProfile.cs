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

            //// Add mappings for RegionDto and SubregionDto if needed
            //CreateMap<Region, RegionDto>()
            //    .ForMember(dest => dest.Countries, opt => opt.Ignore()) // handle countries separately
            //    .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.Countries.Sum(c => c.Population)));

            //CreateMap<Subregion, SubregionDto>()
            //    .ForMember(dest => dest.Countries, opt => opt.Ignore()) // handle countries separately
            //    .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.Countries.Sum(c => c.Population)));
        }
    }
}