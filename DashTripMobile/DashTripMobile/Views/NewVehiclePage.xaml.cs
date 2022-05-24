using DashTripMobile.Models;
using DashTripMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DashTripMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewVehiclePage : ContentPage
    {
        public Vehicle Vehicle { get; set; }

        public NewVehiclePage()
        {
            InitializeComponent();
            BindingContext = new NewVehicleViewModel();
        }
    }
}