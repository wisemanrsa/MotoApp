using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCOREDEMO.Controllers.Resources;
using ASPNETCOREDEMO.Models;
using ASPNETCOREDEMO.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCOREDEMO.Controllers
{
    //[Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        
        private readonly MotoDbContext context;
        private readonly IMapper mapper;
        public VehiclesController(MotoDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await context.Makes.ToListAsync();
            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }

        [HttpGet("/api/models/{id}")]
        public async Task<IEnumerable<ModelResource>> GetModelAsync(int id)
        {
            var models = await context.Models.Where(m => m.MakeId == id).ToListAsync();
            return mapper.Map<List<Model>, List<ModelResource>>(models);
        }

        [HttpGet("/api/features")]
        public async Task<IEnumerable<FeatureResource>> GetFeatures()
        {
            var features = await context.Features.ToListAsync();
            return mapper.Map<List<Feature>, List<FeatureResource>>(features);
        }
    }
}