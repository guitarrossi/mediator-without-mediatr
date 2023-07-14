using MediatorWithoutMediatr.Database;
using MediatorWithoutMediatr.Endpoints.Course;
using MediatorWithoutMediatr.Interfaces;
using System.Reflection;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

foreach (var type in typeof(Program).Assembly.GetTypes().Where(r => (r.Name.EndsWith("Handler") || r.Name.EndsWith("Pipeline")) && !r.IsAbstract && !r.IsInterface))
{
    builder.Services.AddScoped(type);
}

builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.RegisterCreateCourseEndpoint();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
