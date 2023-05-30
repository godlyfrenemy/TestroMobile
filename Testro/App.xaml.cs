using Testro.Models;
using Testro.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Testro
{
    public partial class App : Application
    {
        public static bool IsOnTestingProcess { get; set; } = false;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            if (IsLoggedIn())
            {
                User.UserId = Preferences.Get("USER_ID", User.UNKNOWN_ID);
                User.UserDataId = Preferences.Get("USER_DATA_ID", User.UNKNOWN_ID);
                Shell.Current.GoToAsync($"//{nameof(Views.MainPage)}");
            }
            else
                Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            if (IsOnTestingProcess)
            {
                int index = Current.MainPage.Navigation.ModalStack.Count - 1;
                Page currPage = Current.MainPage.Navigation.ModalStack[index];
                (currPage as TestProcessPage).ForceEndTesting();
            }
        }

        protected bool IsLoggedIn()
        {
            return Preferences.Get("USER_ID", User.UNKNOWN_ID) != User.UNKNOWN_ID;
        }
    }
}
