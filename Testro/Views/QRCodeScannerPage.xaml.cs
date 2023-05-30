using Testro.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRCodeScannerPage : ContentPage
    {
        protected MainPageViewModel MainPageViewModel { get; set; }
        public QRCodeScannerPage(MainPageViewModel mainPage)
        {
            InitializeComponent();
            MainPageViewModel = mainPage;
            zxing.OnScanResult += (result) => Device.BeginInvokeOnMainThread(() =>
            {
                MainPageViewModel.ActiveTest = result.Text;
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
            MainPageViewModel.ActiveTest = "1234";
            zxing.IsScanning = false;
            base.OnDisappearing();
        }

    }
}