using Isi.ShoppingApp.Presentation.ViewModels;
using System;
using System.Diagnostics;
using System.Windows;

namespace Isi.ShoppingApp.Presentation.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            LoginViewModel viewModel = new LoginViewModel();
            DataContext = viewModel;
            viewModel.LoginSucceeded += OnLoginSucceeded;
            signUpButton.Click += OnSignUpButtonClicked;
        }

        //TODO open one window
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

        //TODO GET SECURED PASSWORD
    }
}
