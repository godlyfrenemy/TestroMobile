using System.IO;
using Testro.Models;
using Testro.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        public TestPage(long testId)
        {
            InitializeComponent();
            BindingContext = new TestProcessViewModel(testId);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as TestProcessViewModel).OnAppearing();
        }

        ~TestPage()
        {
            (BindingContext as TestProcessViewModel).Test.Questions.ForEach(x =>
            {
                if (File.Exists(x.QuestionImagePath))
                    File.Delete(x.QuestionImagePath);
            });
        }

    }
}