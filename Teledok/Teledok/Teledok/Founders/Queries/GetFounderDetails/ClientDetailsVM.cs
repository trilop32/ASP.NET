using AutoMapper;
using Teledok.Domain;
using Teledok.Application.Mappings;

namespace Teledok.Application.Founders.Queries.GetFounderDetails;

public class ClientDetailsVM : IMapWith<Client>
{
    public required string INN { get; set; }
    public required string TitleCompany { get; set; }
    public required TypeCompany TypeCompany { get; set; }
    public required DateTime DateAdd { get; set; }
    public required DateTime? DateEdit { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Client, ClientDetailsVM>()
            .ForMember(client => client.INN,
                opt => opt.MapFrom(client => client.INN))
            .ForMember(client => client.TitleCompany,
                opt => opt.MapFrom(client => client.TitleCompany))
            .ForMember(client => client.TypeCompany,
                opt => opt.MapFrom(client => client.TypeCompany))
            .ForMember(client => client.DateAdd,
                opt => opt.MapFrom(client => client.DateAdd))
            .ForMember(client => client.DateEdit,
                opt => opt.MapFrom(client => client.DateEdit));
    }
}