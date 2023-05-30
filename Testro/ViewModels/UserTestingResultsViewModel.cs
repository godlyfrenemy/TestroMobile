using System.Collections.ObjectModel;

namespace Testro.ViewModels
{
    public class UserTestingResultsViewModel : BaseViewModel
    {
        public ObservableCollection<string> UserTestingResults { get; set; }

        private bool _hasUserPassedTests = false;
        public bool HasUserPassedTests { 
            get => _hasUserPassedTests; 
            set => SetProperty(ref _hasUserPassedTests, value); 
        }

        public bool NoUserPassedTests
        {
            get => !HasUserPassedTests;
            set => HasUserPassedTests = !value;
        }
    }
}
