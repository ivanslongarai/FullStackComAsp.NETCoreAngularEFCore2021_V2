using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEvents.Domain
{
    //[Table("Events")]
    public class Event
    {
        //[Key]
        public int Id { get; set; }    
        public string Local {get; set;}
        public DateTime? Date { get; set; }

        //[NotMapped]
        //public int DaysCount {get; set;} 

        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }
        public int AmountOfPeople { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }   
        public string Email { get; set; }
        public IEnumerable<Lot> Lots { get; set; }
        public IEnumerable<SocialNetwork> SocialNetworks { get; set; }
        public IEnumerable<SpeakerEvent> SpeakerEvents { get; set; }
    }
}