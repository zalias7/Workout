namespace Workout.Api.Models.Entities
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public int WorkoutId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Duration { get; set; }
        public required Workout Workout { get; set; }
    }
}
