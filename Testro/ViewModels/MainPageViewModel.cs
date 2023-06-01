using MySqlConnector;
using Testro.Views;
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
            await PushModalAsync(new QRCodeScannerPage(this));
        }
        protected async void OnGoToTestClicked()
        {
            if (GetDataBaseRequestResult(CheckIfTestExists) ?? false)
                await PushModalAsync(new TestPage(long.Parse(ActiveTest)));
            else
                DisplayErrorAlert("Такий тест не існує!");
        }

        private bool? CheckIfTestExists(MySqlConnection connection)
        {
            string query = "SELECT * FROM `tests` WHERE `test_id` = '" + ActiveTest + "'";
            return GetHasRows(query, connection);
        }

        public Command ScanQRCodeCommand { get; set; }
        public Command GoToTestCommand { get; set; }

        public string ActiveTest
        {
            get => _activeTest;
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