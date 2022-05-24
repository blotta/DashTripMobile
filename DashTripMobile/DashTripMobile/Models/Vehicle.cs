using System;
using System.Collections.Generic;
using System.Text;

namespace DashTripMobile.Models
{
    public class Vehicle
    {
        public string Id { get; set; }
        public string Name { get; set; }
        // public VehicleType Type { get; set; }
        public string Type { get; set; }
    }

    public enum VehicleType
    {
        Car
    }
}
