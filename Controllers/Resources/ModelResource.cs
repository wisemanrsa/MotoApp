using ASPNETCOREDEMO.Models;

namespace ASPNETCOREDEMO.Controllers.Resources
{
    public class ModelResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Make Make { get; set; }
        public int MakeId { get; set; }
    }
}