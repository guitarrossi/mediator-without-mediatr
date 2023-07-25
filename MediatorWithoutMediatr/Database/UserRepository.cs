using MediatorWithoutMediatr.Entities;
using MediatorWithoutMediatr.Interfaces;

namespace MediatorWithoutMediatr.Database
{
    public class UserRepository : IUserRepository
    {
        private static IList<User> users = Enumerable.Empty<User>().ToList();
        public void Add(User course)
        {
            users.Add(course);
        }

        public User GetById(Guid Id)
        {
            return users.FirstOrDefault(c => c.Id == Id);
        }

    }
}
