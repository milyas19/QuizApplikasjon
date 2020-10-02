using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QuizFeatures.SubmittQuiz
{
    public class SubmittQuizCommandHandler : IRequestHandler<SubmittQuizCommand, int>
    {
        private readonly QuizApplikasjonContext _dbContext;
        public SubmittQuizCommandHandler(QuizApplikasjonContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(SubmittQuizCommand request, CancellationToken cancellationToken)
        {
            int score = 0;
            var quiz = await _dbContext.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(c => c.Choices)
                .Where(q => q.QuizId == request.Dto.QuizId)
                .FirstOrDefaultAsync();

            foreach (var answer in request.Dto.Answers)
            {
                var choice = quiz.Questions
                    .Where(q => q.QuestionId == answer.QuestionId).FirstOrDefault()
                    .Choices.Where(c => c.ChoiceId == answer.ChoiceId).FirstOrDefault();

                if (choice.IsCorrect)
                {
                    score++;
                }
            }

            quiz.Score = score;
            await _dbContext.SaveChangesAsync();
            return quiz.Score;
        }
    }

    public class SubmittQuizCommand : IRequest<int>
    {
        public SubmittQuizDto Dto { get; set; }
        public SubmittQuizCommand(SubmittQuizDto submittQuizDto)
        {
            Dto = submittQuizDto;
        }
    }
}
