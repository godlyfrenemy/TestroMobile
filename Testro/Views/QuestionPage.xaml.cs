using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
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
        }

        public void Handle_ItemTapped(object sender, EventArgs e)
        {
            if(LastSelectedViewCell != null)
                LastSelectedViewCell.View.BackgroundColor = Color.Transparent;

            LastSelectedViewCell = ((ViewCell)sender);
            LastSelectedViewCell.View.BackgroundColor = Color.LightBlue;

            QuestionViewModel questionViewModel = BindingContext as QuestionViewModel;
            questionViewModel.AddUserAnswer(MyListView, e);
        }
    }
}
