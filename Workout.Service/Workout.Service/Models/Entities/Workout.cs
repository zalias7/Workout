namespace Workout.Api.Models.Entities
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Exercise> Exercises { get; set; } = [];
        public List<Dates> datesOfWorkouts { get; set; } = [];
    }
}
