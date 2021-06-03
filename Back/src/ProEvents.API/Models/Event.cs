namespace ProEvents.API.Models
{
    public class Event
    {
        public int EventId { get; set; }    
        public string Local {get; set;}
        public string EventDate { get; set; }
        public string Subject { get; set; }
        public int AmountPeople { get; set; }
        public string Lot { get; set; }
        public string ImageUrl { get; set; }


    }
}