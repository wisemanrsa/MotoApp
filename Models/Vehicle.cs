using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCOREDEMO.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Make Make {get; set;}
        public Model Model { get; set; }
        public bool IsRegistered { get; set; }
        public Contact Contact { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<VehicleFeature> Features { get; set; }

        public Vehicle ()
        {
            Features = new Collection<VehicleFeature>();
        }
    }
}