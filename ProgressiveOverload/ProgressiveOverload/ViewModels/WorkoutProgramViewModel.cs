using MvvmHelpers;
using ProgressiveOverload.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static ProgressiveOverload.AppShell;

namespace ProgressiveOverload.ViewModels
{
    public class WorkoutProgramViewModel : BaseViewModel
    {
        public WorkoutProgram Program { get; set; }
        public ObservableRangeCollection<WorkoutDay> WorkoutDay { get; set; } = new ObservableRangeCollection<WorkoutDay>();
        public Command LoadItemsCommand { get;}
        public ICommand OnTappedWorkoutDayCommand { get; }

        public WorkoutProgramViewModel()
        {
            Title = "Workout Program";
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            OnTappedWorkoutDayCommand = new Command<WorkoutDay>(async (workout) =>
            {
                await Shell.Current.GoToAsync($"{Routes.WorkoutDayDetails}?workoutId={workout.Id}");
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Program = (await ProgramDataStore.GetItemsAsync(true)).First();
                WorkoutDay.Clear();
                WorkoutDay.AddRange(Program.WorkoutDays);
                OnPropertyChanged(nameof(Program));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
