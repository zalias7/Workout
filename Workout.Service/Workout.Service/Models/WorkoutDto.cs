namespace Workout.Api.Models
{
    public class WorkoutDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IEnumerable<ExerciseDto> Exercises { get; set; } = [];
    }
}
