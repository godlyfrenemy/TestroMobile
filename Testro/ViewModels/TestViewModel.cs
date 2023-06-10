using MySqlConnector;
using Testro.Models;
using Testro.Views;
using Xamarin.Forms;

namespace Testro.ViewModels
{
    public class TestViewModel : BaseTestViewModel
    {
        public Command StartTestCommand { get; set; }
        public Command StartTestMistakesCorrectionCommand { get; set; }

        private bool _startTestButtonEnabled = false;
        public bool StartTestButtonEnabled
        {
            get => _startTestButtonEnabled;
            set => SetProperty(ref _startTestButtonEnabled, value);
        }

        private bool _startTestMistakesCorrectionButtonEnabled = false;
        public bool StartTestMistakesCorrectionButtonEnabled
        {
            get => _startTestMistakesCorrectionButtonEnabled;
            set => SetProperty(ref _startTestMistakesCorrectionButtonEnabled, value);
        }

        public TestViewModel(long testId, bool mistakesOnly = false)
            : base(testId, mistakesOnly)
        {
            StartTestCommand = new Command(OnStartTestClicked);
            StartTestMistakesCorrectionCommand = new Command(OnStartTestMistakesCorrectionClicked);
        }

        public TestViewModel(Test test)
            : base(test)
        {
            StartTestCommand = new Command(OnStartTestClicked);
            StartTestMistakesCorrectionCommand = new Command(OnStartTestMistakesCorrectionClicked);
        }

        public void OnAppearing()
        {
            StartTestButtonEnabled = GetDataBaseRequestResult(HasUserAccessToTest);
            StartTestMistakesCorrectionButtonEnabled = GetDataBaseRequestResult(HasUserAccessToTestMistakesCorrection);
        }

        private async void OnStartTestClicked()
        {
            await PushModalAsync(new TestProcessPage(this));
        }

        private async void OnStartTestMistakesCorrectionClicked()
        {
            await PushModalAsync(new TestProcessPage(new TestMistakesCorrectionViewModel(Test)));
        }

        private bool HasUserAccessToTest(MySqlConnection connection)
        {
            if (Test.Questions.Count == 0)
                return false;

            string query = "SELECT * FROM `pupil_test_completions` WHERE `pupil_id` = '" + User.UserId + "' AND `test_id` = '" + Test.TestId + "'"; ;
            return !GetHasRows(query, connection);
        }

        private bool HasUserAccessToTestMistakesCorrection(MySqlConnection connection)
        {
            bool hasTestCorrectionAccess = GetFirstValue<bool>("CALL GetTestData('" + Test.TestId + "');", connection, "test_mistakes_correction");
            if (Test.Questions.Count == 0 || !hasTestCorrectionAccess)
                return false;

            string hasUserCompletedTestOnceQuery = "SELECT * FROM `pupil_test_completions` WHERE `pupil_id` = '" + User.UserId + "' " +
                                                    "AND `test_id` = '" + Test.TestId + "' AND `completion_times` = '1'";
            string hasUserIncorrectAnswers = "CALL GetTestQuestionsWithMistakes('" + Test.TestId + "', '" + User.UserId + "');";
            return hasTestCorrectionAccess && GetHasRows(hasUserCompletedTestOnceQuery, connection) && GetHasRows(hasUserIncorrectAnswers, connection);

        }
    }
}
