
namespace ASPNETCOREDEMO.Models
{
    public class VehicleQuery
    {
        public int? MakeId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
    }
}