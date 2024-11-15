using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        User addUser(User user);
        User getUserById(int id);
        User login(string email, string password);
        User updateUser(int id, User userToUpdate);
    }
}