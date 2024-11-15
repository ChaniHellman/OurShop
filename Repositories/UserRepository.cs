using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {

        }
        string filePath = "M:\\WebApi\\OurShop\\Repositories\\Data.txt";

        public User getUserById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        return user;
                }
            }
            return null;
        }

        public User addUser(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return (user);
        }

        public User login(string email, string password)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == email && user.Password == password)
                        return user;
                }
            }
            return null;
        }

        public User updateUser(int id, User userToUpdate)
        {
            userToUpdate.UserId = id;
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
                return userToUpdate;
            }
            return null;
        }
    }
}
