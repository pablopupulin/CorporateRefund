using Application.Boundaries.UseCases;
using Domain.Receip;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceipController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IReceipRepository _repository;

        public ReceipController(IMediator mediator, IReceipRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpPost("Process")]
        [ProducesResponseType(typeof(Receip), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Process(ProcessReceip processReceip)
        {
            var receip = await _mediator.Send(processReceip);

            return Ok(receip);
        }

        [HttpGet("{clientId:guid}")]
        [ProducesResponseType(typeof(IEnumerable<Receip>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> List(Guid clientId)
        {
            var receips = await _repository.ListAsync(clientId);

            return Ok(receips);
        }

        [HttpGet("{clientId:guid}/{id}")]
        [ProducesResponseType(typeof(Receip), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(Guid clientId, string id)
        {
            var receips = await _repository.GetAsync(clientId, id);

            return Ok(receips);
        }
    }
}