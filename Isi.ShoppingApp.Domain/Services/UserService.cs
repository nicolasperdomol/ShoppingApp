using Isi.ShoppingApp.Core.Entities;
using Isi.ShoppingApp.Data.Repositories;
using Isi.Utility.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isi.ShoppingApp.Domain.Services
{
    public class UserService
    {
        UserRepository repository;
        public UserService()
        {
            repository = new UserRepository();
        }

        public List<User> GetUsers()
        {
            return repository.GetUsers();
        }

        public User GetUser(string username)
        {
            return repository.GetUser(username);
        }

        public HashedPassword GetUserPassword(string username)
        {
            return repository.GetUserPassword(username);
        }

        public User AddUser(User user)
        {
            return repository.CreateUser(user);
        }

        public bool DeleteUser(User user)
        {
            return repository.DeleteUser(user.Username);
        }
    }
}
