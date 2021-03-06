﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProgressiveOverload.Services;
using ProgressiveOverload.Views;

namespace ProgressiveOverload
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<MockWorkoutDataStore>();
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
