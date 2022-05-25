using DashTripMobile.Models;
using DashTripMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DashTripMobile.ViewModels
{
    public class TripsViewModel : BaseViewModel
    {
        private Trip _selectedTrip;

        public ObservableCollection<Trip> Trips { get; }
        public Command LoadTripsCommand { get; }
        // public Command AddTripCommand { get; }
        public Command CancelCommand { get; }
        public Command<Trip> TripTapped { get; }

        public TripsViewModel()
        {
            Title = "Meus Percursos";
            Trips = new ObservableCollection<Trip>();
            LoadTripsCommand = new Command(async () => await ExecuteLoadTripsCommand());

            TripTapped = new Command<Trip>(OnTripSelected);

            // AddTripCommand = new Command(OnAddTrip);
            CancelCommand = new Command(OnCancel);
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        async Task ExecuteLoadTripsCommand()
        {
            IsBusy = true;

            try
            {
                Trips.Clear();
                var items = await DashTripDataStore.GetTripsAsync(true);
                items = items.OrderByDescending(t => t.CreatedAt);
                foreach (var item in items)
                {
                    Trips.Add(item);
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
            SelectedTrip = null;
        }

        public Trip SelectedTrip
        {
            get => _selectedTrip;
            set
            {
                SetProperty(ref _selectedTrip, value);
                OnTripSelected(value);
            }
        }

/*        private async void OnAddTrip(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewVehiclePage));
        }
*/
        async void OnTripSelected(Trip item)
        {
            if (item == null)
                return;

            // This will push the TripDetailPage onto the navigation stack
            // await Shell.Current.GoToAsync($"{nameof(TripDetailPage)}?{nameof(TripDetailViewModel.TripId)}={item.Id}");
            await Shell.Current.GoToAsync("..");
        }

    }

}
