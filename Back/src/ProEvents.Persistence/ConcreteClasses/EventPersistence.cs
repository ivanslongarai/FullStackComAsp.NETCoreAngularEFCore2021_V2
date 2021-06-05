using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEvents.Domain;
using ProEvents.Persistence.Contexts;
using ProEvents.Persistence.Contracts;

namespace ProEvents.Persistence.ConcreteClasses
{
    public class EventPersistence : IEventPersistence
    {
        private readonly ProEventsContext _context;

        public EventPersistence(ProEventsContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }     

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Lots)
                .Include(sn => sn.SocialNetworks);

            if(includeSpeakers){
                query = query.Include(e => e.SpeakerEvents)
                    .ThenInclude(se => se.Speaker);
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Event[]> GetEventsBySubjectAsync(string subject, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Lots)
                .Include(sn => sn.SocialNetworks);

            if(includeSpeakers){
                query = query.Include(e => e.SpeakerEvents)
                    .ThenInclude(se => se.Speaker);
            }

            query = query
                .Where(e => e.Subject.ToLower().Contains(subject.ToLower()))
                .OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }    

        public async Task<Event> GetEventByIdAsync(int idEvent, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Lots)
                .Include(sn => sn.SocialNetworks);

            if(includeSpeakers){
                query = query.Include(e => e.SpeakerEvents)
                    .ThenInclude(se => se.Speaker);
            }

            query = query.Where(e => e.Id == idEvent);

            return await query.FirstOrDefaultAsync();
        }                   
    }
}