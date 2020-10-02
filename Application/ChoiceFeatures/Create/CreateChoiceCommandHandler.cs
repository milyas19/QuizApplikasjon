using Application.Create;
using Entities;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ChoiceFeatures.Create
{
    public class CreateChoiceCommandHandler : IRequestHandler<CreateChoiceCommand, CreatedChoiceDto>
    {
        private readonly QuizApplikasjonContext _dbContext;

        public CreateChoiceCommandHandler(QuizApplikasjonContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CreatedChoiceDto> Handle(CreateChoiceCommand request, CancellationToken cancellationToken)
        {
            var choice = new Choice
            {
                ChoiceText = request.Dto.ChoiceText,
                IsCorrect = request.Dto.IsCorrect,
                QuestionId = request.Dto.QuestionId
            };
            _dbContext.Add(choice);
            await _dbContext.SaveChangesAsync();

            var createdChoiceDto = new CreatedChoiceDto
            {
                ChoiceId = choice.ChoiceId,
                ChoiceText = choice.ChoiceText,
                IsCorrect = choice.IsCorrect,
                QuestionId = choice.QuestionId
            };
            return createdChoiceDto;
        }
    }

    public class CreateChoiceCommand : IRequest<CreatedChoiceDto>
    {
        public CreateChoiceDto Dto { get; set; }
        public CreateChoiceCommand(CreateChoiceDto createChoiceDto)
        {
            Dto = createChoiceDto;
        }
    }
}
