using Testro.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using MySqlConnector;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Testro.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command SignUpCommand { get; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            SignUpCommand = new Command(OnSignUpClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            if (DoesUserExist())
            {
                string userId = GetUserId();

                if (userId.Length > 0)
                {
                    Preferences.Set("USER_ID", userId);
                    await Shell.Current.GoToAsync($"{nameof(MainPage)}");
                }
                else
                    DisplayAlert("Неправильний пароль, спробуйте знову!");
            }
            else
                DisplayAlert("Користувач з таким логіном не існує!");
        }

        private async void OnSignUpClicked(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(SignUpPage)}");
        }

        private string GetUserId()
        {
            string result = string.Empty;
            MySqlConnection connection = DataBaseConnectionInstance;

            try
            {
                string query = "SELECT * FROM `pupil_users` WHERE `pupil_login` = '" + UserLogin + 
                               "' AND `pupil_password` = '" + GetHash(UserPassword) + "'";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    result = reader.GetInt64("pupil_id").ToString();
                }

                reader.Close();
            }
            catch (Exception e)
            {
                DisplayAlert(e.Message);
            }

            connection.Close();
            return result;
        }

        private bool DoesUserExist()
        {
            bool result = false;
            MySqlConnection connection = DataBaseConnectionInstance;

            try
            {
                string query = "SELECT * FROM `pupil_users` WHERE `pupil_login` = '" + UserLogin + "'";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                result = reader.HasRows;
                reader.Close();
            }
            catch (Exception e)
            {
                DisplayAlert(e.Message);
            }

            connection.Close();
            return result;
        }

        private string _userLogin = string.Empty;
        public string UserLogin
        {
            get => _userLogin;
            set
            {
                SetProperty(ref _userLogin, value.Trim());
                LoginButtonEnabled = UserPassword != string.Empty && UserLogin != string.Empty;
            }
        }

        private string _userPassword = string.Empty;
        public string UserPassword {
            get => _userPassword;
            set
            {
                SetProperty(ref _userPassword, value.Trim());
                LoginButtonEnabled = UserPassword != string.Empty && UserLogin != string.Empty;
            }
        }

        private string _errorText = string.Empty;
        public string ErrorText {
            get => _errorText;
            set
            {
                SetProperty(ref _errorText, value.Trim());
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
