using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProEvents.Application.Contracts;
using ProEvents.Application.Dtos;
using ProEvents.Domain;
using ProEvents.Persistence.Contracts;
using AutoMapper;

namespace ProEvents.Application.ConcreteClasses
{
    public class EventService : IEventService
    {
        private readonly IGennericPersistence _gennericPersistence;
        private readonly IEventPersistence _eventPersistence;
        private readonly IMapper _mapper;

        public EventService(
            IGennericPersistence gennericPersistence, 
            IEventPersistence eventPersistence, 
            IMapper mapper)
        {
            _eventPersistence = eventPersistence;
            _mapper = mapper;
            _gennericPersistence = gennericPersistence;

        }
        public async Task<EventDto> AddEvent(EventDto model)
        {
            try
            {
                var _addEvent  = _mapper.Map<Event>(model);
                _gennericPersistence.Add<Event>(_addEvent);

                if(await _gennericPersistence.SaveChangesAsync()){
                   var _eventReturn = _mapper.Map<EventDto>(await _eventPersistence.GetEventByIdAsync(_addEvent.Id, false));
                   return _eventReturn;  
                }

                return null;

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventDto> UpdateEvent(int eventId, EventDto model)
        {
            try
            {
                var _event = await _eventPersistence.GetEventByIdAsync(eventId, false);

                if (_event == null)
                    return null; 

                model.Id = eventId;

                var _updateEvent = _mapper.Map<Event>(model);

                _gennericPersistence.Update(_updateEvent);            

                if(await _gennericPersistence.SaveChangesAsync()){
                   return _mapper.Map<EventDto>(await _eventPersistence.GetEventByIdAsync(_updateEvent.Id, false));
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

        public async Task<EventDto[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            try
            {
                var _events = await _eventPersistence.GetAllEventsAsync(includeSpeakers);
                
                if(_events == null)
                    return null;

                var result =_mapper.Map<EventDto[]>(_events);

                return result;
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventDto> GetEventByIdAsync(int idEvent, bool includeSpeakers = false)
        {
            try
            {
                var _event = await _eventPersistence.GetEventByIdAsync(idEvent, includeSpeakers);
                
                if(_event == null)
                    return null;

                var result =_mapper.Map<EventDto>(_event);

                return result;
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventDto[]> GetEventsBySubjectAsync(string subject, bool includeSpeakers = false)
        {
            try
            {
                var _events = await _eventPersistence.GetEventsBySubjectAsync(subject, includeSpeakers);
                
                if(_events == null)
                    return null;

                var result =_mapper.Map<EventDto[]>(_events);

                return result;
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

    }
}