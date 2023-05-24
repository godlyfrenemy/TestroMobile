using System;
using System.Collections.Generic;
using Testro.ViewModels;
using Testro.Views;
using Xamarin.Forms;

namespace Testro
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
            Routing.RegisterRoute(nameof(CabinetPage), typeof(CabinetPage));
        }

    }
}
