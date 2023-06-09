using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Testro.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Testro.Models
{
    public class Question : BaseNotify
    {
        public readonly static long UNKNOWN_ID = -1;

        public long QuestionId { get; set; } = UNKNOWN_ID;
        public string QuestionName { get; set; } = string.Empty;
        public long CorrectAnswerId { get; set; } = UNKNOWN_ID;
        public long QuestionResultId { get; set; } = UNKNOWN_ID;
        public string QuestionImagePath { get; set; }
        public bool HasImage = false;
        public ObservableCollection<Answer> Answers { get; set; }

        public static Question CreateQuestion(long questionId)
        {
            Question question = new Question();

            if (questionId != UNKNOWN_ID)
            {
                question.QuestionId = questionId;
                question.QuestionName = BaseViewModel.GetDataBaseRequestResult(question.GetQuestionName);
                question.CorrectAnswerId = BaseViewModel.GetDataBaseRequestResult(question.GetCorrectAnswerId) ?? UNKNOWN_ID;
                question.Answers = question.GetAnswers();
                question.QuestionImagePath = question.GetQuestionImage();
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

        protected byte[] GetQuestionImageData(MySqlConnection connection)
        {
            string query = "SELECT * FROM `questions` WHERE `question_id` = '" + QuestionId + "'";
            return BaseViewModel.GetFirstValue<byte[]>(query, connection, "image");
        }

        protected ObservableCollection<Answer> GetAnswers()
        {
            List<long> answerIds = BaseViewModel.GetDataBaseRequestResult(GetQuestionAnswerIds);
            ObservableCollection<Answer> answers = new ObservableCollection<Answer>();

            answerIds.ForEach(delegate (long answerId)
            {
                answers.Add(Answer.CreateAnswer(answerId));
            });

            return answers;
        }

        private List<long> GetQuestionAnswerIds(MySqlConnection connection)
        {
            string query = "SELECT * FROM `question_answers` WHERE `question_id` = '" + QuestionId + "'";
            return BaseViewModel.GetAllValues<long>(query, connection, "answer_id");
        }

        protected string GetQuestionImage()
        {
            byte[] source = BaseViewModel.GetDataBaseRequestResult(GetQuestionImageData);
            HasImage = source.Length > 0;
            string fileFullPath = string.Empty;

            if (HasImage)
            {
                var directory = Path.Combine(FileSystem.AppDataDirectory, "SavedImages");

                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                fileFullPath = Path.Combine(directory, Guid.NewGuid() + ".png");
                using (FileStream fileStream = System.IO.File.Create(fileFullPath, (int)source.Length))
                {
                    fileStream.Write(source, 0, source.Length);
                }
            }

            return fileFullPath;
        }
    }
}
