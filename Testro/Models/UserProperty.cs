﻿using MySqlConnector;
using Testro.ViewModels;
using Xamarin.Forms;

namespace Testro.Models
{
    public class UserProperty : BaseNotify
    {
        public Command ModifyValueCommand { get; }
        public Command SaveLastValueCommand { get; }

        public UserProperty(string fieldNameForUser, string dataBaseFieldName) : base()
        {
            _dataBaseFieldName = dataBaseFieldName;
            _fieldNameForUser = fieldNameForUser;
            ModifyValueCommand = new Command(PropertyUnfocused);
            SaveLastValueCommand = new Command(PropertyFocused);
        }

        public bool? SetValueFromDataBase(MySqlConnection connection)
        {
            string query = "SELECT * FROM `pupils_data` WHERE `pupil_data_id` = '" + User.UserDataId + "'";
            PropertyValue = BaseViewModel.GetFirstValue<string>(query, connection, _dataBaseFieldName);
            return PropertyValue.Length > 0;
        }

        public void PropertyFocused()
        {
            _lastValue = _value;
        }
        public void PropertyUnfocused()
        {
            if (!(BaseViewModel.GetDataBaseRequestResult(ChangePropertyValueInDataBase) ?? false))
            {
                BaseViewModel.DisplayErrorAlert("Поле '" + _fieldNameForUser + "' не було змінене!");
                PropertyValue = _lastValue;
            }
            else if (_lastValue != PropertyValue)
                BaseViewModel.DisplaySuccessAlert("Поле '" + _fieldNameForUser + "' успішно змінене!");
        }

        private bool? ChangePropertyValueInDataBase(MySqlConnection connection)
        {
            string query = "UPDATE `pupils_data` SET `" + _dataBaseFieldName + "` = '" + PropertyValue +
                               "'  WHERE `pupil_data_id` = '" + User.UserDataId + "'";
            return BaseViewModel.ChangedRows(query, connection);
        }

        private readonly string _dataBaseFieldName;
        private readonly string _fieldNameForUser;

        private string _value = string.Empty;
        private string _lastValue = string.Empty;
        public string PropertyValue
        {
            get => _value;
            set
            {
                SetProperty(ref _value, value.Trim());
                OnPropertyChanged(nameof(PropertyValue));
            }
        }
    }
}
