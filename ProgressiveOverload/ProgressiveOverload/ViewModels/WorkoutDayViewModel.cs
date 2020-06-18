using MvvmHelpers;
using ProgressiveOverload.Models;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProgressiveOverload.ViewModels
{
    public class WorkoutDayViewModel : BaseViewModel
    {
        private WorkoutDay _workoutDay;
        public WorkoutDay WorkoutDay
        {
            get => _workoutDay;
            set => SetProperty(ref _workoutDay, value);
        }

        private ObservableRangeCollection<Exercise> _exercises = new ObservableRangeCollection<Exercise>();
        public ObservableRangeCollection<Exercise> Exercises
        {
            get => _exercises;
            set => SetProperty(ref _exercises, value);
        }

        public ICommand SetDoneCommand { get; }
        public ICommand RemoveDoneCommand { get; }
        public ICommand LoadWorkoutDetailsCommand { get; }

        public WorkoutDayViewModel()
        {
            Title = "Day 1 (Lower #1)";

            LoadWorkoutDetailsCommand = new Command<string>(async (id) => await LoadWorkoutDetails(id));

            SetDoneCommand = new Command<ExerciseSet>((eSet) =>
            {
                GetTappedExerciseSet(eSet).SetToDone();
                OnPropertyChanged(nameof(WorkoutDay));
            });

            RemoveDoneCommand = new Command<ExerciseSet>((eSet) =>
            {
                GetTappedExerciseSet(eSet).RemoveDone();
                OnPropertyChanged(nameof(WorkoutDay));
            });

            //WorkoutDay = _workoutDay;
        }

        private ExerciseSet GetTappedExerciseSet(ExerciseSet eSet)
        {
            return WorkoutDay.Exercises
                .First(x => x.Name == eSet.Exercise.Name).ExerciseSets
                .First(es => es.Index == eSet.Index);
        }

        private async Task LoadWorkoutDetails(string id)
        {
            var program = await ProgramDataStore.GetItemsAsync();
            WorkoutDay = program.First().WorkoutDays.First(w => w.Id == id);

            Exercises.Clear();
            Exercises.AddRange(WorkoutDay.Exercises);
            //OnPropertyChanged(nameof(WorkoutDay));
        }
    }
}