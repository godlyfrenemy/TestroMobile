using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testro.Models;
using Testro.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestProcessPage : CarouselPage
    {
        public readonly TestProcessViewModel viewModel;

        public TestProcessPage(TestViewModel testViewModel)
        {
            InitializeComponent();
            viewModel = (TestProcessViewModel)testViewModel;
            viewModel.TestProcessPage = this;
            viewModel.UserAnswers = new List<UserAnswer>(viewModel.Test.Questions.Count);
            viewModel.TestEndTime = DateTime.Now.AddMinutes(testViewModel.Test.TestData.TestTimeConstraint);
            viewModel.StartTimer();

            for (int i = 0; i < viewModel.Test.Questions.Count; i++)
            {
                viewModel.UserAnswers.Add(new UserAnswer(viewModel.Test.Questions[i].QuestionId));
                Children.Add(new QuestionPage(viewModel, i));
            }

            App.IsOnTestingProcess = true;
        }

        public void ForceEndTesting()
        {
            if (App.IsOnTestingProcess)
                viewModel.SetEndTest(true);
        }

        protected override void OnDisappearing()
        {
            ForceEndTesting();
            base.OnDisappearing();
        }
    }
}