using Amazon.DirectoryService.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QuestionFeatures.GetSingleQuestion
{
    public class GetSingleQuestionQueryHandler : IRequestHandler<GetSingleQuestionQuery, GetSingleQuestionDto>
    {
        private readonly QuizApplikasjonContext _dbContext;
        public GetSingleQuestionQueryHandler(QuizApplikasjonContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetSingleQuestionDto> Handle(GetSingleQuestionQuery request, CancellationToken cancellationToken)
        {

            var question = await _dbContext.Questions.Include(c => c.Choices).FirstOrDefaultAsync(q => q.QuestionId == request.Id);

            if (question == null)
            {
                throw new EntityDoesNotExistException("Question does not exist in database");
            }

            var questionDto = new GetSingleQuestionDto
            {
                QuestionId = question.QuestionId,
                QuestionText = question.QuestionText,
                Choices = question.Choices.Select(c => new GetChoicesBySingleQuestionDto
                {
                    ChoiceId = c.ChoiceId,
                    ChoiceText = c.ChoiceText
                }).ToList()

                //Choices = q
            };
            return questionDto;
        }
    }

    public class GetSingleQuestionQuery : IRequest<GetSingleQuestionDto>
    {
        public int Id { get; set; }
        public GetSingleQuestionQuery(int id)
        {
            Id = id;
        }
    }
}
