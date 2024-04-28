namespace Workout.Api.Models
{
    public class LinkWorkoutToDateRequest
    {
        public DateOnly Date { get; set; }
        public int WorkoutId { get; set; }
    }
}
