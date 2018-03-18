using System.Collections.Generic;
using System.Linq;
using ASPNETCOREDEMO.Controllers.Resources;
using ASPNETCOREDEMO.Models;
using AutoMapper;

namespace ASPNETCOREDEMO.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //domain to resource
            CreateMap<Make, MakeResource>();
            CreateMap<Model, KeyValuePairResource>();
            CreateMap<Contact, ContactResource>();
            CreateMap<Vehicle, SaveVehicleResource>();
            CreateMap<Vehicle, VehicleResource>()
            .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => v.Contact))
            .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => new KeyValuePairResource {Id = vf.Feature.Id, Name = vf.Feature.Name})))
            .ForMember(vr => vr.Make, opt => opt.MapFrom(v => v.Model.Make));
            


            //resource to domain
            CreateMap<VehicleQueryResource, VehicleQuery>();
            CreateMap<ContactResource, Contact>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<SaveVehicleResource, Vehicle>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) => {
                    var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId));

                    foreach( var f in removedFeatures.ToList())
                    v.Features.Remove(f);                    

                    var newFeatures = vr.Features.Where(id => !v.Features.Any(f => f.FeatureId == id)).Select(id => new VehicleFeature{FeatureId = id});
                    foreach (var f in newFeatures.ToList())
                        v.Features.Add(f);
                });
           
        }
    }
}