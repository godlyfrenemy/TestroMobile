using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Testro.Views;
using Xamarin.Forms;

namespace Testro.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
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

        public static void DisplayErrorAlert(string title)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Shell.Current.DisplayAlert("Помилка!", title, "Окей");
            });
        }
        public static void DisplaySuccessAlert(string title)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Shell.Current.DisplayAlert("Успішно!", title, "Окей");
            });
        }

        public static Task PushModalAsync(Page page)
        {
            return Application.Current.MainPage.Navigation.PushModalAsync(page);
        }

        public static Task<Page> PopModalAsync()
        {
            return Application.Current.MainPage.Navigation.PopModalAsync();
        }

        public static Task<bool> DisplayConfirmAlert(string title, string message, string accept = "Так", string cancel = "Ні")
        {
            return Shell.Current.DisplayAlert(title, message, accept, cancel);
        }

        public static T GetDataBaseRequestResult<T>(Func<MySqlConnection, T> function)
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

        public static bool GetHasRows(string query, MySqlConnection connection)
        {
            MySqlDataReader reader = new MySqlCommand(query, connection).ExecuteReader();
            bool result = reader.HasRows;
            reader.Close();
            return result;
        }

        public static T GetFirstValue<T>(string query, MySqlConnection connection, string fieldName)
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

        public static bool UpdateValues(string query, MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            return command.ExecuteNonQuery() != 0;
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

        static public MySqlConnection DataBaseConnectionInstance
        {
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
