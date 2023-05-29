using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Testro.ViewModels;

namespace Testro.Models
{
    public class Question : BaseNotify
    {
        public readonly static long UNKNOWN_ID = -1;

        public long QuestionId { get; set; } = UNKNOWN_ID;
        public string QuestionName { get; set; } = string.Empty; 
        public long CorrectAnswerId { get; set; } = UNKNOWN_ID;
        public long QuestionResultId { get; set; } = UNKNOWN_ID;
        public ObservableCollection<Answer> Answers { get; set; }

        public static Question CreateQuestion(BaseViewModel viewModel, long questionId)
        {
            Question question = new Question();

            if(questionId != UNKNOWN_ID)
            {
                question.QuestionId = questionId;
                question.QuestionName = viewModel.GetDataBaseRequestResult(question.GetQuestionName);
                question.CorrectAnswerId = viewModel.GetDataBaseRequestResult(question.GetCorrectAnswerId) ?? UNKNOWN_ID;
                question.Answers = question.GetAnswers(viewModel);
            }

            return question;
        }

        protected string GetQuestionName(MySqlConnection connection)
        {
            string query = "SELECT * FROM `questions` WHERE `question_id` = '" + QuestionId + "'";
            return BaseViewModel.GetFirstValue<string>(query, connection, "question_name");
        }

        protected long? GetCorrectAnswerId(MySqlConnection connection)
        {
            string query = "SELECT * FROM `questions` WHERE `question_id` = '" + QuestionId + "'";
            return BaseViewModel.GetFirstValue<long>(query, connection, "correct_answer_id");
        }

        protected ObservableCollection<Answer> GetAnswers(BaseViewModel viewModel)
        {
            List<long> answerIds = viewModel.GetDataBaseRequestResult(GetQuestionAnswerIds);
            ObservableCollection<Answer> answers = new ObservableCollection<Answer>();

            answerIds.ForEach(delegate (long answerId)
            {
                answers.Add(Answer.CreateAnswer(viewModel, answerId));
            });

            return answers;
        }

        private List<long> GetQuestionAnswerIds(MySqlConnection connection)
        {
            string query = "SELECT * FROM `question_answers` WHERE `question_id` = '" + QuestionId + "'";
            return BaseViewModel.GetAllValues<long>(query, connection, "answer_id");
        }
    }
}
