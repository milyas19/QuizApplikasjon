using Application.QuestionFeatures.GetSingleQuestion;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QuizFeatures.GetQuizById
{
    public class GetQuizQueryHandler : IRequestHandler<GetQuizQuery, GetQuizDto>
    {
        private readonly QuizApplikasjonContext _dbContext;

        public GetQuizQueryHandler(QuizApplikasjonContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetQuizDto> Handle(GetQuizQuery request, CancellationToken cancellationToken)
        {
            var quiz = await _dbContext.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(x => x.Choices)
                .Where(q => q.QuizId == request.Id)
                .FirstOrDefaultAsync();

            var quizDto = new GetQuizDto
            {
                QuizId = quiz.QuizId,
                Score = quiz.Score,
                Questions = quiz.Questions.Select(q => new GetSingleQuestionDto
                {
                    QuestionText = q.QuestionText,
                    QuestionId = q.QuestionId,
                    Choices = q.Choices.Select(c => new GetChoicesBySingleQuestionDto
                    {
                        ChoiceText = c.ChoiceText,
                        ChoiceId = c.ChoiceId
                    }).ToList()
                }).ToList()
            };
            return quizDto;
        }
    }

    public class GetQuizQuery : IRequest<GetQuizDto>
    {
        public int Id { get; set; }
        public GetQuizQuery(int id)
        {
            Id = id;
        }
    }
}
