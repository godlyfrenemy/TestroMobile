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
        public Test Test { get; set; } = new Test();
        public Command StartTestCommand { get; set; }
        public Command StartTestMistakesCorrectionCommand { get; set; }
        public TestViewModel() { }
        public TestViewModel(long testId, bool withMistakes = false)
        {
            Test = Test.CreateTest(this, testId, withMistakes);
            StartTestCommand = new Command(OnStartTestClicked);
            StartTestMistakesCorrectionCommand = new Command(OnStartTestMistakesCorrectionClicked);
        }

        public void OnAppearing()
        {
            StartTestButtonEnabled = GetDataBaseRequestResult(HasUserAccessToTest);
            StartTestMistakesCorrectionButtonEnabled = GetDataBaseRequestResult(HasUserAccessToTestMistakesCorrection);
        }

        private bool _startTestButtonEnabled = false;
        public bool StartTestButtonEnabled { 
            get => _startTestButtonEnabled; 
            set => SetProperty(ref _startTestButtonEnabled, value);
        }

        private bool _startTestMistakesCorrectionButtonEnabled = false;
        public bool StartTestMistakesCorrectionButtonEnabled
        {
            get => _startTestMistakesCorrectionButtonEnabled;
            set => SetProperty(ref _startTestMistakesCorrectionButtonEnabled, value);
        }

        private async void OnStartTestClicked()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new TestProcessPage(this));
        }

        private async void OnStartTestMistakesCorrectionClicked()
        {
            TestMistakesCorrectionViewModel viewModel = new TestMistakesCorrectionViewModel(Test.TestId);
            await Application.Current.MainPage.Navigation.PushModalAsync(new TestProcessPage(viewModel));
        }

        private bool HasUserAccessToTest(MySqlConnection connection)
        {
            bool hasAccess = Test.Questions.Count > 0;

            if (hasAccess)
            {
                string query = "SELECT * FROM `pupil_test_completions` WHERE `pupil_id` = '" + User.UserId + "' AND `test_id` = '" + Test.TestId + "'"; ;
                hasAccess = !GetHasRows(query, connection);
            }

            return hasAccess;
        }

        private bool HasUserAccessToTestMistakesCorrection(MySqlConnection connection)
        {
            bool hasAccess = Test.Questions.Count > 0;

            if (hasAccess)
            {
                string hasUserCompletedTestOnceQuery = "SELECT * FROM `pupil_test_completions` WHERE `pupil_id` = '" + User.UserId + "' " +
                                                       "AND `test_id` = '" + Test.TestId + "' AND `completion_times` = '1'";
                string hasUserIncorrectAnswers = "CALL GetTestQuestionsWithMistakes('" + Test.TestId + "', '" + User.UserId + "');";
                hasAccess = GetHasRows(hasUserCompletedTestOnceQuery, connection) && GetHasRows(hasUserIncorrectAnswers, connection);
            }

            return hasAccess;
        }
    }
}
