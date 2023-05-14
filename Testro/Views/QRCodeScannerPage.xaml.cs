using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Testro.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRCodeScannerPage : ContentPage
    {
        protected MainPageViewModel mainPageViewModel { get; set; }
        public QRCodeScannerPage( MainPageViewModel mainPage )
        {
            InitializeComponent();
            mainPageViewModel = mainPage;
            zxing.OnScanResult += (result) => Device.BeginInvokeOnMainThread(() => {
                mainPageViewModel.ActiveTest = result.Text;
                Application.Current.MainPage.Navigation.PopModalAsync();
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            zxing.IsScanning = true;
        }
        protected override void OnDisappearing()
        {
            mainPageViewModel.ActiveTest = "1234";
            zxing.IsScanning = false;
            base.OnDisappearing();
        }

    }
}