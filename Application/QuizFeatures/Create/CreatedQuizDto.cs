using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.QuizFeatures.Create
{
   public class CreatedQuizDto
    {
        public int QuizId { get; set; }
        public int Score { get; set; }
        public List<Question> Questions { get; set; }
    }
}
