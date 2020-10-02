using System.Collections.Generic;

namespace Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<Choice> Choices { get; set; }
    }
}
