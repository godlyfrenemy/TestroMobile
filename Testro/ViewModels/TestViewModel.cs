using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;
using Testro.Models;

namespace Testro.ViewModels
{
    class TestViewModel : BaseViewModel
    {
        public TestViewModel() { }
        public TestViewModel(long testId)
        {
            Test = Test.CreateTest(this, testId);
        }

        public Test Test { get; set; } = new Test();
    }
}
