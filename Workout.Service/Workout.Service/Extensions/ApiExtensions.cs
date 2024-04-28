using Microsoft.AspNetCore.Mvc;
using Workout.Api.Models;
using Workout.Api.Services;

namespace Workout.Api.Extensions
{
    public static class ApiExtensions
    {
        public static void RegisterWorkoutEndpoints(this WebApplication app)
        {
            var workouts = app.MapGroup("/api/workout");

            workouts.MapGet("/", async (WorkoutService workoutService) => await workoutService.GetAll());
            workouts.MapGet("/{id}", async (int id, WorkoutService workoutService) => await workoutService.Get(id));
            workouts.MapPost("/", async ([FromBody] WorkoutDto workout, WorkoutService workoutService) =>
            {
                await workoutService.Create(workout);

                return Results.Created($"/workout/{workout.Id}", workout);
            });
            workouts.MapDelete("/", async (int id, WorkoutService workoutService) =>
            {
                await workoutService.Delete(id);

                return Results.NoContent();
            });
        }

        public static void RegisterWorkoutSummaryEndpoints(this WebApplication app)
        {
            app.MapGet("/api/workout/{id}/summary", async (int id, WorkoutService workoutService) => await workoutService.GetSummary(id));
        }

        public static void RegisterCalendarEndpoints(this WebApplication app)
        {
            app.MapPut("/", async ([FromBody] LinkWorkoutToDateRequest request, WorkoutService workoutService) =>
            {
               
            });
        }
    }
}
