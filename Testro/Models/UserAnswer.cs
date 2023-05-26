using System;
using System.Collections.Generic;
using System.Text;

namespace Testro.Models
{
    public class UserAnswer
    {
        public static long UNKNOWN_ID = -1;

        public UserAnswer() { }

        public UserAnswer(long questionId, long answerId)
        {
            QuestionId = questionId;
            AnswerId = answerId;
        }

        public long QuestionId { get; set; } = UNKNOWN_ID;
        public long AnswerId { get; set; } = UNKNOWN_ID;
    }
}
