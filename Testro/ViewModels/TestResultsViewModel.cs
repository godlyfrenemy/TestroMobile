using MySqlConnector;
using Testro.Models;

namespace Testro.ViewModels
{
    public partial class TestResultsViewModel : BaseTestViewModel
    {
        public TestResultsViewModel(long testId)
            : base(testId)
        {
            CorrectAnswersAmount = GetDataBaseRequestResult(CountCorrectAnswers);
            TotalQuestionsAmount = GetDataBaseRequestResult(CountTotalQuestionsAmount);
            CorrectAnswersToTotal = CorrectAnswersAmount.ToString() + " / " + TotalQuestionsAmount.ToString();
            TotalMark = GetDataBaseRequestResult(GetTotalMark);
        }

        private long _correctAnswersAmount = 0;
        private long _totalQuestionsAmount = 0;
        private float _totalMark = 0;
        private string _correctAnswersToTotal = string.Empty;

        public long TotalQuestionsAmount
        {
            get => _totalQuestionsAmount; set => SetProperty(ref _totalQuestionsAmount, value);
        }

        public long CorrectAnswersAmount
        {
            get => _correctAnswersAmount; set => SetProperty(ref _correctAnswersAmount, value);
        }

        public float TotalMark
        {
            get => _totalMark; set => SetProperty(ref _totalMark, value);
        }

        public string CorrectAnswersToTotal
        {
            get => _correctAnswersToTotal; set => SetProperty(ref _correctAnswersToTotal, value);
        }



        private long CountCorrectAnswers(MySqlConnection connection)
        {
            string query = "CALL CountCorrectAnswers('" + User.UserId + "', '" + Test.TestId + "');";
            return GetFirstValue<long>(query, connection, "total_count");
        }

        private long CountTotalQuestionsAmount(MySqlConnection connection)
        {
            string query = "SELECT COUNT(*) AS `total_count` FROM `test_questions` WHERE `test_id` = '" + Test.TestId + "';";
            return GetFirstValue<long>(query, connection, "total_count");
        }

        private float GetTotalMark(MySqlConnection connection)
        {
            long sum = 0;

            Test.Questions.ForEach((x) =>
            {
                string query = "CALL GetQuestionAnswerMark('" + User.UserId + "', '" + x.QuestionId + "');";
                sum += GetFirstValue<long>(query, connection, "result");
            });

            return sum / (100 * (float)TotalQuestionsAmount);
        }
    }
}
