using Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QuizFeatures.Create
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, CreatedQuizDto>
    {
        private readonly QuizApplikasjonContext _dbContext;

        public CreateQuizCommandHandler(QuizApplikasjonContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CreatedQuizDto> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            var questions = await _dbContext.Questions.Include(c => c.Choices).ToListAsync();
            var randomQuestions = RandomQuestions(questions);

            var quiz = new Quiz
            {
                Questions = randomQuestions,
                Score = 0
            };
            _dbContext.Quizzes.Add(quiz);
            await _dbContext.SaveChangesAsync();

            var quizDto = new CreatedQuizDto
            {
                QuizId = quiz.QuizId,
                Score = quiz.Score,
                Questions = quiz.Questions
            };

            return quizDto;
        }

        private List<Question> RandomQuestions(List<Question> questions)
        {

            var rand = new Random();
            var randomQuestions = new List<Question>();

            for (var i = 0; i <= 4; i++)
            {
                var question = questions[rand.Next(questions.Count)];
                questions.Remove(question);
                randomQuestions.Add(question);
            }
            return randomQuestions;
        }
    }

    public class CreateQuizCommand : IRequest<CreatedQuizDto>
    {
        public CreateQuizDto Dto { get; set; }
        public CreateQuizCommand(CreateQuizDto createQuizDto)
        {
            Dto = createQuizDto;
        }
    }
}
