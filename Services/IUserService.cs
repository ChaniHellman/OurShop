using Entities;

namespace Services
{
    public interface IUserService
    {
        User addUser(User user);
        int checkPasswordStrength(string password);
        User getUserById(int id);
        User login(string email, string password);
        User updateUser(int id, User userToUpdate);
    }
}