using System.Collections.Generic;

namespace Application.QuestionFeatures.GetQuestions
{
    public class GetQuestionsDto
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<GetChoicesByQuestionDto> Choices { get; set; }
    }
}
