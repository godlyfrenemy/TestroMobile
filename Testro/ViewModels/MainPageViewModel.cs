using System;
using System.Net.NetworkInformation;
using System.Windows.Input;
using Testro.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Testro.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            Title = "Головна сторінка";
            ScanQRCodeCommand = new Command(OnScanQRCodeClicked);
            GoToTestCommand = new Command(OnGoToTestClicked);
        }

        protected async void OnScanQRCodeClicked()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new QRCodeScannerPage(this));
        }
        protected async void OnGoToTestClicked()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new QRCodeScannerPage(this));
        }

        public Command ScanQRCodeCommand { get; set; }
        public Command GoToTestCommand { get; set; }

        public string ActiveTest {
            get => _activeTest ; 
            set
            {
                SetProperty(ref _activeTest, value);
                GoToTestButtonEnabled = value.Length > 0;
            }
        }
        private string _activeTest;

        public bool GoToTestButtonEnabled
        {
            get => _goToTestButtonEnabled;
            set => SetProperty(ref _goToTestButtonEnabled, value);
        }
        private bool _goToTestButtonEnabled = false;
    }
}