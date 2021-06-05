using System.Threading.Tasks;
using ProEvents.Domain;

namespace ProEvents.Application.Contracts
{
    public interface IEventService
    {
         Task<Event> AddEvent(Event model);
         Task<Event> UpdateEvent(int eventId, Event model);
         Task<bool> DeleteEvent(int eventId);

        Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false);
        Task<Event[]> GetEventsBySubjectAsync(string subject, bool includeSpeakers = false);
        Task<Event> GetEventByIdAsync(int idEvent, bool includeSpeakers = false);
            
    }
}