using ProgressiveOverload.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveOverload.Services
{
    class MockWorkoutDataStore : IDataStore<WorkoutProgram>
    {
        readonly WorkoutProgram workoutProgram;

        public MockWorkoutDataStore()
        {
            var exercises = new List<Exercise>
            {
                new Exercise("Squat", new OneRM(75), 3, 4, 100, 3),
                new Exercise("Stiff Leg Deadlift", new RPE(7), 3, 10, 60, 2),
                new Exercise("Leg Press", new RPE(8), 2, 20, 75, 2),
                new Exercise("Calf Raise", new RPE(8), 5, 12, 50, 2),
            };

            var lowerDay1 = new WorkoutDay("Lower #1", 1, exercises, DateTimeOffset.Now);

            workoutProgram = new WorkoutProgram()
            {
                Title = "Upper/Lower Strenght and Size",
                WorkoutDays = new List<WorkoutDay>
                {
                    lowerDay1, lowerDay1, lowerDay1, lowerDay1
                },
            };
        }

        public Task<bool> AddItemAsync(WorkoutProgram item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<WorkoutProgram> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WorkoutProgram>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(new List<WorkoutProgram> { workoutProgram });
        }

        public Task<bool> UpdateItemAsync(WorkoutProgram item)
        {
            throw new NotImplementedException();
        }

        public static class WorkoutProgramData
        {
            public static IList<WorkoutProgram> Programs { get; private set; }

            static WorkoutProgramData()
            {
                Programs = new List<WorkoutProgram>
                {
                    new WorkoutProgram
                    {
                        Title = "Upper/Lower Strenght and Size",
                        WorkoutDays = null,
                    }
                };
            }
        }

        public static class WorkoutDayData
        {
            public static IList<WorkoutDay> Workouts { get; }

            static WorkoutDayData()
            {
                Workouts = new List<WorkoutDay>
                {
                    new WorkoutDay("Lower #1", 1, ExererciseData.Exercises["Lower1"], DateTimeOffset.Now),
                    new WorkoutDay("Lower #1", 1, ExererciseData.Exercises["Upper1"], DateTimeOffset.Now),
                    new WorkoutDay("Lower #2", 1, ExererciseData.Exercises["Lower2"], DateTimeOffset.Now),
                    new WorkoutDay("Lower #2", 1, ExererciseData.Exercises["Upper2"], DateTimeOffset.Now),
                    new WorkoutDay("Lower #3", 1, ExererciseData.Exercises["Lower1"], DateTimeOffset.Now),
                    new WorkoutDay("Lower #3", 1, ExererciseData.Exercises["Upper1"], DateTimeOffset.Now),
                };
            }
        }

        public static class ExererciseData
        {

            public static Dictionary<string, List<Exercise>> Exercises { get; }

            static ExererciseData()
            {
                Exercises = new Dictionary<string, List<Exercise>>
                {
                    {
                        "Lower1", new List<Exercise>
                        {
                            new Exercise("Squat", new OneRM(75), 3, 4, 100, 3) ,
                            new Exercise("Stiff Leg Deadlift", new RPE(7), 3, 10, 60, 2),
                            new Exercise("Leg Press", new RPE(8), 2, 20, 75, 2),
                            new Exercise("Calf Raise", new RPE(8), 5, 12, 50, 2)
                        }
                    },
                    {
                        "Upper1", new List<Exercise>
                        {
                            new Exercise("Bench Press", new OneRM(75), 3, 4, 70, 3) ,
                            new Exercise("Pull-Up", new RPE(7), 3, 6, 0, 2),
                            new Exercise("Leg Press", new RPE(7), 2, 20, 75, 2),
                            new Exercise("Calf Raise", new RPE(7), 5, 12, 50, 2)
                        }
                    },
                    {
                        "Lower2", new List<Exercise>
                        {
                            new Exercise("Squat", new OneRM(75), 3, 4, 100, 3) ,
                            new Exercise("Stiff Leg Deadlift", new RPE(7), 3, 10, 60, 2),
                            new Exercise("Leg Press", new RPE(7), 2, 20, 75, 2),
                            new Exercise("Calf Raise", new RPE(7), 5, 12, 50, 2)
                        }
                    },
                    {
                        "Upper2", new List<Exercise>
                        {
                            new Exercise("Bench Press", new OneRM(75), 3, 4, 70, 3) ,
                            new Exercise("Pull-Up", new RPE(7), 3, 6, 0, 2),
                            new Exercise("Leg Press", new RPE(7), 2, 20, 75, 2),
                            new Exercise("Calf Raise", new RPE(7), 5, 12, 50, 2)
                        }
                    },

                };
            }
        }
    }
}
