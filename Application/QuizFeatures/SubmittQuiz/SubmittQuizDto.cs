using System.Collections.Generic;

namespace Application.QuizFeatures.SubmittQuiz
{
    public class SubmittQuizDto
    {
        public int QuizId { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
