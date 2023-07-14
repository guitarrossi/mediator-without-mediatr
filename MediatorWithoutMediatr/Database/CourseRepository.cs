using MediatorWithoutMediatr.Entities;
using MediatorWithoutMediatr.Interfaces;

namespace MediatorWithoutMediatr.Database
{
    public class CourseRepository : ICourseRepository
    {
        private static IList<Course> courses = Enumerable.Empty<Course>().ToList();
        public void Add(Course course)
        {
            courses.Add(course); 
        }

        public Course GetById(Guid Id)
        {
            return courses.FirstOrDefault(c => c.Id == Id);
        }
    }
}
