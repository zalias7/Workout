namespace Workout.Api.Models
{
    public class WorkoutSummary
    {
        public int WorkoutId { get; set; }
        public int TotalSets { get; set; }
        public int TotalReps { get; set; }
        public int TotalDuration { get; set; }
    }
}
