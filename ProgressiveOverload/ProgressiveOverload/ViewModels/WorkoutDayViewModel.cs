using ProgressiveOverload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProgressiveOverload.ViewModels
{
    class WorkoutDayViewModel : BaseViewModel
    {
        private List<Exercise> _workout = new List<Exercise>();
        public List<Exercise> Workout
        {
            get => _workout;
            set => SetProperty(ref _workout, value);
        }

        public ICommand SetDoneCommand { get; }
        public ICommand RemoveDoneCommand { get; }

        public WorkoutDayViewModel()
        {
            Title = "Day 1 (Lower)";

            SetDoneCommand = new Command<ExerciseSet>((eSet) =>
            {
                GetTappedExerciseSet(eSet).SetToDone();
                OnPropertyChanged("Workout");
            });

            RemoveDoneCommand = new Command<ExerciseSet>((eSet) =>
            {
                GetTappedExerciseSet(eSet).RemoveDone();
                OnPropertyChanged("Workout");
            });


            Workout = new List<Exercise>
            {
                new Exercise("Squat", "75%", 3, 4, 100, 3),
                new Exercise("Stiff Leg Deadlift", "RPE7", 3, 10, 60, 2),
                new Exercise("Leg Press", "RPE8", 2, 20, 75, 2),
                new Exercise("Calf Raise", "RPE 8", 4, 12, 50, 2),
            };
        }

        private ExerciseSet GetTappedExerciseSet(ExerciseSet eSet)
        {
            return Workout
                .First(x => x.Name == eSet.Exercise.Name).ExerciseSets
                .First(es => es.Index == eSet.Index);
        }
    }
}