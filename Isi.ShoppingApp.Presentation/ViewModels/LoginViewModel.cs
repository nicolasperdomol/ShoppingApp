using Isi.Utility.ViewModels;
using Isi.ShoppingApp.Core.Entities;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Isi.ShoppingApp.Presentation.ViewModels
{
    public delegate void ActionSucceededHandler(string message);

    class LoginViewModel : ViewModel
    {
        public DelegateCommand LoginCommand { get; }
        public DelegateCommand SignUpCommand { get; }

        public event ActionSucceededHandler SignUpSucceeded;

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) 
                { 
                    username = value;
                    LoginCommand.NotifyCanExecuteChanged();
                    SignUpCommand.NotifyCanExecuteChanged();
                }

            }

        }


        public string Password
        { 

            get 
            {
                return password;
            } 
            set
            {
                if(!string.IsNullOrWhiteSpace(value))
                {
                    password = value;
                    LoginCommand.NotifyCanExecuteChanged();
                    SignUpCommand.NotifyCanExecuteChanged();
                }

            }
        }

        private string username;
        private string password;
        public LoginViewModel() 
        {
            SignUpCommand = new DelegateCommand(SignUp, CanSignUp);
            LoginCommand = new DelegateCommand(LogIn, CanLogIn);
        }

        private bool CanSignUp(object _)
        {
            return !string.IsNullOrWhiteSpace(username)
                && !string.IsNullOrWhiteSpace(password);
        }

        private void SignUp(object _) {

            if (CanSignUp(_))
            {

                Username = username;
                Password = password;
                Trace.WriteLine("Signing up");
            }
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
                //login, close current window + open main application window
                Trace.WriteLine("Logging in");
            }
        }

        private void ClearFieldProperties()
        {
            Username = "";
            Password = "";
        }

        private bool IsInputValid(string input)
        {
            if(!string.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Username and password can only contain 9 characters and cannot contain spaces","Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }

        private void CreateUser(string username, string password)
        {
            User user = new User(username, password, false);
            SignUpSucceeded?.Invoke("Successfully created");
        }
    }
}
