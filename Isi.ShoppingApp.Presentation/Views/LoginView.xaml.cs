using Isi.ShoppingApp.Presentation.ViewModels;
using Isi.Utility.Authentication;
using System;
using System.Diagnostics;
using System.Windows;

namespace Isi.ShoppingApp.Presentation.Views
{
    public partial class LoginView : Window
    {
        LoginViewModel viewModel;
        public LoginView()
        {
            InitializeComponent();
            viewModel = new LoginViewModel();
            DataContext = viewModel;
            viewModel.LoginSucceeded += OnLoginSucceeded;
            signUpButton.Click += OnSignUpButtonClicked;
        }

        private void OnSignUpButtonClicked(object sender, RoutedEventArgs e)
        {
            SignUpView signUpView = new SignUpView();
            signUpView.Show();
            this.Close();
        }

        private void OnLoginSucceeded()
        {
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
            this.Close();
            Trace.WriteLine("Opening main window");
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            viewModel.LoginCommand.NotifyCanExecuteChanged();
            viewModel.Password = passwordBox.Password; //TODO
        }

        private void ClearFields()
        {
            usernameTextBox.Clear();
        }

    }
}
