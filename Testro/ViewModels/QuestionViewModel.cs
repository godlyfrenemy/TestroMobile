using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Testro.Models;
using Xamarin.Forms;

namespace Testro.ViewModels
{
    public class QuestionViewModel : BaseViewModel
    {
        public ObservableCollection<Answer> Answers { get; set; }
        public Question Question { get; set; }
        public int QuestionIndex {  get; set; }
        public string ContinueButtonText { get; private set; }
        public Command ContinueTestingCommand { get; private set; }
        private TestProcessViewModel TestProcessViewModel { get; set; }

        public QuestionViewModel(TestProcessViewModel testViewModel, int questionIndex)
        {
            TestProcessViewModel = testViewModel;
            Question = TestProcessViewModel.Test.Questions.ElementAt(questionIndex);
            QuestionIndex = questionIndex;
            Answers = Question.Answers;
            Title = "Запитання №" + (QuestionIndex + 1).ToString();
            ContinueButtonText = GetContinueButtonText();
            ContinueTestingCommand = new Command(TestProcessViewModel.ContinueTesting);
        }

        private string GetContinueButtonText()
        {
            return TestProcessViewModel.Test.Questions.Count - QuestionIndex > 1 ? 
                    "Перейти до наступного запитання" : 
                    "Завершити тестування";
        }

        public void AddUserAnswer(object sender, EventArgs e)
        {            
            Answer answer = (sender as ListView).SelectedItem as Answer;
            TestProcessViewModel.AddUserAnswer(QuestionIndex, Question.QuestionId, answer.AnswerId);
        }
    }
}
