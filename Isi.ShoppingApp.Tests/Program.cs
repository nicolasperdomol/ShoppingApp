using Isi.ShoppingApp.Core.Entities;
using Isi.ShoppingApp.Data.Repositories;
using Isi.ShoppingApp.Domain.Services;
using Isi.Utility.Authentication;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Isi.ShoppingApp.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            //Isi.ShoppingApp.Domain.Services.Inventory inventory = new Domain.Services.Inventory();

            UserRepository repository = new UserRepository();
            User test = new User("Mia", "Taylor", "mtaylor", PasswordHasher.HashPassword("goudacheese10"), true, 200);
            User user = repository.CreateUser(test);



          //bool exist = repository.UserExist("GlutenFouri");
          //
          //if (exist)
          //{
          //    Console.WriteLine("Created");
          //}
          //else
          //{
          //    Console.WriteLine("Not created");
          //}
          //
          //List<User> users = repository.GetUsers();
          //foreach (User username in users)
          //{
          //    Console.WriteLine(username);
          //}
        }  
    }
}
