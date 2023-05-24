using System;
using Testro.Models;
using Testro.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testro
{
    public partial class App : Application
    {

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
        }

        protected bool IsLoggedIn()
        {
            return Preferences.Get("USER_ID", User.UNKNOWN_ID) != User.UNKNOWN_ID;
        }
    }
}
