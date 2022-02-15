using Isi.Utility.Authentication;

namespace Isi.ShoppingApp.Core.Entities
{
     public class User
    {
        private int MaxCharacter = 9; //Max characters for username and password
        
        public string Username
        {
            get
            {
                return username;
            }
            private set
            {
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
            private set
            {
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

        public User(string username, string password, bool isAdmin)
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
