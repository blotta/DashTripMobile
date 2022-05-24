using DashTripMobile.Models;
using DashTripMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DashTripMobile.ViewModels
{
    public class VehiclesViewModel : BaseViewModel
    {
        private Vehicle _selectedVehicle;

        public ObservableCollection<Vehicle> Vehicles { get; }
        public Command LoadVehiclesCommand { get; }
        public Command AddVehicleCommand { get; }
        public Command<Vehicle> VehicleTapped { get; }

        public VehiclesViewModel()
        {
            Title = "Meus Veículos";
            Vehicles = new ObservableCollection<Vehicle>();
            LoadVehiclesCommand = new Command(async () => await ExecuteLoadVehiclesCommand());

            VehicleTapped = new Command<Vehicle>(OnVehicleSelected);

            AddVehicleCommand = new Command(OnAddVehicle);
        }

        async Task ExecuteLoadVehiclesCommand()
        {
            IsBusy = true;

            try
            {
                Vehicles.Clear();
                var items = await DashTripDataStore.GetVehiclesAsync(true);
                foreach (var item in items)
                {
                    Vehicles.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedVehicle = null;
        }

        public Vehicle SelectedVehicle
        {
            get => _selectedVehicle;
            set
            {
                SetProperty(ref _selectedVehicle, value);
                OnVehicleSelected(value);
            }
        }

        private async void OnAddVehicle(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewVehiclePage));
        }

        async void OnVehicleSelected(Vehicle item)
        {
            if (item == null)
                return;

            // This will push the VehicleDetailPage onto the navigation stack
            // await Shell.Current.GoToAsync($"{nameof(VehicleDetailPage)}?{nameof(VehicleDetailViewModel.VehicleId)}={item.Id}");
            await Shell.Current.GoToAsync("..");
        }

    }
}
