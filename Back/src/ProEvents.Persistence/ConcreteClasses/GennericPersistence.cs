using System.Threading.Tasks;
using ProEvents.Persistence.Contexts;
using ProEvents.Persistence.Contracts;

namespace ProEvents.Persistence.ConcreteClasses
{
    public class GennericPersistence : IGennericPersistence
    {
        private readonly ProEventsContext _context;

        public GennericPersistence(ProEventsContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }        
    }
}