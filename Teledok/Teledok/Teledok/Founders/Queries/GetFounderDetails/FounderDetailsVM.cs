using AutoMapper;
using Teledok.Domain;
using Teledok.Application.Mappings;

namespace Teledok.Application.Founders.Queries.GetFounderDetails;

public class FounderDetailsVM : IMapWith<Founder>
{
    public required string INN { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string? Patronymic { get; set; }
    public required DateTime AddDate { get; set; }
    public required DateTime? EditDate { get; set; }
    public required List<ClientDetailsVM> Clients { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Founder, FounderDetailsVM>()
            .ForMember(client => client.INN,
                opt => opt.MapFrom(client => client.INN))
            .ForMember(client => client.Name,
                opt => opt.MapFrom(client => client.Name))
            .ForMember(client => client.Surname,
                opt => opt.MapFrom(client => client.Surname))
            .ForMember(client => client.Patronymic,
                opt => opt.MapFrom(client => client.Patronymic))
            .ForMember(client => client.AddDate,
                opt => opt.MapFrom(client => client.AddDate))
            .ForMember(client => client.EditDate,
                opt => opt.MapFrom(client => client.EditDate))
            .ForMember(client => client.Clients,
                opt => opt.MapFrom(client => client.Clients));
    }
}