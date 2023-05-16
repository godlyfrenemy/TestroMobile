using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Testro.Models;
using Testro.Services;
using Xamarin.Forms;
using MySqlConnector;
using System.Security.Cryptography;
using System.Text;
using System.Data;

namespace Testro.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public void DisplayAlert(string title)
        {
            Device.BeginInvokeOnMainThread(() => {
                Shell.Current.DisplayAlert("Упс", title, "Окей");
            });
        }

        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
 
            return Convert.ToBase64String(hash);
        }

        static MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
        {
            Server = "10.0.2.2",
            Port = 3306,
            UserID = "root",
            Password = "",
            Database = "u981289406_testro_main"
        };

       static public MySqlConnection DataBaseConnectionInstance {
            get
            {
                MySqlConnection _databaseConnection = new MySqlConnection(builder.ConnectionString);
                _databaseConnection.Open();
                return _databaseConnection;
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
