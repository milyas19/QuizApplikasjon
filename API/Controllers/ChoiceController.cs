using Application.ChoiceFeatures.Create;
using Application.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Post a choice related to question
        /// </summary>
        /// <param name="createChoiceDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CreatedChoiceDto>> CreateChoices(CreateChoiceDto createChoiceDto)
        {
            var result = await _mediator.Send(new CreateChoiceCommand(createChoiceDto));
            return Ok(result);
        }
    }
}
