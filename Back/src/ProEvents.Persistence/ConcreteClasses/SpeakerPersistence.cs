using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEvents.Domain;
using ProEvents.Persistence.Contexts;
using ProEvents.Persistence.Contracts;

namespace ProEvents.Persistence.ConcreteClasses
{
    public class SpeakerPersistence : ISpeakerPersistence
    {
        private readonly ProEventsContext _context;

        public SpeakerPersistence(ProEventsContext context)
        {
            _context = context;
        }        

        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(sn => sn.SocialNetworks);

            if(includeEvents){
                query = query.Include(s => s.SpeakerEvents)
                    .ThenInclude(se => se.Event);
            }

            query = query.OrderBy(s => s.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Speaker[]> GetSpeakersByNameAsync(string name, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(sn => sn.SocialNetworks);

            if(includeEvents){
                query = query.Include(s => s.SpeakerEvents)
                    .ThenInclude(se => se.Event);
            }

            query = query
                .Where(s => s.Name.ToLower().Contains(name.ToLower()))
                .OrderBy(s => s.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Speaker> GetSpeakerByIdAsync(int idSpeaker, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(sn => sn.SocialNetworks);

            if(includeEvents){
                query = query.Include(s => s.SpeakerEvents)
                    .ThenInclude(se => se.Event);
            }

            query = query.Where(s => s.Id == idSpeaker);

            return await query.FirstOrDefaultAsync();
        }

    }
}