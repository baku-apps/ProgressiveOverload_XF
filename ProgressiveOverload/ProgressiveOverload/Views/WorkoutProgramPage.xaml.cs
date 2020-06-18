using ProgressiveOverload.Models;
using ProgressiveOverload.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgressiveOverload.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutProgramPage : ContentPage
    {
        private readonly WorkoutProgramViewModel ViewModel;
        public WorkoutProgramPage()
        {
            InitializeComponent();
            ViewModel = BindingContext as WorkoutProgramViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.LoadItemsCommand.Execute(null);
        }
    }
}