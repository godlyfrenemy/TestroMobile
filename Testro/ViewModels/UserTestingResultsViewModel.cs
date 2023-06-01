using MySqlConnector;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Testro.Models;

namespace Testro.ViewModels
{
    public class UserTestingResultsViewModel : BaseViewModel
    {
        public ObservableCollection<UserTestingResult> UserTestingResults { get; set; } = new ObservableCollection<UserTestingResult>();

        public bool HasUserPassedTests { 
            get => UserTestingResults.Count > 0;
        }

        public bool NoUserPassedTests
        {
            get => !HasUserPassedTests;
        }

        public void OnAppearing()
        {
            UserTestingResults.Clear(); 

            List<long> testsUserCompleted = GetDataBaseRequestResult(GetTestIdsUserCompleted);
            testsUserCompleted.Reverse();

            testsUserCompleted.ForEach((x) =>
            {
                UserTestingResults.Add(UserTestingResult.CreateTestingResult(x));
            });

            OnPropertyChanged(nameof(HasUserPassedTests));
            OnPropertyChanged(nameof(NoUserPassedTests));
        }

        private List<long> GetTestIdsUserCompleted(MySqlConnection connection)
        {
            string query = "SELECT * FROM `pupil_test_completions` WHERE `pupil_id` = '" + User.UserId + "';";
            return GetAllValues<long>(query, connection, "test_id");
        }
    }
}
