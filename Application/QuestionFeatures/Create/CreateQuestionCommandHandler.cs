using AutoMapper;
using Entities;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Create
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, CreatedQuestionDto>
    {
        private readonly QuizApplikasjonContext _dbContext;
        private readonly IMapper _mapper;
        public CreateQuestionCommandHandler(QuizApplikasjonContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CreatedQuestionDto> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = new Question
            {
                QuestionText = request.Dto.QuestionText
            };
            _dbContext.Add(question);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CreatedQuestionDto>(question);
        }
    }

    public class CreateQuestionCommand : IRequest<CreatedQuestionDto>
    {
        public CreateQuestionDto Dto { get; set; }
        public CreateQuestionCommand(CreateQuestionDto createQuestionDto)
        {
            Dto = createQuestionDto;
        }
    }
}
