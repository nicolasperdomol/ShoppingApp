using Isi.ShoppingApp.Core.Entities;
using Isi.Utility.Authentication;
using Isi.Utility.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Windows;

namespace Isi.ShoppingApp.Presentation.ViewModels
{
    public delegate void SignUpSucceededHandler(string message);


    class SignUpViewModel : ViewModel
    {
        public DelegateCommand SignUpCommand { get; }

        public event SignUpSucceededHandler SignUpSucceeded;

        //public SecureString SecuredPassword
        //{
        //    get => securedPassword;
        //    set
        //    {
        //        securedPassword = value;
        //    }
        //}
        //private SecureString securedPassword;

        public string FirstName
        {
            get => firstName;
            set
            {
                if (IsInputValid(value))
                {
                    firstName = value;
                    NotifyPropertyChanged(nameof(FirstName));
                    SignUpCommand.NotifyCanExecuteChanged();
                }
            }
        }
        private string firstName;

        public string LastName
        {
            get => lastName;
            set
            {
                if (IsInputValid(value))
                {
                    lastName = value;
                    NotifyPropertyChanged(nameof(LastName));
                    SignUpCommand.NotifyCanExecuteChanged();
                }
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
            set
            {
                if (IsInputValid(value))
                {
                    username = value;
                    NotifyPropertyChanged(nameof(Username));
                    SignUpCommand.NotifyCanExecuteChanged();
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
                    NotifyPropertyChanged(nameof(Password));
                    SignUpCommand.NotifyCanExecuteChanged();
                }

            }
        }
        private string password;

        public HashedPassword HashedPassword
        {
            get => hashedPassword;
            set
            {
                hashedPassword = PasswordHasher.HashPassword(Password);
            }
        }
        private HashedPassword hashedPassword;

        public bool IsAdmin
        {
            get => isAdmin;
            set
            {
                isAdmin = value;
            }
        }
        private bool isAdmin;

        public SignUpViewModel()
        {
            SignUpCommand = new DelegateCommand(SignUp, CanSignUp);
        }

        private bool CanSignUp(object _)
        {
            return !string.IsNullOrWhiteSpace(firstName)
                && !string.IsNullOrWhiteSpace(lastName)
                && !string.IsNullOrWhiteSpace(username)
                && !string.IsNullOrWhiteSpace(password);
        }

        private void SignUp(object _)
        {

            if (CanSignUp(_))
            {
               //IsAdmin = false;
               //User user = new User(FirstName, LastName, Username, HashedPassword, IsAdmin);
               SignUpSucceeded?.Invoke("Successfully created your account.");
                Trace.WriteLine("Signing up"); //FOR TESTING PURPOSES
            }
        }


        private void ClearFieldProperties()
        {
            FirstName = "";
            LastName = "";
            Username = "";
            Password = "";
        }

        private bool IsInputValid(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Username and password can only contain 9 characters and cannot contain spaces", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }

    }






}
