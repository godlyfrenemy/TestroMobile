using System;
using Testro.Models;
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

            if(testViewModel.Test.TestData.TestTimeConstraint == 0)
                TestTimeInfo.Children.RemoveAt(0);

            IncidentImageData.IsVisible = (BindingContext as QuestionViewModel).HasImage;

            if (IncidentImageData.IsVisible)
                IncidentImageData.Source = ImageSource.FromFile((BindingContext as QuestionViewModel).Question.QuestionImagePath);
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

        public void OnImageTapped(object sender, EventArgs args)
        {
            IncidentImageData.Aspect = IncidentImageData.Aspect == Aspect.AspectFit ? Aspect.AspectFill : Aspect.AspectFit;
        }
    }
}
