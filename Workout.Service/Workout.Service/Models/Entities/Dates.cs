namespace Workout.Api.Models.Entities
{
    public class Dates
    {
        public int DateId { get; set; }
        public DateOnly Date { get; set; }
        public required List<Workout> Workouts { get; set; }
    }
}
