using ProgressiveOverload.Models;
using ProgressiveOverload.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgressiveOverload.Views
{
    [QueryProperty("WorkoutId", "workoutId")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutDayPage : ContentPage
    {
        public WorkoutDayViewModel ViewModel { get; set; }
        public string WorkoutId
        {
            set
            {
                ViewModel.LoadWorkoutDetailsCommand.Execute(value);
            }
        }
        public WorkoutDayPage()
        {
            InitializeComponent();
            SizeChanged += MainPageSizeChanged;
            ViewModel = BindingContext as WorkoutDayViewModel;

            TapCountDisposable = TapSubject
                .Buffer(TapSubject.Throttle(TimeSpan.FromMilliseconds(200)))
                .Select((xx) => xx.Count)
                .Subscribe(taps =>
                {
                    if (exSet.Done == -1)
                    {
                        ViewModel.SetDoneCommand.Execute(exSet);
                    }
                    else
                    {
                        ViewModel.RemoveDoneCommand.Execute(exSet);

                    }
                });
        }

        private void MainPageSizeChanged(object sender, EventArgs e)
        {
            //var button = this.FindByName<Button>("ExerciseSetButton");
            //var size = (Width / 5);
            //button.WidthRequest = button.HeightRequest = size;
            //button.CornerRadius = (int)Math.Round(size / 2);
        }

        private int TapCount = 0;
        private readonly IDisposable TapCountDisposable;
        private Subject<int> TapSubject = new Subject<int>();
        private ExerciseSet exSet;

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            TapCountDisposable?.Dispose();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var parent = sender as Button;
            exSet = parent.BindingContext as ExerciseSet;
            TapCount += 1;
            TapSubject.OnNext(TapCount);
        }
    }
}