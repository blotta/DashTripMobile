using DashTripMobile.Models;
using DashTripMobile.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DashTripMobile.ViewModels
{
    [QueryProperty(nameof(TripId), nameof(TripId))]
    public class DuringTripViewModel : BaseViewModel
    {

        public Command FinishTripCommand { get; }

        public DuringTripViewModel()
        {
            Title = "Durante o Percurso";

            // SaveCommand = new Command(OnSave, ValidateSave);
            // CancelCommand = new Command(OnCancel);
            FinishTripCommand = new Command(OnTripFinished);
            // this.PropertyChanged +=
                // (_, __) => SaveCommand.ChangeCanExecute();
        }

        private string tripId;

        public string TripId
        {
            get
            {
                return tripId;
            }
            set
            {
                tripId = value;
                LoadTripId(value);
            }
        }

        public string Id { get; set; }

        private DateTimeOffset tripStart;
        public DateTimeOffset TripStart
        {
            get => tripStart;
            set => SetProperty(ref tripStart, value);
        }

        public TimeSpan Duration
        {
            get => (DateTimeOffset.UtcNow - TripStart);
        }

        public string DurationFmt
        {
            get
            {
                var d = (DateTimeOffset.UtcNow - tripStart);
                return String.Format("{0:D2}:{1:D2}:{2:D2}", d.Hours, d.Minutes, d.Seconds);
            }
        }


        private string transport;
        public string Transport
        {
            get => transport;
            set => SetProperty(ref transport, value);
        }


        private string finishAddress;
        public string FinishAddress
        {
            get => finishAddress;
            set => SetProperty(ref finishAddress, value);
        }


        public async void LoadTripId(string tripId)
        {
            try
            {
                var trip = await DashTripDataStore.GetTripAsync(tripId);
                Id = trip.Id;
                TripStart = trip.CreatedAt;
                Transport = trip.TransportType == Models.TransportType.Vehicle
                    ? Enum.GetName(typeof(VehicleType), trip.Vehicle.Type)
                    : Enum.GetName(typeof(TransportType), trip.TransportType);
                FinishAddress = trip.FinishAddress;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Trip");
            }
        }

        // public Command SaveCommand { get; }
        // // public Command CancelCommand { get; }
        // public Command FinishTripCommand { get; }

        // private bool ValidateSave()
        // {
        //     return true;
        // }

        private async void OnTripFinished()
        {
            Trip trip = await DashTripDataStore.GetTripAsync(Id);

            trip.FinishedAt = DateTimeOffset.UtcNow;

            await DashTripDataStore.UpdateTripAsync(trip);
            var path = $"//{nameof(TripsPage)}";
            await Shell.Current.GoToAsync(path);
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        public void OnDisappearing()
        {
            IsBusy = true;
        }

        // private async void OnCancel()
        // {
        //     // This will pop the current page off the navigation stack
        //     await Shell.Current.GoToAsync("..");
        // }

        // private async void OnSave()
        // {
        //     Trip newTrip = new Trip()
        //     {
        //         Id = Guid.NewGuid().ToString(),
        //         StartAddress = StartAddress,
        //         FinishAddress = FinishAddress,
        //         TransportType = transportType,
        //         CreatedAt = DateTimeOffset.UtcNow,
        //         FinishedAt = null,
        //         Vehicle = null,
        //     };

        //     await DashTripDataStore.AddTripAsync(newTrip);

        //     await Shell.Current.GoToAsync(nameof(DuringTripPage));
        // }
    }
}
