using MediatorWithoutMediatr.Entities;

namespace MediatorWithoutMediatr.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);

        User GetById(Guid Id);
    }
}
