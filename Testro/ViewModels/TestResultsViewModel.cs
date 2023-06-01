using MySqlConnector;
using Testro.Models;

namespace Testro.ViewModels
{
    public partial class TestResultsViewModel : BaseTestViewModel
    {
        public UserTestingResult UserTestingResult { get; set; }

        public TestResultsViewModel(long testId)
            : base(testId)
        {
            UserTestingResult = UserTestingResult.CreateTestingResult(Test);
        }
    }
}
