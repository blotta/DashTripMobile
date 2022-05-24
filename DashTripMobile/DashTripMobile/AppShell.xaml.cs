using DashTripMobile.ViewModels;
using DashTripMobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DashTripMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(VehiclesPage), typeof(VehiclesPage));
            Routing.RegisterRoute(nameof(NewVehiclePage), typeof(NewVehiclePage));
        }

        //private async void OnMenuItemClicked(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync("//LoginPage");
        //}
    }
}
