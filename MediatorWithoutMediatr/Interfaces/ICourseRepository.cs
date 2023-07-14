using MediatorWithoutMediatr.Entities;

namespace MediatorWithoutMediatr.Interfaces
{
    public interface ICourseRepository
    {
        void Add(Course course);

        Course GetById(Guid Id);
    }
}
