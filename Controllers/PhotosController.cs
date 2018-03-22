using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCOREDEMO.Controllers.Resources;
using ASPNETCOREDEMO.Models;
using ASPNETCOREDEMO.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ASPNETCOREDEMO.Controllers
{
    public class PhotosController : Controller
    {
        private readonly IHostingEnvironment host;
        private readonly IVehicleRepository repo;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly PhotoSettings photoSettings;
        public PhotosController(IHostingEnvironment host, IVehicleRepository repo, IUnitOfWork unitOfWork, IMapper mapper, IOptionsSnapshot<PhotoSettings> options)
        {
            this.photoSettings = options.Value;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repo = repo;
            this.host = host;

        }
        [HttpPost("/api/vehicles/{vehicleId}/photos")]
        public async Task<IActionResult> Upload(int vehicleId, IFormFile file)
        {
            var vehicle = await repo.GetVehicle(vehicleId, includeRelated: false);
            if (vehicle == null) return NotFound();
            if (file == null) return BadRequest("File is null");
            if (file.Length == 0) return BadRequest("No file");
            if (file.Length > photoSettings.MaxBytes) return BadRequest("Max file size exceeded");
            if (!photoSettings.IsSupportedFile(file.FileName)) return BadRequest("Max file size exceeded");

            var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filepath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var photo = new Photo { FileName = fileName };
            vehicle.Photos.Add(photo);
            await unitOfWork.Complete();
            var photoResource = mapper.Map<Photo, PhotoResource>(photo);
            return Ok(photoResource);
        }
    }
}