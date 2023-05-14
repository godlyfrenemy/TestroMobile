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
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }

        

    }
}
