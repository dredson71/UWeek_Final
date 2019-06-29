using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Repository;

namespace Service.Implementation
{
    public class UserService : IUserService
    {

        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool Delete(int id)
        {
            return userRepository.Delete(id);
        }

        public User Get(int id)
        {
            return userRepository.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public bool Save(User entity)
        {
            return userRepository.Save(entity);
        }

        public bool Update(User entity)
        {
            return userRepository.Update(entity);
        }
    }
}
