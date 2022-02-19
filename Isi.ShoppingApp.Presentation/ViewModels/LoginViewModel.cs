using Isi.Utility.ViewModels;
using Isi.ShoppingApp.Core.Entities;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Isi.Utility.Authentication;
using System.Collections.ObjectModel;
using Isi.ShoppingApp.Presentation.Views;
using Isi.ShoppingApp.Domain.Services;

namespace Isi.ShoppingApp.Presentation.ViewModels
{
    public delegate void LoginSucceededHandler();
    class LoginViewModel : ViewModel
    {
        public UserService userService;
        public DelegateCommand LoginCommand { get; }
        public ObservableCollection<User> Users { get; }
        public System.Security.SecureString SecuredPassword { get; }

        public event LoginSucceededHandler LoginSucceeded;

        public string Username
        {
            get => username;
            set
            {
                if(IsInputValid(value))
                {
                    username = value;
                    LoginCommand.NotifyCanExecuteChanged();
                }
            }
        }
        private string username;

        public string Password
        {
            get => password;
            set
            {
                if (IsInputValid(value))
                {
                    password = value;
                    LoginCommand.NotifyCanExecuteChanged();
                }

            }
        }
        private string password;

        public HashedPassword HashedPassword
        {
            get => hashedPassword;
            set
            {
                if (value != null )
                    hashedPassword = value;
            }
  
        }
        private HashedPassword hashedPassword;

        public bool IsLoggedIn
        {
            get => loggedIn;
            set
            {
                loggedIn = value;
            }
        }
        private bool loggedIn;

        public bool IsLoggedOut
        {
            get => !loggedIn;
        }

        public LoginViewModel() 
        {
            userService = new UserService();
            LoginCommand = new DelegateCommand(LogIn, CanLogIn);
        }

        private bool CanLogIn(object _)
        {
            return !string.IsNullOrWhiteSpace(Username)
                    && !string.IsNullOrWhiteSpace(Password);
        }

        private void LogIn(object _)
        {
            if (CanLogIn(_))
            { 
                if (IsUsernameValid(Username))
                {
                    HashedPassword = getHashedPasswordOfUsername(Username);
                    if (ValidateLogin(Password, HashedPassword))
                    {
                        IsLoggedIn = true;
                        LoginSucceeded?.Invoke(); //WILL CLOSE CURRENT WINDOW AND OPEN NEW ONE (?)
                        Trace.WriteLine("Logging in"); //FOR TESTING PURPOSES
                    }
                    MessageBox.Show("Username and password combination does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                MessageBox.Show("Username or password is invalid.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsInputValid(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
                return true;

            return false;
        }

        private bool IsUsernameValid(string username)
        {
            if (userService.GetUser(username) != null)
                return true;

            MessageBox.Show("Username does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        private HashedPassword getHashedPasswordOfUsername(string username)
        {
            if (IsUsernameValid(username)) 
            {
                return HashedPassword = userService.GetUserPassword(username);
            }
            return null;
        }

       private bool ValidateLogin(string password, HashedPassword hashedPassword)
        {
            PasswordResult result = PasswordHasher.CheckPassword(password, hashedPassword);
            return (result == PasswordResult.Correct);
        }


    }
}
