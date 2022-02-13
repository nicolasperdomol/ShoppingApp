using Isi.ShoppingApp.Utilities
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isi.ShoppingApp.Core.Entities
{
     class Users
    {
        private int MaxCharacter = 9; //Max characters for username and password
        
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if(IsUsernameValid(value))
                    username = value;
            }
                
        }
        private string username;

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (IsPasswordValid(value))
                    password = value;
            }
        }
        private string password;

        public HashedPassword HashedPassword 
        { 
            get
            {
                return hashedPassword;
            }
            private set
            {
                hashedPassword = value;
            }
        }
        private HashedPassword hashedPassword;


        public bool IsAdmin
        {
            get
            {
                return isAdmin;
            }
            private set
            {
                isAdmin = value;
            }
        }
        private bool isAdmin;

        public Users(string username, string password, bool isAdmin)
        {
            Username = createUsername(username);
            HashedPassword = createPassword(password);
            IsAdmin = isAdmin;
        }

        private string createUsername(string username)
        {
            if (!string.IsNullOrWhiteSpace(username) 
                && (username.Length <= MaxCharacter))
                    return username;


            return null;
        }

        private HashedPassword createPassword(string password)
        {
            
            if(!string.IsNullOrWhiteSpace(password) 
                && password.Length <= MaxCharacter)
            {
                HashedPassword hashedPassword = PasswordHasher.HashPassword(password);
                return hashedPassword;
            }
            
            return null;
        }

     }
}
