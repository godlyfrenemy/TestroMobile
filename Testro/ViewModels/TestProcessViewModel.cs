using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Testro.Models;
using Testro.Views;
using Xamarin.Forms;

namespace Testro.ViewModels
{
    public class TestProcessViewModel : TestViewModel
    {
        public TestProcessViewModel(long testId) : base(testId) { }

        public int CurrentTestIndex { get; set; } = 0;
        public TestProcessPage TestProcessPage { get; set; }
        public List<UserAnswer> UserAnswers { get; set; }

        public void AddUserAnswer(int questionIndex, long questionId, long answerId)
        {
            UserAnswers[questionIndex] = new UserAnswer(questionId, answerId);
        }

        private bool? WriteUserAnswers(MySqlConnection connection)
        {
            bool isOk = true;

            UserAnswers.ForEach(x =>
            {
                string insertQuestionResultsQuery = "INSERT INTO question_results(`question_id`, `result_answer_id`) VALUES('" + x.QuestionId + "', '" + x.AnswerId + "')";
                long questionResultsId = InsertValues(insertQuestionResultsQuery, connection);
                string insertPupilUsersQuery = "INSERT INTO pupil_results(`pupil_id`, `question_result_id`) VALUES('" + User.UserId + "', '" + questionResultsId + "')";
                isOk &= InsertValues(insertPupilUsersQuery, connection) != User.UNKNOWN_ID;
            });

            return isOk;
        }

        public void ContinueTesting()
        {
            if (!IsCurrentPageLast())
                TestProcessPage.CurrentPage = TestProcessPage.Children[CurrentTestIndex++];
            else if (!(GetDataBaseRequestResult(WriteUserAnswers) ?? false))
                DisplayErrorAlert("Не вдається записати результат!");
            else
                Application.Current.MainPage.Navigation.PopModalAsync();
        }

        public bool IsCurrentPageLast()
        {
            return Test.Questions.Count <= CurrentTestIndex + 1;
        }
    }
}
