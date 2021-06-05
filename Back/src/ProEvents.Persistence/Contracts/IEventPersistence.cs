using System.Threading.Tasks;
using ProEvents.Domain;

namespace ProEvents.Persistence.Contracts
{
    public interface IEventPersistence
    {
        //Events methods
        Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false);
        Task<Event[]> GetEventsBySubjectAsync(string subject, bool includeSpeakers = false);
        Task<Event> GetEventByIdAsync(int idEvent, bool includeSpeakers = false);
   
    }
}