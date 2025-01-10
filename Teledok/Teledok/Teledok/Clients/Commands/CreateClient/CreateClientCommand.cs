using MediatR;
using Teledok.Domain;

namespace Teledok.Application.Clients.Commands.CreateClient;

public class CreateClientCommand : IRequest
{
    public required string INN { get; set; }
    public required string TitleCompany { get; set; }
    public required TypeCompany TypeCompany { get; set; }
    public required List<string> INNFounders { get; set; }
}