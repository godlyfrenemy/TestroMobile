using System;
using Testro.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionPage : ContentPage
    {
        ViewCell LastSelectedViewCell { get; set; } = null;
        public QuestionPage(TestProcessViewModel testViewModel, int questionIndex)
        {
            InitializeComponent();
            BindingContext = new QuestionViewModel(testViewModel, questionIndex);

            if (testViewModel.Test.TestData.TestQuestionTimeConstraint == 0)
                TestTimeInfo.Children.RemoveAt(1);
        }

        public void Handle_ItemTapped(object sender, EventArgs e)
        {
            if (LastSelectedViewCell != null)
                LastSelectedViewCell.View.BackgroundColor = Color.Transparent;

            LastSelectedViewCell = ((ViewCell)sender);
            LastSelectedViewCell.View.BackgroundColor = Color.LightBlue;

            QuestionViewModel questionViewModel = BindingContext as QuestionViewModel;
            questionViewModel.AddUserAnswer(AnswersListView, e);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as QuestionViewModel).OnPageAppearing();
        }
    }
}
