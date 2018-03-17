using ASPNETCOREDEMO.Models;
using Microsoft.AspNetCore.Mvc;
using ASPNETCOREDEMO.Controllers.Resources;
using AutoMapper;
using ASPNETCOREDEMO.Persistence;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ASPNETCOREDEMO.Controllers
{
    [Route("api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository vehicleRepository;
        private readonly IUnitOfWork unitOfWork;
        public VehiclesController(IMapper mapper, IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.vehicleRepository = vehicleRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleResource>> GetVehicles() 
        {
            var vehicles = await vehicleRepository.GetVehicles();
            
            return mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleResource>>(vehicles);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            
            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            
            vehicleRepository.Add(vehicle);
            await unitOfWork.Complete();

            vehicle = await vehicleRepository.GetVehicle(vehicle.Id);
            var results = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(results);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = await vehicleRepository.GetVehicle(id);
            if (vehicle == null) return NotFound();
            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await unitOfWork.Complete();

            vehicle = await vehicleRepository.GetVehicle(vehicle.Id);
            var results = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(results);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {

            var vehicle = await vehicleRepository.GetVehicle(id, includeRelated: false);
            if (vehicle == null) return NotFound();
            vehicleRepository.Remove(vehicle);
            await unitOfWork.Complete();
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await vehicleRepository.GetVehicle(id);
            if (vehicle == null) return NotFound();
            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);
        }
    }
}