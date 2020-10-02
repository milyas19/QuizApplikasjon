namespace Application.Create
{
    public class CreatedChoiceDto
    {
        public int ChoiceId { get; set; }
        public string ChoiceText { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
