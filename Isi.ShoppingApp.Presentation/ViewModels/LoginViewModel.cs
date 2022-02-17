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
    public delegate void LoginFailedHandler(string message);
    class LoginViewModel : ViewModel
    {
        public UserService userService;
        public DelegateCommand LoginCommand { get; }
        public ObservableCollection<User> Users { get; }
        public System.Security.SecureString SecuredPassword { get; }

        public event LoginSucceededHandler LoginSucceeded;
        public event LoginFailedHandler FailedLogin;

        private string username;
        public string Username
        {
            get => username;
            set
            {
                if(IsInputValid(value))
                {
                    username = value;
                    LoginCommand.NotifyCanExecuteChanged();
                    NotifyPropertyChanged(nameof(Username));
                }
            }
        }


        private string password;
        public string Password
        {
            get => password;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    password = value;
                    NotifyPropertyChanged(nameof(Password));
                }
            }

        }

        private HashedPassword hashedPassword;
        public HashedPassword HashedPassword
        {
            get => hashedPassword;
            set
            {
                if (value != null)
                {
                    hashedPassword = value;
                    NotifyPropertyChanged(nameof(HashedPassword));
                }
            }
  
        }

        private bool loggedIn;
        public bool IsLoggedIn
        {
            get => loggedIn;
            set
            {
                loggedIn = value;
            }
        }

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
            return !string.IsNullOrWhiteSpace(username)
                && !string.IsNullOrWhiteSpace(password);
        }

        private void LogIn(object _)
        {
            if (CanLogIn(_))
            { 
                if (IsUsernameExistant(Username))
                {
                    HashedPassword = GetHashedPassword(Username);
                    if (ValidateLogin(Password, HashedPassword))
                    {
                        IsLoggedIn = true;
                        LoginSucceeded?.Invoke(); //WILL CLOSE CURRENT WINDOW AND OPEN NEW ONE (?)
                        ClearFields();
                    }
                    else
                    {
                        FailedLogin?.Invoke("Username or password is incorrect.");
                    }
                }
                else
                {
                    FailedLogin?.Invoke("Username does not exist.");
                }
            }
            else
            {
                FailedLogin?.Invoke("Could not log in. Username or password is invalid.");
            }

            ClearFields();
        }

        private bool IsInputValid(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        private bool IsUsernameExistant(string username)
        {
            return userService.UserExist(username);
        }

        private HashedPassword GetHashedPassword(string username)
        {
            return HashedPassword = userService.GetUserPassword(username);
        }

       private bool ValidateLogin(string password, HashedPassword hashedPassword)
       {
            PasswordResult result = PasswordHasher.CheckPassword(password, hashedPassword);
            return result == PasswordResult.Correct;
       }

        private void ClearFields()
        {
            Username = string.Empty;
            Password = string.Empty;
            HashedPassword = null;
        }
    }
}
