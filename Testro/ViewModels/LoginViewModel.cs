using Testro.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using MySql.Data.MySqlClient;


namespace Testro.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            string userId = GetUserId();

            if(userId.Length > 0)
            {
                Preferences.Set("USER_ID", userId);
                Application.Current.MainPage = new AppShell();
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
            else
                ErrorText = "Такий користувач не існує, спробуйте знову";
        }

        private string GetUserId()
        {
            return "1";
            DataBaseConnection.Open();
            string query = "SELECT * FROM `pupil_users` WHERE `pupil_login` = '$login' AND `pupil_password` = 'password'";
            MySqlCommand command = new MySqlCommand(query, DataBaseConnection);
            command.Parameters.AddWithValue("@login", UserLogin);
            command.Parameters.AddWithValue("@password", GetHash(UserPassword));
            command.Prepare();
            MySqlDataReader reader = command.ExecuteReader();
            string result = string.Empty;

            if (reader.HasRows)
            {
                reader.Read();
                result = reader.GetString("pupil_id");
            }

            reader.Close();
            DataBaseConnection.Close();
            return result;
        }

        private string _userLogin = string.Empty;
        public string UserLogin
        {
            get => _userLogin;
            set
            {
                SetProperty(ref _userLogin, value);
                LoginButtonEnabled = UserPassword != string.Empty && UserLogin != string.Empty;
            }
        }

        private string _userPassword = string.Empty;
        public string UserPassword {
            get => _userPassword;
            set
            {
                SetProperty(ref _userPassword, value);
                LoginButtonEnabled = UserPassword != string.Empty && UserLogin != string.Empty;
            }
        }

        private string _errorText = string.Empty;
        public string ErrorText {
            get => _errorText;
            set
            {
                SetProperty(ref _errorText, value);
            } 
        }

        private bool _loginButtonEnabled = false;
        public bool LoginButtonEnabled
        {
            get => _loginButtonEnabled;
            set => SetProperty(ref _loginButtonEnabled, value);
        }
    }
}
