using System;
using System.Collections.ObjectModel;
using System.Linq;
using Testro.Models;
using Xamarin.Forms;

namespace Testro.ViewModels
{
    public class QuestionViewModel : BaseViewModel
    {
        static readonly TimeSpan SECOND = TimeSpan.FromSeconds(1);

        public ObservableCollection<Answer> Answers { get; set; }
        public Question Question { get; set; }
        public int QuestionIndex { get; set; }
        public string ContinueButtonText { get; private set; }
        public Command ContinueTestingCommand { get; private set; }
        public TestProcessViewModel TestProcessViewModel { get; set; }
        private int TestQuestionTime { get; set; }

        private bool _canSetAnwers = true;
        public bool CanSetAnswers
        {
            get => _canSetAnwers;
            set
            {
                if (_canSetAnwers)
                {
                    SetProperty(ref _canSetAnwers, value);

                    if (!value)
                        QuestionTimeColor = Color.Red;
                }
            }
        }

        private TimeSpan _timeToEndTest;
        public TimeSpan TimeToEndTest
        {
            get => _timeToEndTest;
            private set { SetProperty(ref _timeToEndTest, value); }
        }
        private TimeSpan _timeToEndQuestion;
        public TimeSpan TimeToEndQuestion
        {
            get => _timeToEndQuestion;
            private set { SetProperty(ref _timeToEndQuestion, value); }
        }

        private Color _questionTimeColor = (Color)Label.TextColorProperty.DefaultValue;
        public Color QuestionTimeColor
        {
            get => _questionTimeColor;
            set { SetProperty(ref _questionTimeColor, value); }
        }

        public QuestionViewModel(TestProcessViewModel testViewModel, int questionIndex)
        {
            TestProcessViewModel = testViewModel;
            Question = TestProcessViewModel.Test.Questions.ElementAt(questionIndex);
            QuestionIndex = questionIndex;
            Answers = Question.Answers;
            Title = "Запитання №" + (QuestionIndex + 1).ToString();
            ContinueButtonText = GetContinueButtonText();
            ContinueTestingCommand = new Command(TestProcessViewModel.ContinueTesting);

            TestQuestionTime = (int)testViewModel.Test.TestData.TestQuestionTimeConstraint;
            TimeToEndQuestion = new TimeSpan(0, 0, TestQuestionTime);
        }

        public void OnPageAppearing()
        {
            Device.StartTimer(SECOND, OnTimerTick);
        }

        private string GetContinueButtonText()
        {
            long questionsLeft = TestProcessViewModel.Test.Questions.Count - QuestionIndex - 1;
            return questionsLeft > 0 ? "Перейти до наступного запитання" : "Завершити тестування";
        }

        public void AddUserAnswer(object sender, EventArgs e)
        {
            Answer answer = (sender as ListView).SelectedItem as Answer;
            int answerTime = TestQuestionTime - (int)TimeToEndQuestion.TotalSeconds;
            UserAnswer userAnswer = new UserAnswer(Question.QuestionId, answer.AnswerId, answerTime);
            TestProcessViewModel.AddUserAnswer(QuestionIndex, userAnswer);
        }

        private bool OnTimerTick()
        {
            if (DateTime.Now > TestProcessViewModel.TestEndTime)
            {
                TestProcessViewModel.EndTesting();
                return false;
            }

            if (TestQuestionTime > 0 && CanSetAnswers)
            {
                CanSetAnswers = TimeToEndQuestion > SECOND;
                TimeToEndQuestion = CanSetAnswers ? TimeToEndQuestion.Subtract(SECOND) : TimeSpan.Zero;
            }

            TimeSpan timeLeft = TestProcessViewModel.TestEndTime - DateTime.Now;
            TimeToEndTest = new TimeSpan(timeLeft.Hours, timeLeft.Minutes, timeLeft.Seconds);
            return true;
        }
    }
}
