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
        int count = 0;
        public TripsPage()
        {
            InitializeComponent();

            LabelCount.Text = "Hello from Code Behind";
        }

        private void ButtonClick_Clicked(object sender, EventArgs e)
        {
            count++;
            LabelCount.Text = $"You clicked {count} time(s)";
        }
    }
}