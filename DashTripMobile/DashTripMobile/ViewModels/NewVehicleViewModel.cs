using DashTripMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DashTripMobile.ViewModels
{
    public class NewVehicleViewModel : BaseViewModel
    {
        private string name;
        // private VehicleType type;
        // private string type;

        public string[] VehicleTypes { get; set; }
        public VehicleType vtype;

        public NewVehicleViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

            VehicleTypes = Enum.GetNames(typeof(VehicleType));

        }


        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        // public string Type
        // {
        //     get => type;
        //     set => SetProperty(ref type, value);
        // }
        // public VehicleType Type
        // {
        //     get => type;
        //     set => SetProperty(ref type, value);
        // }
        public string VType
        {
            get => Enum.GetName(typeof(VehicleType), vtype);
            set {
                VehicleType t = (VehicleType)Enum.Parse(typeof(VehicleType), value);
                SetProperty(ref vtype, t);
            }
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Vehicle newVehicle = new Vehicle()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Type = vtype
            };

            await DashTripDataStore.AddVehicleAsync(newVehicle);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

    }
}
