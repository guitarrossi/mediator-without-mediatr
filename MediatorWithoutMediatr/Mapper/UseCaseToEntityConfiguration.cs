using MediatorWithoutMediatr.Entities;
using MediatorWithoutMediatr.UseCases.Course.Create;
using MediatorWithoutMediatr.UseCases.User;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MediatorWithoutMediatr.Mapper
{
    public static class UseCaseToEntityConfiguration
    {
        public static Course MapToCourse(this CreateCourse createCourse)
        {
            return new Course(createCourse.Name, createCourse.Description, createCourse.InitialDate);
        }

        public static User MapToUser(this CreateUser createUser)
        {
            return new User(createUser.Name, createUser.Password);
        }
    }
}
