using System;
using System.Collections.Generic;

namespace ProgressiveOverload.Models
{
    public class WorkoutDay
    {
        public WorkoutDay()
        {
            Id = Guid.NewGuid().ToString();
        }

        public WorkoutDay(string title, int block, List<Exercise> exercises, DateTimeOffset date) : this()
        {
            Title = title;
            Block = block;
            Exercises = exercises;
            Date = date;
            Completed = false;
        }

        public string Id { get; }
        public string Title { get; }
        public int Block { get; }
        public List<Exercise> Exercises { get; }
        public DateTimeOffset Date { get; }
        public bool Completed { get; }
    }
}
