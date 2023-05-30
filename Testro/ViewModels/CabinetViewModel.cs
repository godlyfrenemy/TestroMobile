using MySqlConnector;
using Testro.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

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