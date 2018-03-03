using ASPNETCOREDEMO.Controllers.Resources;
using ASPNETCOREDEMO.Models;
using AutoMapper;

namespace ASPNETCOREDEMO.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
        }
    }
}