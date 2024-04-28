using Workout.Api.Extensions;
using Workout.Api.Persistence;
using Workout.Api.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Workouts") ?? "Data Source=Workouts.db";

builder.Services.AddSqlite<WorkoutDbContext>(connectionString);
builder.Services.AddScoped<WorkoutService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Workout api v1"));
}

ApiExtensions.RegisterWorkoutEndpoints(app);
ApiExtensions.RegisterWorkoutSummaryEndpoints(app);

app.UseHttpsRedirection();

app.Run();
