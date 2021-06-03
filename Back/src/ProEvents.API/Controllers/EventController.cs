﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEvents.API.Data;
using ProEvents.API.Models;

namespace ProEvents.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly DataContext _context;
        public EventController(DataContext context)
        {
            _context = context;
        }      

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _context.Events;
        }

        [HttpGet("{id}")]
        public Event GetById(int id)
        {
            return _context.Events.FirstOrDefault(e => e.EventId == id);
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
