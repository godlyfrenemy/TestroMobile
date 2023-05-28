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
        public TestProcessViewModel(long testId) : base(testId) {}

        public int CurrentTestIndex { get; set; } = 0;
        public TestProcessPage TestProcessPage { get; set; }
        public List<UserAnswer> UserAnswers { get; set; }
        public DateTime TestEndTime { get; set; }

        public void AddUserAnswer(int questionIndex, UserAnswer userAnswer)
        {
            UserAnswers[questionIndex] = userAnswer;
        }

        private bool? WriteUserAnswers(MySqlConnection connection)
        {
            bool isOk = true;

            UserAnswers.ForEach(x =>
            {            
                string insertQuestionResultsQuery = "INSERT INTO question_results(`question_id`, `result_answer_id`, `answer_time`) " +
                                                    "VALUES('" + x.QuestionId + "', '" + x.AnswerId + "', '" + x.AnswerTime + "')";
                long questionResultsId = InsertValues(insertQuestionResultsQuery, connection);
                string insertPupilUsersQuery = "INSERT INTO pupil_results(`pupil_id`, `question_result_id`) " +
                                               "VALUES('" + User.UserId + "', '" + questionResultsId + "')";
                isOk &= InsertValues(insertPupilUsersQuery, connection) != User.UNKNOWN_ID;
            });

            if (isOk)
            {
                string insertTestCompletionQuery = "INSERT INTO pupil_test_completions(`pupil_id`, `test_id`) " +
                                                        "VALUES('" + User.UserId + "', '" + Test.TestId + "')";
                isOk = InsertValues(insertTestCompletionQuery, connection) != User.UNKNOWN_ID;
            }

            return isOk;
        }

        public void ContinueTesting()
        {
            if(IsCurrentPageLast())
                EndTesting();
            else
                TestProcessPage.CurrentPage = TestProcessPage.Children[++CurrentTestIndex];
        }

        public void EndTesting(bool writeEmpty = false)
        {
            if (writeEmpty)
            {
                UserAnswers.ForEach(x =>
                {
                    x.AnswerId = UserAnswer.UNKNOWN_ID;
                });

                DisplayErrorAlert("Результати тестування було анульовано");
            }

            if (!(GetDataBaseRequestResult(WriteUserAnswers) ?? false))
                DisplayErrorAlert("Не вдається записати результат!");

            App.IsOnTestingProcess = false;
            Application.Current.MainPage.Navigation.PopModalAsync();
        }

        public bool IsCurrentPageLast()
        {
            return Test.Questions.Count <= CurrentTestIndex + 1;
        }
    }
}
