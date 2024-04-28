using Microsoft.EntityFrameworkCore;
using Workout.Api.Models.Entities;

namespace Workout.Api.Persistence
{
    public class WorkoutDbContext : DbContext
    {
        public WorkoutDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Entities.Workout>()
                .HasMany(workout => workout.Exercises)
                .WithOne(exercise => exercise.Workout)
                .HasForeignKey(exercise => exercise.WorkoutId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Exercise>()
            .Property(e => e.ExerciseId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Dates>()
                .HasMany(dateOfWorkout => dateOfWorkout.Workouts)
                .WithMany(workout => workout.datesOfWorkouts).UsingEntity<DatesToWorkouts>();
        }
        public DbSet<Models.Entities.Workout> Workouts { get; set; } = null!;
        public DbSet<Exercise> Exercises { get; set; } = null!;
        public DbSet<Dates> DatesOfWorkouts { get; set; } = null!;
    }
}
