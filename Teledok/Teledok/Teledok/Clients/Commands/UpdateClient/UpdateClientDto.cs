using AutoMapper;
using Teledok.Domain;
using Teledok.Application.Mappings;

namespace Teledok.Application.Clients.Commands.UpdateClient;

public class UpdateClientDto : IMapWith<UpdateClientCommand>
{
    public required string INN { get; set; }
    public required string TitleCompany { get; set; }
    public required TypeCompany TypeCompany { get; set; }
    public required List<string> INNFounders { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateClientDto, UpdateClientCommand>()
            .ForMember(client => client.INN,
                opt => opt.MapFrom(client => client.INN))
            .ForMember(client => client.TitleCompany,
                opt => opt.MapFrom(client => client.TitleCompany))
            .ForMember(client => client.TypeCompany,
                opt => opt.MapFrom(client => client.TypeCompany))
            .ForMember(client => client.INNFounders,
                opt => opt.MapFrom(client => client.INNFounders));
    }
}