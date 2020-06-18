using System;
using System.Collections.Generic;

namespace ProgressiveOverload.Models
{
    public class WorkoutProgram
    {
        public string Id => Guid.NewGuid().ToString();
        public string Title { get; set; }
        public List<WorkoutDay> WorkoutDays { get; set; }
    }
}
