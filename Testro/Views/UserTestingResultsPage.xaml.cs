using System;
using System.Collections.ObjectModel;
using Testro.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserTestingResultsPage : ContentPage
    {
        public UserTestingResultsPage()
        {
            InitializeComponent();
            Title = "Результати тестувань";
            BindingContext = new UserTestingResultsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as UserTestingResultsViewModel).OnAppearing();
        }

        public void Handle_ItemTapped(object sender, EventArgs e)
        {
            UserTestingResultsListView.SelectedItem = null;
            BaseViewModel.DisplayErrorAlert("Для більш детальної інформації зверніться до вчителя");
        }
    }
}
