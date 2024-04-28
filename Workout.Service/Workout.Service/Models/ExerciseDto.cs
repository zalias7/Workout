namespace Workout.Api.Models
{
    public class ExerciseDto
    {
        public string Name { get; set; } = string.Empty;
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Duration { get; set; }
    }
}
