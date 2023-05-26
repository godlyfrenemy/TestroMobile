using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;
using Testro.Models;
using Testro.Views;
using Xamarin.Forms;

namespace Testro.ViewModels
{
    public class TestViewModel : BaseViewModel
    {
        public Command StartTestCommand { get; set; }
        public TestViewModel() { }
        public TestViewModel(long testId)
        {
            Test = Test.CreateTest(this, testId);
            StartTestCommand = new Command(OnStartTestClicked);
        }

        public Test Test { get; set; } = new Test();

        private async void OnStartTestClicked()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new TestProcessPage(this));
        }
    }
}
