using Isi.Utility.ViewModels;

namespace Isi.ShoppingApp.Presentation.ViewModels
{
    public delegate void ActionSucceededHandler(string message);

    class LoginViewModel : ViewModel
    {
        //TODO model the model class
        public DelegateCommand LoginCommand { get;  }
        public DelegateCommand SignUpCommand { get; }

        public event ActionSucceededHandler ActionSucceeded;

        public string Username 
        { 
            get 
            {
                return username;
            } 
            set
            {
                if(!string.IsNullOrWhiteSpace(value))
                    username = value;

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
                password = value;
            }
        }

        private string username;
        private string password;
        public LoginViewModel() 
        {
            SignUpCommand = new DelegateCommand(SignUp, CanSignUp);
        }

        private bool CanSignUp(object _)
        {
            //TODO check if password and username are valid
            return true;
        }

        private void SignUp(object _) {

            if (CanSignUp(_))
            {
                //TODO create username + password + store in database
                //display success message

                Trace.WriteLine("Signing up");
            }
        }

        private bool CanLogIn(object _)
        {
            //check if password/username pair is correct
            return true;
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
                return true;

            return false;
        }
    }
}
