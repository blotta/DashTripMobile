using DashTripMobile.Models;
using DashTripMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DashTripMobile.ViewModels
{
    public class NewTripViewModel : BaseViewModel
    {
        public string[] TransportTypes { get; set; }
        public string[] VehicleTypes { get; set; }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }


        public NewTripViewModel()
        {
            Title = "Novo Percurso";

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

            TransportTypes = Enum.GetNames(typeof(TransportType));
            VehicleTypes = Enum.GetNames(typeof(VehicleType));

            startAddress = "Av Paulista, 1000";
        }


        private string startAddress;
        public string StartAddress
        {
            get => startAddress;
            set => SetProperty(ref startAddress, value);
        }

        private string finishAddress;
        public string FinishAddress
        {
            get => finishAddress;
            set => SetProperty(ref finishAddress, value);
        }

        private TransportType transportType;
        public string TransportType
        {
            get => Enum.GetName(typeof(TransportType), transportType);
            set
            {
                TransportType t = (TransportType)Enum.Parse(typeof(TransportType), value);
                SetProperty(ref transportType, t);
            }
        }

        private VehicleType? vehicleType;
        public string VehicleType
        {
            get => vehicleType.HasValue ? Enum.GetName(typeof(VehicleType), vehicleType.Value) : null;
            set
            {
                VehicleType? t = (VehicleType)Enum.Parse(typeof(VehicleType), value);
                SetProperty(ref vehicleType, t);
            }
        }


        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(finishAddress)
                && !String.IsNullOrWhiteSpace(TransportType);
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Trip newTrip = new Trip()
            {
                Id = Guid.NewGuid().ToString(),
                StartAddress = StartAddress,
                FinishAddress = FinishAddress,
                TransportType = transportType,
                CreatedAt = DateTimeOffset.UtcNow,
                FinishedAt = null,
                Vehicle = null,
            };

            await DashTripDataStore.AddTripAsync(newTrip);

            // await Shell.Current.GoToAsync(nameof(DuringTripPage));
            var path = $"{nameof(DuringTripPage)}?{nameof(DuringTripViewModel.TripId)}={newTrip.Id}";
            await Shell.Current.GoToAsync(path);
        }

    }
}
