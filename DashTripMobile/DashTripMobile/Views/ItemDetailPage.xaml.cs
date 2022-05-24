using DashTripMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DashTripMobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}