using System.Collections.ObjectModel;
using Workout.Api.Models;
using Workout.Api.Models.Entities;
using Workout.Api.Persistence;

namespace Workout.Api.Services
{
    public class WorkoutService
    {
        private readonly WorkoutDbContext workoutDb;

        public WorkoutService(WorkoutDbContext workoutDbContext)
        {
            workoutDb = workoutDbContext;
        }

        public async Task<WorkoutDto> Get(int id)
        {
            var workout = await workoutDb.Workouts.FindAsync(id);

            if (workout == null)
            {
                //404 
            }

            var exerciseDtos = new List<ExerciseDto> { };
            foreach (var exercise in workoutDb.Exercises.Where(exercise => exercise.WorkoutId == id))
            {
                exerciseDtos.Add(
                    new ExerciseDto()
                    {
                        Duration = exercise.Duration,
                        Name = exercise.Name,
                        Sets = exercise.Sets,
                        Reps = exercise.Reps
                    });
            }
            var workoutDto = new WorkoutDto()
            {
                Id = workout.WorkoutId,
                Description = workout.Description,
                Exercises = exerciseDtos,
                Title = workout.Title
            };

            return await Task.FromResult(workoutDto);
        }
        public async Task<WorkoutSummary> GetSummary(int id)
        {
            var workout = await workoutDb.Workouts.FindAsync(id);

            if (workout == null)
            {
                //404 
            }

            var workoutSummary = new WorkoutSummary { WorkoutId = id };
            foreach (var exercise in workoutDb.Exercises.Where(exercise => exercise.WorkoutId == id))
            {
                workoutSummary.TotalSets += exercise.Sets;
                workoutSummary.TotalReps += exercise.Sets*exercise.Reps;
                workoutSummary.TotalDuration += exercise.Duration;
            }

            return await Task.FromResult(workoutSummary);
        }
        public async Task<IEnumerable<WorkoutDto>> GetAll()
        {
            var workoutDtos = new List<WorkoutDto>();
            foreach (var workout in workoutDb.Workouts)
            {
                var exerciseDtos = new List<ExerciseDto> { };
                foreach (var exercise in workoutDb.Exercises.Where(exercise => exercise.WorkoutId == workout.WorkoutId))
                {
                    exerciseDtos.Add(
                        new ExerciseDto()
                        {
                            Duration = exercise.Duration,
                            Name = exercise.Name,
                            Sets = exercise.Sets,
                            Reps = exercise.Reps
                        });
                }
                workoutDtos.Add(new WorkoutDto()
                {
                    Id = workout.WorkoutId,
                    Description = workout.Description,
                    Exercises = exerciseDtos,
                    Title = workout.Title
                });
            }

            return await Task.FromResult(workoutDtos);
        }
        public async Task<WorkoutDto> Create(WorkoutDto request)
        {
            var workoutEntity = new Models.Entities.Workout()
            {
                WorkoutId = request.Id,
                Description = request.Description,
                Title = request.Title
            };

            var exerciseEntities = new Collection<Exercise>();

            for (int i = 0; i < request.Exercises.Count(); i++)
            {
                var exerciseEntity = new Exercise()
                {
                    WorkoutId = request.Id,
                    Sets = request.Exercises.ToList()[i].Sets,
                    Reps = request.Exercises.ToList()[i].Reps,
                    Duration = request.Exercises.ToList()[i].Duration,
                    Name = request.Exercises.ToList()[i].Name,
                    Workout = workoutEntity
                };
                exerciseEntities.Add(exerciseEntity);
            }
            workoutEntity.Exercises.AddRange(exerciseEntities);
            workoutDb.Workouts.Add(workoutEntity);
            await workoutDb.SaveChangesAsync();

            return await Task.FromResult(request);
        }
        public async Task Delete(int id)
        {
            var workout = await workoutDb.Workouts.FindAsync(id);

            if (workout == null)
            {
                //404 
            }

            workoutDb.Workouts.Remove(workout);
            await workoutDb.SaveChangesAsync();
        }
    }
}
