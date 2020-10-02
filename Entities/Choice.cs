namespace Entities
{
    public class Choice
    {
        public int ChoiceId { get; set; }
        public string ChoiceText { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
