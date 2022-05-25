using DashTripMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DashTripMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DuringTripPage : ContentPage
    {
        DuringTripViewModel _viewModel;
        public DuringTripPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new DuringTripViewModel();
        }

    }
}