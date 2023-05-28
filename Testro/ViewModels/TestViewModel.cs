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

        public void OnAppearing()
        {
            StartButtonEnabled = GetDataBaseRequestResult(HasUserAccessToTest);
        }

        private bool _startButtonEnabled = true;
        public bool StartButtonEnabled { 
            get => _startButtonEnabled; 
            set => SetProperty(ref _startButtonEnabled, value);
        }

        public Test Test { get; set; } = new Test();

        private async void OnStartTestClicked()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new TestProcessPage(this));
        }

        private bool HasUserAccessToTest(MySqlConnection connection)
        {
            bool hasAccess = Test.Questions.Count > 0;

            if (hasAccess)
            {
                string query = "SELECT * FROM `pupil_test_completions` WHERE `pupil_id` = '" + User.UserId + "' AND `test_id` = '" + Test.TestId + "'"; ;
                hasAccess = !GetHasRowsAndClose(query, connection);
            }

            return hasAccess;
        }
    }
}
