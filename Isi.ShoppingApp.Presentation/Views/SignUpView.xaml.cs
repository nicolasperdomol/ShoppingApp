using Isi.ShoppingApp.Presentation.ViewModels;
using System.Windows;

namespace Isi.ShoppingApp.Presentation.Views
{
    public partial class SignUpView : Window
    {
        private const int MaxCharacter = 9;
        public SignUpView()
        {
            SignUpViewModel viewModel = new SignUpViewModel();
            InitializeComponent();
            DataContext = viewModel;
            viewModel.SignUpSucceeded += OnSignUpSucceeded;
        }

       //TODO GET SECURED PASSWORD
       //private void OnSignUpClicked()
       //{
       //    LoginViewModel loginView = new LoginViewModel();
       //    if (passwordField.Password != null
       //        && passwordField.Password.Length <= MaxCharacter)
       //    {
       //        SignUpViewModel signUpViewModel = new SignUpViewModel();
       //        signUpViewModel.Password = passwordField.Password;
       //    }
       //}
        private void OnSignUpSucceeded(string message)
        {
            MessageBox.Show(message, "Creating account", MessageBoxButton.OK, MessageBoxImage.Information);
            
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();
        }
    }
}
