using AutoMapper;
using Teledok.Application.Mappings;

namespace Teledok.Application.Founders.Commands.CreateFounder;

public class CreateFounderDto : IMapWith<CreateFounderCommand>
{
    public required string INN { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string? Patronymic { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateFounderDto, CreateFounderCommand>()
            .ForMember(client => client.INN,
                opt => opt.MapFrom(client => client.INN))
            .ForMember(client => client.Name,
                opt => opt.MapFrom(client => client.Name))
            .ForMember(client => client.Surname,
                opt => opt.MapFrom(client => client.Surname))
            .ForMember(client => client.Patronymic,
                opt => opt.MapFrom(client => client.Patronymic));
    }
}