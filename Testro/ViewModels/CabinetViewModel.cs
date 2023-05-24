using MySqlConnector;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Testro.Models;
using Testro.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZXing;

namespace Testro.ViewModels
{
    public class CabinetViewModel : BaseViewModel
    {
        
        public Command SignOutCommand { get; }

        public CabinetViewModel()
        {
            Title = "Кабінет користувача";
            SignOutCommand = new Command(OnSignOutClicked);
            UserName = new UserProperty(this, "ім'я", "pupil_name");
            UserSurname = new UserProperty(this, "прізвище", "pupil_surname");
            UserForm = new UserProperty(this, "клас", "pupil_form");
        }

        public void OnAppearing()
        {
            GetDataBaseRequestResult(UserName.SetValueFromDataBase);
            GetDataBaseRequestResult(UserSurname.SetValueFromDataBase);
            GetDataBaseRequestResult(UserForm.SetValueFromDataBase);
        }

        async void OnSignOutClicked()
        {
            if (await DisplayConfirmAlert("Вихід з аккаунту", "Ви впевнені, що хочете вийти?"))
            {
                Preferences.Remove("USER_ID");
                await Shell.Current.GoToAsync($"//{nameof(Views.LoginPage)}", true);
            }
        }

        private bool? ChangeUserDataInDataBase(MySqlConnection connection, string fieldName, string fieldValue)
        {
            string query = "UPDATE `pupils_data` SET `" + fieldName + "` = '" + fieldValue +
                               "'  WHERE `pupil_data_id` = '" + User.UserDataId + "'";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            bool changedInDataBase = reader.RecordsAffected == 1;
            reader.Close();
            return changedInDataBase;
        }

        public class UserProperty : INotifyPropertyChanged
        {
            public Command ModifyValueCommand { get; }
            public Command SaveLastValueCommand { get; }
            public UserProperty(CabinetViewModel viewModel, string fieldNameForUser, string dataBaseFieldName)
            {
                _viewModel = viewModel;
                _dataBaseFieldName = dataBaseFieldName;
                _fieldNameForUser = fieldNameForUser;
                ModifyValueCommand = new Command(PropertyUnfocused);
                SaveLastValueCommand = new Command(PropertyFocused);
            }

            public bool? SetValueFromDataBase(MySqlConnection connection)
            {
                string query = "SELECT * FROM `pupils_data` WHERE `pupil_data_id` = '" + User.UserDataId + "'";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                bool result = reader.HasRows;
                if (result)
                {
                    reader.Read();
                    PropertyValue = reader.GetString(_dataBaseFieldName);
                    result = PropertyValue.Length > 0;
                }
                reader.Close();
                return result;
            }

            private readonly CabinetViewModel _viewModel;
            private readonly string _dataBaseFieldName;
            private readonly string _fieldNameForUser;

            private string _value = string.Empty;
            private string _lastValue = string.Empty;
            public string PropertyValue
            {
                get => _value;
                set
                {
                    _viewModel.SetProperty(ref _value, value.Trim());
                    OnPropertyChanged(nameof(PropertyValue));
                }
            }

            public void PropertyFocused()
            {
                _lastValue = _value;
            }
            public void PropertyUnfocused()
            {
                if (!(_viewModel.GetDataBaseRequestResult(ChangePropertyValueInDataBase) ?? false))
                {
                    _viewModel.DisplayErrorAlert("Поле '" + _fieldNameForUser + "' не було змінене!");
                    PropertyValue = _lastValue;
                }
                else if(_lastValue != PropertyValue)
                    _viewModel.DisplaySuccessAlert("Поле '" + _fieldNameForUser + "' успішно змінене!");
            }

            private bool? ChangePropertyValueInDataBase(MySqlConnection connection)
            {
                return _viewModel.ChangeUserDataInDataBase(connection, _dataBaseFieldName, PropertyValue);
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private UserProperty _userName;
        public UserProperty UserName
        {
            get => _userName;
            set
            {
                SetProperty(ref _userName, value);
            }
        }


        private UserProperty _userSurname;
        public UserProperty UserSurname
        {
            get => _userSurname;
            set
            {
                SetProperty(ref _userSurname, value);
            }
        }

        private UserProperty _userForm;
        public UserProperty UserForm
        {
            get => _userForm;
            set
            {
                SetProperty(ref _userForm, value);
            }
        }

#if false
        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        } 
#endif
    }
}