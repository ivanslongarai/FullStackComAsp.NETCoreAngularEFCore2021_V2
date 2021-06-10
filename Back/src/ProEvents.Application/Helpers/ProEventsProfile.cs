using AutoMapper;
using ProEvents.Application.Dtos;
using ProEvents.Domain;

namespace ProEvents.Application.Helpers
{
    public class ProEventsProfile : Profile
    {

        public ProEventsProfile()
        {
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Speaker, SpeakerDto>().ReverseMap();
            CreateMap<SocialNetwork, SocialNetworkDto>().ReverseMap();
            CreateMap<Lot, LotDto>().ReverseMap();
        }
        
    }
}