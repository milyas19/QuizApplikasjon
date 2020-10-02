using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QuestionFeatures.GetQuestions
{

    public class GetQuestionsQueryHandler : IRequestHandler<GetQuestionsQuery, List<GetQuestionsDto>>
    {
        private readonly QuizApplikasjonContext _dbContext;
        public GetQuestionsQueryHandler(QuizApplikasjonContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetQuestionsDto>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
        {
            var questions = await _dbContext.Questions.Include(c => c.Choices).ToListAsync();

            var questionsDto = new List<GetQuestionsDto>();

            foreach (var question in questions)
            {
                var qDto = new GetQuestionsDto
                {
                    QuestionId = question.QuestionId,
                    QuestionText = question.QuestionText,
                    Choices = question.Choices.Select(c => new GetChoicesByQuestionDto
                    {
                        ChoiceId = c.ChoiceId,
                        ChoiceText = c.ChoiceText
                    }).ToList()
                };
                questionsDto.Add(qDto);
            };
            return questionsDto;
        }
    }
    public class GetQuestionsQuery : IRequest<List<GetQuestionsDto>>
    {

    }
}
