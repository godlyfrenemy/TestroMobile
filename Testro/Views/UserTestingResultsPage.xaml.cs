using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserTestingResultsPage : ContentPage
    {
        public ObservableCollection<string> UserTestingResults { get; set; }

        public UserTestingResultsPage()
        {
            InitializeComponent();
            Title = "Результати тестувань";
        }
    }
}
