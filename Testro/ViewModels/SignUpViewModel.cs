﻿using Testro.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using MySqlConnector;
using System;
using System.Linq;
using System.Threading.Tasks;
using ZXing;

namespace Testro.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        public Command SignUpCommand { get; }

        public SignUpViewModel()
        {
            SignUpCommand = new Command(OnSignUpClicked);
        }

        private async void OnSignUpClicked(object obj)
        {
            if (GetDataBaseRequestResult(CheckIfUserExists) ?? false)
            {
                long newUserId = GetDataBaseRequestResult(AddNewUser) ?? -1;

                if (newUserId != -1)
                {
                    Preferences.Set("USER_ID", newUserId.ToString());
                    await Shell.Current.GoToAsync($"{nameof(MainPage)}");
                }
                else
                    DisplayErrorAlert("Не вдалося додати користувача, спробуйте пізніше");
            }
            else
                DisplayErrorAlert("Такий користувач вже існує!");
        }

        private bool? CheckIfUserExists(MySqlConnection connection)
        {
            string query = "SELECT * FROM `pupil_users` WHERE `pupil_login` = '" + UserLogin + "'";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            bool result = reader.HasRows;
            reader.Close();
            return result;
        }

        private long? AddNewUser(MySqlConnection connection)
        {
            string query = "INSERT INTO pupil_users(`pupil_login`, `pupil_password`) VALUES('" + UserLogin + "', '" + GetHash(UserPassword) + "')";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            return command.LastInsertedId;
        }

        private int _enteredFieldsCount = 0;
        private int EnteredFieldsCount
        {
            get => _enteredFieldsCount;
            set
            {
                SetProperty(ref _enteredFieldsCount, value);
                SignUpButtonEnabled = _enteredFieldsCount == 4;
            }
        }

        private void SetEnteredFieldsCount(string previousValue, string currentValue)
        {
            if (previousValue.Length > 0)
            {
                if (currentValue.Length == 0) EnteredFieldsCount--;
            }
            else
            {
                if (currentValue.Length > 0) EnteredFieldsCount++;
            }
        }

        private string _userName = string.Empty;
        public string UserName
        {
            get => _userName;
            set
            {
                SetEnteredFieldsCount(_userName, value.Trim());
                SetProperty(ref _userName, value.Trim());
            }
        }

        private string _userSurname = string.Empty;
        public string UserSurname
        {
            get => _userSurname;
            set
            {
                SetEnteredFieldsCount(_userSurname, value.Trim());
                SetProperty(ref _userSurname, value.Trim());
            }
        }

        private string _userLogin = string.Empty;
        public string UserLogin
        {
            get => _userLogin;
            set
            {
                SetEnteredFieldsCount(_userLogin, value.Trim());
                SetProperty(ref _userLogin, value.Trim());
            }
        }

        private string _userPassword = string.Empty;
        public string UserPassword {
            get => _userPassword;
            set
            {
                SetEnteredFieldsCount(_userPassword, value.Trim());
                SetProperty(ref _userPassword, value.Trim());
            }
        }

        private bool _signUpButtonEnabled = false;
        public bool SignUpButtonEnabled
        {
            get => _signUpButtonEnabled;
            set => SetProperty(ref _signUpButtonEnabled, value);
        }
    }
}
