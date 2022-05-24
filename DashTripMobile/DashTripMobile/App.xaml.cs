﻿using DashTripMobile.Services;
using DashTripMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DashTripMobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<MockDashTripStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
