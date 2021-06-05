using System;
using System.Threading.Tasks;
using ProEvents.Application.Contracts;
using ProEvents.Domain;
using ProEvents.Persistence.Contracts;

namespace ProEvents.Application.ConcreteClasses
{
    public class EventService : IEventService
    {
        private readonly IGennericPersistence _gennericPersistence;
        private readonly IEventPersistence _eventPersistence;
        public EventService(IGennericPersistence gennericPersistence, IEventPersistence eventPersistence)
        {
            _eventPersistence = eventPersistence;
            _gennericPersistence = gennericPersistence;

        }
        public async Task<Event> AddEvent(Event model)
        {
            try
            {
                _gennericPersistence.Add<Event>(model);

                if(await _gennericPersistence.SaveChangesAsync()){
                    return await _eventPersistence.GetEventByIdAsync(model.Id, false);  
                }

                return null;

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> UpdateEvent(int eventId, Event model)
        {
            try
            {
                var _event = await _eventPersistence.GetEventByIdAsync(eventId, false);

                if (_event == null)
                    return null; 

                model.Id = eventId;

                _gennericPersistence.Update(model);            

                if(await _gennericPersistence.SaveChangesAsync()){
                    return await _eventPersistence.GetEventByIdAsync(model.Id, false);  
                }

                return null;

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }            
        }        

        public async Task<bool> DeleteEvent(int eventId)
        {
            try
            {
                var _event = await _eventPersistence.GetEventByIdAsync(eventId, false);

                if (_event == null)
                    return false; 

                _gennericPersistence.Delete<Event>(_event);            

                if(await _gennericPersistence.SaveChangesAsync()){
                    return true;  
                }

                return false;

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }            
        }        

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            try
            {
                var _events = await _eventPersistence.GetAllEventsAsync(includeSpeakers);
                
                if(_events == null)
                    return null;

                return _events;
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> GetEventByIdAsync(int idEvent, bool includeSpeakers = false)
        {
            try
            {
                var _event = await _eventPersistence.GetEventByIdAsync(idEvent, includeSpeakers);
                
                if(_event == null)
                    return null;

                return _event;
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event[]> GetEventsBySubjectAsync(string subject, bool includeSpeakers = false)
        {
            try
            {
                var _events = await _eventPersistence.GetEventsBySubjectAsync(subject, includeSpeakers);
                
                if(_events == null)
                    return null;

                return _events;
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

    }
}