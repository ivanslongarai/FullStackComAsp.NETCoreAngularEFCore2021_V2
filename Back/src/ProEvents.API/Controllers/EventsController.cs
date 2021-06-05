using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEvents.Application.Contracts;
using ProEvents.Domain;

namespace ProEvents.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var events = await _eventService.GetAllEventsAsync(true);    
                
                if(events == null){
                    return NotFound("Events is empty");
                }

                return Ok(events);                
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error in trying to get events. Error: {ex.Message}");
            }
            
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var _event = await _eventService.GetEventByIdAsync(id, true);    
                
                if(_event == null){
                    return NotFound("Event by id not found");
                }

                return Ok(_event);                
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error in trying to get the event. Error: {ex.Message}");
            }
        }

        [HttpGet("subject/{subject}")]
        public async Task<IActionResult> GetBySubject(string subject)
        {
            try
            {
                var _event = await _eventService.GetEventsBySubjectAsync(subject, true);    
                
                if(_event == null){
                    return NotFound("Events by subject not found");
                }

                return Ok(_event);                
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error in trying to get the event. Error: {ex.Message}");
            }
        }        

        [HttpPost]
        public async Task<IActionResult> Post(Event model)
        {
            try
            {
                var _event = await _eventService.AddEvent(model);    
                
                if(_event == null){
                    return BadRequest("Error in trying to add the event");
                }

                return Ok(_event);                
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error in trying to add the event. Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Event model)
        {
            try
            {
                model.Id = id;

                var _event = await _eventService.UpdateEvent(id, model);    
                
                if(_event == null){
                    return BadRequest("Error in trying to update the event");
                }

                return Ok(_event);                
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error in trying to update the event. Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {                
                var isDeleted = await _eventService.DeleteEvent(id);    
                
                if(isDeleted == false){
                    return BadRequest("Error in trying to delete the event");
                }

                return Ok("Deleted");                
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error in trying to delete the event. Error: {ex.Message}");
            }
        }

    }
}
