using System.Collections.Generic;

namespace ProgressiveOverload.Models
{
    class Exercise
    {
        public Exercise(string name, string intensity, int sets, int reps, int weight, int restMin)
        {
            Name = name;
            Intensity = intensity;
            Sets = sets;
            Reps = reps;
            Weight = weight;
            RestMin = restMin;

            var setList = new List<ExerciseSet>();
            for (int i = 0; i < Sets; i++)
            {
                setList.Add(new ExerciseSet(this, i, Reps, -1));
            }

            ExerciseSets = setList;
        }

        public string Name { get; set; }
        public string Intensity { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int RestMin { get; set; }
        public int Weight { get; set; }

        public string Volume { get => $"{Sets} x {Reps} x {Weight}kg"; }


        public List<ExerciseSet> ExerciseSets { get; set; }
    }

    class ExerciseSet : MvvmHelpers.ObservableObject
    {
        public ExerciseSet(Exercise exercise, int index, int reps, int done)
        {
            Exercise = exercise;
            Index = index;
            Reps = reps;
            Done = done;
        }

        public void SetToDone()
        {
            Done = 1;
        }

        public void RemoveDone()
        {
            Done = -1;
        }

        public Exercise Exercise { get; set; }

        public int Index { get; set; }

        public int _done;
        public int Done
        {
            get => _done;
            set => SetProperty(ref _done, value);
        }
        public int Reps { get; set; }
    }
}
