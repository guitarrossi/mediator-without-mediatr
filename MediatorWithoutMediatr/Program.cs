using MediatorWithoutMediatr.Database;
using MediatorWithoutMediatr.Endpoints.Course;
using MediatorWithoutMediatr.Interfaces;
using System.Reflection;
using FluentValidation;
using MediatorWithoutMediatr.Notifications.Base;
using MediatorWithoutMediatr.Endpoints.User;

var builder = WebApplication.CreateBuilder(args);

foreach (var type in typeof(Program).Assembly.GetTypes().Where(r => (r.Name.EndsWith("Handler") || r.Name.EndsWith("Pipeline")) && !r.IsAbstract && !r.IsInterface))
{
    builder.Services.AddScoped(type);
}

builder.Services.AddScoped<Dispatcher>();

foreach (var type in typeof(Program).Assembly.GetTypes()
    .Where(x => x.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(INotificationHandler<>))
    && !x.IsAbstract && !x.IsInterface))
{
    builder.Services.AddScoped(
        type.GetInterfaces().First(x => x.GetGenericTypeDefinition() == typeof(INotificationHandler<>)),
        type
    );
}

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.RegisterCreateCourseEndpoint();
app.RegisterCreateUserEndpoint();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
