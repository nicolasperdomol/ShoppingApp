using Isi.ShoppingApp.Core.Entities;
using Isi.ShoppingApp.Domain.Services;
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
    public delegate void SignUpFailedHandler(string message);

    class SignUpViewModel : ViewModel
    {
        UserService userService;
        public DelegateCommand SignUpCommand { get; }

        public event SignUpSucceededHandler SignUpSucceeded;
        public event SignUpFailedHandler SignUpFailed;


        private string firstName;
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

        private string lastName;
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

        public string FullName
        {
            get => firstName + " " + lastName;
        }

        private string username;
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


        private bool isAdmin;
        public bool IsAdmin
        {
            get => isAdmin;
            set
            {
                isAdmin = value;
            }
        }

        private decimal balance;
        public decimal Balance
        {
            get => balance;
            set
            {
                if (value > 0)
                    balance = value;
            }
        }

        public SignUpViewModel()
        {
            userService = new UserService();
            SignUpCommand = new DelegateCommand(SignUp, CanSignUp);
        }

        //TODO
        private bool CanSignUp(object _)
        {
            return !string.IsNullOrWhiteSpace(firstName)
                && !string.IsNullOrWhiteSpace(lastName)
                && !string.IsNullOrWhiteSpace(username)
                && hashedPassword != null;
        }

        private void SignUp(object _)
        {

            if (CanSignUp(_))
            {
               userService.AddUser(new User(FirstName, LastName, Username, HashedPassword, IsAdmin, Balance));
               SignUpSucceeded?.Invoke("Successfully created your account.");
            }
            SignUpFailed?.Invoke("Could not successfully sign up");
        }


        private void ClearFieldProperties()
        {
            FirstName = "";
            LastName = "";
            Username = "";
            HashedPassword = null;
        }

        private bool IsInputValid(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

    }






}
