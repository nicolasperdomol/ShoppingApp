using Isi.Utility.Authentication;

namespace Isi.ShoppingApp.Core.Entities
{
     public class User
    {
        private int MaxCharacter = 10;

        public string FirstName
        {
            get => firstName;
            set
            {
                if (IsNameValid(value))
                    firstName = value;
            }
        }
        private string firstName;

        public string LastName
        {
            get => lastName;
            set
            {
                if (IsNameValid(value))
                    lastName = value;
            }
        }
        private string lastName;

        public string FullName
        {
            get => firstName + " " + lastName;
        }

        public string Username
        {
            get => username;
            private set
            {
                if(IsInputValid(value))
                    username = value;
            }
                
        }
        private string username;

        public string Password
        {
            get => password;
            private set
            {
                if(IsInputValid(value))
                    password = value;
            }
        }
        private string password;

        public HashedPassword HashedPassword 
        { 
            get => hashedPassword;
            private set
            {
                hashedPassword = CreateHashedPassword(Password);
            }
        }
        private HashedPassword hashedPassword;

        public decimal Balance
        {
            get => balance;
            private set
            {
                if (value > 0)
                    balance = value;
            }
        }
        private decimal balance;

        public bool IsAdmin
        {
            get => isAdmin;
            private set
            {
                isAdmin = value;
            }
        }
        private bool isAdmin;

        public User(string firstName, string lastName, string username, HashedPassword hashedPassword, bool isAdmin)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            HashedPassword = CreateHashedPassword(Password);
            IsAdmin = isAdmin;
            Balance = 0;
        }

        private HashedPassword CreateHashedPassword(string password)
        {
            
            if(IsInputValid(password))
            {
                HashedPassword hashedPassword = PasswordHasher.HashPassword(password);
                return hashedPassword;
            }
            
            return null;
        }

        private bool IsNameValid(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                return true;

            return false;
        }

        private bool IsInputValid(string input)
        {
            if (!string.IsNullOrWhiteSpace(input)
                && input.Length <= MaxCharacter)
                return true;

            return false;
        }

        public void AddAmountToBalance(decimal amount)
        {
            if (amount > 0)
                Balance += amount;
        }

        public void SubtractAmountFromBalance(decimal amount)
        {
            if (amount <= Balance)
                Balance -= amount;
        }
     }
}
