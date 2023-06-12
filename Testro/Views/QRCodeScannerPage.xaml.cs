using System.Net.NetworkInformation;
using Testro.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRCodeScannerPage : ContentPage
    {
        protected MainPageViewModel MainPageViewModel { get; set; }
        public QRCodeScannerPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            MainPageViewModel = mainPageViewModel;
            zxing.OnScanResult += (result) => Device.BeginInvokeOnMainThread(() =>
            {
                MainPageViewModel.ActiveTest = result.Text;
                MainPageViewModel.PopModalAsync();
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            zxing.IsScanning = true;
        }
        protected override void OnDisappearing()
        {
            zxing.IsScanning = false;
            base.OnDisappearing();
        }

    }
}