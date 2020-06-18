using ProgressiveOverload.Views;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ProgressiveOverload
{
    public partial class AppShell : Shell
    {
        readonly Dictionary<string, Type> routes = new Dictionary<string, Type>();

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        void RegisterRoutes()
        {
            routes.Add(Routes.WorkoutDayDetails, typeof(WorkoutDayPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

        public static class Routes
        {
            public static string WorkoutDayDetails => "WorkoutDayDetail";
        }
    }
}
