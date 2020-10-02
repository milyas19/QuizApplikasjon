namespace Application.Create
{
    public class CreateChoiceDto
    {
        public string ChoiceText { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
