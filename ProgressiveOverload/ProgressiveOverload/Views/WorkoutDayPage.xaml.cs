using ProgressiveOverload.Models;
using ProgressiveOverload.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgressiveOverload.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutDayPage : ContentPage
    {
        public WorkoutDayPage()
        {
            InitializeComponent();
            var vm = BindingContext as WorkoutDayViewModel;

            TapCountDisposable = TapSubject
                .Buffer(TapSubject.Throttle(TimeSpan.FromMilliseconds(200)))
                .Select((xx) => xx.Count)
                .Subscribe(taps =>
                {
                    if (taps > 2)
                    {
                        TapCount = 0;
                        return;
                    }
                    else if (taps == 1)
                    {
                        vm.SetDoneCommand.Execute(exSet);
                    }
                    else if (taps == 2)
                    {
                        vm.RemoveDoneCommand.Execute(exSet);
                    }
                });
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