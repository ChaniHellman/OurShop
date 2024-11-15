using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Zxcvbn;


namespace Services
{
    public class UserService: IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User getUserById(int id)
        {
            return _userRepository.getUserById(id);
        }
        public User addUser(User user)
        {
            int PasswordStrength = checkPasswordStrength(user.Password);
            if (PasswordStrength > 2)
                return _userRepository.addUser(user);
            else
                throw new Exception(PasswordStrength.ToString());
        }
        //llll

        public User login(string email, string password)
        {
            return _userRepository.login(email, password);
        }

        public User updateUser(int id, User userToUpdate)
        {
            return _userRepository.updateUser(id, userToUpdate);
        }

        public int checkPasswordStrength(string password)
        {
            return Zxcvbn.Core.EvaluatePassword(password).Score; ;
        }
    }


}

