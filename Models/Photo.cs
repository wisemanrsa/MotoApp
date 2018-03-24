using System.ComponentModel.DataAnnotations;

namespace ASPNETCOREDEMO.Models
{
    public class Photo
    {
        public int Id { get; set; } 
        [Required]
        [StringLength(255)]
        public string FileName { get; set; }
        public int VehicleId { get; set; }
    }
}