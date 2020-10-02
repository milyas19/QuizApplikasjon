using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Create;
using Application.QuestionFeatures.GetQuestions;
using Application.QuestionFeatures.GetSingleQuestion;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Post a question 
        /// </summary>
        /// <param name="createQuestionDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CreatedQuestionDto>> CreateQuestion(CreateQuestionDto createQuestionDto)
        {
            var result = await _mediator.Send(new CreateQuestionCommand(createQuestionDto));
            return Ok(result);
        }

        /// <summary>
        /// Return a Question by give Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSingleQuestionDto>> GetQuestion(int id)
        {
            var result = await _mediator.Send(new GetSingleQuestionQuery(id));
            return Ok(result);
        }

        /// <summary>
        /// Returns a list of Questions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<GetQuestionsDto>>> GetQuestions()
        {
            var result = await _mediator.Send(new GetQuestionsQuery());
            return Ok(result);
        }

    }
}
