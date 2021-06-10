using System.Threading.Tasks;
using ProEvents.Application.Dtos;

namespace ProEvents.Application.Contracts
{
    public interface IEventService
    {
         Task<EventDto> AddEvent(EventDto model);
         Task<EventDto> UpdateEvent(int eventId, EventDto model);
         Task<bool> DeleteEvent(int eventId);

        Task<EventDto[]> GetAllEventsAsync(bool includeSpeakers = false);
        Task<EventDto[]> GetEventsBySubjectAsync(string subject, bool includeSpeakers = false);
        Task<EventDto> GetEventByIdAsync(int idEvent, bool includeSpeakers = false);
            
    }
}