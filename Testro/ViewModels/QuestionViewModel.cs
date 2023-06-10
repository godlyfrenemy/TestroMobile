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
        public Command EndTestingCommand { get; private set; }
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

        public bool startedClockDown = false;

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

        private bool _hasImage = false;
        public bool HasImage { get => _hasImage; set => SetProperty(ref _hasImage, value); }

        public QuestionViewModel(TestProcessViewModel testViewModel, int questionIndex)
        {
            TestProcessViewModel = testViewModel;
            Question = TestProcessViewModel.Test.Questions.ElementAt(questionIndex);
            QuestionIndex = questionIndex;
            Answers = Question.Answers;

            HasImage = Question.HasImage;

            EndTestingCommand = new Command(() => TestProcessViewModel.SetEndTest());
            Title = "Запитання " + (QuestionIndex + 1).ToString() + " / " + testViewModel.Test.Questions.Count().ToString();

            TestQuestionTime = (int)testViewModel.Test.TestData.TestQuestionTimeConstraint;
            TimeToEndQuestion = new TimeSpan(0, 0, TestQuestionTime);
        }

        public void OnPageAppearing()
        {
            startedClockDown = true;
        }

        public void AddUserAnswer(object sender, EventArgs e)
        {
            Answer answer = (sender as ListView).SelectedItem as Answer;
            int answerTime = TestQuestionTime - (int)TimeToEndQuestion.TotalSeconds;
            UserAnswer userAnswer = new UserAnswer(Question.QuestionId, answer.AnswerId, answerTime);
            TestProcessViewModel.AddUserAnswer(QuestionIndex, userAnswer);
        }

        public void OnTimerTick()
        {
            if (TestQuestionTime > 0 && CanSetAnswers && startedClockDown)
            {
                CanSetAnswers = TimeToEndQuestion >= SECOND;

                if(!CanSetAnswers)
                {
                    TestProcessViewModel.SetAnswerBlocked(QuestionIndex);
                    TimeToEndQuestion = TimeSpan.Zero;
                }
                else
                    TimeToEndQuestion = TimeToEndQuestion.Subtract(SECOND);

            }

            TimeToEndTest = TestProcessViewModel.GetTimeToEndTest();
        }
    }
}
