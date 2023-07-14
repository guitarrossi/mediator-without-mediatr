using MediatorWithoutMediatr.Entities;
using MediatorWithoutMediatr.UseCases.Course.Create;

namespace MediatorWithoutMediatr.Mapper
{
    public static class UseCaseToEntityConfiguration
    {
        public static Course MapToCourse(this CreateCourse createCourse)
        {
            return new Course(createCourse.Name, createCourse.Description, createCourse.InitialDate);
        }
    }
}
