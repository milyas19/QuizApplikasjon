using System.Collections.Generic;

namespace Application.QuestionFeatures.GetSingleQuestion
{
    public class GetSingleQuestionDto
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<GetChoicesBySingleQuestionDto> Choices { get; set; }
    }
}