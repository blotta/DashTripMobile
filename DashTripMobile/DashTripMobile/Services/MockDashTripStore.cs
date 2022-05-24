using DashTripMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashTripMobile.Services
{
    public class MockDashTripStore : IDashTripDataStore
    {
        readonly List<Vehicle> vehicles;
        public MockDashTripStore()
        {
            vehicles = new List<Vehicle>()
            {
                new Vehicle { Id = Guid.NewGuid().ToString(), Name = "VW Golf", Type = "Carro" }
            };
        }

        public async Task<bool> AddVehicleAsync(Vehicle item)
        {
            vehicles.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateVehicleAsync(Vehicle item)
        {
            var oldItem = vehicles.Where((Vehicle arg) => arg.Id == item.Id).FirstOrDefault();
            vehicles.Remove(oldItem);
            vehicles.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteVehicleAsync(string id)
        {
            var oldItem = vehicles.Where((Vehicle arg) => arg.Id == id).FirstOrDefault();
            vehicles.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Vehicle> GetVehicleAsync(string id)
        {
            return await Task.FromResult(vehicles.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(vehicles);
        }

    }
}
