using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;
using Testro.ViewModels;

namespace Testro.Models
{
    public class UserTestingResult : BaseNotify
    {
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

        public Test Test { get; set; }

        public static UserTestingResult CreateTestingResult(Test test)
        {
            UserTestingResult result = new UserTestingResult { Test = test };

            result.CorrectAnswersAmount = BaseViewModel.GetDataBaseRequestResult(result.CountCorrectAnswers);
            result.TotalQuestionsAmount = BaseViewModel.GetDataBaseRequestResult(result.CountTotalQuestionsAmount);
            result.CorrectAnswersToTotal = result.CorrectAnswersAmount.ToString() + " / " + result.TotalQuestionsAmount.ToString();
            result.TotalMark = BaseViewModel.GetDataBaseRequestResult(result.GetTotalMark);

            return result;
        }

        public static UserTestingResult CreateTestingResult(long testId)
        {
            return CreateTestingResult(Test.CreateTest(testId));
        }

        private long CountCorrectAnswers(MySqlConnection connection)
        {
            string query = "CALL CountCorrectAnswers('" + User.UserId + "', '" + Test.TestId + "');";
            return BaseViewModel.GetFirstValue<long>(query, connection, "total_count");
        }

        private long CountTotalQuestionsAmount(MySqlConnection connection)
        {
            string query = "SELECT COUNT(*) AS `total_count` FROM `test_questions` WHERE `test_id` = '" + Test.TestId + "';";
            return BaseViewModel.GetFirstValue<long>(query, connection, "total_count");
        }

        private float GetTotalMark(MySqlConnection connection)
        {
            double totalMark = 0;
            double coef = Test.TestMark / (100.0 * TotalQuestionsAmount);

            Test.Questions.ForEach((x) =>
            {
                string query = "CALL GetQuestionAnswerMark('" + User.UserId + "', '" + x.QuestionId + "');";
                totalMark += BaseViewModel.GetFirstValue<double>(query, connection, "result") * coef;
            });

            return (float)Math.Round(totalMark, 2);
        }
    }
}
