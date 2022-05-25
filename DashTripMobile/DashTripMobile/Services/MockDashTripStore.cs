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
        readonly List<Trip> trips;
        public MockDashTripStore()
        {
            vehicles = new List<Vehicle>()
            {
                new Vehicle { Id = Guid.NewGuid().ToString(), Name = "VW Golf", Type = VehicleType.Car }
            };

            trips = new List<Trip>()
            {
                new Trip {
                    Id = Guid.NewGuid().ToString(),
                    CreatedAt = DateTimeOffset.Parse("2022-04-01 09:15"),
                    FinishedAt = DateTimeOffset.Parse("2022-04-01 10:23"),
                    TransportType = TransportType.Walking,
                    Vehicle = null,
                    StartAddress = "Av Paulista, 123",
                    FinishAddress = "Rua da Paz 1022"
                },
                new Trip {
                    Id = Guid.NewGuid().ToString(),
                    CreatedAt = DateTimeOffset.Parse("2022-04-01 09:45"),
                    FinishedAt = DateTimeOffset.Parse("2022-04-01 10:00"),
                    TransportType = TransportType.Vehicle,
                    Vehicle = vehicles.First(),
                    StartAddress = "Av Paulista, 123",
                    FinishAddress = "Rua da Paz 1022"
                }
            };

        }

        // Vehicles
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



        // Trips
        public async Task<bool> AddTripAsync(Trip item)
        {
            trips.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateTripAsync(Trip item)
        {
            var oldItem = trips.Where((Trip arg) => arg.Id == item.Id).FirstOrDefault();
            trips.Remove(oldItem);
            trips.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteTripAsync(string id)
        {
            var oldItem = trips.Where((Trip arg) => arg.Id == id).FirstOrDefault();
            trips.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Trip> GetTripAsync(string id)
        {
            return await Task.FromResult(trips.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Trip>> GetTripsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(trips);
        }
    }
}
