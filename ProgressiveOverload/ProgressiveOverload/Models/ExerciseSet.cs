using System;

namespace ProgressiveOverload.Models
{
    public class ExerciseSet : MvvmHelpers.ObservableObject
    {
        public ExerciseSet(Exercise exercise, int index, int reps, int done)
        {
            Id = Guid.NewGuid().ToString();

            Exercise = exercise;
            Index = index;
            Reps = reps;
            Done = done;
        }

        public string Id { get; }

        public Exercise Exercise { get; }

        public int Index { get; }

        public int _done;
        public int Done
        {
            get => _done;
            set => SetProperty(ref _done, value);
        }

        public int Reps { get; }

        public void SetToDone()
        {
            Done = 1;
        }

        public void RemoveDone()
        {
            Done = -1;
        }
    }
}
