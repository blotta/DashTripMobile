using DashTripMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DashTripMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TripsPage : ContentPage
    {
        TripsViewModel _viewModel;
        public TripsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TripsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private async void AddTripButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(NewTripPage));

        }
    }
}