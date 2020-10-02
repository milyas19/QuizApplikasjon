using System.Collections.Generic;

namespace Entities
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public int Score { get; set; }
        public List<Question> Questions { get; set; }
    }
}
