using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;
using Testro.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

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

        public override void EndTesting(bool writeEmpty = false)
        {
            if (writeEmpty)
            {
                DisplayErrorAlert("Результати тестування анульовано та не буде враховано");
                UserAnswers.Clear();
            }

            if (!(GetDataBaseRequestResult(WriteTestingResults) ?? false))
                DisplayErrorAlert("Не вдається записати результат!");

            App.IsOnTestingProcess = false;
            Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
