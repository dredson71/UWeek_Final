using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Repository.Context;

namespace Repository.Implementation
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext Context;

        public UserRepository(ApplicationDbContext Context)
        {
            this.Context = Context;
        }

        public bool Delete(int id)
        {
            try
            {
                var user = Context.Users.Single(x => x.Id == id);

                Context.Users.Remove(user);
                Context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public User Get(int id)
        {
            var user = new User();
            try
            {
                user = Context.Users.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                throw;
            }
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            var users = new List<User>();
            try
            {
                users = Context.Users.ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
            return users;
        }

        public bool Save(User entity)
        {
            try
            {
                Context.Users.Add(entity);
                Context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(User entity)
        {
            User user = new User
            {
                Name = entity.Name,
                Birth = entity.Birth,
                Password = entity.Password,
                Address = entity.Address
            };
            try
            {
                Context.Users.Add(user);
                Context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
    }
}
