using Testro.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestResultsPage : ContentPage
    {
        public TestResultsPage(long testId)
        {
            InitializeComponent();
            BindingContext = new TestResultsViewModel(testId);
        }
    }
}