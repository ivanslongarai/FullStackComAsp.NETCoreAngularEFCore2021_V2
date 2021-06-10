
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEvents.Application.Dtos
{
    public class EventDto
    {
        public int Id { get; set; }
        [
            Required(ErrorMessage = "The field {0} is required"),
            MinLength(4),
            MaxLength(50)
        ]
        public string Local { get; set; }
        [Required]
        public string Date { get; set; }
        [
            Required(ErrorMessage = "The field {0} is required"),
            MinLength(4),
            MaxLength(50)
        ]
        public string Subject { get; set; }
        [Required]
        [Range(1,120000)]
        public int AmountOfPeople { get; set; }
        [Required]
        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$",
            ErrorMessage ="It's not a valid image. Use: (gif, jpg, jpeg, bmp or png)")]
        public string ImageUrl { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        [Display(Name ="E-mail"), Required, EmailAddress]
        public string Email { get; set; }

        public IEnumerable<LotDto> Lots { get; set; }
        public IEnumerable<SocialNetworkDto> SocialNetworks { get; set; }
        public IEnumerable<SpeakerDto> Speakers { get; set; }
    }
}

