using MySqlConnector;
using Testro.Models;

namespace Testro.ViewModels
{
    public class TestMistakesCorrectionViewModel : TestProcessViewModel
    {
        public TestMistakesCorrectionViewModel(long testId) : base(testId, true) { }

        protected override bool WriteCompletionTimes(MySqlConnection connection)
        {
            string updateTestCompletionQuery = "UPDATE pupil_test_completions SET `completion_times` = 2 " +
                                               "WHERE `pupil_id` = '" + User.UserId + "' AND `test_id` = '" + Test.TestId + "'";
            return UpdateValues(updateTestCompletionQuery, connection);
        }

        public override void WriteResults(bool writeEmpty = false)
        {
            if (writeEmpty)
            {
                DisplayErrorAlert("Результати тестування анульовано та не буде враховано");
                UserAnswers.Clear();
            }

            base.WriteResults();
        }
    }
}
