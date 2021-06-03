using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEvents.API.Models;

namespace ProEvents.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        public EventController()
        {
        }

        public IEnumerable<Event> _events = new Event[]
            {
                new Event(){
                    EventId = 1,
                    Subject = "Angular e .Net Core",
                    Local = "Belo Horizonte",
                    Lot = "1º Lote",
                    AmountPeople = 250,
                    EventDate = DateTime.Now.AddDays(2).ToString(),
                    ImageUrl = "img1.jpg"
                },
                new Event(){
                    EventId = 2,
                    Subject = "Node JS",
                    Local = "São Paulo",
                    Lot = "1º Lote",
                    AmountPeople = 350,
                    EventDate = DateTime.Now.AddDays(2).ToString(),
                    ImageUrl = "img2.jpg"
                }
            };

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _events;
        }

        [HttpGet("{id}")]
        public IEnumerable<Event> GetById(int id)
        {
            return _events.Where(e => e.EventId == id);
        }        

        [HttpPost]
        public string Post()
        {
            return "Post example";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return "Put example " + id;
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "Delete example " + id;
        }

    }
}
