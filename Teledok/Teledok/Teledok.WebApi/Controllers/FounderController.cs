using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teledok.Application.Founders.Commands.CreateFounder;
using Teledok.Application.Founders.Commands.DeleteFounder;
using Teledok.Application.Founders.Commands.UpdateFounder;
using Teledok.Application.Founders.Queries.GetFounderDetails;
using Teledok.Application.Founders.Queries.GetFounderList;

namespace Teledok.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class FounderController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet]
    [ActionName(nameof(GetAll))]
    public async Task<ActionResult<FounderListVM>> GetAll(int countSkip, int countTake)
    {
        var query = new GetFounderListQuery
        {
            CountSkip = countSkip,
            CountTake = countTake
        };

        var founderList = await mediator.Send(query);

        return Ok(founderList);
    }

    [HttpGet("{iNN}")]
    [ActionName(nameof(GetByINN))]
    public async Task<IActionResult> GetByINN(string iNN)
    {
        var query = new GetFounderDetailsQuery
        {
            INN = iNN
        };

        var founderDetails = await mediator.Send(query);

        return Ok(founderDetails);
    }

    [HttpPost]
    [ActionName(nameof(Create))]
    public async Task<ActionResult<string>> Create([FromBody] CreateFounderDto createFounderDto)
    {
        var command = mapper.Map<CreateFounderCommand>(createFounderDto);
        await mediator.Send(command);

        return NoContent();
    }

    [HttpPut]
    [ActionName(nameof(Update))]
    public async Task<IActionResult> Update([FromBody] UpdateFounderDto updateFounderDto)
    {
        var command = mapper.Map<UpdateFounderCommand>(updateFounderDto);
        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{iNN}")]
    [ActionName(nameof(Delete))]
    public async Task<IActionResult> Delete(string iNN)
    {
        var command = new DeleteFounderCommand
        {
            INN = iNN,
        };

        await mediator.Send(command);

        return NoContent();
    }
}