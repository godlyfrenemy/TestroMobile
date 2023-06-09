using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using Testro.Models;
using Testro.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Testro.ViewModels
{
    public class TestProcessViewModel : TestViewModel
    {
        public TestProcessViewModel(long testId, bool withMistakesOnly = false) : base(testId, withMistakesOnly) {}
        public TestProcessViewModel(Test test) : base(test) { }

        public TestProcessPage TestProcessPage { get; set; }
        public List<UserAnswer> UserAnswers { get; set; }
        public DateTime TestEndTime { get; set; }

        bool ForceEndTesting = false;

        public void AddUserAnswer(int questionIndex, UserAnswer userAnswer)
        {
            UserAnswers[questionIndex] = userAnswer;
        }

        protected bool? WriteTestingResults(MySqlConnection connection)
        {
            return (WriteUserAnswers(connection) ?? false) && WriteCompletionTimes(connection);
        }

        protected virtual bool? WriteUserAnswers(MySqlConnection connection)
        {
            bool isOk = true;

            UserAnswers.ForEach(x =>
            {
                string insertQuestionResultsQuery = "INSERT INTO question_results(`question_id`, `result_answer_id`, `answer_time`) " +
                                                    "VALUES('" + x.QuestionId + "', '" + x.AnswerId + "', '" + (x.AnswerTime == 0 ? 1 : x.AnswerTime) + "')";
                long questionResultsId = InsertValues(insertQuestionResultsQuery, connection);
                string insertPupilUsersQuery = "INSERT INTO pupil_results(`pupil_id`, `question_result_id`) " +
                                               "VALUES('" + User.UserId + "', '" + questionResultsId + "')";
                isOk &= InsertValues(insertPupilUsersQuery, connection) != User.UNKNOWN_ID;
            });

            return isOk;
        }

        protected virtual bool WriteCompletionTimes(MySqlConnection connection)
        {
            string insertTestCompletionQuery = "INSERT INTO pupil_test_completions(`pupil_id`, `test_id`) " +
                                               "VALUES('" + User.UserId + "', '" + Test.TestId + "')";
            return InsertValues(insertTestCompletionQuery, connection) != User.UNKNOWN_ID;
        }

        public virtual void WriteResults(bool writeEmpty = false)
        {
            if (writeEmpty)
            {
                UserAnswers.ForEach(x =>
                {
                    x.AnswerId = UserAnswer.UNKNOWN_ID;
                });

                DisplayErrorAlert("Результати тестування було анульовано");
            }

            if (!(GetDataBaseRequestResult(WriteTestingResults) ?? false))
                DisplayErrorAlert("Не вдається записати результат!");
        }

        public void EndTesting()
        {
            WriteResults(ForceEndTesting);
            App.IsOnTestingProcess = false;

            PopModalAsync();
            PushModalAsync(new TestResultsPage(Test.TestId));
        }

        private bool OnTimerTick()
        {
            if (DateTime.Now > TestEndTime || ForceEndTesting)
            {
                EndTesting();
                return false;
            }

            for (int i = 0; i < TestProcessPage.Children.Count; i++)
                (TestProcessPage.Children[i].BindingContext as QuestionViewModel).OnTimerTick();

            return true;
        }

        public void StartTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
        }

        public async void SetEndTest(bool force = false)
        {
            ForceEndTesting = force;

            if (!ForceEndTesting)
            {
                bool hasEmpty = false;
                UserAnswers.ForEach(x =>
                {
                    hasEmpty |= x.AnswerId == Answer.UNKNOWN_ID;
                });

                if (!hasEmpty || (hasEmpty && await DisplayConfirmAlert("У вас є пусті відповіді", "Продовжити?")))
                    TestEndTime = DateTime.Now;
            }
        }
    }
}
