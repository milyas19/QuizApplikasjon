using Application.QuestionFeatures.GetSingleQuestion;
using System.Collections.Generic;

namespace Application.QuizFeatures.GetQuizById
{
    public class GetQuizDto
    {
        public int QuizId { get; set; }
        public int Score { get; set; }
        public List<GetSingleQuestionDto> Questions { get; set; }
    }
}
