using Isi.ShoppingApp.Presentation.ViewModels;
using System.Windows.Controls;

namespace Isi.ShoppingApp.Presentation.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
            LoginViewModel viewModel = new LoginViewModel();
            DataContext = viewModel;
            //add listeners for success message
        }
    }
}
