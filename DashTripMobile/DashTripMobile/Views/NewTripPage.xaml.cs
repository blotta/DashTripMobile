using DashTripMobile.Models;
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
    public partial class NewTripPage : ContentPage
    {
        public Trip Trip { get; set; }
        public NewTripPage()
        {
            InitializeComponent();
            BindingContext = new NewTripViewModel();
        }
    }
}