using DashTripMobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashTripMobile.Services
{
    public interface IDashTripDataStore
    { 

        Task<bool> AddVehicleAsync(Vehicle item);
        Task<bool> UpdateVehicleAsync(Vehicle item);
        Task<bool> DeleteVehicleAsync(string id);
        Task<Vehicle> GetVehicleAsync(string id);
        Task<IEnumerable<Vehicle>> GetVehiclesAsync(bool forceRefresh = false);


        Task<bool> AddTripAsync(Trip item);
        Task<bool> UpdateTripAsync(Trip item);
        Task<bool> DeleteTripAsync(string id);
        Task<Trip> GetTripAsync(string id);
        Task<IEnumerable<Trip>> GetTripsAsync(bool forceRefresh = false);
    }
}
