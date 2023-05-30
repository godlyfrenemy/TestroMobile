using Testro.Models;

namespace Testro.ViewModels
{
    public class BaseTestViewModel : BaseViewModel
    {
        public Test Test { get; set; } = new Test();
        public BaseTestViewModel(long testId, bool mistakesOnly = false)
        {
            Test = Test.CreateTest(this, testId, mistakesOnly);
        }
    }
}
