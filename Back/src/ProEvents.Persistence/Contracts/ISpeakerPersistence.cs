using System.Threading.Tasks;
using ProEvents.Domain;

namespace ProEvents.Persistence.Contracts
{
    public interface ISpeakerPersistence
    {
        Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false);
        Task<Speaker[]> GetSpeakersByNameAsync(string name, bool includeEvents = false);
        Task<Speaker> GetSpeakerByIdAsync(int idSpeaker, bool includeEvents = false);
    }
}