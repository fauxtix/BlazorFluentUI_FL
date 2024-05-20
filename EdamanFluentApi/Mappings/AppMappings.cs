using AutoMapper;
using EdamanFluentApi.Models.Youtube.Dtos;
using EdamanFluentApi.Models.Youtube.Entities;

namespace EdamanFluentApi.Mappings;

public class AppMappings : Profile
{
    public AppMappings()
    {
        CreateMap<Categoria, CategoryVM>().ReverseMap();
        CreateMap<Formato_Media, FormatoMediaVM>().ReverseMap();
        CreateMap<Media, MediaVM>().ReverseMap();
    }
}