using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;
using Testro.ViewModels;

namespace Testro.Models
{
    public class Answer : BaseNotify
    {
        public readonly static long UNKNOWN_ID = -1;

        public long AnswerId { get; set; } 
        public string AnswerText { get; set; }

        public static Answer CreateAnswer(BaseViewModel viewModel, long answerId)
        {
            Answer answer = new Answer();

            if(answerId != UNKNOWN_ID)
            {
                answer.AnswerId = answerId;
                answer.AnswerText = viewModel.GetDataBaseRequestResult(answer.GetAnswerText);
            }

            return answer;
        }

        private string GetAnswerText(MySqlConnection connection)
        {
            string query = "SELECT * FROM `answers` WHERE `answer_id` = '" + AnswerId + "'";
            return BaseViewModel.GetFirstValueAndClose<string>(query, connection, "answer_text");
        }
    }
}
