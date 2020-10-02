using System.Threading.Tasks;
using Application.QuizFeatures.Create;
using Application.QuizFeatures.GetQuizById;
using Application.QuizFeatures.SubmittQuiz;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {

        private readonly IMediator _mediator;

        public QuizController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GetQuizDto>> GetQuiz(int id)
        {
            var result = await _mediator.Send(new GetQuizQuery(id));
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createQuestionDto"></param>
        /// <returns></returns>
        // POST api/<QuizController>
        [HttpPost]
        public async Task<ActionResult<CreatedQuizDto>> CreateQuestion(CreateQuizDto createQuestionDto)
        {
            var result = await _mediator.Send(new CreateQuizCommand(createQuestionDto));
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="submittQuizDto"></param>
        /// <returns></returns>
        [HttpPut("")]
        public async Task<ActionResult<int>> SubmittQuiz(SubmittQuizDto submittQuizDto)
        {
            var result = await _mediator.Send(new SubmittQuizCommand(submittQuizDto));
            return Ok(result);
        }

    }
}
