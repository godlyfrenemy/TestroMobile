using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testro.Models;
using Testro.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestProcessPage : TabbedPage
    {
        private readonly TestProcessViewModel viewModel;

        public TestProcessPage (TestViewModel testViewModel)
        {
            InitializeComponent();
            viewModel = (TestProcessViewModel)testViewModel;
            viewModel.TestProcessPage = this;
            viewModel.UserAnswers = new List<UserAnswer>(viewModel.Test.Questions.Count);

            for (int i = 0; i < viewModel.Test.Questions.Count; i++)
            {
                viewModel.UserAnswers.Add(new UserAnswer());
                Children.Add(new QuestionPage(viewModel, i));
            }
        }
    }
}