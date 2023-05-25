using Testro.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using MySqlConnector;
using System;
using System.Linq;
using System.Threading.Tasks;
using ZXing;
using Testro.Models;

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
            if (GetDataBaseRequestResult(DoesUserExist) ?? false)
            {
                long userId = GetDataBaseRequestResult(GetUserId) ?? -1;

                if (userId != -1)
                {
                    User.UserId = userId;
                    User.UserDataId = GetDataBaseRequestResult(GetUserDataId) ?? -1;
                    await Shell.Current.GoToAsync($"//{nameof(Views.MainPage)}", true);
                    await Task.Delay(2000);
                    UserLogin = string.Empty;
                    UserPassword = string.Empty;
                }
                else
                    DisplayErrorAlert("Неправильний пароль, спробуйте знову!");
            }
            else
                DisplayErrorAlert("Користувач з таким логіном не існує!");
        }

        private async void OnSignUpClicked(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(SignUpPage)}");
        }

        private long? GetUserId(MySqlConnection connection)
        {
            string query = "SELECT * FROM `pupil_users` WHERE `pupil_login` = '" + UserLogin +
                               "' AND `pupil_password` = '" + GetHash(UserPassword) + "'";
            return GetFirstValueAndClose<long>(query, connection, "pupil_id");
        }

        private long? GetUserDataId(MySqlConnection connection)
        {
            string query = "SELECT * FROM `pupil_users` WHERE `pupil_login` = '" + UserLogin +
                               "' AND `pupil_password` = '" + GetHash(UserPassword) + "'";
            return GetFirstValueAndClose<long>(query, connection, "pupil_data_id");
        }

        private bool? DoesUserExist(MySqlConnection connection)
        {
            string query = "SELECT * FROM `pupil_users` WHERE `pupil_login` = '" + UserLogin + "'";
            return GetHasRowsAndClose(query, connection);
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
