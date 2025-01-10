using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teledok.Application.Clients.Commands.CreateClient;
using Teledok.Application.Clients.Commands.DeleteClient;
using Teledok.Application.Clients.Commands.UpdateClient;
using Teledok.Application.Clients.Queries.GetClientDetails;
using Teledok.Application.Clients.Queries.GetClientList;

namespace Teledok.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ClientController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet]
    [ActionName(nameof(GetAll))]
    public async Task<ActionResult<ClientListVM>> GetAll(int countSkip, int countTake)
    {
        var query = new GetClientListQuery
        {
            CountSkip = countSkip,
            CountTake = countTake
        };

        var clientList = await mediator.Send(query);

        return Ok(clientList);
    }

    [HttpGet("{iNN}")]
    [ActionName(nameof(GetByINN))]
    public async Task<ActionResult<ClientDetailsVM>> GetByINN(string iNN)
    {
        var query = new GetClientDetailsQuery
        {
            INN = iNN
        };

        var clientDetails = await mediator.Send(query);

        return Ok(clientDetails);
    }

    [HttpPost]
    [ActionName(nameof(Create))]
    public async Task<IActionResult> Create([FromBody] CreateClientDto createClientDto)
    {
        var command = mapper.Map<CreateClientCommand>(createClientDto);
        await mediator.Send(command);

        return NoContent();
    }

    [HttpPut]
    [ActionName(nameof(Update))]
    public async Task<IActionResult> Update([FromBody] UpdateClientDto updateClientDto)
    {
        var command = mapper.Map<UpdateClientCommand>(updateClientDto);
        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{iNN}")]
    [ActionName(nameof(Delete))]
    public async Task<IActionResult> Delete(string iNN)
    {
        var command = new DeleteClientCommand
        {
            INN = iNN,
        };

        await mediator.Send(command);

        return NoContent();
    }
}