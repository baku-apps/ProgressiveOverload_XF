using System;
using System.Collections.Generic;

namespace ProgressiveOverload.Models
{
    public class Exercise
    {
        public Exercise(string name, IIntensity intensity, int sets, int reps, int weight, int restMin)
        {
            Id = Guid.NewGuid().ToString();

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

        public string Id { get; }
        public string Name { get; }
        public IIntensity Intensity { get; }
        public int Sets { get; }
        public int Reps { get; }
        public int RestMin { get; }
        public int Weight { get; }

        public string Volume { get => $"{Sets} x {Reps} x {Weight}kg"; }


        public List<ExerciseSet> ExerciseSets { get; }
    }
}
