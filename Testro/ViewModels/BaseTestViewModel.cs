using Testro.Models;

namespace Testro.ViewModels
{
    public class BaseTestViewModel : BaseViewModel
    {
        public Test Test { get; set; } = new Test();
        public BaseTestViewModel(long testId, bool mistakesOnly = false)
        {
            Test = Test.CreateTest(testId, mistakesOnly);
        }

        public BaseTestViewModel(Test test)
        {
            Test = test;
        }
    }
}
