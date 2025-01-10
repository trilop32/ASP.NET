using AutoMapper;
using Teledok.Domain;
using Teledok.Application.Mappings;

namespace Teledok.Application.Clients.Queries.GetClientDetails;

public class FounderDetailsVM : IMapWith<Founder>
{
    public required string INN { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string? Patronymic { get; set; }
    public required DateTime AddDate { get; set; }
    public required DateTime? EditDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Founder, FounderDetailsVM>()
            .ForMember(founder => founder.INN,
                        opt => opt.MapFrom(founder => founder.INN))
             .ForMember(founder => founder.Name,
                        opt => opt.MapFrom(founder => founder.Name))
             .ForMember(founder => founder.Surname,
                        opt => opt.MapFrom(founder => founder.Surname))
             .ForMember(founder => founder.Patronymic,
                        opt => opt.MapFrom(founder => founder.Patronymic))
             .ForMember(founder => founder.AddDate,
                        opt => opt.MapFrom(founder => founder.AddDate))
             .ForMember(founder => founder.EditDate,
                        opt => opt.MapFrom(founder => founder.EditDate));
    }
}