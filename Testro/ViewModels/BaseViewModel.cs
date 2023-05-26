using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using MySqlConnector;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Testro.Models;
using System.Runtime.ConstrainedExecution;
using ZXing;

namespace Testro.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public void DisplayErrorAlert(string title)
        {
            Device.BeginInvokeOnMainThread(() => {
                Shell.Current.DisplayAlert("Помилка!", title, "Окей");
            });
        }
        public void DisplaySuccessAlert(string title)
        {
            Device.BeginInvokeOnMainThread(() => {
                Shell.Current.DisplayAlert("Успішно!", title, "Окей");
            });
        }
        public async Task<bool> DisplayConfirmAlert(string title, string message, string accept = "Так", string cancel = "Ні")
        {
            return await Shell.Current.DisplayAlert(title, message, accept, cancel);
        }

        public T GetDataBaseRequestResult<T>(Func<MySqlConnection, T> function)
        {
            MySqlConnection connection = DataBaseConnectionInstance;

            T result = default;
            try 
            { 
                result = function.Invoke(connection); 
            } 
            catch (Exception e)
            { 
                DisplayErrorAlert(e.Message);
            }

            return result;
        }

        public static bool ChangedRows(string query, MySqlConnection connection)
        {
            MySqlDataReader reader = new MySqlCommand(query, connection).ExecuteReader();
            bool result = reader.RecordsAffected > 0;
            reader.Close();
            return result;
        }

        public static bool GetHasRowsAndClose(string query, MySqlConnection connection)
        {
            MySqlDataReader reader = new MySqlCommand(query, connection).ExecuteReader();
            bool result = reader.HasRows;
            reader.Close();
            return result;
        }

        public static T GetFirstValueAndClose<T>(string query, MySqlConnection connection, string fieldName)
        {
            MySqlDataReader reader = new MySqlCommand(query, connection).ExecuteReader();
            object result = default;

            Dictionary<Type, Action> typeSwitch = new Dictionary<Type, Action>
            {
                { typeof(int), () => result = reader.GetInt32(fieldName) },
                { typeof(long), () => result = reader.GetInt64(fieldName) },
                { typeof(string), () => result = reader.GetString(fieldName) }
            };

            if (reader.HasRows)
            {
                reader.Read();
                typeSwitch[typeof(T)].Invoke();
            }

            reader.Close();
            return (T)result;
        }

        public static List<T> GetAllValues<T>(string query, MySqlConnection connection, string fieldName)
        {
            MySqlDataReader reader = new MySqlCommand(query, connection).ExecuteReader();
            List<object> values = new List<object>();

            Dictionary<Type, Action> typeSwitch = new Dictionary<Type, Action>
            {
                { typeof(int), () => values.Add(reader.GetInt32(fieldName)) },
                { typeof(long), () => values.Add(reader.GetInt64(fieldName)) },
                { typeof(string), () => values.Add(reader.GetString(fieldName)) }
            };

            while (reader.Read())
                typeSwitch[typeof(T)].Invoke();

            reader.Close();
            return values.ConvertAll(value => (T)value);
        }

        public static long InsertValues(string query, MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            return command.LastInsertedId;
        }


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

        static readonly MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
        {
            Server = "10.0.2.2",
            Port = 3306,
            UserID = "root",
            Password = "",
            Database = "testro_db"
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
